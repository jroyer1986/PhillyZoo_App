using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models.DestinationLayer.DestinationTypes
{
    public class DestinationDiningModel : DestinationModel
    {
        //add photos, menu, entrances and exits
        public List<DestinationPhotosModel> Photos
        { get; set; }
        public string Menu
        { get; set; }
        public List<DestinationEnterExitsModel> EnterExits
        { get; set; }

        
    }
}