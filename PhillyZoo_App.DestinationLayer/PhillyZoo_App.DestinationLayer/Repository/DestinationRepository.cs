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
            var destinations = _phillyZooDatabaseEntities.DestinationObjectLayerSet.Include("MapPointStatusType").Include("DestinationPhotos").Include("DestinationMenu").Include("DestinationEnterExits").AsEnumerable();

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

        public DestinationModel GetDestinationByID(int id)
        {
            DestinationObjectLayer destination = _phillyZooDatabaseEntities.DestinationObjectLayerSet.Include("MapPointStatusType").Include("DestinationPhotos").Include("DestinationMenu").Include("DestinationEnterExits").FirstOrDefault(m => m.id == id);

            if (destination != null)
            {
                DestinationModel destinationModel = _destinationModelFactory.createDestination(destination);
                return destinationModel;
            }
            else
            {
                return null;
            }
        }

        #region Helpers
        public List<DestinationPhotosModel> CreatePhotoList(DestinationObjectLayer destination)
        {
            List<DestinationPhotosModel> photoList = new List<DestinationPhotosModel>();
            foreach (DestinationPhotos photo in destination.DestinationPhotos)
            {
                DestinationPhotosModel photoForList = new DestinationPhotosModel(photo.id, photo.destinationLayerId, photo.imagePath);
                photoList.Add(photoForList);
            }
            return photoList;
        }
        public List<DestinationEnterExitsModel> CreateEnterExitsList(DestinationObjectLayer destination)
        {
            List<DestinationEnterExitsModel> enterExitsList = new List<DestinationEnterExitsModel>();
            foreach (DestinationEnterExists enterExit in destination.DestinationEnterExists)
            {
                DestinationEnterExitsModel enterExitForList = new DestinationEnterExitsModel(enterExit.id, enterExit.destinationLayerId, enterExit.typeId, enterExit.latitude, enterExit.longitude, enterExit.hadicapAccessible);
                enterExitsList.Add(enterExitForList);
            }
            return enterExitsList;
        }
        public List<DestinationMenuModel> CreateMenu(DestinationObjectLayer destination)
        {
            List<DestinationMenuModel> menuList = new List<DestinationMenuModel>();
            foreach (DestinationMenu menuItem in destination.DestinationMenu)
            {
                DestinationMenuModel menuForList = new DestinationMenuModel(menuItem.id, menuItem.destinationLayerId, menuItem.menu);
                menuList.Add(menuForList);
            }
            return menuList;
        }
        public List<DestinationAdditionalFeesModel> CreateAdditionalFees(DestinationObjectLayer destination)
        {
            List<DestinationAdditionalFeesModel> feesList = new List<DestinationAdditionalFeesModel>();
            foreach (DestinationAdditionalFees fee in destination.DestinationAdditionalFees)
            {
                DestinationAdditionalFeesModel feeForList = new DestinationAdditionalFeesModel(fee.additionalFeesId, fee.destinationLayerId, fee.fee, fee.feeName);
                feesList.Add(feeForList);
            }
            return feesList;
        }
        #endregion
    }
}