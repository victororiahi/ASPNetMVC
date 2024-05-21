using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNetMVC.Web.Data;
using ASPNetMVC.Web.Models;
using ASPNetMVC.Web.Entities;

namespace ASPNetMVC.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult Index()
        {
            var Db = new SampleDbContext();
            var products = Db.Products.ToList();

            return View(products);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            var Db = new SampleDbContext();
            product.Category = Db.Categories.Find(product.SelectedCategoryId);
            Db.Products.Add(product);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            var Db = new SampleDbContext();
            var categories = Db.Categories.ToList();
            var product = new Product();
            product.Categories = categories.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var Db = new SampleDbContext();
            var product = Db.Products.Find(Id);
            var categories = Db.Categories.ToList();
            if (product == null)
            {
                return HttpNotFound();
            }
            product.SelectedCategoryId = product.Category==null ? 0 : product.Category.Id;
            product.Categories = categories.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product) 
        {
            var Db = new SampleDbContext();
            var Dbproduct = Db.Products.Find(product.Id);
            if (Dbproduct == null)
            {
                return HttpNotFound();
            }
            var Dbcategory = Db.Categories.Find(product.SelectedCategoryId);
            if (Dbcategory == null)
            {
                return HttpNotFound();
            }
            Dbproduct.Name= product.Name;
            Dbproduct.Quantity = product.Quantity;
            Dbproduct.Color = product.Color;
            Dbproduct.Description = product.Description;
            Dbproduct.UnitPrice = product.UnitPrice;
            Dbproduct.Category = Dbcategory;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    }