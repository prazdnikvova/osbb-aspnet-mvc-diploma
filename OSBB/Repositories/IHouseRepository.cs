using System.Collections.Generic;
using System.Threading.Tasks;
using OSBB.Models.House;

namespace OSBB.Repositories
{
    public interface IHouseRepository
    {
        Task<Flat> GetFlatAsync(int id);
        Task<Flat> AddFlatAsync(Flat Flat);
        Task<IEnumerable<Flat>> GetFlatsAsync();
        Task DeleteStudnetAsync(int id);
        Task<Flat> UpdateFlatAsync(Flat Flat);
    }
}