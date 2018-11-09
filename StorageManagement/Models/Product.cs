using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StorageManagement.Models
{
    public class Product
    {
        // ID продукта        
        public int Id { get; set; }
        // название продукта
        [Required]
        [Display(Name = "Название позиции")]
        public string Name { get; set; }
        // единица измерения продукта
        [Required]
        [Display(Name = "Единица измерения")]
        public string Unit { get; set; }
        // количество
        [Required]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        // цена
        [Required]
        [Display(Name = "Цена")]
        public double Price { get; set; }
    }
}