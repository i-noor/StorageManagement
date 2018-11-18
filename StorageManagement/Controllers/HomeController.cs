using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StorageManagement.Models;
using System.Net;

namespace StorageManagement.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        // создаем контекст данных
        ProductContext db = new ProductContext();
        public int productsCount = 1;
        public string ajaxCheck;
        public ActionResult Index()
        {  
            var transactions = db.Transactions.Include(p => p.Product);
            IEnumerable<Product> products = db.Products;
            ViewBag.Products = products;
            //if (ajaxCheck == "1") return PartialView("~/Views/Home/Transactions.cshtml");            
            return View(transactions.ToList());
        }       
        [HttpGet]
        public ActionResult Buy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Buy(Transaction transaction)
        {
            // получаем из бд все объекты Product
            IEnumerable<Product> products = db.Products;
            ViewBag.Products = products;
            Product product = new Product();
            transaction.Date = DateTime.Now;
            var productId = transaction.ProductId;
            product = db.Products.Find(productId);
            // передаем все объекты в динамическое свойство Products в ViewBag
            if (transaction.Operation == "Продажа")
            {
                if (transaction.Quantity <= product.Quantity)
                {
                    transaction.Cost = product.Price * transaction.Quantity;
                    product.Quantity = product.Quantity - transaction.Quantity;
                    db.Entry(product).State = EntityState.Modified;    
                }
                else
                {
                    ViewBag.LogText = "Ошибка: Недостаточное количество на складе";
                }
            }
            else
            {
                transaction.Cost = product.Price * 0.5 * transaction.Quantity;
                product.Quantity = product.Quantity + transaction.Quantity;
                db.Entry(product).State = EntityState.Modified;
            }
            // добавляем информацию о покупке в базу данных
            db.Transactions.Add(transaction);
            // сохраняем в бд все изменения
            db.SaveChanges();
            //ajaxCheck = Request.Form["a"];
            //if (true) return PartialView("~/Views/Home/Transactions");
            if (Request.IsAjaxRequest())
                ajaxCheck = "1";                
            return RedirectToAction("Index");
        }

        public ActionResult Transactions(Transaction transaction)
        {
            ViewBag.LogText = "1";
            // получаем из бд все объекты Product
            IEnumerable<Product> products = db.Products;
            ViewBag.Products = products;
            Product product = new Product();
            var productId = transaction.ProductId;
            if (productId == null)
            {
                productsCount = db.Products.Count();
                //Создание объекта для генерации чисел
                do
                {
                    Random rnd = new Random();
                    productId = rnd.Next(1, productsCount+2);
                    product = db.Products.Find(productId);
                } while (product == null);
                transaction.ProductId = productId;
            }
            transaction.Date = DateTime.Now;
            // передаем все объекты в динамическое свойство Products в ViewBag
            if (transaction.Operation == "Продажа")
            {
                if (transaction.Quantity <= product.Quantity)
                {
                    transaction.Cost = product.Price * transaction.Quantity;
                    product.Quantity = product.Quantity - transaction.Quantity;
                    db.Entry(product).State = EntityState.Modified;
                    // добавляем информацию о покупке в базу данных
                    db.Transactions.Add(transaction);
                    // сохраняем в бд все изменения
                    db.SaveChanges();
                }
                else
                {
                    transaction.Operation = "Поступление";
                    transaction.Quantity = 100;
                    product.Quantity = product.Quantity + transaction.Quantity;
                    transaction.Cost = product.Price * 0.5 * transaction.Quantity;
                    db.Entry(product).State = EntityState.Modified;
                    // добавляем информацию о покупке в базу данных
                    db.Transactions.Add(transaction);
                    // сохраняем в бд все изменения
                    db.SaveChanges();
                    ViewBag.LogText = "0";
                }
            }
            else if (transaction.Operation == "Поступление")
            {
                transaction.Cost = product.Price * 0.5 * transaction.Quantity;
                product.Quantity = product.Quantity + transaction.Quantity;
                db.Entry(product).State = EntityState.Modified;
                // добавляем информацию о покупке в базу данных
                db.Transactions.Add(transaction);
                // сохраняем в бд все изменения
                db.SaveChanges();
            } else
            {
                transaction.Cost = product.Price * 0.5 * transaction.Quantity;
                product.Quantity = product.Quantity - transaction.Quantity;
                db.Entry(product).State = EntityState.Modified;
                // добавляем информацию о покупке в базу данных
                db.Transactions.Add(transaction);
                // сохраняем в бд все изменения
                db.SaveChanges();
            }            
            //ajaxCheck = Request.Form["a"];
            //if (true) return PartialView("~/Views/Home/Transactions");            
            var transactions = db.Transactions.Include(p => p.Product);
            return PartialView(transactions.ToList());
        }
    }
}