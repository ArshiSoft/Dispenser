using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dispenser_API.Controllers
{
    public class Circuit2Controller : ApiController
    {
        // GET: api/Circuit2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Circuit2
        public bool Post(int id, int TDSSensor2, int PHSensor, int ColdTempSensor, int HotTempSensor)
        {
            var rtnValue = false;
            try
            {
                using (var db = new DBContext.DBContext())
                {
                    var device = db.Devices.Find(id);

                    device.TDSSensor2 = TDSSensor2;
                    device.PhSensor = PHSensor;
                    device.ColdTempSensor = ColdTempSensor;
                    device.HotTempSensor = HotTempSensor;

                    db.Entry(device).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    rtnValue = true;
                }
            }
            catch
            {
                rtnValue = false;
            }

            return rtnValue;
        }
    }
}
