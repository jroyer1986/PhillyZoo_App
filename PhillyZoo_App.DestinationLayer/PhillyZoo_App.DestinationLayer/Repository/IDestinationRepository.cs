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
        void SaveDatabaseDestination(DestinationModel newDestination);
        IEnumerable<DestinationModel> SearchDestinations(string name);
        void EditDatabaseDestination(DestinationModel editedDestination);
        List<MapPointType> ListOfMapPointTypes();
        List<MapPointStatusType> ListOfMapPointStatusTypes();
    }
}
