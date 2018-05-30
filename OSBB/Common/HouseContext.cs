using System.Data.Entity;
using OSBB.Models.House;

namespace OSBB.Common
{
    public class HouseContext : DbContext
    {
        public HouseContext() : base("DefaultConnection")
        {
        }

        public DbSet<Flat> Flats { get; set; }
    }
}