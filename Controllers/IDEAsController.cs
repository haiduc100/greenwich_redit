using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GREENWICH.Models;

namespace GREENWICH.Controllers
{
    public class IDEAsController : Controller
    {
        private GREENWICHEntities db = new GREENWICHEntities();

        // GET: IDEAs
        public ActionResult Index()
        {
            var iDEAs = db.IDEAs.Include(i => i.USER);
            return View(iDEAs.ToList());
        }

        // GET: IDEAs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDEA iDEA = db.IDEAs.Find(id);
            if (iDEA == null)
            {
                return HttpNotFound();
            }
            return View(iDEA);
        }

        // GET: IDEAs/Create
        public ActionResult Create()
        {
            ViewBag.AUTHOR = new SelectList(db.USERS, "USERID", "USERNAME");
            return View();
        }

        // POST: IDEAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEAID,AUTHOR,TITLE,SLUG,CONTENT,FIRSTCLOSUREDATE,FINALCLOSUREDATE,PRIVACY,UPLOAD")] IDEA iDEA)
        {
            if (ModelState.IsValid)
            {
                string FileName = Path.GetFileNameWithoutExtension(iDEA.UploadFile.FileName);
                string FileExtension = Path.GetExtension(iDEA.UploadFile.FileName);
                string UploadPath = "D:/Top-up/Web/GREENWICH/Content/FileUpload";
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                //Its Create complete path to store in server.  
                iDEA.UPLOAD = UploadPath + FileName;

                //To copy and save file into server.  
                iDEA.UploadFile.SaveAs(iDEA.UPLOAD);
                db.IDEAs.Add(iDEA); 
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AUTHOR = new SelectList(db.USERS, "USERID", "USERNAME", iDEA.AUTHOR);
            return View(iDEA);
        }

        // GET: IDEAs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDEA iDEA = db.IDEAs.Find(id);
            if (iDEA == null)
            {
                return HttpNotFound();
            }
            ViewBag.AUTHOR = new SelectList(db.USERS, "USERID", "USERNAME", iDEA.AUTHOR);
            return View(iDEA);
        }

        // POST: IDEAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEAID,AUTHOR,TITLE,SLUG,CONTENT,FIRSTCLOSUREDATE,FINALCLOSUREDATE,PRIVACY,UPLOAD")] IDEA iDEA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iDEA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AUTHOR = new SelectList(db.USERS, "USERID", "USERNAME", iDEA.AUTHOR);
            return View(iDEA);
        }

        // GET: IDEAs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDEA iDEA = db.IDEAs.Find(id);
            if (iDEA == null)
            {
                return HttpNotFound();
            }
            return View(iDEA);
        }

        // POST: IDEAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            IDEA iDEA = db.IDEAs.Find(id);
            db.IDEAs.Remove(iDEA);
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
