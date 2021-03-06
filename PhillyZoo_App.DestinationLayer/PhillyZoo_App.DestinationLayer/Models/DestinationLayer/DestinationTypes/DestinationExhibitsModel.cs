﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationExhibitsModel : DestinationModel, IPhotos, IEnterExits
    {
        public List<DestinationPhotosModel> Photos
        { get; set; }
        public List<DestinationEnterExitsModel> EnterExits
        { get; set; }


        public DestinationExhibitsModel() { }
        public DestinationExhibitsModel(int id, int mapPointId, string name, int statusId, int mapPointTypeId, string shortDescription, string longDescription, decimal latitude, decimal longitude, DateTime openingTime, DateTime closingTime, string previewPhoto, string thumbnailPhoto, List<DestinationPhotosModel> photos, List<DestinationEnterExitsModel> enterExits)
            : base(id, mapPointId, name, statusId, mapPointTypeId, shortDescription, longDescription, latitude, longitude, openingTime, closingTime, previewPhoto, thumbnailPhoto)
        {
            Photos = photos;
            EnterExits = enterExits;
        }

        
    }
}