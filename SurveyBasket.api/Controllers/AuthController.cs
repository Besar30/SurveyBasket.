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
        [HttpPost("Refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var loginresult = await _authServices.GetRefeshTokenaync(request.Token, request.RefreshToken, cancellationToken);

            if (loginresult == null) return BadRequest("Token is not valid");
            return Ok(loginresult);
        }
        [HttpPost("RevokeToken")]
        public async Task<IActionResult> RevokeRefreshAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var loginresult = await _authServices.RevokeRefeshTokenaync(request.Token, request.RefreshToken, cancellationToken);

            if (loginresult == false) return BadRequest("operation not complete");
            return Ok();
        }
    }
}
