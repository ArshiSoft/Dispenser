using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dispenser_API.Controllers
{
    public class Circuit1Controller : ApiController
    {
        // GET: api/Circuit1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Circuit1
        public bool Post(int id, int FlowSensor1, int TDSSensor1)
        {
            var rtnValue = false;
            try
            {
                using (var db = new DBContext.DBContext())
                {
                    var device = db.Devices.Find(id);
                    int mililitresadded = 0;

                    if (device.FlowSensor1 != FlowSensor1)
                    {
                        mililitresadded = Convert.ToInt32(FlowSensor1 - device.FlowSensor1);
                    }

                    device.FlowSensor1 = FlowSensor1;
                    device.TDSSensor1 = TDSSensor1;

                    device.SedimentalFilter += mililitresadded;
                    device.GACFilter += mililitresadded;
                    device.CarbonFilter += mililitresadded;
                    device.ROMembraneFilter += mililitresadded;
                    device.PostCarbonFilter += mililitresadded;
                    device.RemineralizationFilter += mililitresadded;

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
