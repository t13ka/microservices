using System;
using System.Text;

namespace AuthService.Services.Utils
{
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;

    using AuthService.Services.Domain;

    using CryptoHelper;

    using Microsoft.IdentityModel.Tokens;

    public static class JwtUtils
    {
        private static string Key => "secretsecretsecret";

        public static int Lifetime => 10;

        public static string Issuer => "MyAuthServer";

        public static string Audience => "http://localhost";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }

        public static string GenerateWriterJwtToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;

            var span = TimeSpan.FromMinutes(Lifetime);

            var jwt = new JwtSecurityToken(
                Issuer,
                Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(span),
                signingCredentials: new SigningCredentials(
                    GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        public static ClaimsIdentity GetIdentity(User user)
        {
            var claims = new List<Claim>
                             {
                                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                                 new Claim("email", user.Email.ToLower()),
                                 new Claim("sub", user.Id.ToString()),
                                 new Claim("name", user.Name),
                             };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}