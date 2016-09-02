﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class WinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wines
        public ActionResult Index()
        {
            var wines = db.Wines.Include(w => w.Winery);
            return View(wines.ToList());
        }

        // GET: Wines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Wine wine = db.Wines.Find(id);

            if (wine == null)
            {
                return HttpNotFound();
            }
            return View(wine);
        }

        // GET: Wines/Create
        public ActionResult Create()
        {
            ViewBag.WineryId = new SelectList(db.Wineries, "WineryId", "Name");
            return View();
        }

        // POST: Wines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WineId,Name,Price,YearOfBottling,AlcoholPercentage,ImagePath,Description,WineType,WineryId")] Wine wine)
        {
            if (ModelState.IsValid)
            {
                db.Wines.Add(wine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WineryId = new SelectList(db.Wineries, "WineryId", "Name", wine.WineryId);
            return View(wine);
        }

        // GET: Wines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return HttpNotFound();
            }
            ViewBag.WineryId = new SelectList(db.Wineries, "WineryId", "Name", wine.WineryId);
            return View(wine);
        }

        // POST: Wines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WineId,Name,Price,YearOfBottling,AlcoholPercentage,ImagePath,Description,WineType,WineryId")] Wine wine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WineryId = new SelectList(db.Wineries, "WineryId", "Name", wine.WineryId);
            return View(wine);
        }

        // GET: Wines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return HttpNotFound();
            }
            return View(wine);
        }

        // POST: Wines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wine wine = db.Wines.Find(id);
            db.Wines.Remove(wine);
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
