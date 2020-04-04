using System.ComponentModel.DataAnnotations;

namespace SoftBox.WEB.ViewModels.Accounts
{
    public class LoginViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
