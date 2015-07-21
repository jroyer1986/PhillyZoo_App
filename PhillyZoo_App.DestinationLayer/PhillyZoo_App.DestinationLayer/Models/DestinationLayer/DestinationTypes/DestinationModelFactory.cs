using PhillyZoo_App.DestinationLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationModelFactory
    {
        DestinationRepository _DestinationRepository = new DestinationRepository();
        public DestinationModel createDestination(DestinationObjectLayer destination)
        {
            DestinationModel newDestination = null;

            if (destination.MapPoint.mapPointTypeId == 252 /*Exhibits*/ || destination.MapPoint.mapPointTypeId == 253 /*Zoo360*/ )
            {
                List<DestinationPhotosModel> photoList = _DestinationRepository.CreatePhotoList(destination);
                List<DestinationEnterExitsModel> enterExitsList = _DestinationRepository.CreateEnterExitsList(destination);
                newDestination = new DestinationExhibitsModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.shortDescription, destination.longDescription, destination.openingTime, destination.closingTime, photoList, enterExitsList);
                
            }
            else if (destination.MapPoint.mapPointTypeId == 254 /*Attractions*/ )
            {
                List<DestinationPhotosModel> photoList = _DestinationRepository.CreatePhotoList(destination);
                List<DestinationEnterExitsModel> enterExitsList = _DestinationRepository.CreateEnterExitsList(destination);
                List<DestinationAdditionalFeesModel> additionalFees = _DestinationRepository.CreateAdditionalFees(destination);
                newDestination = new DestinationAttractionsModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.shortDescription, destination.longDescription, destination.openingTime, destination.closingTime, photoList, enterExitsList, additionalFees);
            }
            else if (destination.MapPoint.mapPointTypeId == 256 /*Dining*/ )
            {
                List<DestinationPhotosModel> photoList = _DestinationRepository.CreatePhotoList(destination);
                List<DestinationEnterExitsModel> enterExitsList = _DestinationRepository.CreateEnterExitsList(destination);
                List<DestinationMenuModel> menu = _DestinationRepository.CreateMenu(destination);
                newDestination = new DestinationDiningModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.shortDescription, destination.longDescription, destination.openingTime, destination.closingTime, photoList, menu, enterExitsList);
            }
            else if (destination.MapPoint.mapPointTypeId == 255  /*GiftsSouvenirs*/ || destination.MapPoint.mapPointTypeId == 257 /*Facilities*/ )
            {
                List<DestinationPhotosModel> photoList = _DestinationRepository.CreatePhotoList(destination);
                newDestination = new DestinationModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.shortDescription, destination.longDescription, destination.openingTime, destination.closingTime, photoList);
            }
            else if (destination.MapPoint.mapPointTypeId == 251)
            {
                return null;
            }
            return newDestination;
        }
    }
}
