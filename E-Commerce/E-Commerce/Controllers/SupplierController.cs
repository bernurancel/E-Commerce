using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Entity;

namespace E_Commerce.Controllers
{
    public class SupplierController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Supplier
        public ActionResult Index()
        {
            return RedirectToAction("Product","Home");
        }

        // GET: Supplier/Details/5
   

        // GET: Supplier/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "Id", "Name");
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Image,Price,Stock,CategoryID,BrandID,Slider,IsApproved")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Product", "Home");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "Id", "Name", product.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", product.CategoryID);
            return RedirectToAction("Product", "Home");
        }

        // GET: Supplier/Edit/5
      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
