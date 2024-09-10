using StockApplication_UserDomain.Contracts.FetchUser;

namespace StockApplication_UserDomain.Services.UserDataService
{
    public interface IUserDataService
    {
        public UserDataResponse FetchUserData(string PanNumber);
    }
}
