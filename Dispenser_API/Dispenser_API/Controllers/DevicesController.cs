using Dispenser_API.DBContext;
using System.Collections.Generic;
using System.Web.Http;

namespace Dispenser_API.Controllers
{
    public class DevicesController : ApiController
    {
        // GET: api/Devices
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Devices/5
        public Device Get(int id)
        {
            using (var db = new DBContext.DBContext())
            {
                return db.Devices.Find(id);
            }
        }

        // POST: api/Devices
        public bool Post([FromBody] Device value)
        {
            var rtnValue = false;

            try
            {
                using (var db = new DBContext.DBContext())
                {
                    db.Devices.Add(value);
                    db.SaveChanges();
                }

                rtnValue = true;
            }
            catch
            {
                rtnValue = false;
            }

            return rtnValue;
        }

        // PUT: api/Devices/5
        public bool Put(int id, [FromBody] Device value)
        {
            var rtnValue = false;

            try
            {
                using (var db = new DBContext.DBContext())
                {
                    db.Entry(value).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                rtnValue = true;
            }
            catch
            {
                rtnValue = false;
            }

            return rtnValue;
        }

        // DELETE: api/Devices/5
        public void Delete(int id)
        {
        }
    }
}
