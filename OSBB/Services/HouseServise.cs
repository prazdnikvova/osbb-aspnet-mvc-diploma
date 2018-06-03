using System.Collections.Generic;
using System.Threading.Tasks;
using OSBB.Models.House;
using OSBB.Repositories;

namespace OSBB.Services
{
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _houseRepository;

        public HouseService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public async Task<Flat> AddFlatAsync(Flat flat)
        {
            return await _houseRepository.AddFlatAsync(flat);
        }

        public async Task<IEnumerable<Flat>> GetFlatsAsync()
        {
            return await _houseRepository.GetFlatsAsync();
        }

        public async Task<Flat> GetFlatAsync(int id)
        {
            return await _houseRepository.GetFlatAsync(id);
        }

        public async Task<Flat> UpdateFlatAsync(Flat flat)
        {
            return await _houseRepository.UpdateFlatAsync(flat);
        }

        public async Task DeleteFlatAsync(int id)
        {
            await _houseRepository.DeleteStudnetAsync(id);
        }
    }
}