using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using OSBB.Common;
using OSBB.Models.House;
using OSBB.Repositories;

namespace OSBB
{
    public class HouseRepository : IHouseRepository
    {
        public HouseRepository()
        { }
        public async Task<Flat> GetHouseAsync(int id)
        {
            House result = null;
            using (var houseContext = new HouseContext())
            {
                result = await houseContext.Flats.FirstOrDefaultAsync(f => f.FlatId == id);
            }
            return result;
        }
        public async Task<Flat> AddFlatAsync(Flat flat)
        {
            House result = null;
            using (var houseContext = new HouseContext())
            {
                result = houseContext.Flat.Add(flat);
                await houseContext.SaveCangesAsync();
            }
            return result;
        }
        public async Task<IEnumerable<Flat>> GetFlatsAsync()
        {
            var result = new List<Flat>();
            using (var houseContext = new HouseContext())
            {
                result = await houseContext.Flats.ToListAsync();
            }
            return result;
        }
        public async Task DeleteFlatAsync(int id)
        {
            using (var houseContext = new HouseContext())
            {
                var flat = await flatContext.Flat.FirstOrDefaultAsync(f => f.FlatId == id);
                houseContext.Entry(flat).State = EntityState.Deleted;
                await houseContext.SaveCangesAsync();
            }
        }
        public async Task<Flat> UpdateFlatAsync(Flat flat)
        {
            using (var houseContext = new HouseContext())
            {
                houseContext.Entry(flat).State = EntityState.Modified;
                await houseContext.SaveChangesAsync();
            }
            return flat;
        }
    }
}