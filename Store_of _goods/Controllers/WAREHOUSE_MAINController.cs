using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store_of__goods;

namespace Store_of__goods.Controllers
{
    public class WAREHOUSE_MAINController : Controller
    {
        private GoodsEntities db = new GoodsEntities();

        // GET: WAREHOUSE_MAIN
        [Authorize]
        public ActionResult Index()
        {
            return View(db.WAREHOUSE_MAIN.ToList());
        }

        // GET: WAREHOUSE_MAIN/Details/5
        [Authorize]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WAREHOUSE_MAIN wAREHOUSE_MAIN = db.WAREHOUSE_MAIN.Find(id);
            if (wAREHOUSE_MAIN == null)
            {
                return HttpNotFound();
            }
            return View(wAREHOUSE_MAIN);
        }

        // GET: WAREHOUSE_MAIN/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WAREHOUSE_MAIN/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CREATION_DATE,CALCULATION_DATE,NAME,NOTE")] WAREHOUSE_MAIN wAREHOUSE_MAIN)
        {
            if (ModelState.IsValid)
            {
                db.WAREHOUSE_MAIN.Add(wAREHOUSE_MAIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wAREHOUSE_MAIN);
        }

        // GET: WAREHOUSE_MAIN/Edit/5
        [Authorize]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WAREHOUSE_MAIN wAREHOUSE_MAIN = db.WAREHOUSE_MAIN.Find(id);
            if (wAREHOUSE_MAIN == null)
            {
                return HttpNotFound();
            }
            return View(wAREHOUSE_MAIN);
        }

        // POST: WAREHOUSE_MAIN/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CREATION_DATE,CALCULATION_DATE,NAME,NOTE")] WAREHOUSE_MAIN wAREHOUSE_MAIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wAREHOUSE_MAIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wAREHOUSE_MAIN);
        }

        // GET: WAREHOUSE_MAIN/Delete/5
        [Authorize]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WAREHOUSE_MAIN wAREHOUSE_MAIN = db.WAREHOUSE_MAIN.Find(id);
            if (wAREHOUSE_MAIN == null)
            {
                return HttpNotFound();
            }
            return View(wAREHOUSE_MAIN);
        }

        // POST: WAREHOUSE_MAIN/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            WAREHOUSE_MAIN wAREHOUSE_MAIN = db.WAREHOUSE_MAIN.Find(id);
            db.WAREHOUSE_MAIN.Remove(wAREHOUSE_MAIN);
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
