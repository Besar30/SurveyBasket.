namespace SurveyBasket.api.Auuthentication
{
    public interface IJwtProvider
    {
        (string token,int expiresIn)GenerateToken(ApplicationUser user);
    }
}
