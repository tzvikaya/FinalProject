﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartCalendar.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class zvikaEntities : DbContext
    {
        public zvikaEntities()
            : base("name=zvikaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Sources> Sources { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Users_Sources> Users_Sources { get; set; }
    }
}
