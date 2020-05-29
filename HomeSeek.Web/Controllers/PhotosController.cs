using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeSeek.Database;
using HomeSeek.Entities;

namespace HomeSeek.Web.Controllers
{
    public class PhotosController : Controller
    {
        private MyDatabase db = new MyDatabase();

        // GET: Photos
        public ActionResult Index()
        {
            return View(db.Photos.ToList());
        }

        // GET: Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhotoId,PhotoUrl,PrimaryPhoto")] Photo photo, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {

                if (Path.GetExtension(ImageFile.FileName).ToLower() == ".jpg"
                 || Path.GetExtension(ImageFile.FileName).ToLower() == ".png"
                 || Path.GetExtension(ImageFile.FileName).ToLower() == ".jpeg"
                 || Path.GetExtension(ImageFile.FileName).ToLower() == ".gif")
                {


                    string path = Path.Combine(Server.MapPath("~/Content/Images"), Path.GetFileName(ImageFile.FileName));
                    ImageFile.SaveAs(path);
                    ViewBag.UploadStatus = " Η φωτογραφία ανέβηκε επιτυχώς.Μπορείτε να ανεβάσετε και άλλη. Διαφορετικά προχωρήστε στην καταχώρηση του σπιτιού";
                    photo.PhotoUrl = "~/Content/Images/" + ImageFile.FileName;
                    db.Photos.Add(photo);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return Content("Only files jpg , png , jpeg and gif are acceptable. Please try again");
                }
                



            }

            return View(photo);
        }

        // GET: Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotoId,PhotoUrl,PrimaryPhoto")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
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
