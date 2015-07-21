using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationEnterExitsModel
    {
        public int ID
        { get; set; }
        public int DestinationLayerID
        { get; set; }
        public int TypeID
        {get; set;}
        public decimal Latitude
        { get; set; }
        public decimal Longitude
        { get; set; }
        public bool IsHandicapAccessible
        { get; set; }

        public DestinationEnterExitsModel(int id, int destinationLayerId, int typeId, decimal latitude, decimal longitude, bool isHandicapAccessible)
        {
            ID = id;
            DestinationLayerID = destinationLayerId;
            TypeID = typeId;
            Latitude = latitude;
            Longitude = longitude;
            IsHandicapAccessible = isHandicapAccessible;
        }

        public DestinationEnterExitsModel() { }
    }
}