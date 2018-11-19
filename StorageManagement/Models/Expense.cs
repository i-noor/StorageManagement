using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StorageManagement.Models
{
    public class Expense
    {
        // ID затрат
        public int Id { get; set; }         
        // затраты
        public double Cost { get; set; }
        // дата затраты
        public DateTime Date { get; set; }
    }
}