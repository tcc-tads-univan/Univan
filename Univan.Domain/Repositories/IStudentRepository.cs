using Univan.Domain.Entities;

namespace Univan.Domain.Repositories
{
    public interface IStudentRepository : IUserBaseRepository<Student>
    {
        Task<Student> GetStudentBasicInfo(int studentId);
        Task<IEnumerable<Subscription>> GetPendingSubscription(int studentId);
        Task<Subscription> GetSubscription(int studentId);
        Task DeleteStudentAddress(int studentId, int addressId);
        Task<Address> GetStudentAddress(int studentId, int addressId);
    }
}
