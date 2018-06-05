using OSBB_N.Common;
using OSBB_N.Models;
using OSBB_N.Models.House;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OSBB_N.Repositorys
{
    public class HouseRepository : IHouseRepository
    {
        private static List<Flat> _flats;

        public HouseRepository()
        {
            _flats = new List<Flat>{ new Flat { FlatId = 1, FlatName = "23213132213", Pib = "ferfef rfewfr rfew", Address = "fewf 34", PhoneNumber = "+555555455", AreaMetr = "63", CostMetr = "3.5", CostMetr2 = "0.5", CostOll = "552", CostPrivilege50 = "253", CostPrivilege75 = "126", CostSubsidy = "0" } };
        }
        public async Task<List<Flat>> GetFlat()
        {
            return await Task.Run(() => _flats);
        }

        public async Task<Flat> GetFlat(int id)
        {
            return await Task.Run(() =>_flats.FirstOrDefault(f => f.FlatId == id));
        }

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