using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vivu.Service;
using Vivu.Service.Base;
using Vivu.Common.DTO.AuthDTO;

namespace Vivu.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;

        public AuthController(AuthService authService, UserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IBusinessResult> Register(SignUpDTO user)
        {
            return await _authService.Register(user);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IBusinessResult> Login(LoginDTO loginDTO)
        {
            return await _authService.Login(loginDTO);
        }
    }
}
