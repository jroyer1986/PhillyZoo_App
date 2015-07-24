using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public interface IEnterExits
    {
        List<DestinationEnterExitsModel> EnterExits
        { get; set; }
    }
}