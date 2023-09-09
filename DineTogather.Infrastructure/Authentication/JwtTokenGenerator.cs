using DineTogather.Application.Common.Interfaces;
using DineTogather.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DineTogather.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IOptions<JWTSettings> _jwtSettings;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JWTSettings> jwtSettings)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtSettings;
        }
        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            var signingCredentials = new SigningCredentials
                                    (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Secret)),
                                            SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                    issuer: _jwtSettings.Value.Issuer,
                    claims: claims,
                    expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.Value.ExpiryMinutes),
                    signingCredentials: signingCredentials

                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
