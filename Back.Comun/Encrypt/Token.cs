using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Back.Comun.Encrypt
{
    public class Token
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public Token(IConfiguration config)
        {
            _secretKey = config["JwtSettings:Key"];
            _issuer = config["JwtSettings:Issuer"];
            _audience = config["JwtSettings:Audience"];
        }
       
        public string GenerateToken(string username)
        {
            var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim("correo", username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kfklerflkejrgkljelktjgklrelkjllolololo"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.Now.AddMinutes(120);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
