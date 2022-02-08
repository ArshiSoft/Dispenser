using System;
namespace Dispenser.Models
{
    public class ResetFilter
    {
        public int DeviceID { get; set; }
        public bool IsSedimental { get; set; }
        public bool IsGAC { get; set; }
        public bool IsCarbon { get; set; }
        public bool IsRO { get; set; }
        public bool IsPostCarbon { get; set; }
        public bool IsRemineralization { get; set; }
    }
}
