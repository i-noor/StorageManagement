using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StorageManagement.Models
{
    public class Transaction
    {
        // ID покупки
        public int Id { get; set; }
        // ID продукта
        public int ProductId { get; set; }
        // купленное количество
        public int Quantity { get; set; }
        // стоимость
        public int Cost { get; set; }
        // дата покупки
        public DateTime Date { get; set; }
    }
}