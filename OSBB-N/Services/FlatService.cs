using System.Collections.Generic;
using System.Threading.Tasks;
using OSBB_N.Models;
using OSBB_N.Repositorys;

namespace OSBB_N.Services
{
    public class FlatService
    {
        private readonly FlatRepository _flatRepository;

        public FlatService()
        {
            _flatRepository = new FlatRepository();
        }

        public async Task<List<Flat>> GetFlat()
        {
            return await _flatRepository.GetFlat();
        }
    }
}