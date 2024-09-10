namespace StockApplication_UserDomain.Contracts.CreateAccount
{
    public class CreateAccountContract
    {
        public string? Email {  get; set; }
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public string? PanNumber { get; set; }
        public long? PhoneNumber { get; set; }
    
    }
}
