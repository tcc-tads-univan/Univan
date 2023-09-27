using Microsoft.EntityFrameworkCore;
using Univan.Domain.Entities;
using Univan.Domain.Enums;
using Univan.Domain.Repositories;
using Univan.Infrastructure.Persistence.Context;

namespace Univan.Infrastructure.Persistence.Repository
{
    public class StudentRepository : UserBaseRepository<Student>, IStudentRepository
    {
        private readonly UnivanContext _dbContext;
        public StudentRepository(UnivanContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Subscription>> GetPendingSubscription(int studentId)
        {
            return await _dbContext.Set<Subscription>().Where(s => s.StudentId == studentId && s.Status == nameof(SubscriptionStatus.PENDING)).ToListAsync();
        }

        public Task<Student> GetStudentBasicInfo(int studentId)
        {
            return _dbContext.Set<Student>().FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public Task<Subscription> GetSubscription(int studentId)
        {
            return _dbContext.Set<Subscription>()
                .Include(s => s.Driver.Vehicle)
                .Include(s => s.SubscriptionHistory.LastOrDefault())
                .FirstOrDefaultAsync(s => s.StudentId == studentId && s.Status == nameof(SubscriptionStatus.ACTIVE));
        }
    }
}
