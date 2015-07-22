using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhillyZoo_App.DestinationLayer.Models
{
    public class DestinationDiningModel : DestinationModel, IPhotos, IMenu
    {
        public List<DestinationPhotosModel> Photos
        { get; set; }
        public List<DestinationMenuModel> Menu
        { get; set; }
        public List<DestinationEnterExitsModel> EnterExits
        { get; set; }
        public override bool HasMenu
        { get { return Menu != null && Menu.Any(); } }
        public override bool HasPhotos
        { get { return Photos != null && Photos.Any(); } }

        public DestinationDiningModel(int id, int mapPointId, string name, int statusId, int mapPointTypeId, string shortDescription, string longDescription, decimal latitude, decimal longitude, DateTime openingTime, DateTime closingTime, List<DestinationPhotosModel> photos, List<DestinationMenuModel> menu, List<DestinationEnterExitsModel> enterExits)
            : base(id, mapPointId, name, statusId, mapPointTypeId, shortDescription, longDescription, latitude, longitude, openingTime, closingTime)
        {
            Menu = menu;
            EnterExits = enterExits;
            Photos = photos;
        }
    }
}