using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApplication_UserDomain.Contracts.kyc;
using StockApplication_UserDomain.Data;
using StockApplication_UserDomain.Services.KYC;
using System.IdentityModel.Tokens.Jwt;

namespace StockApplication_UserDomain.Controllers.KYC
{
    [ApiController]
    public class KYCController : Controller
    {
        private readonly ApplicationContext _database;
        private readonly IAddKYC _service;
        public KYCController(ApplicationContext _database, IAddKYC _service) {
            this._database = _database;
            this._service = _service;

        }

        [HttpPost("addkyc"), Authorize]

        public IActionResult AddUserKYCInfo(UserKYC data)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var response = _service.AddKYCInfo(data, jsonToken.Claims.First().Value);


            return new JsonResult(response);

        }
    }
}
