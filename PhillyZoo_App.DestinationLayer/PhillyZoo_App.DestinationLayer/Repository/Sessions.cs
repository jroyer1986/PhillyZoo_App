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
    
    public partial class Sessions
    {
        public int sessionsId { get; set; }
        public int userId { get; set; }
        public System.DateTime startSessionTS { get; set; }
        public Nullable<System.DateTime> endSessionTS { get; set; }
        public bool active { get; set; }
        public string deviceToken { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
