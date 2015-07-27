using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationThumbModel
    {
        public int ID
        { get; set; }
        public int DestinationLayerID
        { get; set; }
        public string ThumbPath
        { get; set; }

        public DestinationThumbModel(int id, int destinationLayerId, string thumbPath)
        {
            ID = id;
            DestinationLayerID = destinationLayerId;
            ThumbPath = thumbPath;
        }

        public DestinationThumbModel() { }
    }
}