﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIdbWithRipo.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InventoryDataContext : DbContext
    {
        public InventoryDataContext()
            : base("name=InventoryDataContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Catagory> Catagories { get; set; }
        public virtual DbSet<contactU> contactUs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Catagory1> Catagories1 { get; set; }
        public virtual DbSet<Product1> Products1 { get; set; }
    }
}