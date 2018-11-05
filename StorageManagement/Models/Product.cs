using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StorageManagement.Models
{
    public class Product
    {
        // ID продукта
        public int Id { get; set; }
        // название продукта
        public string Name { get; set; }
        // единица измерения продукта
        public string Unit { get; set; }
        // количество
        public int Quantity { get; set; }
        // цена
        public int Price { get; set; }
    }
}