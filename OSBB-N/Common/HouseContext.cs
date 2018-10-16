using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OSBB_N.Models.House;
//using OSBB_N.Migrations;

namespace OSBB_N.Common
{
    public class HouseContext : DbContext
    {
        public HouseContext() : base("DefaultConnection")
        {
          //  Database.SetInitializer<HouseContext>(new MigrateDatabaseToLatestVersion<HouseContext,OSBB_N.Migrations.Configuration>());
        }

        public DbSet<Flat> Flats { get; set; }
        public DbSet<Resident> Residents { get; set; }
    }
}