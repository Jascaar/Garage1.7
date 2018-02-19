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
using PagedList;
using PagedList.Mvc;

namespace Garage1._7.Controllers
{
   



    public class ParkedVehiclesController : Controller
    {

        public static int Capacity = 35;
        private RegisterVehicleContext db = new RegisterVehicleContext();

        public ActionResult Summary()
        {




            var model = db.Garage.GroupBy(p => p.TypeOfVehicle)
                            .Select(g => new SummaryViewModel
                            {
                                Name = g.Key,
                                Count = g.Count(),
                                SumTires = g.Sum(f => f.TiresOnVehicle),
                                ParkingTime = g.Sum(h => DbFunctions.DiffMinutes(h.StartParking, DateTime.Now)),
                                AccumulatedRevenue = g.Sum(h => DbFunctions.DiffMinutes(h.StartParking, DateTime.Now)*2)
                            }).ToList();



            ;




            return View(model);

            ViewBag.FreeSlots = Capacity - db.Garage.Where(g => (g.ParkingSlot > 0)).Count();
            ViewBag.Capacity = Capacity;

            ViewBag.NumberOfWheels = db.Garage.Sum(g => g.TiresOnVehicle);
            ViewBag.Capacity = Capacity;

            return View(model);


        }






        // GET: ParkedVehicles
        public ActionResult Index(string searchBy, string search, int? page, string sortOrder)
        {
            ViewBag.FreeSlots = Capacity - db.Garage.Where(g => (g.ParkingSlot > 0)).Count();
            ViewBag.Capacity = Capacity;
            

            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "ParkingSlot_desc" : "ParkingSlot";
            ViewBag.ParkingSlotSortParm = sortOrder == "ParkingSlot" ? "ParkingSlot_desc" : "ParkingSlot";
            ViewBag.TypeOfVehicleSortParm = sortOrder == "TypeOfVehicle" ? "TypeOfVehicle_desc" : "TypeOfVehicle";
            ViewBag.VehicleRegistrationNumberSortParm = sortOrder == "VehicleRegistrationNumber" ? "VehicleRegistrationNumber_desc" : "VehicleRegistrationNumber";
            ViewBag.VehicleBrandSortParm = sortOrder == "VehicleBrand" ? "VehicleBrand_desc" : "VehicleBrand";
            ViewBag.VehicleModelSortParm = sortOrder == "VehicleModel" ? "VehicleModel_desc" : "VehicleModel";
            ViewBag.ColorSortParm = sortOrder == "Color" ? "Color_desc" : "Color";
            ViewBag.TiresOnVehicleSortParm = sortOrder == "TiresOnVehicle" ? "TiresOnVehicle_desc" : "TiresOnVehicle";
            ViewBag.StartParkingSortParm = sortOrder == "StartParking" ? "StartParking_desc" : "StartParking";

            var vehicles = db.Garage.OrderBy(v => v.ParkingSlot).AsQueryable();

            

            if (searchBy == "TypeOfVehicle")
            {
                // listsearch
                return View(db.Garage.OrderBy(v => v.ParkingSlot).Where(v => v.TypeOfVehicle.ToString().Contains(search)
                || search == null).ToList().ToPagedList(page ?? 1,10));
            }
            else if (searchBy == "VehicleRegistrationNumber")
            {
                return View(db.Garage.OrderBy(v => v.ParkingSlot).Where(v => v.VehicleRegistrationNumber.Contains(search) 
                || search == null).ToList().ToPagedList(page ?? 1,10));
            }
            else if (searchBy == "VehicleBrand")
            {
                return View(db.Garage.OrderBy(v => v.ParkingSlot).Where(v => v.VehicleBrand.Contains(search) 
                || search == null).ToList().ToPagedList(page ?? 1,10));
            }
            else
            { 
            switch (sortOrder)
            {
                case "ParkingSlot_desc":
                    vehicles = vehicles.OrderByDescending(s => s.ParkingSlot);
                    break;
                case "ParkingSlot":
                    vehicles = vehicles.OrderBy(s => s.ParkingSlot);
                    break;
                    case "VehicleRegistrationNumber_desc":
                        vehicles = vehicles.OrderByDescending(s => s.VehicleRegistrationNumber);
                        break;
                    case "VehicleRegistrationNumber":
                        vehicles = vehicles.OrderBy(s => s.VehicleRegistrationNumber);
                        break;

                case "TypeOfVehicle_desc":
                    vehicles = vehicles.OrderByDescending(s => s.TypeOfVehicle);
                    break;
                case "TypeOfVehicle":
                    vehicles = vehicles.OrderBy(s => s.TypeOfVehicle);
                    break;
                    case "VehicleBrand_desc":
                        vehicles = vehicles.OrderByDescending(s => s.VehicleBrand);
                        break;
                    case "VehicleBrand":
                        vehicles = vehicles.OrderBy(s => s.VehicleBrand);
                        break;
                    case "VehicleModel_desc":
                        vehicles = vehicles.OrderByDescending(s => s.VehicleModel);
                        break;
                    case "VehicleModel":
                        vehicles = vehicles.OrderBy(s => s.VehicleModel);
                        break;
                    case "Color_desc":
                        vehicles = vehicles.OrderByDescending(s => s.Color);
                        break;
                    case "Color":
                        vehicles = vehicles.OrderBy(s => s.Color);
                        break;
                    case "TiresOnVehicle_desc":
                        vehicles = vehicles.OrderByDescending(s => s.TiresOnVehicle);
                        break;
                    case "TiresOnVehicle":
                        vehicles = vehicles.OrderBy(s => s.TiresOnVehicle);
                        break;
                    case "StartParking_desc":
                        vehicles = vehicles.OrderByDescending(s => s.StartParking);
                        break;
                    case "StartParking":
                        vehicles = vehicles.OrderBy(s => s.TiresOnVehicle);
                        break;
                        
                    default:
                    vehicles = vehicles.OrderBy(s => s.ParkingSlot);
                    break;
            }

            return View(vehicles.ToList().ToPagedList(page ?? 1,10));
            }

            // Dropdown searchfunction

            // https://www.youtube.com/watch?v=srN56uxw76s

            //SerchString for Paging


            // Ajax Action Methods

  //          var model = db.Garage .OrderBy (e => e.TypeOfVehicle);
    //        return View(model.ToList());
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

            ViewBag.FreeSlots = Capacity - db.Garage.Where(g => (g.ParkingSlot > 0)).Count();
            ViewBag.Capacity = Capacity;

            var model = db.Garage.OrderBy(db => db.ParkingSlot);
            var usedSlots = model.Where(db => (db.ParkingSlot > 0));
            int tester1 = 0;
            int tester2 = 0;
            int tester3 = 0;
            ViewBag.FreeSlot = 0;
            foreach (var item in usedSlots)
            {
                tester2 = item.ParkingSlot;
                if (tester2 - tester1 > 1)
                {
                    ViewBag.FreeSlot = tester2-1;
                    break; }
                tester1++;
                tester3 = item.ParkingSlot;
            }
            if (ViewBag.FreeSlot == 0 && tester3 < Capacity)
                     ViewBag.FreeSlot = tester3 + 1;
            var model2 = new ParkedVehicle { ParkingSlot = ViewBag.FreeSlot };
            

            return View(model2);
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ParkingSlot,TypeOfVehicle,VehicleRegistrationNumber,VehicleBrand,VehicleModel,Color,TiresOnVehicle,StartParking")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Garage.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.FreeSlots = Capacity - db.Garage.Where(g => (g.ParkingSlot > 0)).Count();
            ViewBag.Capacity = Capacity;

            var model = db.Garage.OrderBy(db => db.ParkingSlot);
            var usedSlots = model.Where(db => (db.ParkingSlot > 0));
            int tester1 = 0;
            int tester2 = 0;
            int tester3 = 0;
            ViewBag.FreeSlot = 0;
            foreach (var item in usedSlots)
            {
                tester2 = item.ParkingSlot;
                if (tester2 - tester1 > 1)
                {
                    ViewBag.FreeSlot = tester2 - 1;
                    break;
                }
                tester1++;
                tester3 = item.ParkingSlot;
            }
            if (ViewBag.FreeSlot == 0 && tester3 < Capacity)
                ViewBag.FreeSlot = tester3 + 1;
            var model2 = new ParkedVehicle { ParkingSlot = ViewBag.FreeSlot };

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
        public ActionResult Edit([Bind(Include = "Id,ParkingSlot,TypeOfVehicle,VehicleRegistrationNumber,VehicleBrand,VehicleModel,Color,TiresOnVehicle,StartParking")] ParkedVehicle parkedVehicle)
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

            ViewBag.timeInGarage=Math.Round((DateTime.Now-db.Garage.Find(id).StartParking).TotalHours,2);
            //ViewBag.CurrentCost = Math.Max(Math.Round(ViewBag.timeInGarage*2*60, 0),45);
            ViewBag.CurrentCost = Math.Round(ViewBag.timeInGarage*2*60, 0);
            ViewBag.CurrentPricingModel = "2 SEK/minute";



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
