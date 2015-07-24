using PhillyZoo_App.DestinationLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PhillyZoo_App.DestinationLayer.Repository
{
    public class DestinationRepository : IDestinationRepository
    {
        phillyzoo_newEntities _phillyZooDatabaseEntities = new phillyzoo_newEntities();
        protected DestinationModelFactory _DestinationModelFactory
        { get; set; }
        

        public IEnumerable<DestinationModel> GetDestinations()
        {
            var destinations = _phillyZooDatabaseEntities.DestinationObjectLayer.Include("MapPointStatusType").Include("DestinationPhotos").Include("DestinationMenu").Include("DestinationEnterExits").AsEnumerable();

            if (destinations != null)
            {
                List<DestinationModel> destinationsForController = new List<DestinationModel>();
                foreach (DestinationObjectLayer destination in destinations)
                {
                    DestinationModel destinationForList = _DestinationModelFactory.createDestination(destination);
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
            DestinationObjectLayer destination = _phillyZooDatabaseEntities.DestinationObjectLayer.Include("MapPointStatusType").Include("DestinationPhotos").Include("DestinationMenu").Include("DestinationEnterExits").FirstOrDefault(m => m.id == id);

            if (destination != null)
            {
                DestinationModel destinationModel = _DestinationModelFactory.createDestination(destination);
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
            var searchedDestination = _phillyZooDatabaseEntities.DestinationObjectLayer.Where(i => i.destinationName.Contains(name));

            //create matching list of movies to be sent back 
            List<DestinationModel> matchingList = new List<DestinationModel>();

            foreach (DestinationObjectLayer dbDestination in searchedDestination)
            {
                DestinationModel matchingDestination = _DestinationModelFactory.createDestination(dbDestination);
                matchingList.Add(matchingDestination);
            }
            return matchingList;
        }

        public int SaveDatabaseDestination(DestinationModel newDestination)
        {
            MapPoint dbMapPoint = new MapPoint();
            dbMapPoint.mapPointId = newDestination.MapPointID;
            dbMapPoint.name = newDestination.Name;
            dbMapPoint.description = newDestination.LongDescription;
            dbMapPoint.latitude = newDestination.Latitude;
            dbMapPoint.longitude = newDestination.Longitude;
            dbMapPoint.mapPointTypeId = newDestination.MapPointTypeID;

            string targetFolder = HttpContext.Current.Server.MapPath("~/TempPreviewThumbs");
            string targetPath1 = Path.Combine(targetFolder, newDestination.PreviewPhoto);
            string targetPath2 = Path.Combine(targetFolder, newDestination.ThumbnailPhoto);
            

            //obsolete columns
            dbMapPoint.imageX = 1;
            dbMapPoint.imageY = 1;

            _phillyZooDatabaseEntities.MapPoint.Add(dbMapPoint);
            _phillyZooDatabaseEntities.SaveChanges();

            DestinationObjectLayer dbDestination = new DestinationObjectLayer();
            dbDestination.id = newDestination.ID;
            dbDestination.mapPointId = dbMapPoint.mapPointId;
            dbDestination.statusTypeId = newDestination.StatusID;
            dbDestination.destinationName = dbMapPoint.name;
            dbDestination.shortDescription = newDestination.ShortDescription;
            dbDestination.longDescription = dbMapPoint.description;
            dbDestination.openingTime = newDestination.OpeningTime;
            dbDestination.closingTime = newDestination.ClosingTime;

            if(newDestination is IMenu)
            {
                IMenu menuItem = (IMenu)newDestination;
                SaveDatabaseMenu(menuItem);
            }

            if(newDestination is IPhotos)
            {
                IPhotos photoItem = (IPhotos)newDestination;
                SaveDatabasePhotos(photoItem);
            }

            if(newDestination is IAdditionalFees)
            {
                IAdditionalFees additionalFeesItem = (IAdditionalFees)newDestination;
                SaveDatabaseAdditionalFees(additionalFeesItem);
            }

            _phillyZooDatabaseEntities.DestinationObjectLayer.Add(dbDestination);
            _phillyZooDatabaseEntities.SaveChanges();
            return dbDestination.id;
        }

        public void DeleteDatabaseDestination(int id)
        {
            DestinationObjectLayer destinationToDelete = _phillyZooDatabaseEntities.DestinationObjectLayer.FirstOrDefault(m => m.id == id);
            
            _phillyZooDatabaseEntities.DestinationObjectLayer.Remove(destinationToDelete);
            _phillyZooDatabaseEntities.SaveChanges();
        }

        public void EditDatabaseDestination(DestinationModel editedDestination)
        {
            DestinationObjectLayer destinationToEdit = _phillyZooDatabaseEntities.DestinationObjectLayer.Include("MapPoint").Include("MapPointStatusType").FirstOrDefault(m => m.id == editedDestination.ID);

            if (destinationToEdit != null)
            {
                destinationToEdit.statusTypeId = editedDestination.StatusID;
                destinationToEdit.destinationName = editedDestination.Name;
                destinationToEdit.shortDescription = editedDestination.ShortDescription;
                destinationToEdit.longDescription = editedDestination.LongDescription;
                destinationToEdit.openingTime = editedDestination.OpeningTime;
                destinationToEdit.closingTime = editedDestination.ClosingTime;

                _phillyZooDatabaseEntities.SaveChanges();
            }
        }

        public List<MapPointType> ListOfMapPointTypes()
        {
            List<MapPointType> listForController = new List<MapPointType>();
            foreach(var mapPointType in _phillyZooDatabaseEntities.MapPointType)
            {
                listForController.Add(mapPointType);
            }
            return listForController;
        }

        public List<MapPointStatusType> ListOfMapPointStatusTypes()
        {
            List<MapPointStatusType> listForController = new List<MapPointStatusType>();
            foreach(var mapPointStatusType in _phillyZooDatabaseEntities.MapPointStatusType)
            {
                listForController.Add(mapPointStatusType);
            }
            return listForController;
        }


        #region Saving Helpers
        public void SaveDatabasePhotos(IPhotos photoList)
        {
            if(photoList != null)
            {
                foreach (DestinationPhotosModel photoModel in photoList.Photos)
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

        public void SaveDatabaseMenu(IMenu menuList)
        {
            if (menuList != null)
            {
                foreach (DestinationMenuModel menuModel in menuList.Menu)
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

        public void SaveDatabaseAdditionalFees(IAdditionalFees additionalFeesList)
        {
            if(additionalFeesList != null)
            {
                foreach(DestinationAdditionalFeesModel feesModel in additionalFeesList.AdditionalFees)
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
        #endregion

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
            foreach (DestinationEnterExits enterExit in destination.DestinationEnterExits)
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

        #region Constructors
        public DestinationRepository()
        {
            _DestinationModelFactory = new DestinationModelFactory(this);
        }
        #endregion
    }
}