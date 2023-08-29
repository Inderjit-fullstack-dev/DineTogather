using DineTogather.Application.Common.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DineTogather.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateJwtToken(long userId, string firstName, string lastName, string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Email, email),
            };

            var signingCredentials = new SigningCredentials
                                    (new SymmetricSecurityKey(Encoding.UTF8.GetBytes("79pZ5MFFtUtkNwCOnFS6797EeeaVDVqq")),
                                            SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                    issuer: "DineTogather",
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingCredentials

                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
