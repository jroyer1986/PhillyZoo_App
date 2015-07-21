using PhillyZoo_App.DestinationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Repository
{
    public class DestinationRepository
    {
        DestinationModelFactory _destinationModelFactory = new DestinationModelFactory();
        phillyzoo_newEntities _phillyZooDatabaseEntities = new phillyzoo_newEntities();

        public IEnumerable<DestinationModel> GetDestinations()
        {
            var destinations = _phillyZooDatabaseEntities.DestinationLayer.Include("MapPointStatusType").AsEnumerable();

            if (destinations != null)
            {
                List<DestinationModel> destinationsForController = new List<DestinationModel>();
                foreach (DestinationObjectLayer destination in destinations)
                {
                    DestinationModel destinationForList = _destinationModelFactory.createDestination(destination);

                    destinationsForController.Add(destinationForList);
                }

                return destinationsForController;
            }
            else
            { 
                return null;
            }
        }
    }
}