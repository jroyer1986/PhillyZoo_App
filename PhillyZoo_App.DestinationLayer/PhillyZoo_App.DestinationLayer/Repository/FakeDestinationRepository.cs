using PhillyZoo_App.DestinationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Repository
{
    public class FakeDestinationRepository  : IDestinationRepository
    {
        protected DestinationModelFactory _DestinationModelFactory
        { get; set; }


        IEnumerable<DestinationModel> IDestinationRepository.GetDestinations()
        {
            List<DestinationModel> listForController = new List<DestinationModel>();
            for(int i = 1; i <= 5; i++)
            {
                DestinationModel destinationForList = new DestinationModel(i, (i * 100), "Destination " + i, 1, 255, "Short Description " + i, "Long Description " + i, (i *111.111m), (i *111.111m), DateTime.Now, DateTime.Now, "previewPhoto", "thumbnailPhoto");
                listForController.Add(destinationForList);
            }
            return listForController;
        }

        DestinationModel IDestinationRepository.GetDestinationByID(int id)
        {
            DestinationModel destination = new DestinationModel(1, 100, "Destination " + 1, 1, 255, "Short Description 1", "Long Description 1", 111.111m, 111.111m, DateTime.Now, DateTime.Now, "previewPhoto", "thumbnailPhoto");
            return destination;
        }

        IEnumerable<DestinationModel> IDestinationRepository.SearchDestinations(string name)
        {
            List<DestinationModel> listToReturn = new List<DestinationModel>();

            DestinationModel destination1 = new DestinationModel(1, 100, name.ToString(), 1, 255, "Short Description", "Long Description", 111.111m, 111.111m, DateTime.Now, DateTime.Now, "previewPhoto", "thumbnailPhoto");
            listToReturn.Add(destination1);
            DestinationModel destination2 = new DestinationModel(2, 200, name.ToString() + " and more", 1, 255, "Short Description", "Long Description", 333.333m, 333.333m, DateTime.Now, DateTime.Now, "previewPhoto", "thumbnailPhoto");
            listToReturn.Add(destination1);

            return listToReturn;
        }

        int IDestinationRepository.SaveDatabaseDestination(DestinationModel newDestination)
        {
            Console.WriteLine("Saved!");
            return 1;
        }

        void IDestinationRepository.DeleteDatabaseDestination(int id)
        {
            Console.WriteLine("deleted!");
        }

        void IDestinationRepository.EditDatabaseDestination(DestinationModel editedDestination)
        {
            throw new NotImplementedException();
        }

        List<MapPointType> IDestinationRepository.ListOfMapPointTypes()
        {
            List<MapPointType> list = new List<MapPointType>();
            MapPointType newMapPointType1 = new MapPointType();
            newMapPointType1.mapPointTypeId = 251;
            newMapPointType1.type = "NavPoint";
            MapPointType newMapPointType2 = new MapPointType();
            newMapPointType2.mapPointTypeId = 252;
            newMapPointType2.type = "Exhibit";
            MapPointType newMapPointType3 = new MapPointType();
            newMapPointType3.mapPointTypeId = 253;
            newMapPointType3.type = "Zoo360";
            MapPointType newMapPointType4 = new MapPointType();
            newMapPointType4.mapPointTypeId = 254;
            newMapPointType4.type = "Attractions";
            MapPointType newMapPointType5 = new MapPointType();
            newMapPointType5.mapPointTypeId = 255;
            newMapPointType5.type = "Gifts_Souvenirs";
            MapPointType newMapPointType6 = new MapPointType();
            newMapPointType6.mapPointTypeId = 256;
            newMapPointType6.type = "Dining";
            MapPointType newMapPointType7 = new MapPointType();
            newMapPointType7.mapPointTypeId = 257;
            newMapPointType7.type = "Facilities";
            list.Add(newMapPointType1);
            list.Add(newMapPointType2);
            list.Add(newMapPointType3);
            list.Add(newMapPointType4);
            list.Add(newMapPointType5);
            list.Add(newMapPointType6);
            list.Add(newMapPointType7);
            return list;
        }

        List<MapPointStatusType> IDestinationRepository.ListOfMapPointStatusTypes()
        {
            List<MapPointStatusType> list = new List<MapPointStatusType>();
            MapPointStatusType mapPointType1 = new MapPointStatusType();
            mapPointType1.id = 0;
            mapPointType1.status = "Not Applicable";
            MapPointStatusType mapPointType2 = new MapPointStatusType();
            mapPointType2.id = 1;
            mapPointType2.status = "Open";
            MapPointStatusType mapPointType3 = new MapPointStatusType();
            mapPointType3.id = 2;
            mapPointType3.status = "Closed";
            list.Add(mapPointType1);
            list.Add(mapPointType2);
            list.Add(mapPointType3);
            return list;
        }

        void IDestinationRepository.SavePreviewPathToDatabase(int destinationLayerId, string path)
        {
            return;
        }

        void IDestinationRepository.SaveThumbnailPathToDatabase(int destinationLayerId, string path)
        {
            return;
        }
    }
}