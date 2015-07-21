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

            if (destination.MapPoint.mapPointTypeId == 252 /*Exhibits*/ || destination.MapPoint.mapPointTypeId == 253 /*Zoo360*/ )
            {
                newDestination = new DestinationExhibitsModel();
            }
            else if (destination.MapPoint.mapPointTypeId == 254 /*Attractions*/ )
            {
                newDestination = new DestinationAttractionsModel();
            }
            else if (destination.MapPoint.mapPointTypeId == 256 /*Dining*/ )
            {
                newDestination = new DestinationDiningModel();
            }
            else if (destination.MapPoint.mapPointTypeId == 255  /*GiftsSouvenirs*/ || destination.MapPoint.mapPointTypeId == 257 /*Facilities*/ )
            {
                newDestination = new DestinationModel();
            }
            else if (destination.MapPoint.mapPointTypeId == 251)
            {
                return null;
            }
            return newDestination;
        }
    }
}
