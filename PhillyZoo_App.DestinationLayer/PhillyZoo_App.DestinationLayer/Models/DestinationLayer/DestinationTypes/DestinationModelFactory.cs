using PhillyZoo_App.DestinationLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationModelFactory
    {
        public DestinationModel createDestination(DestinationObjectLayer destination)
        {
            DestinationModel newDestination = null;

            if(destination.MapPoint.mapPointTypeId == 251)
            {
                newDestination = new DestinationAttractionsModel();
            }
            else if (destination.MapPoint.mapPointTypeId == 252)
            {
                newDestination = new DestinationDiningModel();
            }
            else if (destination.MapPoint.mapPointTypeId == 253)
            {

            }
            else if (destination.MapPoint.mapPointTypeId == 254)
            {
                    
            }
            else if (destination.MapPoint.mapPointTypeId == 255)
            {

            }
            return newDestination;
        }
    }
}