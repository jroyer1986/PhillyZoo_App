using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationExhibitsModel : DestinationModel
    {
        //add entrances and exits
        public List<DestinationEnterExitsModel> EnterExits
        { get; set; }
        
        public DestinationExhibitsModel(int id, int mapPointId, string name, int statusId, string shortDescription, string longDescription, DateTime openingTime, DateTime closingTime, List<DestinationPhotosModel> photos, List<DestinationEnterExitsModel> enterExits) : base(id, mapPointId, name, statusId, shortDescription, longDescription, openingTime, closingTime, photos)
        {
            EnterExits = enterExits;
        }
    }
}