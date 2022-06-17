using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace LibraryApp.Api.Identity
{
    public class JWTAuthenticationManager : IJWTAuthenticationService
    {
        
        private readonly string _key;
        public JWTAuthenticationManager(string key)
        {
            _key = key;
        }
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            {"usr1","pwd1" },
            {"usr2","pwd2" }

        };
        public string Authenticate(string username, string password)
        {
            if (!users.Any(x=> x.Key==username && x.Value==password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            //token will be user specific
            //token management
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name,username)
                    }),
                //open for 1 hour according to international time(for token)
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials=new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
