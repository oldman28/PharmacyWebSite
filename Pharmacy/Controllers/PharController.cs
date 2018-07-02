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
        public ActionResult Index()
        {
            return View();
        }
    }
}