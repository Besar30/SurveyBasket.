using SurveyBasket.api.contracts.Authentication;

namespace SurveyBasket.api.Services
{
    public interface IAuthServices
    {
        Task<AuthRespons?> GetTokenaync(string email,string password,CancellationToken cancellationToken=default);
        Task<AuthRespons?> GetRefeshTokenaync(string Token, string RefreshToken, CancellationToken cancellationToken = default);
        Task<bool> RevokeRefeshTokenaync(string Token,string  RefreshToken, CancellationToken cancellationToken = default);
    }

}
