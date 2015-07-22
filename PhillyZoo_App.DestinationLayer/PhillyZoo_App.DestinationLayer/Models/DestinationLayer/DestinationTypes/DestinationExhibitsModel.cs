using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationExhibitsModel : DestinationModel, IPhotos
    {
        public List<DestinationPhotosModel> Photos
        { get; set; }
        public List<DestinationEnterExitsModel> EnterExits
        { get; set; }
        public override bool HasPhotos
        { get { return Photos != null && Photos.Any(); } }

        public DestinationExhibitsModel(int id, int mapPointId, string name, int statusId, int mapPointTypeId, string shortDescription, string longDescription, decimal latitude, decimal longitude, DateTime openingTime, DateTime closingTime, List<DestinationPhotosModel> photos, List<DestinationEnterExitsModel> enterExits)
            : base(id, mapPointId, name, statusId, mapPointTypeId, shortDescription, longDescription, latitude, longitude, openingTime, closingTime)
        {
            Photos = photos;
            EnterExits = enterExits;
        }

        
    }
}