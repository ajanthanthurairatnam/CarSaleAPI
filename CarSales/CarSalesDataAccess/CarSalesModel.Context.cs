﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarSalesEntities : DbContext
    {
        public CarSalesEntities()
            : base("name=CarSalesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<VehicleAdvertisement> VehicleAdvertisements { get; set; }
        public virtual DbSet<ConfigSetting> ConfigSettings { get; set; }
        public virtual DbSet<VehicleBody> VehicleBodies { get; set; }
        public virtual DbSet<VehicleFuel> VehicleFuels { get; set; }
    }
}