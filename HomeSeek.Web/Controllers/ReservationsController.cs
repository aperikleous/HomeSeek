using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using PayPal.Api;
using System.Web.Mvc;
using HomeSeek.Database;
using HomeSeek.Entities;
using HomeSeek.Repository;
using HomeSeek.Web.Models;

namespace HomeSeek.Web.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        UnitOfWork db = new UnitOfWork(new MyDatabase());

        // GET: Reservations
        public ActionResult Index()
        {
            return View(db.Reservations.GetAll());
        }

        public ActionResult OnApprove()
        {
            return View();
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.GetById(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create(int placeId, DateTime checkin, DateTime checkout)
        {
            var place = db.Places.SingleOrDefault(x => x.PlaceId == placeId);
            var days = (checkout - checkin).Days;
            decimal totalPrice = place.PricePerDay * days + place.CleanCost;
            DateTime receiptDate = DateTime.Now;

            ViewBag.CleanCost = place.CleanCost;
            ViewBag.PricePerDay = place.PricePerDay;

            ViewBag.TotalPrice = totalPrice;
            ViewBag.Checkin = checkin.ToString("dd/MM/yyyy");
            ViewBag.Checkout = checkout.ToString("dd/MM/yyyy");
            ViewBag.DaysOfStaying = days;
            ViewBag.ReservationDate = receiptDate.ToString("dd/MM/yyyy");
            ViewBag.PlaceId = placeId;
            return View();
        }


        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId,CheckInDate,CheckOutDate,DaysOfStaying,PaymentDate,TotalAmount,TotalFees,PlaceId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.Complete();
                return RedirectToAction("Details","Places",new {id=reservation.PlaceId });
            }

            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.GetById(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationId,CheckInDate,CheckOutDate,DaysOfStaying,PaymentDate,TotalAmount,TotalFees")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Edit(reservation);
                db.Complete();
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.GetById(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.GetById(id);
            db.Reservations.Remove(reservation);
            db.Complete();
            return RedirectToAction("Index");
        }

    }
}
