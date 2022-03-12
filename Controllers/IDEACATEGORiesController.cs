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
    public class IDEACATEGORiesController : Controller
    {
        private GREENWICHEntities db = new GREENWICHEntities();

        // GET: IDEACATEGORies
        public ActionResult Index()
        {
            var iDEACATEGORies = db.IDEACATEGORies.Include(i => i.IDEA).Include(i => i.IDEATAG);
            return View(iDEACATEGORies.ToList());
        }

        // GET: IDEACATEGORies/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDEACATEGORY iDEACATEGORY = db.IDEACATEGORies.Find(id);
            if (iDEACATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(iDEACATEGORY);
        }

        // GET: IDEACATEGORies/Create
        public ActionResult Create()
        {
            ViewBag.IDEAID = new SelectList(db.IDEAs, "IDEAID", "AUTHOR");
            ViewBag.IDEATAGID = new SelectList(db.IDEATAGs, "IDEATAGID", "TITLE");
            return View();
        }

        // POST: IDEACATEGORies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEACATEGORYID,IDEAID,IDEATAGID")] IDEACATEGORY iDEACATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.IDEACATEGORies.Add(iDEACATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEAID = new SelectList(db.IDEAs, "IDEAID", "AUTHOR", iDEACATEGORY.IDEAID);
            ViewBag.IDEATAGID = new SelectList(db.IDEATAGs, "IDEATAGID", "TITLE", iDEACATEGORY.IDEATAGID);
            return View(iDEACATEGORY);
        }

        // GET: IDEACATEGORies/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDEACATEGORY iDEACATEGORY = db.IDEACATEGORies.Find(id);
            if (iDEACATEGORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEAID = new SelectList(db.IDEAs, "IDEAID", "AUTHOR", iDEACATEGORY.IDEAID);
            ViewBag.IDEATAGID = new SelectList(db.IDEATAGs, "IDEATAGID", "TITLE", iDEACATEGORY.IDEATAGID);
            return View(iDEACATEGORY);
        }

        // POST: IDEACATEGORies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEACATEGORYID,IDEAID,IDEATAGID")] IDEACATEGORY iDEACATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iDEACATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEAID = new SelectList(db.IDEAs, "IDEAID", "AUTHOR", iDEACATEGORY.IDEAID);
            ViewBag.IDEATAGID = new SelectList(db.IDEATAGs, "IDEATAGID", "TITLE", iDEACATEGORY.IDEATAGID);
            return View(iDEACATEGORY);
        }

        // GET: IDEACATEGORies/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDEACATEGORY iDEACATEGORY = db.IDEACATEGORies.Find(id);
            if (iDEACATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(iDEACATEGORY);
        }

        // POST: IDEACATEGORies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            IDEACATEGORY iDEACATEGORY = db.IDEACATEGORies.Find(id);
            db.IDEACATEGORies.Remove(iDEACATEGORY);
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
