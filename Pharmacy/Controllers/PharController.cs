using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmacy.Controllers
{
    public class PharController : Controller
    {
        // GET: Phar
        // private Models.DatabasePharmacyEntities db = new Models.DatabasePharmacyEntities();
        Models.DatabasePharmacyEntities db = new Models.DatabasePharmacyEntities();
        public ActionResult Index()
        {
            return View();
        }
    }
}