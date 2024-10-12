using StockApplication_UserDomain.Contracts.kyc;
using StockApplication_UserDomain.Data;
using StockApplication_UserDomain.Models;
using System.Security.Cryptography.X509Certificates;

namespace StockApplication_UserDomain.Services.KYC
{
    public class AddKYC  : IAddKYC
    {
        private readonly ApplicationContext _database;

        public AddKYC(ApplicationContext database)
        {
            this._database = database;
        }

        public AccountInfo AddKYCInfo(UserKYC data, string? panNumber)
        {

            var user = _database.Users.FirstOrDefault(e => e.PanNumber == panNumber);
            AccountInfo userKYC = new AccountInfo {
                AccountNumber = data.AccountNumber,
                HolderName = data.HolderName,
                IFSCCode = data.IFSCCode,
                BranchName = data.BranchName,
                Balance = 0,
                PanNumber = panNumber
               

            };

            if(user != null)
            {
                user.PhoneNumberVerified = true;
                user.EmailVerified = true;
                user.AddedPaymentMethod = true;

               
            };

           

            _database.AccountInfo.Add(userKYC);
            _database.SaveChanges();


            return userKYC;

        }

    }
}
