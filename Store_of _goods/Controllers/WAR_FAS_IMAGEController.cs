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
    public class WAR_FAS_IMAGEController : Controller
    {
        private GoodsEntities db = new GoodsEntities();

        // GET: WAR_FAS_IMAGE
        [Authorize]
        public ActionResult Index()
        {
            return View(db.WAR_FAS_IMAGE.ToList());
        }

        // GET: WAR_FAS_IMAGE/Details/5
        [Authorize]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WAR_FAS_IMAGE wAR_FAS_IMAGE = db.WAR_FAS_IMAGE.Find(id);
            if (wAR_FAS_IMAGE == null)
            {
                return HttpNotFound();
            }
            return View(wAR_FAS_IMAGE);
        }

        // GET: WAR_FAS_IMAGE/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WAR_FAS_IMAGE/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FAS,IMAGE_1,IMAGE_2,IMAGE_3,IMAGE_4,IMAGE_5,NOTE")] WAR_FAS_IMAGE wAR_FAS_IMAGE)
        {
            if (ModelState.IsValid)
            {
                db.WAR_FAS_IMAGE.Add(wAR_FAS_IMAGE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wAR_FAS_IMAGE);
        }

        // GET: WAR_FAS_IMAGE/Edit/5
        [Authorize]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WAR_FAS_IMAGE wAR_FAS_IMAGE = db.WAR_FAS_IMAGE.Find(id);
            if (wAR_FAS_IMAGE == null)
            {
                return HttpNotFound();
            }
            return View(wAR_FAS_IMAGE);
        }

        // POST: WAR_FAS_IMAGE/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FAS,IMAGE_1,IMAGE_2,IMAGE_3,IMAGE_4,IMAGE_5,NOTE")] WAR_FAS_IMAGE wAR_FAS_IMAGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wAR_FAS_IMAGE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wAR_FAS_IMAGE);
        }

        // GET: WAR_FAS_IMAGE/Delete/5
        [Authorize]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WAR_FAS_IMAGE wAR_FAS_IMAGE = db.WAR_FAS_IMAGE.Find(id);
            if (wAR_FAS_IMAGE == null)
            {
                return HttpNotFound();
            }
            return View(wAR_FAS_IMAGE);
        }

        // POST: WAR_FAS_IMAGE/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            WAR_FAS_IMAGE wAR_FAS_IMAGE = db.WAR_FAS_IMAGE.Find(id);
            db.WAR_FAS_IMAGE.Remove(wAR_FAS_IMAGE);
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
