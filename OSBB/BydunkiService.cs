using OSBB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OSBB
{
    public class BydunkiService
    {
        private readonly BydunkiRepository _bydunkiRepository;

        public BydunkiService()
        {
            _bydunkiRepository = new BydunkiRepository();
        }
        public async Task<List<Bydunki>> GetBydunki()
        {
            return await _bydunkiRepository.GetBydunki();
        }
    }
}