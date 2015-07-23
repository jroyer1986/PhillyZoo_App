﻿using PhillyZoo_App.DestinationLayer.Models;
using PhillyZoo_App.DestinationLayer.Repository;
using PhillyZoo_App.DestinationLayer.ViewModels;
using System;
using System.Collections.Generic;
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

        public ActionResult DestinationDetails(int id)
        {
            DestinationModel destinationToDetail = _destinationRepository.GetDestinationByID(id);
            return View(destinationToDetail);
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
        public ActionResult CreateDestination(DestinationModel newDestination)
        {
            _destinationRepository.SaveDatabaseDestination(newDestination);
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

        [HttpGet]
        public ActionResult CreateMenu(int destinationLayerId)
        {
            DestinationMenuModel menus = new DestinationMenuModel();
            menus.DestinationLayerID = destinationLayerId;

            return View(menus);
        }

        [HttpGet]
        public ActionResult CreateAdditionalFees(int destinationLayerId)
        {
            DestinationAdditionalFeesModel additionalFees = new DestinationAdditionalFeesModel();
            additionalFees.DestinationLayerID = destinationLayerId;

            return View(additionalFees);
        }
    }
}