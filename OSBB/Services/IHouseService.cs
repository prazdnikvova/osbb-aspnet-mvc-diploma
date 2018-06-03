using System.Collections.Generic;
using System.Threading.Tasks;
using OSBB.Models.House;

namespace OSBB.Services
{
    public interface IHouseService
    {
        Task<Flat> GetFlatAsync(int id);
        Task<Flat> AddFlatAsync(Flat flat);
        Task<IEnumerable<Flat>> GetFlatsAsync();
        Task DeleteFlatAsync(int id);
        Task<Flat> UpdateFlatAsync(Flat flat);


    }
}