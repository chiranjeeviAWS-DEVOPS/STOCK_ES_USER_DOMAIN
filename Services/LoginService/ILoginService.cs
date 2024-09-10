using StockApplication_UserDomain.Models;

namespace StockApplication_UserDomain.Services.LoginService
{
    public interface ILoginService
    {
        public Users CreateUser(Users user);
    }
}
