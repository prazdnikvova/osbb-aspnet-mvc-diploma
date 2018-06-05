using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OSBB_N.Models.House;

namespace OSBB_N.Common
{
    public class HouseContext : DbContext
    {
        public HouseContext() : base("DefaultConnection")
        {
        }

        public DbSet<Flat> Flats { get; set; }
    }
}