using OSBB.Models.House;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OSBB.Services
{
    public class IHouseService
    {
        Task<Flat> GetFlatAsync(int id);
        Task<Flat> AddFlatAsync(Flat flat);
        Task<IEnumerable<Flat>> GetFlatsAsync();
        Task DeleteFlatAsync(int id);
        Task<Flat> UpdateFlatAsync(Flat flat);

    }
}