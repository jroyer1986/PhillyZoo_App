using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationAttractionsModel : DestinationModel, IPhotos
    {
        //add additionalFees, entrances and exits
        public List<DestinationPhotosModel> Photos
        { get; set; }
        public List<DestinationEnterExitsModel> EnterExits
        { get; set; }
        public List<DestinationAdditionalFeesModel> AdditionalFees
        { get; set; }
        public override bool HasAdditionalFees
        { get { return AdditionalFees != null && AdditionalFees.Any(); } }
        public override bool HasPhotos
        { get { return Photos != null && Photos.Any(); } }


        public DestinationAttractionsModel(int id, int mapPointId, string name, int statusId, string shortDescription, string longDescription, DateTime openingTime, DateTime closingTime, List<DestinationPhotosModel> photos, List<DestinationEnterExitsModel> enterExits, List<DestinationAdditionalFeesModel> additionalFees) : base(id, mapPointId, name, statusId, shortDescription, longDescription, openingTime, closingTime)
        {
            Photos = photos;
            EnterExits = enterExits;
            AdditionalFees = additionalFees;
        }
    }
}