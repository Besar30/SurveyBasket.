using Microsoft.AspNetCore.Identity;
using SurveyBasket.api.Auuthentication;
using SurveyBasket.api.contracts.Authentication;

namespace SurveyBasket.api.Services
{
    public class AuthServices(UserManager<ApplicationUser> userManager,IJwtProvider jwtProvider)
        : IAuthServices
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<AuthRespons?> GetTokenaync(string email, string password, CancellationToken cancellationToken = default)
        {
            //check if user is her
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }
            //check if password valid
            var isvalidpassword = await _userManager.CheckPasswordAsync(user, password);
            if (isvalidpassword == false) return null;
            //generte jwt
            var (token, expiresIn) = _jwtProvider.GenerateToken(user);
            //return null;
            return new AuthRespons(user.Id, user.Email, user.FirstName, user.LastName, token,expiresIn );
        }
    }
}
