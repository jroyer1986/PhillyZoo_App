using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationMenuModel
    {
        public int ID
        { get; set; }
        public int DestinationLayerID
        { get; set; }
        public string Menu
        { get; set; }

        public DestinationMenuModel(int id, int destinationLayerId, string menu)
        {
            ID = id;
            DestinationLayerID = destinationLayerId;
            Menu = menu;
        }
    }
}