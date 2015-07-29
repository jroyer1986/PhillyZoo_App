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
            var destinations = _phillyZooDatabaseEntities.DestinationObjectLayer.Include("MapPointStatusType").Include("DestinationPhotos").Include("DestinationMenu").Include("DestinationEnterExits").Include("DestinationAdditionalFees").AsEnumerable();

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

            _phillyZooDatabaseEntities.DestinationObjectLayer.Add(dbDestination);
            _phillyZooDatabaseEntities.SaveChanges();

            //if (newDestination is IMenu)
            //{
            //    IMenu menuItem = (IMenu)newDestination;
            //    SaveDatabaseMenu(menuItem);
            //}

            //if (newDestination is IPhotos)
            //{
            //    IPhotos photoItem = (IPhotos)newDestination;
            //    SaveDatabasePhotos(photoItem);
            //}

            //if (newDestination is IAdditionalFees)
            //{
            //    IAdditionalFees additionalFeesItem = (IAdditionalFees)newDestination;
            //    SaveDatabaseAdditionalFees(additionalFeesItem);
            //}

            //if (newDestination is IEnterExits)
            //{
            //    IEnterExits enterExits = (IEnterExits)newDestination;
            //    SaveDatabaseEnterExits(enterExits);
            //}

            return dbDestination.id;
        }

        public void SavePreviewPathToDatabase(int destinationLayerId, string path)
        {
            DestinationObjectLayer destination = _phillyZooDatabaseEntities.DestinationObjectLayer.Include("MapPointStatusType")
                                                                                                    .Include("DestinationPhotos")
                                                                                                    .Include("DestinationMenu")
                                                                                                    .Include("DestinationEnterExits")
                                                                                                    .Include("DestinationPreview")
                                                                                                    .Include("DestinationThumb").FirstOrDefault(m => m.id == destinationLayerId);

            if (destination != null)
            {
                DestinationPreview newPreview = new DestinationPreview();
                newPreview.destinationLayerId = destinationLayerId;
                newPreview.previewPath = path;

                _phillyZooDatabaseEntities.DestinationPreview.Add(newPreview);
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }

        public void SaveThumbnailPathToDatabase(int destinationLayerId, string path)
        {
            DestinationObjectLayer destination = _phillyZooDatabaseEntities.DestinationObjectLayer.Include("MapPointStatusType")
                                                                                                    .Include("DestinationPhotos")
                                                                                                    .Include("DestinationMenu")
                                                                                                    .Include("DestinationEnterExits")
                                                                                                    .Include("DestinationPreview")
                                                                                                    .Include("DestinationThumb")
                                                                                                    .FirstOrDefault(m => m.id == destinationLayerId);

            if (destination != null)
            {
                DestinationThumb newThumb = new DestinationThumb();
                newThumb.destinationLayerId = destinationLayerId;
                newThumb.thumbPath = path;
                _phillyZooDatabaseEntities.DestinationThumb.Add(newThumb);
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }

        public void DeleteDatabaseDestination(int id)
        {
            DestinationObjectLayer destinationToDelete = _phillyZooDatabaseEntities.DestinationObjectLayer.Include("MapPoint").Include("DestinationPhotos").Include("DestinationMenu").Include("DestinationAdditionalFees").Include("DestinationEnterExits").FirstOrDefault(m => m.id == id);

            if (destinationToDelete.DestinationPhotos.Count() != 0)
            {
                DeleteDatabasePhotos(destinationToDelete.id);
            }
            if (destinationToDelete.DestinationMenu.Count() != 0)
            {
                DeleteDatabaseMenu(destinationToDelete.id);
            }
            if (destinationToDelete.DestinationAdditionalFees.Count() != 0)
            {
                DeleteDatabaseAdditionalFees(destinationToDelete.id);
            }
            if (destinationToDelete.DestinationEnterExits.Count() != 0)
            {
                DeleteDatabaseEnterExits(destinationToDelete.id);
            }
            if (destinationToDelete.DestinationPreview.Count() != 0)
            {
                DeleteDatabasePreviewImage(destinationToDelete.id);
            }
            if (destinationToDelete.DestinationThumb.Count() != 0)
            {
                DeleteDatabaseThumbImage(destinationToDelete.id);
            }

            _phillyZooDatabaseEntities.DestinationObjectLayer.Remove(destinationToDelete);
            _phillyZooDatabaseEntities.SaveChanges();
        }

        public void EditDatabaseDestination(DestinationModel editedDestination)
        {
            DestinationObjectLayer destinationToEdit = _phillyZooDatabaseEntities.DestinationObjectLayer.Include("MapPoint")
                                                                                                        .Include("MapPointStatusType")
                                                                                                        .Include("DestinationMenu")
                                                                                                        .Include("DestinationAdditionalFees")
                                                                                                        .Include("DestinationPhotos")
                                                                                                        .Include("DestinationEnterExits")
                                                                                                        .Include("DestinationPreview")
                                                                                                        .Include("DestinationThumb")
                                                                                                        .FirstOrDefault(m => m.id == editedDestination.ID);

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

        #region Deleting Helpers
        public void DeleteDatabasePhotos(int destinationLayerId)
        {
            var databasePhotosToDelete = _phillyZooDatabaseEntities.DestinationPhotos.Where(m => m.destinationLayerId == destinationLayerId);
            if (databasePhotosToDelete != null)
            {
                foreach (var databasePhoto in databasePhotosToDelete)
                {
                    _phillyZooDatabaseEntities.DestinationPhotos.Remove(databasePhoto);
                }
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }
        public void DeleteDatabaseMenu(int destinationLayerId)
        {
            var databaseMenuToDelete = _phillyZooDatabaseEntities.DestinationMenu.Where(m => m.destinationLayerId == destinationLayerId);
            if (databaseMenuToDelete != null)
            {
                foreach (var databaseMenu in databaseMenuToDelete)
                {
                    _phillyZooDatabaseEntities.DestinationMenu.Remove(databaseMenu);
                }
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }
        public void DeleteDatabaseAdditionalFees(int destinationLayerId)
        {
            var databaseAdditionalFeesToDelete = _phillyZooDatabaseEntities.DestinationAdditionalFees.Where(m => m.destinationLayerId == destinationLayerId);
            if (databaseAdditionalFeesToDelete != null)
            {
                foreach (var databaseAdditionalFee in databaseAdditionalFeesToDelete)
                {
                    _phillyZooDatabaseEntities.DestinationAdditionalFees.Remove(databaseAdditionalFee);
                }
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }
        public void DeleteDatabaseEnterExits(int destinationLayerId)
        {
            var databaseEnterExitsToDelete = _phillyZooDatabaseEntities.DestinationEnterExits.Where(m => m.destinationLayerId == destinationLayerId);
            if (databaseEnterExitsToDelete != null)
            {
                foreach (var databaseEnterExit in databaseEnterExitsToDelete)
                {
                    _phillyZooDatabaseEntities.DestinationEnterExits.Remove(databaseEnterExit);
                }
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }
        public void DeleteDatabasePreviewImage(int destinationLayerId)
        {
            var databasePreviewImageToDelete = _phillyZooDatabaseEntities.DestinationPreview.Where(m => m.destinationLayerId == destinationLayerId);
            if (databasePreviewImageToDelete != null)
            {
                foreach (var databasePreview in databasePreviewImageToDelete)
                {
                    _phillyZooDatabaseEntities.DestinationPreview.Remove(databasePreview);
                }
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }
        public void DeleteDatabaseThumbImage(int destinationLayerId)
        {
            var databaseThumbnailToDelete = _phillyZooDatabaseEntities.DestinationThumb.Where(m => m.destinationLayerId == destinationLayerId);
            if (databaseThumbnailToDelete != null)
            {
                foreach (var databaseThumb in databaseThumbnailToDelete)
                {
                    _phillyZooDatabaseEntities.DestinationThumb.Remove(databaseThumb);
                }
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }
        #endregion

        #region Saving Helpers
        public void SaveDatabasePhotos(DestinationPhotosModel photo)
        {
            if(photo != null)
            {  
                DestinationPhotos dbPhoto = new DestinationPhotos();
                dbPhoto.id = photo.ID;
                dbPhoto.destinationLayerId = photo.DestinationLayerID;
                dbPhoto.imagePath = photo.ImagePath;

                _phillyZooDatabaseEntities.DestinationPhotos.Add(dbPhoto);
                
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }

        public void SaveDatabaseMenu(DestinationMenuModel menu)
        {
            if (menu != null)
            {
                DestinationMenu dbMenu = new DestinationMenu();
                dbMenu.id = menu.ID;
                dbMenu.destinationLayerId = menu.DestinationLayerID;
                dbMenu.menu = menu.Menu;

                _phillyZooDatabaseEntities.DestinationMenu.Add(dbMenu);
                
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }

        public void SaveDatabaseAdditionalFees(DestinationAdditionalFeesModel additionalFees)
        {
            if(additionalFees != null)
            {                
                DestinationAdditionalFees dbFee = new DestinationAdditionalFees();
                dbFee.additionalFeesId = additionalFees.ID;
                dbFee.destinationLayerId = additionalFees.DestinationLayerID;
                dbFee.fee = additionalFees.Fee;
                dbFee.feeName = additionalFees.FeeName;

                _phillyZooDatabaseEntities.DestinationAdditionalFees.Add(dbFee);               
                _phillyZooDatabaseEntities.SaveChanges();
            }
        }

        public void SaveDatabaseEnterExits(DestinationEnterExitsModel enterExits)
        {
            if(enterExits != null)
            {
                DestinationEnterExits dbEnterExit = new DestinationEnterExits();
                dbEnterExit.id = enterExits.ID;
                dbEnterExit.destinationLayerId = enterExits.DestinationLayerID;
                dbEnterExit.typeId = enterExits.TypeID;
                dbEnterExit.latitude = enterExits.Latitude;
                dbEnterExit.longitude = enterExits.Longitude;
                dbEnterExit.hadicapAccessible = enterExits.IsHandicapAccessible;

                _phillyZooDatabaseEntities.DestinationEnterExits.Add(dbEnterExit);
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