using StockApplication_UserDomain.Contracts.watchlist;


namespace StockApplication_UserDomain.Services.WatchlistService
{
    public interface IWatchlistService {

        public Boolean AddStock(WatchlistContract Data, string PanNumber);

        public Boolean RemoveStock(WatchlistContract Data, string PanNumber);   
       
        public ReturnWatchlist GetWatchlist(string PanNumber);
    
    }


}
