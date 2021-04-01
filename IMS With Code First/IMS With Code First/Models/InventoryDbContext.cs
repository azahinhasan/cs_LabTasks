using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace IMS_With_Code_First.Models
{
    public class InventoryDbContext:DbContext
    {
        //1. No Parameter
        //2. Database name
        //3. using connection string name

        public InventoryDbContext():base("name=CFInventoryContext")
        {
            //1. new CreateDatabaseIfNotExists<InventoryDbContext>();
            //2. new DropCreateDatabaseIfModelChanges<InventoryDbContext>();
            //3. new DropCreateDatabaseAlways<InventoryDbContext>();
            //4. Custom

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<InventoryDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
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
                                           
        }

        public DbSet<Product> Products { set; get; }
        public DbSet<Category> Categories { set; get; }
    }
}