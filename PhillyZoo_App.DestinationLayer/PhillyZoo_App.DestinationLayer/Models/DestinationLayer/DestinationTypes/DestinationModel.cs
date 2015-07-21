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
        public string Status
        { get; set; }
        public string ShortDescription
        { get; set; }
        public string LongDescription
        { get; set; }
        public DateTime OpeningTime
        { get; set; }
        public DateTime ClosingTime
        { get; set; }
  
        public DestinationModel(int id, int mapPointId, string name, string status, string shortDescription, string longDescription, DateTime openingTime, DateTime closingTime)
        {
            ID = id;
            MapPointID = mapPointId;
            Name = name;
            Status = status;
            ShortDescription = shortDescription;
            LongDescription = LongDescription;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }

        public DestinationModel() { }
    }
}