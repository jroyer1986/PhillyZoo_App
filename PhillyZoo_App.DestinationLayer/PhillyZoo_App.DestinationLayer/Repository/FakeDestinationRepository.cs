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
                DestinationModel destinationForList = new DestinationModel(i, (i * 100), "Destination " + i, 1, 255, "Short Description " + i, "Long Description " + i, (i *111.111m), (i *111.111m), DateTime.Now, DateTime.Now);
                listForController.Add(destinationForList);
            }
            return listForController;
        }

        DestinationModel IDestinationRepository.GetDestinationByID(int id)
        {
            DestinationModel destination = new DestinationModel(1, 100, "Destination " + 1, 1, 255, "Short Description 1", "Long Description 1", 111.111m, 111.111m, DateTime.Now, DateTime.Now);
            return destination;
        }

        IEnumerable<DestinationModel> IDestinationRepository.SearchDestinations(string name)
        {
            List<DestinationModel> listToReturn = new List<DestinationModel>();

            DestinationModel destination1 = new DestinationModel(1, 100, name.ToString(), 1, 255, "Short Description", "Long Description", 111.111m, 111.111m, DateTime.Now, DateTime.Now);
            listToReturn.Add(destination1);
            DestinationModel destination2 = new DestinationModel(2, 200, name.ToString() + " and more", 1, 255, "Short Description", "Long Description", 333.333m, 333.333m, DateTime.Now, DateTime.Now);
            listToReturn.Add(destination1);

            return listToReturn;
        }

        void IDestinationRepository.SaveDatabaseDestination(DestinationModel newDestination)
        {
            throw new NotImplementedException();
        }

        void IDestinationRepository.DeleteDataaseDestination(string name)
        {
            throw new NotImplementedException();
        }
    }
}