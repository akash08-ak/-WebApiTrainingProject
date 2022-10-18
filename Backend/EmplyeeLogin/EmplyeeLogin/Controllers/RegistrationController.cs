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
    public class RegistrationController : ApiController
    {
        EmployeesEntities DB = new EmployeesEntities();
        [Route("InsertEmployee")]
        [HttpPost]
        public object InsertEmployee(Register Reg)
        {
            try
            {
                EmployeeLogin EL = new EmployeeLogin();
                if (EL.UserName == null)
                {
                    EL.UserName = Reg.UserName;
                    EL.Password = Reg.Password;
                    EL.SecQue = Reg.SecQue;
                    DB.EmployeeLogins.Add(EL);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Record SuccessFully Saved." };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }      
    }
}
