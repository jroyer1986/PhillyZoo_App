using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public interface IAdditionalFees
    {
        List<DestinationAdditionalFeesModel> AdditionalFees
        { get; set; }
    }
}