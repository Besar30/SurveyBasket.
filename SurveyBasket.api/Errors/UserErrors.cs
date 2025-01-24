namespace SurveyBasket.api.Errors
{
    public static class UserErrors
    {
        public  static readonly  Error InvalidCerdentials=
            new(" User.InvalidCerdentials", "Invalid email/Password");

        public static readonly Error InvalidJwtToken =
           new("User.InvalidJwtToken", "Invalid Jwt token");

        public static readonly Error InvalidRefreshToken =
            new("User.InvalidRefreshToken", "Invalid refresh token");
    }
}
