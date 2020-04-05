using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SoftBox.WEB
{
    public class AuthorizationOptions
    {
        public const string ISSUER = "SoftBox_Server"; 
        public const string AUDIENCE = "SoftBox_Client";
        const string KEY = "mysupersecret_secretkey!123";
        public const int LIFETIME = 60;
        
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
