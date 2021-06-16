using HMS.Areas.Dashboard.ViewModels;
using HMS.Entities;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Areas.Dashboard.Controllers
{
    public class AccomodationTypeController : Controller
    {
        AccomodationTypeService accomodationTypeServices = new AccomodationTypeService();
        // GET: Dashboard/AccomodationType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listing()
        {
            AccomodationTypesListingModels model = new AccomodationTypesListingModels();
            model.AccomodationTypes = accomodationTypeServices.GetAllAccomodationType();

            return PartialView("_Listing", model);
        }

        [HttpGet]
        public ActionResult Action()
        {
            AccomodationTypesActionModels model = new AccomodationTypesActionModels();

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationTypesActionModels model)
        {
            JsonResult json = new JsonResult();

            AccomodationType accomodationType = new AccomodationType();

            accomodationType.Name = model.Name;
            accomodationType.Description = model.Description;


            var result = accomodationTypeServices.SaveAccomodationType(accomodationType);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Accomodation Type." };
            }

            return json;
        }
    }
}