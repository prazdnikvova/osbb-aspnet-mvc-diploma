using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using OSBB_N.Common;
using OSBB_N.Models.House;
using OSBB_N.Repositorys;
using OSBB_N.Services;
using OSBB_N.ViewModels;

namespace OSBB_N.Controllers
{

    [Authorize]
    public class FlatController : Controller
    {
        private readonly IHouseService _houseService; 

        public FlatController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        public FlatController()
        {
            HouseRepository houseRepository = new HouseRepository();
            _houseService = new HouseService(houseRepository);
        }

        //public FlatController()
        //{
        //    _houseService = new HouseService();
        //}

        public async Task<ActionResult> Index()
        {
            var flats = await _houseService.GetFlatsAsync();
            return View((List<Flat>) flats); //(List<Flat>) возможно не то
        }

        public ActionResult AddNewFlat()
        {
            var flatViewModel = new FlatViewModel
            {
                Title = "Додати нову квартиру",
                AddButtonTitle = "Додати",
                RedirectUrl = Url.Action("Index", "Flat")
            };

            return View(flatViewModel);
        }
        // Посилання на сайти комунальних служб (кнопка «Комунальні служби» на головній)
        public ActionResult Utilities()
        {
            return View();
        }

        public async Task<ActionResult> EditFlat(int id)
        {
            var flat = await _houseService.GetFlatAsync(id);
            if (flat == null)
            {
                return HttpNotFound();
            }

            var flatViewModel = new FlatViewModel
            {
                Title = "Редагувати квартиру",
                AddButtonTitle = "Зберегти",
                RedirectUrl = Url.Action("Index", "Flat"),
                FlatId = flat.FlatId,
                FlatName = flat.FlatName,
                FlatIp1 = flat.FlatIp1,
                Pib = flat.Pib,
                FlatAddress = flat.Address,
                PhoneNumber = flat.PhoneNumber,
                AreaMetr = flat.AreaMetr,
                CostMetr = flat.CostMetr,
                CostOll = flat.CostOll,
                CostSubsidy = flat.CostSubsidy,
                CostPrivilege75 = flat.CostPrivilege75,
                CostPrivilege50 = flat.CostPrivilege50
            };

            return View(flatViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewFlat(FlatViewModel flatViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                // підпис кнопки не надсилається з форми, тому відновлюємо його
                flatViewModel.AddButtonTitle = "Додати";
                return View(flatViewModel);
            }
            var flat = new Flat
            {
                FlatName = flatViewModel.FlatName,
                FlatIp1 = flatViewModel.FlatIp1,
                Pib = flatViewModel.Pib,
                Address = flatViewModel.FlatAddress,
                PhoneNumber = flatViewModel.PhoneNumber,
                AreaMetr = flatViewModel.AreaMetr,
                CostMetr = flatViewModel.CostMetr,
                CostOll = flatViewModel.CostOll,
                CostSubsidy = flatViewModel.CostSubsidy,
                CostPrivilege75 = flatViewModel.CostPrivilege75,
                CostPrivilege50 = flatViewModel.CostPrivilege50


            };
            await _houseService.AddFlatAsync(flat);
            return RedirectToLocal(redirectUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditFlat(FlatViewModel flatViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                flatViewModel.Title = "Редагувати квартиру";
                flatViewModel.AddButtonTitle = "Зберегти";
                return View(flatViewModel);
            }

            // беремо квартиру з бази, щоб не затерти поля, яких немає у формі (CostMetr2)
            var flat = await _houseService.GetFlatAsync(flatViewModel.FlatId);
            if (flat == null)
            {
                return HttpNotFound();
            }

            flat.FlatName = flatViewModel.FlatName;
            flat.FlatIp1 = flatViewModel.FlatIp1;
            flat.Pib = flatViewModel.Pib;
            flat.Address = flatViewModel.FlatAddress;
            flat.PhoneNumber = flatViewModel.PhoneNumber;
            flat.AreaMetr = flatViewModel.AreaMetr;
            flat.CostMetr = flatViewModel.CostMetr;
            flat.CostOll = flatViewModel.CostOll;
            flat.CostSubsidy = flatViewModel.CostSubsidy;
            flat.CostPrivilege75 = flatViewModel.CostPrivilege75;
            flat.CostPrivilege50 = flatViewModel.CostPrivilege50;

            await _houseService.UpdateFlatAsync(flat);
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




        public async Task<ActionResult> DeleteFlat(int id)
        {
            await _houseService.DeleteFlatAsync(id);

            return RedirectToAction("Index");
        }




        /*
        [HttpPost]
        public ActionResult FlatSearch(string name)
        {
            using (var houseContext = new HouseContext())
            {

                var allflat = houseContext.Flats.Where(a => a.Pib.Contains(name)).ToList();
                if (allflat.Count <= 0)
                {
                    return HttpNotFound();
                }
                return AllFlat(allflat);
            }
        }
        */

     





    }
}