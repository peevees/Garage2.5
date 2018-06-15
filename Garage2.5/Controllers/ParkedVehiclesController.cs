using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2._5.Models;

namespace Garage2._5.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private Garage2_5Context db = new Garage2_5Context();


        private List<ParkedVehicles> empty = new List<ParkedVehicles>();

        // GET: Members
        public ActionResult Index(string a, string b)
        {
            var parkedVehicles = db.ParkedVehicles.Include(e => e.Type).Include(e => e.Member);
            switch (a)
            {
                case "RegistrationNumber":
                    if (parkedVehicles.Where(i => i.RegistrationNumber.ToString().Contains(b)).ToList().Count() > 0)
                    {
                        return View(parkedVehicles.Where(i => i.RegistrationNumber.ToString() == b).ToList());
                    }
                    else
                    {
                        ViewBag.output = ($".... {b} couldn't be found....");
                        return View(empty);
                    }


                case "Type":
                    if (parkedVehicles.Where(i => i.Type.TypeName.ToString().Contains(b)).ToList().Count() > 0)
                    {
                        return View(parkedVehicles.Where(i => i.Type.TypeName.ToString().ToLower().Contains(b.ToLower())).ToList());
                    }
                    else
                    {
                        ViewBag.output = ($".... {b} couldn't be found....");
                        return View(empty);
                    }

                default:
                    if (a == null && b == null)
                    { return View(parkedVehicles.ToList()); }
                    else if (a == null || b == null)
                    {
                        ViewBag.output = ("....Please select a filter and write an input....");
                        return View(empty);
                    }
                    else
                    {
                        ViewBag.output = ("....The garage is empty....");
                        return View(empty);
                    }
            }
        }

        [HttpPost, ActionName("Search")]
        [ValidateAntiForgeryToken]
        public ActionResult SearchConfirmed(string filter, string Search)
        {

            return RedirectToAction("Index", new { a = filter, b = Search });
        }
        // GET: ParkedVehicles
        public ActionResult Overview(string a, string b)
        {
            var parkedVehicles = db.ParkedVehicles.Include(e => e.Type).Include(e => e.Member);
            switch (a)
            {
                case "RegistrationNumber":
                    if (parkedVehicles.Where(i => i.RegistrationNumber.ToString().Contains(b)).ToList().Count() > 0)
                    {
                        return View(parkedVehicles.Where(i => i.RegistrationNumber.ToString() == b).ToList());
                    }
                    else
                    {
                        ViewBag.output = ($".... {b} couldn't be found....");
                        return View(empty);
                    }


                case "Type":
                    if (parkedVehicles.Where(i => i.Type.TypeName.ToString().Contains(b)).ToList().Count() > 0)
                    {
                        return View(parkedVehicles.Where(i => i.Type.TypeName.ToString().ToLower().Contains(b.ToLower())).ToList());
                    }
                    else
                    {
                        ViewBag.output = ($".... {b} couldn't be found....");
                        return View(empty);
                    }

                default:
                    if (a == null && b == null)
                    { return View(parkedVehicles.ToList()); }
                    else if (a == null || b == null)
                    {
                        ViewBag.output = ("....Please select a filter and write an input....");
                        return View(empty);
                    }
                    else
                    {
                        ViewBag.output = ("....The garage is empty....");
                        return View(empty);
                    }
            }
        }

        [HttpPost, ActionName("searchOverview")]
        [ValidateAntiForgeryToken]
        public ActionResult SearchConfirmedOverview(string filter, string search)
        {

            return RedirectToAction("Index", new { a = filter, b = search });
        }


        public ActionResult Receipt(ParkedVehicles vehicles)
        {

            DateTime checkOut = GenerateTime();
            TimeSpan parkedTime = checkOut.Subtract(vehicles.CheckIn);
            var TotalTime = parkedTime.ToString(@"d\.h\:mm");

            double parkedTimeInMinutes = parkedTime.TotalMinutes;
            //var hour = Math.Floor(parkedTimeInMinutes / 60);
            //var Minute = Math.Ceiling(parkedTimeInMinutes - (hour * 60));
            var Price = (float)Math.Ceiling(parkedTimeInMinutes * 10);

            ViewBag.checkOut = checkOut;
            ViewBag.totalTime = TotalTime;
            ViewBag.price = Price;
            ViewBag.name = db.Members.Find(vehicles.MemberId).Name;
            return View(vehicles);
        }

        [HttpPost, ActionName("Receipt")]
        [ValidateAntiForgeryToken]
        public ActionResult ReceiptConfirmed()
        {
            return RedirectToAction("Index");
        }




        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicles parkedVehicles = db.ParkedVehicles.Find(id);
            if (parkedVehicles == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicles);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
			var model = new CreateViewmodel() { Types = db.VehicleTypes, Members = db.Members };
            //ViewBag.TypeId = new SelectList(db.VehicleTypes, "Id", "TypeName");
            //ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");
            return View(model);
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationNumber,Color,Brand,TypeId,MemberId")] ParkedVehicles parkedVehicles)
        {
            if (ModelState.IsValid)
            {
                parkedVehicles.CheckIn = GenerateTime();
                db.ParkedVehicles.Add(parkedVehicles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			var model = new CreateViewmodel() { Types = db.VehicleTypes, Members = db.Members };
			//ViewBag.TypeId = new SelectList(db.VehicleTypes, "Id", "TypeName");
			//ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");
			return View(model);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicles parkedVehicles = db.ParkedVehicles.Find(id);
            if (parkedVehicles == null)
            {
                return HttpNotFound();
            }
            //ViewBag.TypeId = new SelectList(db.VehicleTypes, "Id", "TypeName",parkedVehicles.TypeId);
            //ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", parkedVehicles.MemberId);
            return View(parkedVehicles);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationNumber,Color,Brand,TypeId,MemberId,CheckIn")] ParkedVehicles parkedVehicles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.TypeId = new SelectList(db.VehicleTypes, "Id", "TypeName", parkedVehicles.TypeId);
			ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", parkedVehicles.MemberId);
			return View(parkedVehicles);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicles parkedVehicles = db.ParkedVehicles.Find(id);
            if (parkedVehicles == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicles);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicles parkedVehicles = db.ParkedVehicles.Find(id);
            db.ParkedVehicles.Remove(parkedVehicles);
            db.SaveChanges();
            return RedirectToAction("Receipt", parkedVehicles);
        }
        public DateTime GenerateTime()
        {
           return DateTime.Now;
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
