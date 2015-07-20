using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models.DestinationLayer.DestinationTypes
{
    public class DestinationExhibitsModel : DestinationModel
    {
        //add photos, entrances and exits
        public List<DestinationPhotosModel> Photos
        { get; set; }
        public List<DestinationEnterExitsModel> EnterExits
        { get; set; }
        
    }
}