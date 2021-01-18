using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogueApp.Models;
namespace CatalogueApp.Service
{
    
    public static class DbInit
    {
        public static void initData(CatalogueDbRepository catalogueDb)
        {
            Console.WriteLine("Data initialisation....");
            catalogueDb.Categories.Add(new Category { Name = "oRDINATEUR" });
            catalogueDb.Categories.Add(new Category { Name = "Imprimante" });
            catalogueDb.Categories.Add(new Category { Name = "souris" });

            catalogueDb.Products.Add(new Product { Name = "Ord HP 540", Price = 650.8, CategorieID=1 });
            catalogueDb.Products.Add(new Product { Name = "Ord dell ", Price = 452, CategorieID = 2 });
            catalogueDb.Products.Add(new Product { Name = "Ord assus ", Price = 771, CategorieID = 3 });

            catalogueDb.SaveChanges();

        }
    }
}
