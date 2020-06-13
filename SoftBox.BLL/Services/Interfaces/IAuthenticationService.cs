using SoftBox.DAL.Entities;
using System.Threading.Tasks;

namespace SoftBox.BLL.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<User> AuthenticateAsync(string login, string password);

        Task<User> GetUserByIdAsync(int userId);
    }
}
