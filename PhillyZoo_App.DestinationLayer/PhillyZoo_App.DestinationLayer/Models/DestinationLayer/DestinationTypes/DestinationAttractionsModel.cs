using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationAttractionsModel : DestinationModel
    {
        //add photos, additionalFees, entrances and exits
        public List<DestinationPhotosModel> Photos
        { get; set; }
        public List<DestinationEnterExitsModel> EnterExits
        { get; set; }
        public string AdditionalFees
        { get; set; }



        public DestinationAttractionsModel() : base() { }
    }
}