using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public interface IMenu
    {
        List<DestinationMenuModel> Menu
        { get; set; }
    }
}