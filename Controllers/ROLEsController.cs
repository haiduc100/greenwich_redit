using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GREENWICH.Models;

namespace GREENWICH.Controllers
{
    public class ROLEsController : Controller
    {
        private GREENWICHEntities db = new GREENWICHEntities();

        // GET: ROLEs
        public ActionResult Index()
        {
            return View(db.ROLEs.ToList());
        }

        // GET: ROLEs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLE rOLE = db.ROLEs.Find(id);
            if (rOLE == null)
            {
                return HttpNotFound();
            }
            return View(rOLE);
        }

        // GET: ROLEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ROLEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ROLEID,ROLENAME")] ROLE rOLE)
        {
            if (ModelState.IsValid)
            {
                db.ROLEs.Add(rOLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rOLE);
        }

        // GET: ROLEs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLE rOLE = db.ROLEs.Find(id);
            if (rOLE == null)
            {
                return HttpNotFound();
            }
            return View(rOLE);
        }

        // POST: ROLEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ROLEID,ROLENAME")] ROLE rOLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rOLE);
        }

        // GET: ROLEs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROLE rOLE = db.ROLEs.Find(id);
            if (rOLE == null)
            {
                return HttpNotFound();
            }
            return View(rOLE);
        }

        // POST: ROLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ROLE rOLE = db.ROLEs.Find(id);
            db.ROLEs.Remove(rOLE);
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
