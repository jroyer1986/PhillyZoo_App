using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationAdditionalFeesModel
    {
        public int ID
        { get; set; }
        public int DestinationLayerID
        { get; set; }
        public decimal Fee
        { get; set; }
        public string FeeName
        { get; set; }

        public DestinationAdditionalFeesModel(int id, int destinationLayerId, decimal fee, string feeName)
        {
            ID = id;
            DestinationLayerID = destinationLayerId;
            Fee = fee;
            FeeName = feeName;
        }

        public DestinationAdditionalFeesModel() { }
    }
}