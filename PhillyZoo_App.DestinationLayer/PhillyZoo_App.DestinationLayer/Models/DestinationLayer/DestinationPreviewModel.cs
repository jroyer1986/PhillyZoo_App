using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationPreviewModel
    {
        public int ID
        { get; set; }
        public int DestinationLayerID
        { get; set; }
        public string PreviewPath
        { get; set; }

        public DestinationPreviewModel(int id, int destinationLayerId, string previewPath)
        {
            ID = id;
            DestinationLayerID = destinationLayerId;
            PreviewPath = previewPath;
        }

        public DestinationPreviewModel() { }
    }
}