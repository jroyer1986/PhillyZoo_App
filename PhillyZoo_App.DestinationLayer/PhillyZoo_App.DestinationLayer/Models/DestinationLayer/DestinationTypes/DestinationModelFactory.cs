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

            if (destination.MapPoint.MapPointType.type == "Exhibits" || destination.MapPoint.MapPointType.type == "Zoo360" )
            {
                List<DestinationPhotosModel> photoList = _DestinationRepository.CreatePhotoList(destination);
                List<DestinationEnterExitsModel> enterExitsList = _DestinationRepository.CreateEnterExitsList(destination);
                newDestination = new DestinationExhibitsModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.MapPoint.mapPointTypeId, destination.shortDescription, destination.longDescription, destination.MapPoint.latitude, destination.MapPoint.longitude, destination.openingTime, destination.closingTime, destination.DestinationPreview.FirstOrDefault().previewPath, destination.DestinationThumb.FirstOrDefault().thumbPath, photoList, enterExitsList);        
            }
            else if (destination.MapPoint.MapPointType.type == "Attractions" )
            {
                List<DestinationPhotosModel> photoList = _DestinationRepository.CreatePhotoList(destination);
                List<DestinationEnterExitsModel> enterExitsList = _DestinationRepository.CreateEnterExitsList(destination);
                List<DestinationAdditionalFeesModel> additionalFees = _DestinationRepository.CreateAdditionalFees(destination);
                newDestination = new DestinationAttractionsModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.MapPoint.mapPointTypeId, destination.shortDescription, destination.longDescription, destination.MapPoint.latitude, destination.MapPoint.longitude, destination.openingTime, destination.closingTime, destination.DestinationPreview.FirstOrDefault().previewPath, destination.DestinationThumb.FirstOrDefault().thumbPath, photoList, enterExitsList, additionalFees);
            }
            else if (destination.MapPoint.MapPointType.type == "Dining" )
            {
                List<DestinationPhotosModel> photoList = _DestinationRepository.CreatePhotoList(destination);
                List<DestinationEnterExitsModel> enterExitsList = _DestinationRepository.CreateEnterExitsList(destination);
                List<DestinationMenuModel> menu = _DestinationRepository.CreateMenu(destination);
                newDestination = new DestinationDiningModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.MapPoint.mapPointTypeId, destination.shortDescription, destination.longDescription, destination.MapPoint.latitude, destination.MapPoint.longitude, destination.openingTime, destination.closingTime, destination.DestinationPreview.FirstOrDefault().previewPath, destination.DestinationThumb.FirstOrDefault().thumbPath, photoList, menu, enterExitsList);
            }
            else if(destination.MapPoint.MapPointType.type ==  "Gifts/Souvenirs" )
            {
                List<DestinationPhotosModel> photoList = _DestinationRepository.CreatePhotoList(destination);
                List<DestinationEnterExitsModel> enterExitsList = _DestinationRepository.CreateEnterExitsList(destination);
                newDestination = new DestinationGiftSouvenirsModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.MapPoint.mapPointTypeId, destination.shortDescription, destination.longDescription, destination.MapPoint.latitude, destination.MapPoint.longitude, destination.openingTime, destination.closingTime, destination.DestinationPreview.FirstOrDefault().previewPath, destination.DestinationThumb.FirstOrDefault().thumbPath, photoList, enterExitsList);
            }
            else if (destination.MapPoint.MapPointType.type == "Facilities" )
            {
                newDestination = new DestinationModel(destination.id, destination.mapPointId, destination.destinationName, destination.statusTypeId, destination.MapPoint.mapPointTypeId, destination.shortDescription, destination.longDescription, destination.MapPoint.latitude, destination.MapPoint.longitude, destination.openingTime, destination.closingTime, destination.DestinationPreview.FirstOrDefault().previewPath, destination.DestinationThumb.FirstOrDefault().thumbPath);
            }
            else if (destination.MapPoint.MapPointType.type == "NavigationPoint" )
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
