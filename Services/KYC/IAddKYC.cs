using StockApplication_UserDomain.Contracts.kyc;
using StockApplication_UserDomain.Models;

namespace StockApplication_UserDomain.Services.KYC
{
    public interface IAddKYC {

        public AccountInfo AddKYCInfo(UserKYC data, string? panNumber);
    }

}
