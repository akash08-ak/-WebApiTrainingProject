using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmplyeeLogin.Models;
using EmplyeeLogin.VM;

namespace EmplyeeLogin.Controllers
{
    [RoutePrefix("Api/login")]
    public class LoginController : ApiController
    {
        EmployeesEntities DB = new EmployeesEntities();
        
        [Route("Login")]
        [HttpPost]
        public Response employeeLogin(Login login)
        {
            var log = DB.EmployeeLogins.Where(x => x.UserName.Equals(login.UserName) &&
                      x.Password.Equals(login.Password)).FirstOrDefault();

            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
            else
                return new Response { Status = "Success", Message = "Login Successfully" };
        }
    }
}
