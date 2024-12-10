using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Options;
using SurveyBasket.api.Auuthentication;
using SurveyBasket.api.Services;
namespace SurveyBasket.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IAuthServices authServices) : ControllerBase
    {
        private readonly IAuthServices _authServices = authServices;
        [HttpPost("")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDTO loginRequest, CancellationToken cancellationToken)
        {
            var loginresult = await _authServices.GetTokenaync(loginRequest.Email, loginRequest.Password, cancellationToken);

            if (loginresult == null) return BadRequest("Email/Password is not valid");
            return Ok(loginresult);
        }
     
    }
}
