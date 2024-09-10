using System.ComponentModel.DataAnnotations;

namespace StockApplication_UserDomain.Models
{
    public class StockInfo
    {
        [Key]
        public string? StockID { get; set; }
        public string? StockName { get; set; }
        public string? StockCategory { get; set; }
        public long OutstandingShares   { get; set; }
        public List<string>? WatchList  { get; set; }

    }
}
