using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharpAssignment.CriminalServiceReference;
using CSharpAssignment.Models;

namespace CSharpAssignment.Controllers
{
    public class HomeController : Controller
    {
        Service1Client client;
        public HomeController()
        {
            if (client == null)
            {
                client = new Service1Client();
                client.Open();
            }
        }
        public ActionResult Index()
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

        public ActionResult GetCrimeTypes()
        {
            var list = client.GetCrimeTypes();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLocations()
        {
            var list = client.GetLocations();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCriminalSearchDetails(CriminalSearchViewModel model)
        {
            var serviceModel = new CriminalModel
            {
                Name = model.Name,
                AgeRange = model.Age,
                Gender = model.Gender,
                MaxHeight = model.MaxHeight,
                MinHeight = model.MinHeight,
                MinWeight = model.MinWeight,
                MaxWeight = model.MaxWeight,
                CrimeTypeId = model.Crime,
                Location = model.Location,
                Nationality = model.Nationality
            };
            var count = client.GetCriminalSearchDetails(serviceModel);
            if (count > 0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}