using OSBB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OSBB
{

    public class FlatService
    {
        private readonly FlatRepository _flatRepository;

        public FlatService()
        {
            _flatRepository = new FlatRepository();
        }

        public async Task<List<Flat>> GetFlats()
        {
            return await _flatRepository.GetFlats();
        }
    }
}