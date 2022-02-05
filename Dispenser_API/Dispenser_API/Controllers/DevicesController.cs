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
                    var model = db.Devices.Find(value.ID);

                    if (model == null)
                    {
                        db.Devices.Add(value);
                        db.SaveChanges();
                    }
                    else
                    {
                        model.FlowSensor1 = value.FlowSensor1;
                        model.ColdTempSensor = value.ColdTempSensor;
                        model.HotTempSensor = value.HotTempSensor;
                        model.CarbonFilter = value.CarbonFilter;
                        model.CarbonFilterMax = value.CarbonFilterMax;
                        model.PostCarbonFilter = value.PostCarbonFilter;
                        model.PostCarbonFilterMax = value.PostCarbonFilterMax;
                        model.ROMembraneFilter = value.ROMembraneFilter;
                        model.ROMembraneFilterMax = value.ROMembraneFilterMax;
                        model.SedimentalFilter = value.SedimentalFilter;
                        model.SedimentalFilterMax = value.SedimentalFilterMax;
                        model.RemineralizationFilter = value.RemineralizationFilter;
                        model.RemineralizationFilterMax = value.RemineralizationFilterMax;
                        model.GACFilter = value.GACFilter;
                        model.GACFilterMax = value.GACFilterMax;
                        model.PhSensor = value.PhSensor;
                        model.TDSSensor1 = value.TDSSensor1;
                        model.TDSSensor1Max = value.TDSSensor1Max;
                        model.TDSSensor2 = value.TDSSensor2;
                        model.TDSSensor2Max = value.TDSSensor2Max;

                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
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
        public void Put(int id, [FromBody] Device value)
        {
            //var rtnValue = false;

            //try
            //{
            //    using (var db = new DBContext.DBContext())
            //    {
            //        db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            //        db.SaveChanges();
            //    }

            //    rtnValue = true;
            //}
            //catch
            //{
            //    rtnValue = false;
            //}

            //return rtnValue;
        }

        // DELETE: api/Devices/5
        public void Delete(int id)
        {
        }
    }
}
