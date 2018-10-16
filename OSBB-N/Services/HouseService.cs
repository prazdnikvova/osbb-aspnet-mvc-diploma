using System.Collections.Generic;
using System.Threading.Tasks;
using OSBB_N.Models.House;
using OSBB_N.Repositorys;

namespace OSBB_N.Services
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
            await _houseRepository.DeleteFlatAsync(id);
        }

        public async Task<IEnumerable<Resident>> GetResidentsAsync()
        {
            return await _houseRepository.GetResidentsAsync();
        }

        public async Task<Resident> GetResidentAsync(int id)
        {
            return await _houseRepository.GetResidentAsync(id);
        }

        public async Task<Resident> AddResidentAsync(Resident resident)
        {
            return await _houseRepository.AddResidentAsync(resident);
        }

        public async Task<Resident> UpdateResidentAsync(Resident resident)
        {
            return await _houseRepository.UpdateResidentAsync(resident);
        }

        public async Task DeleteResidentAsync(int id)
        {
            await _houseRepository.DeleteResidentAsync(id);
        }
    }
}