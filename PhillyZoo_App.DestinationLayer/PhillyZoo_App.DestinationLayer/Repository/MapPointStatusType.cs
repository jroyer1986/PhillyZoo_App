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
    
    public partial class MapPointStatusType
    {
        public MapPointStatusType()
        {
            this.DestinationObjectLayer = new HashSet<DestinationObjectLayer>();
        }
    
        public int id { get; set; }
        public string status { get; set; }
    
        public virtual ICollection<DestinationObjectLayer> DestinationObjectLayer { get; set; }
    }
}