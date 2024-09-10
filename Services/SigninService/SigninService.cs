using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IdentityModel.Tokens;
using StockApplication_UserDomain.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockApplication_UserDomain.Services.SigninService
{
    public class SigninService : ISigninService
    {

        private readonly ApplicationContext _database;
        private string? PasswordHash;
        public string? PanNumber;

        public SigninService(ApplicationContext database)
        {
            _database = database;
        }
        public string CreateToken(string PanNumber)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, PanNumber)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TopSecretKeySecretSecretSecretSecret"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }
        public string SignIn(string email, string password)
        {
           

            var response = _database.Users.Where(e => e.Email == email).ToList();
            foreach (var v in response)
            {
                PasswordHash = v.Password;
                PanNumber = v.PanNumber;
              
            }
            
            
            if(PanNumber != null)
            {
                var result = BCrypt.Net.BCrypt.EnhancedVerify(password, PasswordHash);
                string token = CreateToken(PanNumber);
                return token;
            }
            else
            {
                return "userNotfound";
            }
            

            
        }
    }
}
 