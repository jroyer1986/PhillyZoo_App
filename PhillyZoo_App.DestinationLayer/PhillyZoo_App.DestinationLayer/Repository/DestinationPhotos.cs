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
    
    public partial class DestinationPhotos
    {
        public int id { get; set; }
        public int destinationLayerId { get; set; }
        public string imagePath { get; set; }
    
        public virtual DestinationObjectLayer DestinationLayer { get; set; }
    }
}
