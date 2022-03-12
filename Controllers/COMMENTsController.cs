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
    public class COMMENTsController : Controller
    {
        private GREENWICHEntities db = new GREENWICHEntities();

        // GET: COMMENTs
        public ActionResult Index()
        {
            var cOMMENTs = db.COMMENTs.Include(c => c.IDEA).Include(c => c.USER);
            return View(cOMMENTs.ToList());
        }

        // GET: COMMENTs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENT cOMMENT = db.COMMENTs.Find(id);
            if (cOMMENT == null)
            {
                return HttpNotFound();
            }
            return View(cOMMENT);
        }

        // GET: COMMENTs/Create
        public ActionResult Create()
        {
            ViewBag.IDEAID = new SelectList(db.IDEAs, "IDEAID", "AUTHOR");
            ViewBag.REPLYFOR = new SelectList(db.USERS, "USERID", "USERNAME");
            return View();
        }

        // POST: COMMENTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COMMENTID,IDEAID,REPLYFOR,CONTENT,PRIVACY")] COMMENT cOMMENT)
        {
            if (ModelState.IsValid)
            {
                db.COMMENTs.Add(cOMMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEAID = new SelectList(db.IDEAs, "IDEAID", "AUTHOR", cOMMENT.IDEAID);
            ViewBag.REPLYFOR = new SelectList(db.USERS, "USERID", "USERNAME", cOMMENT.REPLYFOR);
            return View(cOMMENT);
        }

        // GET: COMMENTs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENT cOMMENT = db.COMMENTs.Find(id);
            if (cOMMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEAID = new SelectList(db.IDEAs, "IDEAID", "AUTHOR", cOMMENT.IDEAID);
            ViewBag.REPLYFOR = new SelectList(db.USERS, "USERID", "USERNAME", cOMMENT.REPLYFOR);
            return View(cOMMENT);
        }

        // POST: COMMENTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COMMENTID,IDEAID,REPLYFOR,CONTENT,PRIVACY")] COMMENT cOMMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEAID = new SelectList(db.IDEAs, "IDEAID", "AUTHOR", cOMMENT.IDEAID);
            ViewBag.REPLYFOR = new SelectList(db.USERS, "USERID", "USERNAME", cOMMENT.REPLYFOR);
            return View(cOMMENT);
        }

        // GET: COMMENTs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENT cOMMENT = db.COMMENTs.Find(id);
            if (cOMMENT == null)
            {
                return HttpNotFound();
            }
            return View(cOMMENT);
        }

        // POST: COMMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            COMMENT cOMMENT = db.COMMENTs.Find(id);
            db.COMMENTs.Remove(cOMMENT);
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
