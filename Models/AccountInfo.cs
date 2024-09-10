using System.ComponentModel.DataAnnotations;

namespace StockApplication_UserDomain.Models
{
    public class AccountInfo
    {
        public string? HolderName { get; set; }
        public string? PanNumber { get; set; }


        [Key]
        public long AccountNumber { get; set; }

        public string? IFSCCode {  get; set; }
        public string? BranchName { get; set; }
        public long Balance { get; set; }   


    }
}
