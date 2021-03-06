﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FactoryOrganizerWebsite.Models;
using FactoryOrganizerOfficeProgram;

namespace FactoryOrganizerWebsite.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private FolderNames folderNames = new FolderNames();

        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            var exePath = db.FilePathToPrograms
                .Where(x => x.FilePathToProgramID == 1)
                .FirstOrDefault();

            var cellProductPath = db.FilePathToWebsiteInformationForProducts
                .Where(x => x.CustomerName != null)
                .ToList();
                //from u in db.FilePathToWebsiteInformationForProducts
                //                  select new FilePath
                //                  {
                //                      CustomerName = u.CustomerName,
                //                      IsAssignedToCell = u.IsAssignedToCell,
                //                      CellNumber = u.CellNumber,
                //                      ItemNumber = u.ItemNumber
                //                      //WholeFilePath = u.WholeFilePath
                //                  };

            List<Product> products = new List<Product>();
            Product product = new Product();
            string cellPathValue = "";
            string basePath;

            foreach(var path in cellProductPath)
            {
                if(path.IsAssignedToCell == true)
                {
                    cellPathValue = @"\" + folderNames.CellsFolder + @"\" + path.CellNumber + @"\";
                }
                basePath = path.WholeFilePath;
                path.WholeFilePath = basePath + @"\" + folderNames.CustomersFolder + @"\" + path.CustomerName + cellPathValue + folderNames.WebsiteFolder;

                product.Customer = path.CustomerName;
                product.Price = 10.00M;
                product.WholeFilePath = path.WholeFilePath;
                product.CellNumber = path.CellNumber;
                product.ItemNumber = path.ItemNumber;

                var checkProducts = db.Products
                    .Where(x => x.Customer == product.Customer && x.ItemNumber == product.ItemNumber)
                    .FirstOrDefault();
                if (checkProducts == null)
                {
                    db.Products.Add(product);
                }
                //products.Add(product);
            }
            db.SaveChanges();
            //string websiteFilePath = exePath.FilePath + @"\" + folderNames.CustomersFolder;
            //ExternalFile.RetrieveAllFolderNamesInDirectory(websiteFilePath);

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Product product = db.Products.Find(id);
            //if (product == null)
            //{
            //    return HttpNotFound();
            //}
            return View(cellProductPath);//product
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Customer,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Customer,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
