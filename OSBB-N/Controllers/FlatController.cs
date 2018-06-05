using System.Threading.Tasks;
using System.Web.Mvc;
using OSBB_N.Services;

namespace OSBB_N.Controllers
{
    public class FlatController : Controller
    {
        private readonly FlatService _flatService;
        public FlatController()
        {
            _flatService = new FlatService();
        }

        public async Task<ActionResult> Index()
        {
            var flats = await _flatService.GetFlat();
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