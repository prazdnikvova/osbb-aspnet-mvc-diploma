using OSBB_N.Models;
using OSBB_N.Models.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace OSBB_N.Services
{
    public interface IHouseService
    {
        Task<Flat> GetFlatAsync(int id);
        Task<Flat> AddFlatAsync(Flat flat);
        Task<IEnumerable<Flat>> GetFlatsAsync();
        Task DeleteFlatAsync(int id);
        Task<Flat> UpdateFlatAsync(Flat flat);

        Task<IEnumerable<Resident>> GetResidentsAsync();
        Task<Resident> GetResidentAsync(int id);
        Task<Resident> AddResidentAsync(Resident resident);
        Task<Resident> UpdateResidentAsync(Resident resident);
        Task DeleteResidentAsync(int id);
    }
}