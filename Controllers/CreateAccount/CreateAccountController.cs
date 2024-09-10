using Microsoft.AspNetCore.Mvc;
using StockApplication_UserDomain.Contracts.CreateAccount;
using StockApplication_UserDomain.Data;
using StockApplication_UserDomain.Models;
using StockApplication_UserDomain.Services.LoginService;

namespace StockApplication_UserDomain.Controllers.CreateAccount
{
    [ApiController]
    public class CreateAccountController : Controller
    {
        private readonly ILoginService _service;
        private readonly ApplicationContext _database;


        public CreateAccountController(ILoginService service, ApplicationContext database) {
            
            _database = database;
            _service = service;
        }

        [HttpPost("/createaccount")]
        public JsonResult CreateUser(CreateAccountContract request)
        {
            //checking whether password matched

            if(request.Password == request.ConfirmPassword)
            {
                var User = new Users
                {
                    PanNumber = request.PanNumber,
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = request.Password,
                    PhoneNumber = request.PhoneNumber,
                    EmailVerified = false,
                    PhoneNumberVerified = false,
                    AddedPaymentMethod = false,
                    CreatedAt = DateTime.UtcNow,
                    LastlyModified = DateTime.UtcNow,

                };
                var userEmailExists = _database.Users.Where(e => e.Email == request.Email);
                var userPanExists = _database.Users.Where(e => e.PanNumber == request.PanNumber);
              

                if (userEmailExists.Count() == 0 && userPanExists.Count() == 0) {
                    var response = _service.CreateUser(User);
                    return new JsonResult(response);

                }
                else
                {
                    return new JsonResult(new { messgae = "user already Exists" })
                    {
                        StatusCode = 409

                    };
                }
                

               

            }
            else
            {
                return new JsonResult(new {error = "password not match"})
                {
                    StatusCode = 400
                };
            }
           

            
        }
    }
}
