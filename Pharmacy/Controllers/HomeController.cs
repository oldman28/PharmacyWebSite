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
        Random rnd = new Random();
        PharContext db = new PharContext();
        public ActionResult Index()
        {
            IEnumerable<City> citys = db.Cities;
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
            return View(med);
        }
        public ActionResult Create()
        {
            ViewBag.idPhar = new SelectList(db.Pharmacies, "Id", "Name");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Weight,Quantity,Description,Price,idPhar")] PharmacyMed pharmacyMed)
        {
            if (ModelState.IsValid)
            {
                db.PharmacyMeds.Add(pharmacyMed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPhar = new SelectList(db.Pharmacies, "Id", "Name", pharmacyMed.idPhar);
            return View(pharmacyMed);
        }
        /*  [HttpGet]
          public ActionResult Create(int id)
          {
             ViewBag.PharId = id;
              return View();
          }
          [HttpPost]
          public string Create(string Name, int Weight,int Quantity, string Description, int Price, int idPhar)
          { 

             PharmacyMed PH = new PharmacyMed
                 {

                     //Id = rnd.Next(0, 10500),
                     idPhar = idPhar,
                     Name = Name,
                     Weight = Weight,
                     Quantity = Quantity,
                     Description = Description,
                     Price = Price
                 };
                 db.PharmacyMeds.Add(PH);
                 db.SaveChanges();
              return "Добавлено!";
          }
    */
    }
}