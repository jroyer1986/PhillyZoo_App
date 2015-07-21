using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationAttractionsModel : DestinationModel
    {
        //add additionalFees, entrances and exits
        public List<DestinationEnterExitsModel> EnterExits
        { get; set; }
        public List<DestinationAdditionalFeesModel> AdditionalFees
        { get; set; }


        public DestinationAttractionsModel(int id, int mapPointId, string name, int statusId, string shortDescription, string longDescription, DateTime openingTime, DateTime closingTime, List<DestinationPhotosModel> photos, List<DestinationEnterExitsModel> enterExits, List<DestinationAdditionalFeesModel> additionalFees) : base(id, mapPointId, name, statusId, shortDescription, longDescription, openingTime, closingTime, photos)
        {
            EnterExits = enterExits;
            AdditionalFees = additionalFees;
        }
    }
}