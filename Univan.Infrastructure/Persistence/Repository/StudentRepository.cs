using Microsoft.EntityFrameworkCore;
using Univan.Domain.Entities;
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

        public Task<Student> GetStudentBasicInfo(int studentId)
        {
            return _dbContext.Set<Student>().FirstOrDefaultAsync(s => s.Id == studentId);
        }
    }
}
