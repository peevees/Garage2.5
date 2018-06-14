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
    public class MembersController : Controller
    {
        private Garage2_5Context db = new Garage2_5Context();
        private List<Members> empty = new List<Members>();

        // GET: Members
        public ActionResult Index(string a, string b)
        {
            switch (a)
            {
                case "Id":
                    if (db.Members.Where(i => i.Id.ToString() == b).ToList().Count() > 0)
                    {
                        return View(db.Members.Where(i => i.Id.ToString() == b).ToList());
                    }
                    else
                    {
                        ViewBag.output = ($".... {b} couldn't be found....");
                        return View(empty);
                    }
                case "Name":
                    if (db.Members.Where(i => i.Name.ToString().Contains(b)).ToList().Count() > 0)
                    {
                        return View(db.Members.Where(i => i.Name.ToString().ToLower().Contains(b.ToLower())).ToList());
                    }
                    else
                    {
                        ViewBag.output = ($".... {b} couldn't be found....");
                        return View(empty);
                    }
                default:
                    if (a == null && b == null)
                    { return View(db.Members.ToList()); }
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

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PhoneNumber,Address,Email")] Members members)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(members);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(members);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PhoneNumber,Address,Email")] Members members)
        {
            if (ModelState.IsValid)
            {
                db.Entry(members).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(members);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Members members = db.Members.Find(id);
            db.Members.Remove(members);
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
