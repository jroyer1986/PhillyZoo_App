//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhillyZoo_App.DestinationLayer.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class MapPointType
    {
        public MapPointType()
        {
            this.MapPoint = new HashSet<MapPoint>();
        }
    
        public int mapPointTypeId { get; set; }
        public string type { get; set; }
    
        public virtual ICollection<MapPoint> MapPoint { get; set; }
    }
}
