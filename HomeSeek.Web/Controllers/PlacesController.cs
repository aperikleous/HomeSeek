using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using HomeSeek.Database;
using HomeSeek.Entities;
using HomeSeek.Repository;

namespace HomeSeek.Web.Controllers
{
    public class PlacesController : Controller
    {
        UnitOfWork db = new UnitOfWork(new MyDatabase());

        //GET: Places
        public ActionResult Index()
        {
            var places = db.Places.GetAll();
            return View(places.ToList());
        }

        // GET: Places/Details/5
        [HandleError]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.GetById(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: Places/Create
        [HandleError]
        public ActionResult Create(int addressId)
        {
            ViewBag.AddressId = addressId;
            ViewBag.AmenitiesId = new SelectList(db.Amenities.GetAll(), "AmenitiesId", "AmenitiesId");
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceId,ApartmentName,Description,Guests,Bedroom,Bathroom,PricePerDay,CleanCost,IsBooked,Created,Modified,AddressId")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Places.Add(place);
                db.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceId = new SelectList(db.Amenities.GetAll(), "AmenitiesId", "AmenitiesId", place.PlaceId);
            return View(place);
        }

        // GET: Places/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.GetById(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceId = new SelectList(db.Amenities.GetAll(), "AmenitiesId", "AmenitiesId", place.PlaceId);
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Edit([Bind(Include = "PlaceId,ApartmentName,Description,Guests,Bedroom,Bathroom,PricePerDay,CleanCost,IsBooked,Created,Modified")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Places.Edit(place);
                db.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceId = new SelectList(db.Amenities.GetAll(), "AmenitiesId", "AmenitiesId", place.PlaceId);
            return View(place);
        }

        // GET: Places/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.GetById(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Places.GetById(id);
            db.Places.Remove(place);
            db.Complete();
            return RedirectToAction("Index");
        }
    }
}
