using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Garage1._7.DataAcessLayer;
using Garage1._7.Models;
using System.Collections.Generic;
using PagedList;
using PagedList.Mvc;

namespace Garage1._7.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private RegisterVehicleContext db = new RegisterVehicleContext();

        // GET: ParkedVehicles
        public ActionResult Index(string searchBy, string search, int? page)
        {

            var vehicles = db.Garage.AsQueryable();

            if (searchBy == "TypeOfVehicle")
            {
                // listsearch
                return View(db.Garage.Where(v => v.TypeOfVehicle.ToString().StartsWith(search) 
                || search == null).ToList().ToPagedList(page ?? 1,3));
            }
            else if (searchBy == "VehicleRegistrationNumber")
            {
                return View(db.Garage.Where(v => v.VehicleRegistrationNumber.StartsWith(search) 
                || search == null).ToList().ToPagedList(page ?? 1,3));
            }
            else if (searchBy == "VehicleBrand")
            {
                return View(db.Garage.Where(v => v.VehicleBrand.StartsWith(search) 
                || search == null).ToList().ToPagedList(page ?? 1,3));
            }
            else
                return View(vehicles.ToList().ToPagedList(page ?? 1,3));

            // Dropdown searchfunction

            // https://www.youtube.com/watch?v=srN56uxw76s

            //SerchString for Paging


            // Ajax Action Methods


        }

        //public PartialViewResult All(int? page)
        //{
        //    List<ParkedVehicle> model = db.Garage.ToList();

        //    model.ToPagedList(page ?? 1, 10);

        //    return PartialView("Index", model);
        //}

        // GET: ParkedVehicles/Details/5
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

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ParkingSlot,TypeOfVehicle,VehicleRegistrationNumber,VehicleBrand,Color,TiresOnVehicle,StartParking")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Garage.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
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
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ParkingSlot,TypeOfVehicle,VehicleRegistrationNumber,VehicleBrand,Color,TiresOnVehicle,StartParking")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
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

        // POST: ParkedVehicles/Delete/5
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
