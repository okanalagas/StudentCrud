using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCrud.Models;
using System.Net;

namespace StudentCrud.Controllers
{
  
    public class OgrencisController : Controller
    {
        Model1 db;

        public OgrencisController(Model1 model1)
        {
            db = model1;
        }

        public ActionResult Index()
        {
            return View(db.MyEntities.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.MyEntities.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.MyEntities.Add(ogrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogrenci);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.MyEntities.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.MyEntities.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogrenci ogrenci = db.MyEntities.Find(id);
            db.MyEntities.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

    internal class HttpStatusCodeResult : ActionResult
    {
        private HttpStatusCode badRequest;

        public HttpStatusCodeResult(HttpStatusCode badRequest)
        {
            this.badRequest = badRequest;
        }
    }
}


