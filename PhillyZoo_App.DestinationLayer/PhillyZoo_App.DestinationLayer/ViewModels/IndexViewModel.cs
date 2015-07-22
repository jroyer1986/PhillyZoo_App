using PhillyZoo_App.DestinationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<DestinationModel> DestinationsList
        { get; set; }

        public IndexViewModel() { }
        public IndexViewModel(IEnumerable<DestinationModel> destinations)
        {
            DestinationsList = destinations;
        }
    }
}