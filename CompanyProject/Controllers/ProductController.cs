using CompanyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyProject.Controllers
{
    public class ProductController : Controller
    {
        StoreDbContext dc = new StoreDbContext();
        public ViewResult DisplayProducts()
        {
            dc.Configuration.LazyLoadingEnabled = false;
            var products = dc.Products.Include(P => P.Category);
            return View(products);
        }
        public ViewResult DisplayProduct(int ProductId)
        {
            dc.Configuration.LazyLoadingEnabled = false;
            Product product = dc.Products.Include(P => P.Category).Where(
            P => P.ProductId == ProductId).Single();
            return View(product);
        }
        public ViewResult AddProduct()
        {
            ViewBag.CategoryId = new SelectList(dc.Categories, "CategoryId", "CategoryName");
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public RedirectToRouteResult AddProduct(Product product)
        {
            dc.Products.Add(product);
            dc.SaveChanges();
            return RedirectToAction("DisplayProducts");
        }
        public ViewResult EditProduct(int Id)
        {
            Product product = dc.Products.Find(Id);
           
            ViewBag.CategoryId = new SelectList(dc.Categories, "CategoryId", "CategoryName", product);
            return View(product);
        }
        public RedirectToRouteResult UpdateProduct(Product product)
        {
            dc.Entry(product).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayProducts");
        }
        public RedirectToRouteResult DeleteProduct(int Id)
        {
            Product product = dc.Products.Find(Id);
            dc.Entry(product).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayProducts");
        }
    }
}
