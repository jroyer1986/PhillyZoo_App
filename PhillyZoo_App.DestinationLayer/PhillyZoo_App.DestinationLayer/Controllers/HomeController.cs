using PhillyZoo_App.DestinationLayer.Models;
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
        DestinationRepository _destinationRepository = new DestinationRepository();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //get a list of destinations from repository
            IEnumerable<DestinationModel> destinations = _destinationRepository.GetDestinations();

            IndexViewModel viewIndex = new IndexViewModel(destinations);
            return View(viewIndex);
        }

        [HttpGet]
        public ActionResult Create()
        {
            DestinationModel destination = new DestinationModel();

            return View(destination);
        }

        [HttpPost]
        public ActionResult Create(DestinationModel newDestination)
        {
            _destinationRepository.SaveDatabaseDestination(newDestination);
            return RedirectToAction("Index");
        }

    }
}
