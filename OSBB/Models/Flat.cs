using System;
using OSBB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSBB.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public string PIB { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string AreaMetr { get; set; }
        public string CostMetr { get; set; }
        public string CostMetr2 { get; set; }
        public string CostOll { get; set; }
        public string CostSubsidy { get; set; }
        public string CostPrivilege75 { get; set; }
        public string CostPrivilege50 { get; set; }

    }
}