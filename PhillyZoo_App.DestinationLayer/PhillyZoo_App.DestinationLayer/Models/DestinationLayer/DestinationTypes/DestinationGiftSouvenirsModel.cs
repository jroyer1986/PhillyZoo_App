using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationGiftSouvenirsModel : DestinationModel, IPhotos
    {
        public List<DestinationPhotosModel> Photos
        { get; set; }
        public override bool HasPhotos
        { get { return Photos != null && Photos.Any(); } }
        //potential for "menu" of wares and products

        public DestinationGiftSouvenirsModel(int id, int mapPointId, string name, int statusId, string shortDescription, string longDescription, DateTime openingTime, DateTime closingTime, List<DestinationPhotosModel> photos, List<DestinationEnterExitsModel> enterExits) : base(id, mapPointId, name, statusId, shortDescription, longDescription, openingTime, closingTime)
        {
            Photos = photos;
        }
    }
}