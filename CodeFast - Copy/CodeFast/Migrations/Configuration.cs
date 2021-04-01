namespace CodeFast.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CodeFast.Models;


    //**** tools>nuGet PackageManger and Type 'enable-migrations -enableautomaticmigration:$true'

    //follow the step in command for migration steps:
    /*
     * enable-migrations
     * Following command hav to run every time when I changed model class
     * 
     * add-migration InitialDb
     * update-database
     * 
     * update-database -targermigration:QuantityRemoved_Product
     *  above one is for go back to the privious migration
     */


    internal sealed class Configuration : DbMigrationsConfiguration<CodeFast.Models.InventoryDbContext>
    {
        //sealed not gonna me inharit
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true; 
            // ^ it will give access to delete row from DB my Models
            ContextKey = "CodeFast.Models.InventoryDbContext";
        }

        protected override void Seed(CodeFast.Models.InventoryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            List<Category> categories = new List<Category>()
            {
                new Category(){CategoryName="Cloth"},
                new Category() { CategoryName = "Electonics" }
            };


            if (!context.Categories.Any())
            {
                foreach (var catagory in categories)
                {
                    context.Categories.Add(catagory);
                    context.SaveChanges();
                }
            }


        }
    }
}
