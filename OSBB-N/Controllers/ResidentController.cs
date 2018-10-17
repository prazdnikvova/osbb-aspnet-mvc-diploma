using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using OSBB_N.Models.House;
using OSBB_N.Repositorys;
using OSBB_N.Services;
using OSBB_N.ViewModels;

namespace OSBB_N.Controllers
{
    [Authorize]
    public class ResidentController : Controller
    {
        private readonly IHouseService _houseService;

        public ResidentController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        public ResidentController()
        {
            HouseRepository houseRepository = new HouseRepository();
            _houseService = new HouseService(houseRepository);
        }

        public async Task<ActionResult> Index()
        {
            var residents = await _houseService.GetResidentsAsync();
            return View(residents.ToList());
        }

        public async Task<ActionResult> Add()
        {
            var residentViewModel = new ResidentViewModel();
            await FillFlatsAsync(residentViewModel);

            return View(residentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(ResidentViewModel residentViewModel)
        {
            await CheckFlatAsync(residentViewModel);
            if (!ModelState.IsValid)
            {
                await FillFlatsAsync(residentViewModel);
                return View(residentViewModel);
            }

            var resident = new Resident();
            CopyToResident(residentViewModel, resident);
            await _houseService.AddResidentAsync(resident);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var resident = await _houseService.GetResidentAsync(id);
            if (resident == null)
            {
                return HttpNotFound();
            }

            var residentViewModel = new ResidentViewModel
            {
                ResidentId = resident.ResidentId,
                Pib = resident.Pib,
                FlatId = resident.FlatId,
                PhoneNumber = resident.PhoneNumber,
                Email = resident.Email,
                IsOwner = resident.IsOwner
            };
            await FillFlatsAsync(residentViewModel);

            return View(residentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ResidentViewModel residentViewModel)
        {
            await CheckFlatAsync(residentViewModel);
            if (!ModelState.IsValid)
            {
                await FillFlatsAsync(residentViewModel);
                return View(residentViewModel);
            }

            if (await _houseService.GetResidentAsync(residentViewModel.ResidentId) == null)
            {
                return HttpNotFound();
            }

            // новий об'єкт без навігації Flat: інакше при зміні квартири EF бачить стару й нову одночасно
            var resident = new Resident { ResidentId = residentViewModel.ResidentId };
            CopyToResident(residentViewModel, resident);
            await _houseService.UpdateResidentAsync(resident);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var resident = await _houseService.GetResidentAsync(id);
            if (resident == null)
            {
                return HttpNotFound();
            }

            return View(resident);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _houseService.DeleteResidentAsync(id);
            return RedirectToAction("Index");
        }

        private async Task FillFlatsAsync(ResidentViewModel residentViewModel)
        {
            var flats = await _houseService.GetFlatsAsync();
            residentViewModel.Flats = flats
                .OrderBy(f => f.Address)
                .Select(f => new SelectListItem
                {
                    Value = f.FlatId.ToString(),
                    Text = f.Address + " — " + f.Pib
                })
                .ToList();
        }

        // Квартиру могли видалити, поки форма була відкрита
        private async Task CheckFlatAsync(ResidentViewModel residentViewModel)
        {
            if (ModelState.IsValidField("FlatId") && await _houseService.GetFlatAsync(residentViewModel.FlatId) == null)
            {
                ModelState.AddModelError("FlatId", "Обраної квартири немає в базі");
            }
        }

        private static void CopyToResident(ResidentViewModel residentViewModel, Resident resident)
        {
            resident.Pib = residentViewModel.Pib;
            resident.FlatId = residentViewModel.FlatId;
            resident.PhoneNumber = residentViewModel.PhoneNumber;
            resident.Email = residentViewModel.Email;
            resident.IsOwner = residentViewModel.IsOwner;
        }
    }
}