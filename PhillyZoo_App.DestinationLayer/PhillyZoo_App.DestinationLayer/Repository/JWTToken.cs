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
    
    public partial class JWTToken
    {
        public int jwttokenId { get; set; }
        public string jwt { get; set; }
        public int userId { get; set; }
        public System.DateTime createdTS { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
