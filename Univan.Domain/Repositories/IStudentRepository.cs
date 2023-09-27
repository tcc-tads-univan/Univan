using Univan.Domain.Entities;

namespace Univan.Domain.Repositories
{
    public interface IStudentRepository : IUserBaseRepository<Student>
    {
        //Specific methods of studentRepository
        Task<Student> GetStudentBasicInfo(int studentId);
        Task<IEnumerable<Subscription>> GetPendingSubscription(int studentId);
        Task<Subscription> GetSubscription(int studentId);
    }
}
