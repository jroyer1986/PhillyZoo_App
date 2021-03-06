﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationPhotosModel
    {
        public int ID
        { get; set; }
        public int DestinationLayerID
        { get; set; }
        public string ImagePath
        { get; set; }

        public DestinationPhotosModel(int id, int destinationLayerId, string imagePath)
        {
            ID = id;
            DestinationLayerID = destinationLayerId;
            ImagePath = imagePath;
        }

        public DestinationPhotosModel() { }
    }
}