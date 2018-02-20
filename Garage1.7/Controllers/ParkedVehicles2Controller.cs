using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage1._7.DataAcessLayer;
using Garage1._7.Models;

namespace Garage1._7.Controllers
{
    public class ParkedVehicles2Controller : Controller
    {
        private RegisterVehicleContext db = new RegisterVehicleContext();

        // GET: ParkedVehicles2
        public ActionResult Index()
        {
            var garage = db.Garage.Include(p => p.Member);
            return View(garage.ToList());
        }

        // GET: ParkedVehicles2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.Garage.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles2/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "SSN");
            return View();
        }

        // POST: ParkedVehicles2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberId,ParkingSlot,TypeOfVehicle,VehicleRegistrationNumber,VehicleBrand,VehicleModel,Color,TiresOnVehicle,StartParking")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Garage.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "SSN", parkedVehicle.MemberId);
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.Garage.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "SSN", parkedVehicle.MemberId);
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberId,ParkingSlot,TypeOfVehicle,VehicleRegistrationNumber,VehicleBrand,VehicleModel,Color,TiresOnVehicle,StartParking")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "SSN", parkedVehicle.MemberId);
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.Garage.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.Garage.Find(id);
            db.Garage.Remove(parkedVehicle);
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
