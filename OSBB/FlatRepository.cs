using OSBB.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using OSBB.Models.House;

namespace OSBB
{
    public class FlatRepository
    {
        private static List<Flat> _flats;

        public FlatRepository()
        {
            _flats = new List<Flat> { new Flat { FlatId = 1234567890, FlatName = "23213132213", Pib = "ferfef rfewfr rfew", Address ="fewf 34", PhoneNumber = "+555555455", AreaMetr = "63", CostMetr = "3.5", CostMetr2 = "0.5", CostOll = "552", CostPrivilege50 = "253", CostPrivilege75 = "126", CostSubsidy = "0"  } };
        }
        public async Task<List<Flat>> GetFlats()
        {
            return await Task.Run(() => _flats);
        }
        public async Task<Flat> GetFlat(int id)
        {
            return await Task.Run(() => _flats.FirstOrDefault(f => f.FlatId == id));

        } 
        //public async Task<Flat> AddFlat(Flat flat)
        //{
        //    _flats.Add(flat);
        //    return
        //}
    }
}