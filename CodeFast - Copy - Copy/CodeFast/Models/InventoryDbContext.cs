using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using CodeFast.Migrations;

namespace CodeFast.Models
{
    public class InventoryDbContext:DbContext
    {
        //3 tecnique for config the DB
        //1. No Parameter
        //2. Database name
        //3. using connection string name

        public InventoryDbContext() : base("name=CFInventoryContext")
        {
            //it will create DB for fast time..but for 2nd time it will give a error
            //1. new CreateDatabaseIfNotExists<InventoryDbContext>();
            //2. new DropCreateDatabaseIfModelChanges<InventoryDbContext>();
            //3. new DropCreateDatabaseAlways<InventoryDbContext>();
            //4. Custom

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<InventoryDbContext>());
            //folowing part is for migration
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InventoryDbContext, Configuration>());
        
        }

     /*   protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Entity Configuration
            modelBuilder.Entity<Category>().ToTable("CategoryTbl")
                                           .HasKey<int>(k => k.CategoryId);


            //Property
            modelBuilder.Entity<Category>().Property(p => p.CategoryId).HasColumnName("CategorySl")
                                                                       .HasColumnOrder(1)
                                                                       .HasColumnType("int")
                                                                       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                                                                       .IsRequired();

            modelBuilder.Entity<Category>().Property(p => p.CategoryName).IsRequired()
                                                                         .HasColumnType("varchar")
                                                                         .HasMaxLength(20);

        }*/
        public DbSet<Product> Products { set; get; }
        public DbSet<Category> Categories { set; get; }
    }
}