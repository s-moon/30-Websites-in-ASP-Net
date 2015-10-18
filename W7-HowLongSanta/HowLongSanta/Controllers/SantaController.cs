using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HowLongSanta.Models;

namespace HowLongSanta.Controllers
{
    public class SantaController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Duration home = new Duration();
            home.StartDate = DateTime.Today; 
            DateTime endDate = new DateTime(DateTime.Today.Year, 12, 25); 
            if (endDate < home.StartDate)
            {
                // we need to look towards next year
                endDate.AddYears(1);
            }
            home.EndDate = endDate;

            return View(home);
        }
    }
}