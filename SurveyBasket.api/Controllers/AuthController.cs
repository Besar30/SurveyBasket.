using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Options;
using SurveyBasket.api.Auuthentication;
using SurveyBasket.api.Errors;
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
            throw new Exception("my exciption ");
            var loginresult = await _authServices.GetTokenaync(loginRequest.Email, loginRequest.Password, cancellationToken);

            return loginresult.IsSuccess ?
                Ok(loginresult.Value) :
                loginresult.ToProblem(StatusCodes.Status400BadRequest);
               
        }
        [HttpPost("Refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var result = await _authServices.GetRefeshTokenaync(request.Token, request.RefreshToken, cancellationToken);

            return result.IsSuccess ?
                NoContent() :
                result.ToProblem(StatusCodes.Status400BadRequest);

        }
        [HttpPost("RevokeToken")]
        public async Task<IActionResult> RevokeRefreshAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var result = await _authServices.RevokeRefeshTokenaync(request.Token, request.RefreshToken, cancellationToken);

            return result.IsSuccess ? 
                NoContent() : 
                result.ToProblem(StatusCodes.Status400BadRequest);

        }
    }
}
