using System.Web.Mvc;
using System.Threading.Tasks;
using OSBB.Models.House;
using OSBB.Services;
using OSBB.ViewModels;


namespace OSBB.Controllers
{
    [Authorize]
    public class FlatController : Controller
    {
        
        private readonly IHouseService _houseService;

        public FlatController(IHouseService houseService)
        {
            _houseService = houseService;
        }
        public async Task<ActionResult> Index()
        {
            var flats = await _houseService.GetFlatsAsync();
            return View(flats);
        }
        public ActionResult AddFlat()
        {
            var flatViewModel = new FlatViewModel
            {
                Title = "Add New Flat",
                AddButtonTitle = "Add",
                RedirectUrl = Url.Action("Index", "Flat")
            };
            return View(flatViewModel);
        }
        public async Task<ActionResult> DetalisOfFlat(int id)
        {
            var flat = await _houseService.GetFlatAsync(id);
            return View(new FlatViewModel {id = flat.Id, Name = flat.FlatName });
        }
        [HttpPost]
        public async Task<ActionResult> SaveFlat(FlatViewModel flatViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(flatViewModel);
            }
            var flat = await _houseService.GetFlatAsync(flatViewModel.Id);
            if (flat != null)
            {
                flat.Flat.Name = flatViewModel.Name;
                await _houseService.UpdateFlatAsync(flat);
            }
            return RedirectToLocal(redirectUrl);
        }

        public async Task<ActionResult> EditFlat(int id)
        {
            var flat = await _houseService.GetFlatAsync(id);

            var flatViewModel = FlatViewModel
            {
                Title = "Edit Flat",
                AddButtonTitle = "Save",
                RedirectUrl = Url.Action("Index", "Flat"),
                Name = flat.FlatName,
                Id = flat.FlatId
            };
            return View(flatViewModel);
        }
        public async Task<ActionResult> DeleteFlat(int id)
        {
            await _houseService.DeleteFlatAsync(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> AddNewFlat(FlatViewModel flatViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(flatViewModel);
            }

            var flat = new Flat
            {
                FlatName = flatViewModel.Name
            };
            await _houseService.AddFlatAsync(flat);
            return RedirectToLocal(redirectUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Flat");
        }
    }
}