using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationAttractionsModel : DestinationModel, IPhotos, IAdditionalFees
    {
        //add additionalFees, entrances and exits
        public List<DestinationPhotosModel> Photos
        { get; set; }
        public List<DestinationEnterExitsModel> EnterExits
        { get; set; }
        public List<DestinationAdditionalFeesModel> AdditionalFees
        { get; set; }       

        public DestinationAttractionsModel() { }
        public DestinationAttractionsModel(int id, int mapPointId, string name, int statusId, int mapPointTypeId, string shortDescription, string longDescription, decimal latitude, decimal longitude, DateTime openingTime, DateTime closingTime, string previewPhoto, string thumbnailPhoto, List<DestinationPhotosModel> photos, List<DestinationEnterExitsModel> enterExits, List<DestinationAdditionalFeesModel> additionalFees)
            : base(id, mapPointId, name, statusId, mapPointTypeId, shortDescription, longDescription, latitude, longitude, openingTime, closingTime, previewPhoto, thumbnailPhoto)
        {
            Photos = photos;
            EnterExits = enterExits;
            AdditionalFees = additionalFees;
        }
    }
}