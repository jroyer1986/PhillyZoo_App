﻿using PhillyZoo_App.DestinationLayer.Models;
using System;
using System.Collections.Generic;
using System.Web;
namespace PhillyZoo_App.DestinationLayer.Repository
{
    interface IDestinationRepository
    {
        void DeleteDatabaseDestination(int id);
        DestinationModel GetDestinationByID(int id);
        IEnumerable<DestinationModel> GetDestinations();
        int SaveDatabaseDestination(DestinationModel newDestination);
        IEnumerable<DestinationModel> SearchDestinations(string name);
        void EditDatabaseDestination(DestinationModel editedDestination, HttpPostedFileBase previewPhoto, HttpPostedFileBase thumbnailPhoto);
        List<MapPointType> ListOfMapPointTypes();
        List<MapPointStatusType> ListOfMapPointStatusTypes();
        void SavePreviewPathToDatabase(int destinationLayerId, string rootPathForPreview);
        void SaveThumbnailPathToDatabase(int destinationLayerId, string rootPathForThumb);
        void SaveDatabasePhotos(DestinationPhotosModel photoList);
        void SaveDatabaseMenu(DestinationMenuModel menuList);
        void SaveDatabaseAdditionalFees(DestinationAdditionalFeesModel additionalFeesList);
        void SaveDatabaseEnterExits(DestinationEnterExitsModel enterExitsList);
    }
}
