using System;
using OSBB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSBB.Controllers
{
    public class FlatController : Controller
    {
        public FlatController()
        {

        }
        public ActionResult Index()
        {
            return View();
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