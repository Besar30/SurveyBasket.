﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SurveyBasket.api.Auuthentication
{
    public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
    {
        private readonly JwtOptions _options = options.Value;
        public (string token, int expiresIn) GenerateToken(ApplicationUser user)
        {
            Claim[] claims = [
                new(JwtRegisteredClaimNames.Sub,user.Id),
                new(JwtRegisteredClaimNames.Email,user.Email!),
                new(JwtRegisteredClaimNames.GivenName,user.FirstName),
                new(JwtRegisteredClaimNames.FamilyName,user.LastName),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

                ];
            var symmetricsecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key)); 
            var signingCredentials=new SigningCredentials(symmetricsecurityKey,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_options.ExpiryMinutes),
                signingCredentials: signingCredentials
                );
            return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIN: (_options.ExpiryMinutes*60));
        }

        public string? validationToken(string token)
        {
            var tokenHandler =new JwtSecurityTokenHandler();
            var symmetricsecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    IssuerSigningKey = symmetricsecurityKey,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwttoken = (JwtSecurityToken)validatedToken;
                return jwttoken.Claims.First(x=>x.Type==JwtRegisteredClaimNames.Sub).Value;
            }
            catch
            {
                return null;

            }
        }
    }
}
