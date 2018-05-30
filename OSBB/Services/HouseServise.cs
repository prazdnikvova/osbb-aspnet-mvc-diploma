using System.Web.Mvc;
using System.Threading.Tasks;
using OSBB.Models.House;
using OSBB.Repositories;

namespace OSBB.Services
{
    public class HouseServise : IHouseService
    {
        private readonly IHouseRepository _houseRepository;

        public HouseServise(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }
        public async Task<Flat> AddFlatAsync(Flat flat)
        {
            return await _houseRepository.AddFlatAsync(flat);
        }
        public async Task<IEnumerable<Flat>> GetFlatAsync()
        {
            return await _houseRepository.GetFlatAsync();
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
            return await _houseRepository.DeleteFlatAsync(id);
        }
    }
}