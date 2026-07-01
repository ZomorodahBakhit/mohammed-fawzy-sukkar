using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniSystemApi.Configurations;
using UniSystemApi.Core.Forms;
using UniSystemApi.Core.Services;
using UniSystemApi.Filter;
using UniSystemApi.Helpers;

namespace UniSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ApiExceptionFilter))]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenHelper _jwtTokenService;
        private readonly IAuthService _authService;

        public AuthController(IJwtTokenHelper jwtTokenHelper, IAuthService authService)
        {
            _jwtTokenService = jwtTokenHelper;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ApiResponse> Register([FromBody] RegisterForm form)
        {
            var dto = await _authService.Register(form);
            return new ApiResponse("User registered successfully", dto);
        }

        [HttpPost("login")]
        public async Task<ApiResponse> Login([FromBody] LoginForm form)
        {
            var user = await _authService.Login(form);
            var token = _jwtTokenService.GenerateToken(user);
            return new ApiResponse("Login successful", token);
        }

        [Authorize]
        [HttpGet("me")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ApiResponse> me()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value
                          ?? User.FindFirst("id")?.Value
                          ?? User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)?.Value
                          ?? User.FindFirst("uid")?.Value; 
            var userInfo = await _authService.GetMe(userId);
            return new ApiResponse("Current user info retrieved successfully", userInfo);
        }
    }
}
