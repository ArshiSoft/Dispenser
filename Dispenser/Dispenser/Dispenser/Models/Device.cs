using System;
namespace Dispenser.Models
{
    public class Device
    {
        public int ID { get; set; }
        public long FlowSensor1 { get; set; }
        public int SedimentalFilter { get; set; }
        public int SedimentalFilterMax { get; set; }
        public int GACFilter { get; set; }
        public int GACFilterMax { get; set; }
        public int CarbonFilter { get; set; }
        public int CarbonFilterMax { get; set; }
        public int ROMembraneFilter { get; set; }
        public int ROMembraneFilterMax { get; set; }
        public int PostCarbonFilter { get; set; }
        public int PostCarbonFilterMax { get; set; }
        public int RemineralizationFilter { get; set; }
        public int RemineralizationFilterMax { get; set; }
        public int TDSSensor1 { get; set; }
        public int TDSSensor1Max { get; set; }
        public int TDSSensor2 { get; set; }
        public int TDSSensor2Max { get; set; }
        public int HotTempSensor { get; set; }
        public int ColdTempSensor { get; set; }
        public int PhSensor { get; set; }
    }
}
