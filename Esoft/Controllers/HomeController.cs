using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esoft.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TripSheet()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult CityMasterList()
        {
            ViewBag.Message = "Your CityMasterList page.";

            return View();
        }

        public ActionResult RateListBilty()
        {
            ViewBag.Message = "Your RateListBilty page.";

            return View();
        }

        public ActionResult CoOprativeLoan()
        {
            ViewBag.Message = "Your CoOprativeLoan page.";

            return View();
        }

        public ActionResult RefundsReceipts()
        {
            ViewBag.Message = "Your RefundsReceipts page.";

            return View();
        }

        public ActionResult ContractScreen()
        {
            ViewBag.Message = "Your ContractScreen page.";

            return View();
        }
    }
}