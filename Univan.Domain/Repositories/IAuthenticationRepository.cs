using Univan.Domain.Entities;

namespace Univan.Domain.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<User> Login(string email);
    }
}
