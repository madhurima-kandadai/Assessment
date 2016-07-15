using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharpAssignment.ServiceReference1;
using CSharpAssignment.Models;

namespace CSharpAssignment.Controllers
{
    /// <summary>
    ///     Class Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The client
        /// </summary>
        Service1Client client;
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        public HomeController()
        {
           
        }

        private void StartService()
        {
            if (client == null)
            {
                client = new Service1Client();
                client.Open();
            }
        }

        /// <summary>
        /// Homes the index.
        /// </summary>
        /// <returns></returns>
        public ActionResult HomeIndex()
        {
            return this.View();
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Request.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                return this.View();
            }
            else
            {
                return this.RedirectToAction("Login", "Account");
            }
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Gets the crime types.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCrimeTypes()
        {
            StartService();
            var list = client.GetCrimeTypes();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets the locations.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetLocations()
        {
            StartService();
            var list = client.GetLocations();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets the criminal search details.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public ActionResult GetCriminalSearchDetails(CriminalSearchViewModel model)
        {
            StartService();
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
                LocationId = model.LocationId,
                Nationality = model.Nationality,
                EmailId = Request.RequestContext.HttpContext.User.Identity.Name
            };
            try
            {
                var count = client.GetCriminalSearchDetails(serviceModel);
                if (count > 0)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}