using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApplication_UserDomain.Services.WatchlistService;
using StockApplication_UserDomain.Contracts.watchlist;
using System.IdentityModel.Tokens.Jwt;
using System.Diagnostics;

namespace StockApplication_UserDomain.Controllers.Watchlist
{
    [ApiController]
    public class WatchlistController : Controller
    {
        private readonly IWatchlistService _watchlistService;


        public WatchlistController(IWatchlistService watchlistService)
        {
            _watchlistService = watchlistService;
        }

        [HttpPost("/watchlist"), Authorize]
        public JsonResult ModifyWatchlist(WatchlistContract request)
        {

            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            Debug.WriteLine(request.Action);
            if (request.Action == "ADD")
            {
                var response = _watchlistService.AddStock(request, jsonToken.Claims.First().Value);
                return new JsonResult(response);
            }
            else if(request.Action == "DEL")
            {
                var response = _watchlistService.RemoveStock(request, jsonToken.Claims.First().Value);
                return new JsonResult(response);
            }

            return new JsonResult(false);
            
        }

        [HttpGet("/watchlist"), Authorize]
        public JsonResult ReturnUserWatchlist()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            var response = _watchlistService.GetWatchlist(jsonToken.Claims.First().Value);
            return new JsonResult(response);
        }
    }
}
