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
         [HttpGet]
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
       /* @using(Html.BeginForm())
        {
            < p > Name: @Html.TextBoxFor(x => x.idPhar) </ p >
   
               < p > Name: @Html.TextBoxFor(x => x.Name) </ p >
      
                  < p > Name: @Html.TextBoxFor(x => x.Weight) </ p >
         
                     < p > Name: @Html.TextBoxFor(x => x.Quantity) </ p >
            
                        < p > Name: @Html.TextBoxFor(x => x.Description) </ p >
               
                           < p > Name: @Html.TextBoxFor(x => x.Price) </ p >
                  
                              < input type = "submit" value = "add" />
        }*/

        /*  public ViewResult Edit(int productId)
          {
              return View();
          }
          public ViewResult Create()
          {
              return View("Edit", new PharmacyMed());
          }*/
    }
}