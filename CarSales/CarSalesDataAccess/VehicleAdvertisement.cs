//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarSalesDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleAdvertisement
    {
        public int Reference_ID { get; set; }
        public string Title { get; set; }
        public string Reference_No { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> BodyType { get; set; }
        public Nullable<int> EngineCapacity { get; set; }
        public Nullable<decimal> AudoMeter { get; set; }
        public Nullable<int> Fuel { get; set; }
        public string Description { get; set; }
    }
}
