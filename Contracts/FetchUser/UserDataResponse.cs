namespace StockApplication_UserDomain.Contracts.FetchUser
{

    public class StockDetails {
    
        public string? StockID { get; set; }
        public string? StockName { get; set; }
        public string? StockCategory { get; set; }
    
    }

    public class UserDataResponse
    {
        public long? AccountNumber { get; set; }

        public string? AccountHolder {  get; set; }
        public string? BranchName { get; set; }
        public string? IFSCCode { get; set; }
        public long Balance { get; set; }

        public long? PhoneNumber { get; set; }
        public string? EmailAddrss  { get; set; }
        public Boolean? PhoneNumberVerified { get; set; }
        public Boolean? EmailVerified { get; set; }

        public List<StockDetails>? UserWatchList_1 { get; set; }
        public List<StockDetails>? UserWatchList_2 { get; set; }
        
    }
}
