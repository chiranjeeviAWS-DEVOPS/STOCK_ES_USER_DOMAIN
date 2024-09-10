using Microsoft.AspNetCore.Mvc;
using StockApplication_UserDomain.Contracts.Login;
using StockApplication_UserDomain.Services.SigninService;

namespace StockApplication_UserDomain.Controllers.Login
{
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ISigninService _signinService;

       
        public LoginController(ISigninService signinService)
        {
            _signinService = signinService;
        }

        [HttpPost("/login")]
        public JsonResult LoginUser(LoginContract request)
        {   
            string res = _signinService.SignIn(request.Email, request.Password);
            if(res == "userNotFount")
            {
                return new JsonResult(new { message = "user not found" })
                {
                    StatusCode = 404
                };
            }
            else
            {
                return Json(res);
            }
            
        }

    }
}
