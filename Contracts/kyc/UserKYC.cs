namespace StockApplication_UserDomain.Contracts.kyc
{
    public class UserKYC
    {
        public long AccountNumber { get; set; }
        public string? HolderName  { get; set; }

        public string? IFSCCode { get; set; }
        public string? BranchName {  get; set; }

        

    }
}
