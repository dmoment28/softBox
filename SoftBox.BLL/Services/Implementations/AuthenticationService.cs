using SoftBox.BLL.Services.Interfaces;
using SoftBox.DAL.Entities;
using SoftBox.DAL.UnitOfWork;
using System.Threading.Tasks;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using SoftBox.BLL.Helper;
using SoftBox.BLL.Helper.Extension;
using Microsoft.Extensions.Options;

namespace SoftBox.BLL.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public AuthenticationService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        public async Task<User> AuthenticateAsync(string login, string password)
        {
            try
            {
                var user = await _unitOfWork.Repository<User>().GetSingleOrDefaultAsync(x => x.Login == login && x.Password == password);
                if (user == null)
                {
                    return null;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Login.ToString()),
                        new Claim(ClaimTypes.Role, user.RoleId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user.WithoutPassword();
            }
            catch (Exception exception)
            {
                throw new Exception($"Error when creating token for user: {login}", exception);
            }
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            try
            {
                var user = await _unitOfWork.Repository<User>().GetSingleOrDefaultAsync(x => x.Id == userId);
                if(user == null)
                {
                    return null;
                }

                return user.WithoutPassword();
            }
            catch (Exception exception)
            {
                throw new Exception($"Error when getting user with id: {userId}", exception);
            }
        }
    }
}
