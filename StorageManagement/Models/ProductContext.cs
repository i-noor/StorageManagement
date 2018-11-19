using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;

namespace StorageManagement.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}