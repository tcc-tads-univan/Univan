using Univan.Domain.Entities;

namespace Univan.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task SaveStudent(Student student);

        Task<Student> GetStudentById(int userId);
    }
}
