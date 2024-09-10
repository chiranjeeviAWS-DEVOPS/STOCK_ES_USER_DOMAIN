namespace StockApplication_UserDomain.Services.SigninService
{
    public interface ISigninService
    {
        public string SignIn(string email, string password);
    }
}
