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
        IDestinationRepository _destinationRepository = new FakeDestinationRepository();
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
            DestinationModel destination = new DestinationModel();
            return View(destination);
        }

        [HttpPost]
        public ActionResult CreateDestination(DestinationModel newDestination)
        {
            _destinationRepository.SaveDatabaseDestination(newDestination);
            return RedirectToAction("Index");
        }

    }
}
