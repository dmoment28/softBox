using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SoftBox.BLL.Services.Interfaces;
using SoftBox.WEB.ViewModels.Accounts;

namespace SoftBox.WEB.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authService;

        public AccountsController(IAuthenticationService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]AuthenticationViewModel model)
        {
            var user = await _authService.Authenticate(model.Login, model.Password);

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
            if(HttpContext.User == null)
            {
                return Ok();
            }
            
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString());
            var user = await _authService.GetUserById(userId);
            if(user == null)
            {
                return Ok(null);
            }
            
            return Ok(user);
        }


        [Authorize]
        [HttpGet("test")]
        public string test() { 
            return "Only for login users"; 
        }
    }
}