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
    public class AccomodationPackageController : Controller
    {
        AccomodationPackageService accomodationPackageServices = new AccomodationPackageService();
        AccomodationTypeService accomodationTypeServices = new AccomodationTypeService();
        // GET: Dashboard/AccomodationType
        public ActionResult Index(string searchTerm, int? accomodationTypeID, int? page)
        {
            int recordSize = 3;
            page = page ?? 1;

            AccomodationPackagesListingModels model = new AccomodationPackagesListingModels();

            model.SearchTerm = searchTerm;

            model.AccomodationTypeID = accomodationTypeID;

            model.AccomodationPackages = accomodationPackageServices.SearchAccomodationPackage(searchTerm, accomodationTypeID, page.Value, recordSize);


            model.AccomodationTypes = accomodationTypeServices.GetAllAccomodationType();

            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationPackageActionModels model = new AccomodationPackageActionModels();

            if (ID.HasValue)// We are trying to edit a record
            {
                var accomodationPackage = accomodationPackageServices.GetAccomodationPackageByID(ID.Value);

                model.ID = accomodationPackage.ID;
                model.AccomodationTypeID = accomodationPackage.AccomodationTypeID;
                model.Name = accomodationPackage.Name;
                model.NoOfRooms = accomodationPackage.NoOfRooms;
                model.FeePerNight = accomodationPackage.FeePerNight;
            }

            model.AccomodationTypes = accomodationTypeServices.GetAllAccomodationType();

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationPackageActionModels model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.ID > 0)// We are trying to edit a record
            {
                var accomodationPackage = accomodationPackageServices.GetAccomodationPackageByID(model.ID);

                accomodationPackage.AccomodationTypeID = model.AccomodationTypeID;
                accomodationPackage.Name = model.Name;
                accomodationPackage.NoOfRooms = model.NoOfRooms;
                accomodationPackage.FeePerNight = model.FeePerNight;

                result = accomodationPackageServices.UpdateAccomodationPackage(accomodationPackage);
            }
            else// We are trying to create a record
            {

                AccomodationPackage accomodationPackage = new AccomodationPackage();

                accomodationPackage.AccomodationTypeID = model.AccomodationTypeID;
                accomodationPackage.Name = model.Name;
                accomodationPackage.NoOfRooms = model.NoOfRooms;
                accomodationPackage.FeePerNight = model.FeePerNight;

                result = accomodationPackageServices.SaveAccomodationPackage(accomodationPackage);
            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation Type." };
            }

            return json;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationPackageActionModels model = new AccomodationPackageActionModels();


            var accomodationPackage = accomodationPackageServices.GetAccomodationPackageByID(ID);

            model.ID = accomodationPackage.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccomodationPackageActionModels model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accomodationPackage = accomodationPackageServices.GetAccomodationPackageByID(model.ID);

            result = accomodationPackageServices.DeleteAccomodationPackage(accomodationPackage);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation Type." };
            }

            return json;
        }
    }
}