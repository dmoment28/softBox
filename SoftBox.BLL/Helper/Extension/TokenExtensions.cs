using SoftBox.DAL.Entities;

namespace SoftBox.BLL.Helper.Extension
{
    public static class TokenExtensions
    {
        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }
    }
}
