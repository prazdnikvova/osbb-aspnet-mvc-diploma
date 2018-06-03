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

        public async Task<Flat> GetFlatAsync(int id)
        {
            Flat result = null;

            using (var houseContext = new HouseContext())
            {
                result = await houseContext.Flats.FirstOrDefaultAsync(f => f.FlatId == id);
            }

            return result;
        }

        public async Task<Flat> AddFlatAsync(Flat flat)
        {
            Flat result = null;

            using (var houseContext = new HouseContext())
            {
                result = houseContext.Flats.Add(flat);
                await houseContext.SaveChangesAsync();
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

        public async Task DeleteStudnetAsync(int id)
        {
            using (var houseContext = new HouseContext())
            {
                var flat = await houseContext.Flats.FirstOrDefaultAsync(f => f.FlatId == id);

                houseContext.Entry(flat).State = EntityState.Deleted;

                await houseContext.SaveChangesAsync();
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