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
    public class REACTIONsController : Controller
    {
        private GREENWICHEntities db = new GREENWICHEntities();

        // GET: REACTIONs
        public ActionResult Index()
        {
            var rEACTIONs = db.REACTIONs.Include(r => r.IDEA).Include(r => r.USER);
            return View(rEACTIONs.ToList());
        }

        // GET: REACTIONs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REACTION rEACTION = db.REACTIONs.Find(id);
            if (rEACTION == null)
            {
                return HttpNotFound();
            }
            return View(rEACTION);
        }

        // GET: REACTIONs/Create
        public ActionResult Create()
        {
            ViewBag.IDEALID = new SelectList(db.IDEAs, "IDEAID", "AUTHOR");
            ViewBag.USERID = new SelectList(db.USERS, "USERID", "USERNAME");
            return View();
        }

        // POST: REACTIONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REACTIONID,USERID,IDEALID,ACTIVE")] REACTION rEACTION)
        {
            if (ModelState.IsValid)
            {
                db.REACTIONs.Add(rEACTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEALID = new SelectList(db.IDEAs, "IDEAID", "AUTHOR", rEACTION.IDEALID);
            ViewBag.USERID = new SelectList(db.USERS, "USERID", "USERNAME", rEACTION.USERID);
            return View(rEACTION);
        }

        // GET: REACTIONs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REACTION rEACTION = db.REACTIONs.Find(id);
            if (rEACTION == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEALID = new SelectList(db.IDEAs, "IDEAID", "AUTHOR", rEACTION.IDEALID);
            ViewBag.USERID = new SelectList(db.USERS, "USERID", "USERNAME", rEACTION.USERID);
            return View(rEACTION);
        }

        // POST: REACTIONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REACTIONID,USERID,IDEALID,ACTIVE")] REACTION rEACTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEACTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEALID = new SelectList(db.IDEAs, "IDEAID", "AUTHOR", rEACTION.IDEALID);
            ViewBag.USERID = new SelectList(db.USERS, "USERID", "USERNAME", rEACTION.USERID);
            return View(rEACTION);
        }

        // GET: REACTIONs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REACTION rEACTION = db.REACTIONs.Find(id);
            if (rEACTION == null)
            {
                return HttpNotFound();
            }
            return View(rEACTION);
        }

        // POST: REACTIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            REACTION rEACTION = db.REACTIONs.Find(id);
            db.REACTIONs.Remove(rEACTION);
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
