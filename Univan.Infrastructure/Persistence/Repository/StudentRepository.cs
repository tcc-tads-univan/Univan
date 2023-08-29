using Microsoft.EntityFrameworkCore;
using Univan.Domain.Entities;
using Univan.Domain.Repositories;
using Univan.Infrastructure.Persistence.Context;

namespace Univan.Infrastructure.Persistence.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UnivanContext _dbContext;
        public StudentRepository(UnivanContext context)
        {
            _dbContext = context;
        }

        public async Task<Student> GetStudentById(int userId)
        {
            return await _dbContext.User.OfType<Student>().FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task SaveStudent(Student student)
        {
            await _dbContext.AddAsync(student);
            await _dbContext.SaveChangesAsync();
        }
    }
}
