using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationModel
    {
        public int ID
        { get; set; }
        public int MapPointID
        { get; set; }
        public string Name
        { get; set; }
        public int StatusID
        { get; set; }
        public int MapPointTypeID
        { get; set; }
        public string ShortDescription
        { get; set; }
        public string LongDescription
        { get; set; }
        public decimal Latitude
        { get; set; }
        public decimal Longitude
        { get; set; }
        public DateTime OpeningTime
        { get; set; }
        public DateTime ClosingTime
        { get; set; }

  
        public DestinationModel(int id, int mapPointId, string name, int statusId, int mapPointTypeId, string shortDescription, string longDescription, decimal latitude, decimal longitude, DateTime openingTime, DateTime closingTime)
        {
            ID = id;
            MapPointID = mapPointId;
            Name = name;
            StatusID = statusId;
            MapPointTypeID = mapPointTypeId;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            Latitude = latitude;
            Longitude = longitude;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }

        public DestinationModel() { }
    }
}