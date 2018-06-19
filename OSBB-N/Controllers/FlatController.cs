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

 





        [HttpPost]
        public async Task<ActionResult> AddNewFlat(FlatViewModel flatViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
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