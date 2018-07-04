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
            IEnumerable<City> citys = db.Cities;
            IEnumerable<Medication> meds = db.Medications;
            ViewBag.Medications = meds;
            ViewBag.Citys = citys;

            return View();
        }

        public ActionResult Pick(int id)
        {
            var phar = db.Pharmacies.Where(p => p.idCities == id).ToList();
            return View(phar);
        }

        public ActionResult Medication(int id)
        {
            var med = db.PharmacyMeds.Where(p => p.idPhar == id).ToList();
            
            //  var her = db.Medications.Where(p => p.Id == ).ToList();
            return View(med);
        }

    }
}