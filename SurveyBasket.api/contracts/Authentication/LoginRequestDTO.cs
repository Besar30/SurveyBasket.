namespace SurveyBasket.api.contracts.Authentication
{
    public record LoginRequestDTO(
        string Email,
        string Password
        );    
}
