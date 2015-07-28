using PhillyZoo_App.DestinationLayer.Models;
using System;
using System.Collections.Generic;
namespace PhillyZoo_App.DestinationLayer.Repository
{
    interface IDestinationRepository
    {
        void DeleteDatabaseDestination(int id);
        DestinationModel GetDestinationByID(int id);
        IEnumerable<DestinationModel> GetDestinations();
        int SaveDatabaseDestination(DestinationModel newDestination);
        IEnumerable<DestinationModel> SearchDestinations(string name);
        void EditDatabaseDestination(DestinationModel editedDestination);
        List<MapPointType> ListOfMapPointTypes();
        List<MapPointStatusType> ListOfMapPointStatusTypes();
        void SavePreviewPathToDatabase(int destinationLayerId, string path);
        void SaveThumbnailPathToDatabase(int destinationLayerId, string path);
        void SaveDatabasePhotos(DestinationPhotosModel photoList);
        void SaveDatabaseMenu(DestinationMenuModel menuList);
        void SaveDatabaseAdditionalFees(DestinationAdditionalFeesModel additionalFeesList);
        void SaveDatabaseEnterExits(DestinationEnterExitsModel enterExitsList);
    }
}
