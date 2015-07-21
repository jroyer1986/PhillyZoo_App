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

        public IEnumerable<DestinationModel> SearchDestinations(string name)
        {
            //get a list of destinations matching by name
            var searchedDestination = _phillyZooDatabaseEntities.DestinationObjectLayerSet.Where(i => i.destinationName.Contains(name));

            //create matching list of movies to be sent back 
            List<DestinationModel> matchingList = new List<DestinationModel>();

            foreach (DestinationObjectLayer dbDestination in searchedDestination)
            {
                DestinationModel matchingDestination = _destinationModelFactory.createDestination(dbDestination);
                matchingList.Add(matchingDestination);
            }
            return matchingList;
        }

        public int CreateDatabaseDestination(DestinationModel newDestination)
        {
            DestinationObjectLayer dbDestination = new DestinationObjectLayer();
            dbDestination.id = newDestination.ID;
            dbDestination.mapPointId = newDestination.MapPointID;
            dbDestination.statusTypeId = newDestination.StatusID;
            dbDestination.destinationName = newDestination.Name;
            dbDestination.shortDescription = newDestination.ShortDescription;
            dbDestination.longDescription = newDestination.LongDescription;
            dbDestination.openingTime = newDestination.OpeningTime;
            dbDestination.closingTime = newDestination.ClosingTime;

            _phillyZooDatabaseEntities.DestinationObjectLayerSet.Add(dbDestination);
            _phillyZooDatabaseEntities.SaveChanges();

            return newDestination.ID;
        }

        public void CreateDatabasePhotos(List<DestinationPhotosModel> photoList)
        {
            if(photoList != null)
            {
                foreach (DestinationPhotosModel photoModel in photoList)
                {
                    DestinationPhotos dbPhoto = new DestinationPhotos();
                    dbPhoto.id = photoModel.ID;
                    dbPhoto.destinationLayerId = photoModel.DestinationLayerID;
                    dbPhoto.imagePath = photoModel.ImagePath;

                    _phillyZooDatabaseEntities.DestinationPhotos.Add(dbPhoto);
                }
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }

        public void CreateDatabaseMenu(List<DestinationMenuModel> menuList)
        {
            if (menuList != null)
            {
                foreach (DestinationMenuModel menuModel in menuList)
                {
                    DestinationMenu dbMenu = new DestinationMenu();
                    dbMenu.id = menuModel.ID;
                    dbMenu.destinationLayerId = menuModel.DestinationLayerID;
                    dbMenu.menu = menuModel.Menu;

                    _phillyZooDatabaseEntities.DestinationMenu.Add(dbMenu);
                }
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }

        public void CreateDatabaseAdditionalFees(List<DestinationAdditionalFeesModel> additionalFeesList)
        {
            if(additionalFeesList != null)
            {
                foreach(DestinationAdditionalFeesModel feesModel in additionalFeesList)
                {
                    DestinationAdditionalFees dbFee = new DestinationAdditionalFees();
                    dbFee.additionalFeesId = feesModel.ID;
                    dbFee.destinationLayerId = feesModel.DestinationLayerID;
                    dbFee.fee = feesModel.Fee;
                    dbFee.feeName = feesModel.FeeName;

                    _phillyZooDatabaseEntities.DestinationAdditionalFees.Add(dbFee);
                }
                _phillyZooDatabaseEntities.SaveChanges();
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