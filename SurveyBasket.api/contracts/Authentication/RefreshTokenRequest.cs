namespace SurveyBasket.api.contracts.Authentication
{
    public record RefreshTokenRequest
    
    (
    string Token,
    string RefreshToken
        );
}
