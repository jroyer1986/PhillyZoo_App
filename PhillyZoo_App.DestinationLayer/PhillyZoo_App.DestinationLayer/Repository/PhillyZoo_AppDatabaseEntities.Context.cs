﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class phillyzoo_newEntities : DbContext
    {
        public phillyzoo_newEntities()
            : base("name=phillyzoo_newEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public DbSet<AspNetRoles> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public DbSet<AspNetUsers> AspNetUsers { get; set; }
        public DbSet<Feed> Feed { get; set; }
        public DbSet<Itinerary> Itinerary { get; set; }
        public DbSet<JWTToken> JWTToken { get; set; }
        public DbSet<PushMessage> PushMessage { get; set; }
        public DbSet<Sessions> Sessions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<DestinationEnterExitType> DestinationEnterExitType { get; set; }
        public DbSet<DestinationMenu> DestinationMenu { get; set; }
        public DbSet<DestinationPhotos> DestinationPhotos { get; set; }
        public DbSet<MapPoint> MapPoint { get; set; }
        public DbSet<MapPointEdges> MapPointEdges { get; set; }
        public DbSet<MapPointStatusType> MapPointStatusType { get; set; }
        public DbSet<MapPointType> MapPointType { get; set; }
        public DbSet<PushType> PushType { get; set; }
        public DbSet<User_PushType> User_PushType { get; set; }
        public DbSet<DestinationObjectLayer> DestinationObjectLayerSet { get; set; }
        public DbSet<DestinationEnterExits> DestinationEnterExits { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<DestinationAdditionalFees> DestinationAdditionalFees { get; set; }
    }
}
