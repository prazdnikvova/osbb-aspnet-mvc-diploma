using System;
using OSBB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace OSBB.Controllers
{
    public class FlatController : Controller
    {
        private readonly FlatService _flatService;
        public FlatController()
        {
            _flatService = new FlatService();
        }
        public async Task< ActionResult> Index()
        {
            var flats = await _flatService.GetFlats();
            
            return View(flats);
        }
        public ActionResult AddFlat()
        {
            return View();
        }
        public ActionResult EditFlat()
        {
            return View();
        }
        public ActionResult DeleteFlat()
        {
            return RedirectToAction("Index");
        }
    }
}