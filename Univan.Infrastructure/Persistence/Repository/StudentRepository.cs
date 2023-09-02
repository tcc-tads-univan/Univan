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
    }
}
