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
        public string ShortDescription
        { get; set; }
        public string LongDescription
        { get; set; }
        public DateTime OpeningTime
        { get; set; }
        public DateTime ClosingTime
        { get; set; }
        public List<DestinationPhotosModel> Photos
        { get; set; }
  
        public DestinationModel(int id, int mapPointId, string name, int statusId, string shortDescription, string longDescription, DateTime openingTime, DateTime closingTime, List<DestinationPhotosModel> photos)
        {
            ID = id;
            MapPointID = mapPointId;
            Name = name;
            StatusID = statusId;
            ShortDescription = shortDescription;
            LongDescription = LongDescription;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
            Photos = photos;
        }

        public DestinationModel() { }
    }
}