using System.ComponentModel.DataAnnotations;

namespace StockApplication_UserDomain.Models
{
    public class Users
    {
        [Key]
        public string? PanNumber { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public long? PhoneNumber { get; set; }
        public Boolean? EmailVerified { get; set; }
        public Boolean? PhoneNumberVerified { get; set; }
        public Boolean? AddedPaymentMethod {  get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? LastlyModified {  get; set; }


    }
}
