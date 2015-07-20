using PhillyZoo_App.DestinationLayer.Models.DestinationLayer.DestinationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Repository
{
    public class DestinationRepository
    {
        phillyzoo_newEntities _phillyZooDatabaseEntities = new phillyzoo_newEntities();

        public IEnumerable<DestinationModel> GetDestinations()
        {
            var destinations = _phillyZooDatabaseEntities.DestinationLayer.Include("MapPointStatusType").AsEnumerable();

            if (destinations != null)
            {
                List<DestinationModel> destinationsForController = new List<DestinationModel>();
                foreach (DestinationLayer destination in destinations)
                {
                    DestinationModel destinationForList = new DestinationModel(destination.id, destination.mapPointId, destination.destinationName, destination.MapPointStatusType.status, destination.shortDescription, destination.longDescription, destination.openingTime, destination.closingTime);



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