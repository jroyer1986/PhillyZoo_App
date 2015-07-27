using PhillyZoo_App.DestinationLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationModelFactory
    {
        public DestinationRepository _DestinationRepository
        { get; set; }

        public DestinationModel createDestination(DestinationObjectLayer destination)
        {
            DestinationModel newDestination = null;

            if (destination.MapPoint.mapPointTypeId == 252 /*Exhibits*/ || destination.MapPoint.mapPointTypeId == 253 /*Zoo360*/ )
            {
                List<DestinationPhotosModel> photoList = _DestinationRepository.CreatePhotoList(destination);
                List<DestinationEnterExitsModel> enterExitsList = _DestinationRepository.CreateEnterExitsList(destination);
                newDestination = new DestinationExhibitsModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.MapPoint.mapPointTypeId, destination.shortDescription, destination.longDescription, destination.MapPoint.latitude, destination.MapPoint.longitude, destination.openingTime, destination.closingTime, destination.id.ToString() + "preview", destination.id.ToString() + "thumbnail", photoList, enterExitsList);
                
            }
            else if (destination.MapPoint.mapPointTypeId == 254 /*Attractions*/ )
            {
                List<DestinationPhotosModel> photoList = _DestinationRepository.CreatePhotoList(destination);
                List<DestinationEnterExitsModel> enterExitsList = _DestinationRepository.CreateEnterExitsList(destination);
                List<DestinationAdditionalFeesModel> additionalFees = _DestinationRepository.CreateAdditionalFeesList(destination);
                newDestination = new DestinationAttractionsModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.MapPoint.mapPointTypeId, destination.shortDescription, destination.longDescription, destination.MapPoint.latitude, destination.MapPoint.longitude, destination.openingTime, destination.closingTime, destination.id.ToString() + "preview", destination.id.ToString() + "thumbnail", photoList, enterExitsList, additionalFees);
            }
            else if (destination.MapPoint.mapPointTypeId == 256 /*Dining*/ )
            {
                List<DestinationPhotosModel> photoList = _DestinationRepository.CreatePhotoList(destination);
                List<DestinationEnterExitsModel> enterExitsList = _DestinationRepository.CreateEnterExitsList(destination);
                List<DestinationMenuModel> menu = _DestinationRepository.CreateMenuList(destination);
                newDestination = new DestinationDiningModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.MapPoint.mapPointTypeId, destination.shortDescription, destination.longDescription, destination.MapPoint.latitude, destination.MapPoint.longitude, destination.openingTime, destination.closingTime, destination.id.ToString() + "preview", destination.id.ToString() + "thumbnail", photoList, menu, enterExitsList);
            }
            else if(destination.MapPoint.mapPointTypeId == 255  /*GiftsSouvenirs*/ )
            {
                List<DestinationPhotosModel> photoList = _DestinationRepository.CreatePhotoList(destination);
                List<DestinationEnterExitsModel> enterExitsList = _DestinationRepository.CreateEnterExitsList(destination);
                newDestination = new DestinationGiftSouvenirsModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.MapPoint.mapPointTypeId, destination.shortDescription, destination.longDescription, destination.MapPoint.latitude, destination.MapPoint.longitude, destination.openingTime, destination.closingTime, destination.id.ToString() + "preview", destination.id.ToString() + "thumbnail", photoList, enterExitsList);
            }
            else if (destination.MapPoint.mapPointTypeId == 257 /*Facilities*/ )
            {
                newDestination = new DestinationModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.MapPoint.mapPointTypeId, destination.shortDescription, destination.longDescription, destination.MapPoint.latitude, destination.MapPoint.longitude, destination.openingTime, destination.closingTime, destination.id.ToString() + "preview", destination.id.ToString() + "thumbnail");
            }
            else if (destination.MapPoint.mapPointTypeId == 251)
            {
                return null;
            }
            return newDestination;
        }

        public DestinationModelFactory(DestinationRepository _destinationRepository)
        {
            _DestinationRepository = _destinationRepository;
        }
    }
}
