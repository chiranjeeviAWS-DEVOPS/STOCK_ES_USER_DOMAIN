using Microsoft.EntityFrameworkCore;
using StockApplication_UserDomain.Contracts.FetchUser;
using StockApplication_UserDomain.Data;
using System.Diagnostics;

namespace StockApplication_UserDomain.Services.UserDataService
{
    public class UserDataService : IUserDataService
    {

        private readonly ApplicationContext _database;

        public UserDataService(ApplicationContext database) { 

            _database = database;
        
        } 
        public UserDataResponse FetchUserData(string PanNumber)
        {
            List<StockDetails> watchList1 = [];
            List<StockDetails> watchList2 = [];

            var query_1 = $"SELECT * FROM public.\"StockInfo\" WHERE '{PanNumber+"_1"}' = ANY(\"StockInfo\".\"WatchList\")";
            var query_2 = $"SELECT * FROM public.\"StockInfo\" WHERE '{PanNumber+"_2"}' = ANY(\"StockInfo\".\"WatchList\")";

            var account_response = _database.AccountInfo.Where(e => e.PanNumber == PanNumber).FirstOrDefault();
            var user_response = _database.Users.Where(e => e.PanNumber ==  PanNumber).FirstOrDefault();
            var stock_watchList1_info = _database.StockInfo.FromSqlRaw(query_1)?.ToList();
            var stock_watchList2_info = _database.StockInfo.FromSqlRaw(query_2)?.ToList();

            foreach(var stock in stock_watchList1_info)
            {
                StockDetails stockDetails = new StockDetails
                {
                    StockID = stock.StockID,
                    StockCategory = stock.StockCategory,
                    StockName = stock.StockName,
                };
                watchList1.Add(stockDetails);
            }
            foreach (var stock in stock_watchList2_info)
            {
                StockDetails stockDetails = new StockDetails
                {
                    StockID = stock.StockID,
                    StockCategory = stock.StockCategory,
                    StockName = stock.StockName,
                };
                watchList2.Add(stockDetails);
            }

            if(account_response == null)
            {
                Debug.WriteLine("its null");
            }

            return new UserDataResponse
            {
                
                EmailAddrss = user_response.Email,
                PhoneNumber = user_response.PhoneNumber,
                EmailVerified = user_response.EmailVerified,
                PhoneNumberVerified = user_response.PhoneNumberVerified,
                UserWatchList_1 = watchList1,
                UserWatchList_2 = watchList2,
                

            };
        } 
    }
}
