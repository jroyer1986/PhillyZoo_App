using PhillyZoo_App.DestinationLayer.Models;
using PhillyZoo_App.DestinationLayer.Repository;
using PhillyZoo_App.DestinationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            string thumbnailPhotoFileName = Path.GetFileName(thumbnailPhoto.FileName);
            string thumbnailSuffix = Path.GetExtension(thumbnailPhotoFileName);
            string pathForDatabaseThumb = dbInt + "_thumbnail" + thumbnailSuffix.ToString();

            string previewPhotoFileName = Path.GetFileName(previewPhoto.FileName);
            string previewSuffix = Path.GetExtension(previewPhotoFileName);
            string pathForDatabasePreview = dbInt + previewSuffix.ToString();
          
            string fullPathForThumb = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["destinationThumbnailDir"]), pathForDatabaseThumb);
            string fullPathForPreview = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["destinationPreviewDir"]), pathForDatabasePreview);

            thumbnailPhoto.SaveAs(fullPathForThumb);
            previewPhoto.SaveAs(fullPathForPreview);
            
            _destinationRepository.SaveThumbnailPathToDatabase(dbInt, pathForDatabaseThumb);
            _destinationRepository.SavePreviewPathToDatabase(dbInt, pathForDatabasePreview);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteDestination(int id)
        {
            string fullPathForThumb = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["destinationThumbnailDir"]), _destinationRepository.GetDestinationByID(id).ThumbnailPhoto.ToString());
            string fullPathForPreview = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["destinationPreviewDir"]), _destinationRepository.GetDestinationByID(id).PreviewPhoto.ToString());

            if (System.IO.File.Exists(fullPathForThumb))
            {
                System.IO.File.Delete(fullPathForThumb);
            }
            if (System.IO.File.Exists(fullPathForPreview))
            {
                System.IO.File.Delete(fullPathForPreview);
            }

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

        [HttpPost]
        public ActionResult EditDestination(DestinationModel updatedDestination, HttpPostedFileBase previewPhoto, HttpPostedFileBase thumbnailPhoto)
        {
            var thumbnailPhotoFileName = Path.GetFileName(thumbnailPhoto.FileName);
            var thumbnailSuffix = Path.GetExtension(thumbnailPhotoFileName);
            var pathForDatabaseThumb = updatedDestination.ID + "_thumbnail" + thumbnailSuffix.ToString();

            var previewPhotoFileName = Path.GetFileName(previewPhoto.FileName);
            var previewSuffix = Path.GetExtension(previewPhotoFileName);
            var pathForDatabasePreview = updatedDestination.ID + previewSuffix.ToString();

            var fullPathForThumb = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["destinationThumbnailDir"]), pathForDatabaseThumb);
            var fullPathForPreview = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["destinationPreviewDir"]), pathForDatabasePreview);

            if(System.IO.File.Exists(fullPathForThumb))
            {
                System.IO.File.Delete(fullPathForThumb);
            }
            if(System.IO.File.Exists(fullPathForPreview))
            {
                System.IO.File.Delete(fullPathForPreview);
            }

            thumbnailPhoto.SaveAs(fullPathForThumb);
            previewPhoto.SaveAs(fullPathForPreview);

            _destinationRepository.EditDatabaseDestination(updatedDestination, previewPhoto, thumbnailPhoto);
            return RedirectToAction("DetailDestination", new { id = updatedDestination.ID });
        }

        public ActionResult DetailDestination(int id)
        {
            DestinationModel destination = _destinationRepository.GetDestinationByID(id);
            if (destination != null)
            {
                ViewBag.rootPathForPreview = Path.Combine(ConfigurationManager.AppSettings["destinationPreviewDir"], _destinationRepository.GetDestinationByID(id).PreviewPhoto);
                ViewBag.rootPathForThumbnail = Path.Combine(ConfigurationManager.AppSettings["destinationThumbnailDir"], _destinationRepository.GetDestinationByID(id).ThumbnailPhoto);
                ViewBag.destinationPhotoLibraryDir = ConfigurationManager.AppSettings["destinationPhotoLibraryDir"];

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
        public ActionResult CreatePhotos(DestinationPhotosModel newPhotoModel, HttpPostedFileBase libraryPhoto)
        {
            var dbInt = _destinationRepository.GetDestinationByID(newPhotoModel.DestinationLayerID).ID;

            string addedPhotoName = Path.GetFileName(libraryPhoto.FileName);
            string pathForDatabase = dbInt + "_" + addedPhotoName;
            string fullPathForDir = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["destinationPhotoLibraryDir"]), pathForDatabase);
            newPhotoModel.ImagePath = pathForDatabase;

            libraryPhoto.SaveAs(fullPathForDir);

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
