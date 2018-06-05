using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using OSBB_N.Models.House;
using OSBB_N.Repositorys;
using OSBB_N.Services;
using OSBB_N.ViewModels;

namespace OSBB_N.Controllers
{
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
                Title = "Add New Flat",
                AddButtonTitle = "Add",
                RedirectUrl = Url.Action("Index", "Flat")
            };

            return View(flatViewModel);
        }
        public ActionResult EditFlat()
        {
            return View();
        }

        public ActionResult DeleteFlat()
        {
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