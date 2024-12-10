using SurveyBasket.api.contracts.Authentication;

namespace SurveyBasket.api.Services
{
    public interface IAuthServices
    {
        Task<AuthRespons?> GetTokenaync(string email,string password,CancellationToken cancellationToken=default);
    }
}
