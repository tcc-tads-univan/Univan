namespace Univan.Domain.Repositories
{
    public interface IUserBaseRepository<T>
    {
        Task SaveUserAsync(T user);
        Task<T> GetUserById(int userId);
        Task UpdateUser(T user);
        Task SaveChanges();
    }
}
