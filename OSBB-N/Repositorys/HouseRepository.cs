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

        public async Task DeleteFlatAsync(int id)
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

        // Мешканці разом із квартирою (для списку й сторінки видалення)
        public async Task<IEnumerable<Resident>> GetResidentsAsync()
        {
            var result = new List<Resident>();

            using (var houseContext = new HouseContext())
            {
                result = await houseContext.Residents
                    .Include(r => r.Flat)
                    .OrderBy(r => r.Flat.Address)
                    .ThenBy(r => r.Pib)
                    .ToListAsync();
            }

            return result;
        }

        public async Task<Resident> GetResidentAsync(int id)
        {
            Resident result = null;

            using (var houseContext = new HouseContext())
            {
                result = await houseContext.Residents
                    .Include(r => r.Flat)
                    .FirstOrDefaultAsync(r => r.ResidentId == id);
            }

            return result;
        }

        public async Task<Resident> AddResidentAsync(Resident resident)
        {
            Resident result = null;

            using (var houseContext = new HouseContext())
            {
                result = houseContext.Residents.Add(resident);
                await houseContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<Resident> UpdateResidentAsync(Resident resident)
        {
            using (var houseContext = new HouseContext())
            {
                houseContext.Entry(resident).State = EntityState.Modified;

                await houseContext.SaveChangesAsync();
            }

            return resident;
        }

        public async Task DeleteResidentAsync(int id)
        {
            using (var houseContext = new HouseContext())
            {
                var resident = await houseContext.Residents.FirstOrDefaultAsync(r => r.ResidentId == id);
                if (resident == null)
                {
                    return;
                }

                houseContext.Residents.Remove(resident);

                await houseContext.SaveChangesAsync();
            }
        }


    }
}