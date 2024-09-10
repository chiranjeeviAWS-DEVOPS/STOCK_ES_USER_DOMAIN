using Microsoft.AspNetCore.Identity;
using StockApplication_UserDomain.Data;
using StockApplication_UserDomain.Models;

namespace StockApplication_UserDomain.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationContext _database;

        public LoginService(ApplicationContext database)
        {
            _database = database;
        }

       public Users CreateUser(Users user)
        {
            var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);
            user.Password = passwordHash;
            _database.Users.Add(user);
            _database.SaveChanges();
            return user;
        }
    }
}
