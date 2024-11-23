using Microsoft.AspNetCore.Mvc;
using WealthSphere.Model;
using WealthSphere.Services.Interface;

namespace WealthSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        public readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
               return BadRequest(new { message = "Username and password are required" });
            
            var isAuthenticated = _authService.Login(request.Username, request.Password);

            if (isAuthenticated)
                return Ok(new { message = "Login successful", username = request.Username });
            else
                return Unauthorized(new { message = "Invalid username or password" });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegistrationModel request)
        {
            if (string.IsNullOrEmpty(request.EmailId) || string.IsNullOrEmpty(request.PhoneNumber))
                return BadRequest(new { message = "Email address and Phone number are required" });
            
            var result = _authService.Register(request);

            return Ok(result);
        }

        [HttpGet("{emailId}")]
        public IActionResult UserProfile(string emailId)
        {
            if (string.IsNullOrEmpty(emailId))
                return BadRequest(new { message = "Email address is required" });

            var result = _authService.GetUser(emailId);

            return Ok(result);
        }
    }
}
