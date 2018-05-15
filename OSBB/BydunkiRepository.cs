using OSBB.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OSBB
{
    public class BydunkiRepository
    {
        private static List<Bydunki> _bydunkis;


        public BydunkiRepository()
        {
            _bydunkis = new List<Bydunki> { new Bydunki { Id = 1, Namber = "23", KolichestvoPodezdov = "3", KolichestvoKvartir = "132" } };
        }
        public async Task<List<Bydunki>> GetBydunki()
        {
            return await Task.Run(() => _bydunkis);
        }
        public async Task<Bydunki> GetBydunki(int id)
        {
            return await Task.Run(() => _bydunkis.FirstOrDefault(f => f.Id == id));
        }

        //
       // public async Task<Bydunki> AddBydunki(Bydunki bydunki)
       // {
       //     _bydunkis.Add(bydunki);

       //     return
       // }
        //

    }
}