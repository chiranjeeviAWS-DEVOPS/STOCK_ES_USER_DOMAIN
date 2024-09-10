using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApplication_UserDomain.Services.UserDataService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography.X509Certificates;

namespace StockApplication_UserDomain.Controllers.FetchUserInfo
{
    [ApiController]
    public class FetchUserInfoController : Controller
    {

        private readonly IUserDataService _userDataService;

        public FetchUserInfoController(IUserDataService userDataService) { 
        
            _userDataService = userDataService;
        }

        [HttpGet("/user"), Authorize]
        public JsonResult FetchUserInfo()
        {

            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            //var id = jsonToken.Claims.First(claim => claim.Type == "PanNumber").Value;

            var userDataResponse = _userDataService.FetchUserData(jsonToken.Claims.First().Value);
            return new JsonResult(userDataResponse);
        }
    }
}
