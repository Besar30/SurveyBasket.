using System.ComponentModel.DataAnnotations;

namespace SurveyBasket.api.Auuthentication
{
    public class JwtOptions
    {
        public static string SectionName = "Jwt";
        [Required]
        public string Key { get; init; }=string.Empty;
        [Required]
        public string issuer { get; init; }=string.Empty ;
        [Required]
        public string audience { get; init; } = string.Empty;
        [Range(1,int.MaxValue),]
        public int ExpiryMinutes { get; init; }

    }
}
