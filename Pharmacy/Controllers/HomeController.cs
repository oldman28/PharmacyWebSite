using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        PharContext db = new PharContext();
        public ActionResult Index()
        {
            IEnumerable<Medication> meds = db.Medications;
            ViewBag.Medications = meds;
            return View();
        }

       
    }
}