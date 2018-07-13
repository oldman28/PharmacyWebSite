using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pharmacy.Models;

namespace Pharmacy.Controllers
{
    public class PharmacyMedsController : Controller
    {
        private PharContext db = new PharContext();

       
        public ActionResult Index()
        {
            var pharmacyMeds = db.PharmacyMeds.Include(p => p.Pharmacy);
            return View(pharmacyMeds.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PharmacyMed pharmacyMed = db.PharmacyMeds.Find(id);
            if (pharmacyMed == null)
            {
                return HttpNotFound();
            }
            return View(pharmacyMed);
        }


        public ActionResult Create(int id)
        {
            ViewBag.idPhar = id;
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
            return View(pharmacyMed);
        }

        
    }
}
