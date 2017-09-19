using System;
using System.Text;

namespace AuthService.Services.Utils
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;

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
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    GetSymmetricSecurityKey(),
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
      
    }
}
