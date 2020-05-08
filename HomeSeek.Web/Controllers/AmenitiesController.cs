using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeSeek.Database;
using HomeSeek.Entities;

namespace HomeSeek.Web.Controllers
{
    public class AmenitiesController : Controller
    {
        private MyDatabase db = new MyDatabase();

        // GET: Amenities
        public ActionResult Index()
        {
            var amenities = db.Amenities.Include(a => a.Place);
            return View(amenities.ToList());
        }

        // GET: Amenities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amenities amenities = db.Amenities.Find(id);
            if (amenities == null)
            {
                return HttpNotFound();
            }
            return View(amenities);
        }

        // GET: Amenities/Create
        public ActionResult Create()
        {
            ViewBag.AmenitiesId = new SelectList(db.Places, "PlaceId", "ApartmentName");
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AmenitiesId,Count,Wifi,Heating,Tv,AirConditioning,HotWater,FirstAidKit,Elevator,PrivateΕntrance,FreeParking")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                db.Amenities.Add(amenities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AmenitiesId = new SelectList(db.Places, "PlaceId", "ApartmentName", amenities.AmenitiesId);
            return View(amenities);
        }

        // GET: Amenities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amenities amenities = db.Amenities.Find(id);
            if (amenities == null)
            {
                return HttpNotFound();
            }
            ViewBag.AmenitiesId = new SelectList(db.Places, "PlaceId", "ApartmentName", amenities.AmenitiesId);
            return View(amenities);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AmenitiesId,Count,Wifi,Heating,Tv,AirConditioning,HotWater,FirstAidKit,Elevator,PrivateΕntrance,FreeParking")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amenities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AmenitiesId = new SelectList(db.Places, "PlaceId", "ApartmentName", amenities.AmenitiesId);
            return View(amenities);
        }

        // GET: Amenities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amenities amenities = db.Amenities.Find(id);
            if (amenities == null)
            {
                return HttpNotFound();
            }
            return View(amenities);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Amenities amenities = db.Amenities.Find(id);
            db.Amenities.Remove(amenities);
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
