using Microsoft.EntityFrameworkCore;
using StockApplication_UserDomain.Contracts.FetchUser;
using StockApplication_UserDomain.Contracts.watchlist;
using StockApplication_UserDomain.Data;
using System.Diagnostics;



namespace StockApplication_UserDomain.Services.WatchlistService
{
    public class WatchlistService : IWatchlistService
    {
        private readonly ApplicationContext _database;

        public WatchlistService(ApplicationContext database) { 
        
            _database = database;
        }

        public Boolean AddStock(WatchlistContract Data, string PanNumber)
        {
           

            if (Data.WatchListID == 1)
            {
                var stock_data = _database.StockInfo.Where(e => e.StockName == Data.Stock).FirstOrDefault();
                var Watchlist = stock_data?.WatchList;
                if(Watchlist == null)
                {
                    return false;
                }
                else
                {

                    if (Watchlist.Contains(PanNumber+"_1"))
                    {
                        return false;
                    }
                    else
                    {
                        Watchlist.Add(PanNumber + "_1");
                        stock_data.WatchList = Watchlist;
                        _database.SaveChanges();
                        return true;
                    }
                }

            }
            else if(Data.WatchListID == 2)
            {
                var stock_data = _database.StockInfo.Where(e => e.StockName == Data.Stock).FirstOrDefault();
                var Watchlist = stock_data?.WatchList;
                if (Watchlist == null)
                {
                    return false;
                }
                else
                {
                    if (Watchlist.Contains(PanNumber + "_2"))
                    {
                        return false;
                    }
                    else
                    {
                        Watchlist.Add(PanNumber + "_2");
                        stock_data.WatchList = Watchlist;
                        _database.SaveChanges();
                        return true;
                    }

                }


            }
            else
            {
                return false;
            }
            
        }

        public Boolean RemoveStock(WatchlistContract Data, string PanNumber)
        {
            if (Data.WatchListID == 1)
            {
                var stock_data = _database.StockInfo.Where(e => e.StockName == Data.Stock).FirstOrDefault();
                var Watchlist = stock_data?.WatchList;
                if (Watchlist == null)
                {
                    return false;
                }
                else
                {

                    if (Watchlist.Contains(PanNumber + "_1"))
                    {
                        Watchlist.Remove(PanNumber + "_1");
                        stock_data.WatchList = Watchlist;
                        _database.SaveChanges();
                        return true;
                       
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            else if (Data.WatchListID == 2)
            {
                var stock_data = _database.StockInfo.Where(e => e.StockName == Data.Stock).FirstOrDefault();
                var Watchlist = stock_data?.WatchList;
                if (Watchlist == null)
                {
                    return false;
                }
                else
                {
                    if (Watchlist.Contains(PanNumber + "_2"))
                    {
                        Watchlist.Remove(PanNumber + "_2");
                        stock_data.WatchList = Watchlist;
                        _database.SaveChanges();
                        return true;
                        
                    }
                    else
                    {
                        return false;
                    }

                }


            }
            else
            {
                return false;
            }
        }
        public ReturnWatchlist GetWatchlist(string PanNumber)
        {
            List<string> watchList1 = [];
            List<string> watchList2 = [];

            var query_1 = $"SELECT * FROM public.\"StockInfo\" WHERE '{PanNumber + "_1"}' = ANY(\"StockInfo\".\"WatchList\")";
            var query_2 = $"SELECT * FROM public.\"StockInfo\" WHERE '{PanNumber + "_2"}' = ANY(\"StockInfo\".\"WatchList\")";

            var stock_watchList1_info = _database.StockInfo.FromSqlRaw(query_1)?.ToList();
            var stock_watchList2_info = _database.StockInfo.FromSqlRaw(query_2)?.ToList();



            foreach (var stock in stock_watchList1_info)
            {
                watchList1.Add(stock.StockName);
            }
            foreach (var stock in stock_watchList2_info)
            {
                watchList2.Add(stock.StockName);
            }

            var result = new ReturnWatchlist
            {
                WatchList_1 = watchList1,
                WatchList_2 = watchList2,
            };
            return result;

        }


    }
}
