using System.Threading.Tasks;
using System.Web.Mvc;

namespace OSBB.Controllers
{
    public class BydunkiController : Controller
    {
        private readonly BydunkiService _bydunkiService;
        public BydunkiController()
        {
            _bydunkiService = new BydunkiService();
        }
        public async Task<ActionResult> Index()
        {
            var bydunki = await _bydunkiService.GetBydunki();

            return View(bydunki);
        }
        public ActionResult AddBydunki()
        {
            return View();
        }
        public ActionResult EditBydunki()
        {
            return View();
        }
        public ActionResult DeleteBydunki()
        {
            return RedirectToAction("Index");
        }

    }
}