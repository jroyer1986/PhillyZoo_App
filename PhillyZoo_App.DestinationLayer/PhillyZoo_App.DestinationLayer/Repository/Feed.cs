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
    
    public partial class Feed
    {
        public int feedId { get; set; }
        public string url { get; set; }
        public string response { get; set; }
        public int cacheTime { get; set; }
        public System.DateTime createdTS { get; set; }
    }
}
