using System;
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
    public class FilePathToWebsiteInformationForProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private FolderNames folderNames = new FolderNames();

        // GET: FilePathToWebsiteInformationForProduct
        public ActionResult Index()
        {
            string websiteImagePath = @"\Content\Images";
            string baseImageFilePath = "";
            string exePath = @"C:\Users\Andross\Desktop\school_projects\C#\FactoryOrganizerWebsiteAndSolution\FactoryOrganizerWebsite";
            exePath += websiteImagePath;

            string description;

            ExternalFile.RemoveAllFilesFromFolder(exePath);

            foreach (var item in db.FilePathToWebsiteInformationForProducts.ToList())
            {
                try
                {
                    baseImageFilePath = item.WholeFilePath;
                    ExternalFile.CopyFileForWebsite(exePath + @"\" + item.ItemNumber + ".png", item.WholeFilePath + @"\" + "Image.png");
                }
                catch
                {

                }
                try
                {
                    ExternalFile.CopyFileForWebsite(exePath + @"\" + item.ItemNumber + ".txt", item.WholeFilePath + @"\" + "Description.txt");
                    description = System.IO.File.ReadAllText(baseImageFilePath + @"\" + "Description.txt");
                    item.CellNumber = description;
                }
                catch
                {

                }
                item.WholeFilePath = websiteImagePath;
            }

            return View(db.FilePathToWebsiteInformationForProducts.ToList());
        }

        // GET: FilePathToWebsiteInformationForProduct/Details/5


        // GET: FilePathToWebsiteInformationForProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilePathToWebsiteInformationForProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilePathToWebsiteInformationForProductID,CustomerName,ItemNumber,IsAssignedToCell,CellNumber,WholeFilePath")] FilePathToWebsiteInformationForProduct filePathToWebsiteInformationForProduct)
        {
            if (ModelState.IsValid)
            {
                db.FilePathToWebsiteInformationForProducts.Add(filePathToWebsiteInformationForProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filePathToWebsiteInformationForProduct);
        }

        // GET: FilePathToWebsiteInformationForProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilePathToWebsiteInformationForProduct filePathToWebsiteInformationForProduct = db.FilePathToWebsiteInformationForProducts.Find(id);
            if (filePathToWebsiteInformationForProduct == null)
            {
                return HttpNotFound();
            }
            return View(filePathToWebsiteInformationForProduct);
        }

        // POST: FilePathToWebsiteInformationForProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilePathToWebsiteInformationForProductID,CustomerName,ItemNumber,IsAssignedToCell,CellNumber,WholeFilePath")] FilePathToWebsiteInformationForProduct filePathToWebsiteInformationForProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filePathToWebsiteInformationForProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filePathToWebsiteInformationForProduct);
        }

        // GET: FilePathToWebsiteInformationForProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilePathToWebsiteInformationForProduct filePathToWebsiteInformationForProduct = db.FilePathToWebsiteInformationForProducts.Find(id);
            if (filePathToWebsiteInformationForProduct == null)
            {
                return HttpNotFound();
            }
            return View(filePathToWebsiteInformationForProduct);
        }

        // POST: FilePathToWebsiteInformationForProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FilePathToWebsiteInformationForProduct filePathToWebsiteInformationForProduct = db.FilePathToWebsiteInformationForProducts.Find(id);
            db.FilePathToWebsiteInformationForProducts.Remove(filePathToWebsiteInformationForProduct);
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

        public ActionResult PurchaseProduct(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var product = db.FilePathToWebsiteInformationForProducts
                .Where(r => r.FilePathToWebsiteInformationForProductID == id)
                .FirstOrDefault();

            return View(product);
        }

        public ActionResult PaymentSuccessful(string stripeEmail, string stripeToken, int? id)
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
    }
}
