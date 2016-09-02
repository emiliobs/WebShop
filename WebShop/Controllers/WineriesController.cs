using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class WineriesController : Controller
    {
      private  ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wineries
        public ActionResult Index()
        {
            List<Winery> wineries = db.Wineries.OrderBy(w => w.Name).ToList();
            return View(wineries);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Winery winery)
        {

            if (ModelState.IsValid)
            {
                db.Wineries.Add(winery);

                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }

            var wineries = db.Wineries.Find(id);

            if (wineries == null)
            {
                return HttpNotFound();
            }

            return View(wineries);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Winery winery)
        {
            if (ModelState.IsValid)
            {
                db.Wineries.AddOrUpdate(winery);

                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return View(winery);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id== null)
            {
                return HttpNotFound();
            }

            var winery = db.Wineries.Find(id);

            if (winery == null)
            {
                return HttpNotFound();
            }

            return View(winery);
        }

        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }

            var winery = db.Wineries.Find(id);

            if (winery == null)
            {
                return HttpNotFound();
            }

            return View(winery);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var winery = db.Wineries.Find(id);

            db.Wineries.Remove(winery);

            try
            {
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

            return View(winery);
        }



    }
}