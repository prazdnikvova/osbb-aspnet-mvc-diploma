using System;

namespace OSBB.Models.House
{
    public class Flat
    {
        public int FlatId { get; set; }
        public string FlatName { get; set; }
        public string Pib { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string AreaMetr { get; set; }
        public string CostMetr { get; set; }
        public string CostMetr2 { get; set; }
        public string CostOll { get; set; }
        public string CostSubsidy { get; set; }
        public string CostPrivilege75 { get; set; }
        public string CostPrivilege50 { get; set; }


        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        //public int FlatId { get; internal set; }
    }
}