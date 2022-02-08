using Dispenser_API.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dispenser_API.Controllers
{
    public class LoginController : ApiController
    {
        // POST: api/Login
        public string Post([FromBody] User value)
        {
            var rtnValue = "false,0";
            try
            {
                using (var db = new DBContext.DBContext())
                {
                    var users = db.Users
                                  .Where(a => a.Username.Equals(value.Username))
                                  .Where(a => a.Password.Equals(value.Password));

                    if (users.Any())
                        rtnValue = $"true,{users.First().UserType}";
                }
            }
            catch
            {

            }

            return rtnValue;
        }
    }
}
