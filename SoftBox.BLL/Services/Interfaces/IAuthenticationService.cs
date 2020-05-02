using SoftBox.DAL.Entities;
using System.Threading.Tasks;

namespace SoftBox.BLL.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<User> Authenticate(string login, string password);

        Task<User> GetUserById(int userId);
    }
}
