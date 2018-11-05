using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StorageManagement.Models;

namespace StorageManagement.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        ProductContext db = new ProductContext();
        
        public ActionResult Index()
        {            
            return View();
        }
        public ActionResult Positions()
        {
            // получаем из бд все объекты Book
            IEnumerable<Product> products = db.Products;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Products = products;
            // возвращаем представление
            return View();
        }
        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = db.Products.Find(id);
            if (product != null)
            {
                return View(product);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Positions");
        }
        [HttpGet]
        public ActionResult Buy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Buy(Transaction transaction)
        {
            // получаем из бд все объекты Book
            IEnumerable<Product> products = db.Products;
            var soldProductId = transaction.ProductId-1;
            var soldProduct = products.ElementAt(soldProductId);
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Products = products;
            transaction.Date = DateTime.Now;
            transaction.Cost = soldProduct.Price * transaction.Quantity;
            // добавляем информацию о покупке в базу данных
            db.Transactions.Add(transaction);
            // сохраняем в бд все изменения
            db.SaveChanges();            
            ViewBag.LogText = "Транзакция №" + transaction.Id + " Куплен продукт " + soldProduct.Name + " " + transaction.Quantity + soldProduct.Unit + " по цене "+ soldProduct.Price + "; Стоимость = " + transaction.Cost;
            return View("~/Views/Home/Index.cshtml");
        }
    }
}