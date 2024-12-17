﻿namespace SurveyBasket.api.contracts.Authentication
{
    public record AuthRespons(
        string Id,
        string? Email,
        string FristName,
        string LastName,
        string Token,
        int ExpirestIn,
        string RefreshToken,
        DateTime RefreshTokenExpiration
        );
 
}
