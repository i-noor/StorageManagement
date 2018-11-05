using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StorageManagement.Models
{
    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            db.Products.Add(new Product { Name = "Яблоки", Unit = "кг", Quantity = 500, Price = 90 });
            db.Products.Add(new Product { Name = "Апельсины", Unit = "кг", Quantity = 350, Price = 85 });
            db.Products.Add(new Product { Name = "Молоко", Unit = "шт", Quantity = 123, Price = 45 });

            base.Seed(db);
        }
    }
}