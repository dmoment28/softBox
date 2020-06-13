using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftBox.WEB.ViewModels.Accounts;

namespace SoftBox.WEB.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly BLL.Services.Interfaces.IAuthenticationService _authService;

        public AccountsController(BLL.Services.Interfaces.IAuthenticationService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]AuthenticationViewModel model)
        {
            var user = await _authService.AuthenticateAsync(model.Login, model.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Invalid Login or Password" });
            }

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet("getCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var token = await HttpContext.GetTokenAsync("apiToken");
            if (token == null)
            {
                return Ok();
            }
            
            var userClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString();
            var userId = Convert.ToInt32(userClaim);
            var user = await _authService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return Ok(null);
            }

            return Ok(user);
        }


        [Authorize]
        [HttpGet("test")]
        public string test()
        {
            return "Super secret data.";
        }
    }
}