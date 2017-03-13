using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NEOOG.Models;

namespace NEOOG.Controllers
{
    public class PlantIndexesController : Controller
    {
        private NEOOGEntities db = new NEOOGEntities();

        // GET: PlantIndexes
        public ActionResult Index()
        {
            return View(db.PlantIndexes.ToList());
        }

        // GET: PlantIndexes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantIndex plantIndex = db.PlantIndexes.Find(id);
            if (plantIndex == null)
            {
                return HttpNotFound();
            }
            return View(plantIndex);
        }

        // GET: PlantIndexes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlantIndexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlantID,PlantName,Information,LinksMore,PhotoSrc")] PlantIndex plantIndex)
        {
            if (ModelState.IsValid)
            {
                db.PlantIndexes.Add(plantIndex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plantIndex);
        }

        // GET: PlantIndexes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantIndex plantIndex = db.PlantIndexes.Find(id);
            if (plantIndex == null)
            {
                return HttpNotFound();
            }
            return View(plantIndex);
        }

        // POST: PlantIndexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlantID,PlantName,Information,LinksMore,PhotoSrc")] PlantIndex plantIndex)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantIndex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plantIndex);
        }

        // GET: PlantIndexes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantIndex plantIndex = db.PlantIndexes.Find(id);
            if (plantIndex == null)
            {
                return HttpNotFound();
            }
            return View(plantIndex);
        }

        // POST: PlantIndexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlantIndex plantIndex = db.PlantIndexes.Find(id);
            db.PlantIndexes.Remove(plantIndex);
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
