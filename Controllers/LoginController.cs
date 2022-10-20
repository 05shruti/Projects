 using Login.models;
using Login.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        LoginDbContext db;
        public LoginController(LoginDbContext _db)
        {
            db = _db;
        }

      


        [HttpPost]
        public IActionResult Login(ViewLogin loginViewModel)
        {
            var Islogin = db.TblLogins.Any(x => x.UserName == loginViewModel.UserName && x.Password == loginViewModel.Password);

            return Ok(new { IsLogin = Islogin, Message = Islogin ? "Successfully login" : "Either username or password is incorrect" });
        }
    }
}