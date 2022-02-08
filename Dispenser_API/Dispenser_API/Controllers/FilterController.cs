using Dispenser_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dispenser_API.Controllers
{
    public class FilterController : ApiController
    {
        // POST: api/Filter
        public bool Post([FromBody] ResetFilter value)
        {
            var rtnValue = false;
            try
            {
                using (var db = new DBContext.DBContext())
                {
                    var device = db.Devices.Find(value.DeviceID);

                    if (value.IsSedimental)
                        device.SedimentalFilter = 0;
                    if (value.IsGAC)
                        device.GACFilter = 0;
                    if (value.IsCarbon)
                        device.CarbonFilter = 0;
                    if (value.IsRO)
                        device.ROMembraneFilter = 0;
                    if (value.IsPostCarbon)
                        device.PostCarbonFilter = 0;
                    if (value.IsRemineralization)
                        device.RemineralizationFilter = 0;

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
