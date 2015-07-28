using PhillyZoo_App.DestinationLayer.Models;
using PhillyZoo_App.DestinationLayer.Repository;
using PhillyZoo_App.DestinationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhillyZoo_App.DestinationLayer.Controllers
{
    public class HomeController : Controller
    {
        IDestinationRepository _destinationRepository = new DestinationRepository();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            IEnumerable<DestinationModel> destinations = _destinationRepository.GetDestinations();

            IndexViewModel viewIndex = new IndexViewModel(destinations);
            return View(viewIndex);
        }

        [HttpPost]
        public ActionResult CreateType(DestinationModel postedType)
        {
            DestinationModel model = null;
            switch (postedType.MapPointTypeID)
            {
                case 2:
                    model =  new DestinationExhibitsModel();
                    break;
                case 3:
                    model = new DestinationExhibitsModel();
                    break;
                case 4:
                    model = new DestinationAttractionsModel();
                    break;
                case 5:
                    model = new DestinationGiftSouvenirsModel();
                    break;
                case 6:
                    model = new DestinationDiningModel();
                    break;
                case 7:
                    model = new DestinationModel();
                    break;
                default:
                    model = new DestinationModel();
                    break;
            }
            model.MapPointTypeID = postedType.MapPointTypeID;
            return View("CreateDestination", model);
        }

        [HttpGet]
        public ActionResult CreateDestination()
        {
            IEnumerable<MapPointStatusType> listOfMapPointStatusTypes = _destinationRepository.ListOfMapPointStatusTypes();
            IEnumerable<SelectListItem> mapPointStatusTypeDropDownList = new List<SelectListItem>();
            mapPointStatusTypeDropDownList = listOfMapPointStatusTypes.Select(m => new SelectListItem() { Value = m.id.ToString(), Text = m.status });

            IEnumerable<MapPointType> listOfMapPointTypes = _destinationRepository.ListOfMapPointTypes();
            IEnumerable<SelectListItem> mapPointTypeDropDownList = new List<SelectListItem>();
            mapPointTypeDropDownList = listOfMapPointTypes.Select(m => new SelectListItem() { Value = m.mapPointTypeId.ToString(), Text = m.type });

            ViewBag.MapPointTypeList = mapPointTypeDropDownList;
            ViewBag.MapPointStatusTypeList = mapPointStatusTypeDropDownList;

            DestinationModel destination = new DestinationModel();
            return View(destination);
        }

        [HttpPost]
        public ActionResult CreateDestination(DestinationModel newDestination, HttpPostedFileBase thumbnailPhoto, HttpPostedFileBase previewPhoto)
        {
            int dbInt = _destinationRepository.SaveDatabaseDestination(newDestination);
            var thumbnailPhotoFileName = Path.GetFileName(thumbnailPhoto.FileName);
            var previewPhotoFileName = Path.GetFileName(previewPhoto.FileName);
            var thumbnailSuffix = Path.GetExtension(thumbnailPhotoFileName);
            var previewSuffix = Path.GetExtension(previewPhotoFileName);
            var thumbnailPhotoPath = dbInt.ToString() + "_thumbnail" + thumbnailSuffix.ToString();
            var previewPhotoPath = dbInt.ToString() + previewSuffix.ToString();

            //create standardized name for preview and thumb...
            var pathForThumb = Path.Combine(Server.MapPath("~/Data/Images/Thumbnail"), thumbnailPhotoPath);
            var pathForPreview = Path.Combine(Server.MapPath("~/Data/Images/Detail"), previewPhotoPath);

            thumbnailPhoto.SaveAs(pathForThumb);
            previewPhoto.SaveAs(pathForPreview);
            _destinationRepository.SaveThumbnailPathToDatabase(dbInt, pathForThumb);
            _destinationRepository.SavePreviewPathToDatabase(dbInt, pathForPreview);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteDestination(int id)
        {
            _destinationRepository.DeleteDatabaseDestination(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditDestination(int id)
        {
            DestinationModel destination = _destinationRepository.GetDestinationByID(id);
            if (destination != null)
            {
                return View(destination);
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult EditDestination(DestinationModel updatedDestination)
        {
            _destinationRepository.EditDatabaseDestination(updatedDestination);
            return RedirectToAction("DestinationDetails", new { id = updatedDestination.ID });
        }

        public ActionResult DetailDestination(int id)
        {
            DestinationModel destination = _destinationRepository.GetDestinationByID(id);
            if (destination != null)
            {
                var pathForThumb = Path.Combine(Server.MapPath("~/TempPreviewThumbs"), destination.ID.ToString() + "_thumbnail_");
                var pathForPreview = Path.Combine(Server.MapPath("~/TempPreviewThumbs"), destination.ID.ToString() + "_preview_");
                ViewBag.DestinationPreviewImage = pathForPreview;
                ViewBag.DestinationThumbnailImage = pathForThumb;
                return View(destination);
            }
            else
            {
                ViewBag.ErrorMessage = "That Destination Does Not Exist!";
                return View("Error");
            } 
        }

        [HttpGet]
        public ActionResult CreatePhotos(int destinationLayerId)
        {
            DestinationPhotosModel photos = new DestinationPhotosModel();
            photos.DestinationLayerID = destinationLayerId;

            return View(photos);
        }

        [HttpPost]
        public ActionResult CreatePhotos(DestinationPhotosModel newPhotoModel)
        {
            _destinationRepository.SaveDatabasePhotos(newPhotoModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateMenu(int destinationLayerId)
        {
            DestinationMenuModel menus = new DestinationMenuModel();
            menus.DestinationLayerID = destinationLayerId;

            return View(menus);
        }

        [HttpPost]
        public ActionResult CreateMenu(DestinationMenuModel newMenuModel)
        {
            _destinationRepository.SaveDatabaseMenu(newMenuModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateAdditionalFees(int destinationLayerId)
        {
            DestinationAdditionalFeesModel additionalFees = new DestinationAdditionalFeesModel();
            additionalFees.DestinationLayerID = destinationLayerId;

            return View(additionalFees);
        }

        [HttpPost]
        public ActionResult CreateAdditionalFees(DestinationAdditionalFeesModel newAdditionalFeeModel)
        {
            _destinationRepository.SaveDatabaseAdditionalFees(newAdditionalFeeModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateEnterExits(int destinationLayerId)
        {
            DestinationEnterExitsModel enterExit = new DestinationEnterExitsModel();
            enterExit.DestinationLayerID = destinationLayerId;

            return View(enterExit);
        }

        [HttpPost]
        public ActionResult CreateEnterExits(DestinationEnterExitsModel newEnterExitModel)
        {
            _destinationRepository.SaveDatabaseEnterExits(newEnterExitModel);
            return RedirectToAction("Index");
        }
    }
}
