using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftBox.BLL.Services.Interfaces;
using SoftBox.WEB.ViewModels.Accounts;
using System.Threading.Tasks;

namespace SoftBox.WEB.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {

        }
    }
}