namespace SurveyBasket.api.contracts.Authentication
{
    public class AuthValidator : AbstractValidator<LoginRequestDTO>
    {
        public AuthValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
