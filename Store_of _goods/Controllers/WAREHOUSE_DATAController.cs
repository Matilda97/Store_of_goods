using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store_of__goods;
using PagedList.Mvc;
using PagedList;

namespace Store_of__goods.Controllers
{
    public class WAREHOUSE_DATAController : Controller
    {
        private GoodsEntities db = new GoodsEntities();

        // GET: WAREHOUSE_DATA
        [Authorize]
        public ActionResult Index(int? page, string category = null, string current = null)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            if (category == null)
            {
                category = current;
            }
            else page = 1;
            ViewBag.Current = category;

            var wAREHOUSE_DATA = db.WAREHOUSE_DATA.Include(w => w.WAREHOUSE_MAIN);
            if(category!= null)
            {
                wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                /*//муж
                if (category == "МУЖ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ДЖЕМПЕР МУЖ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ФУФАЙКА МУЖ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "МАЙКА МУЖ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ТРУСЫ МУЖ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "НОСКИ МУЖ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "КАЛЬСОНЫ МУЖ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "БРЮКИ СПОРТ. МУЖ")
                {
                    wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains("БРЮКИ СПОРТ"));
                    wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains("МУЖ"));
                }
                if (category == "ТРУСЫ КУПАЛЬНЫЕ МУЖ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "БРЮКИ НИЖНИЕ МУЖ.") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));

                //жен
                if (category == "ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ДЖЕМПЕР ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ФУФАЙКА ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "МАЙКА ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ТРУСЫ ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "НОСКИ ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ПИЖАМА ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "БРИДЖИ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ПЛАТЬЕ ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "СОРОЧКА НОЧНАЯ ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ЛЕГИНСЫ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ШОРТЫ ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "БРЮКИ СПОРТ  ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "КОМПЛЕКТ ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ХАЛАТ ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ПАНТАЛОНЫ ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "КАПРИ ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ХАЛАТ ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ТУНИКА ЖЕН") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));

                //мал
                if (category == "ТРУСЫ МАЛ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "МАЙКА МАЛ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ДЖЕМПЕР МАЛ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "КОМПЛЕКТ МАЛ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ПИЖАМА МАЛ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "КОСТЮМ СПОРТ. МАЛ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "БРЮКИ МАЛ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "БРЮКИ НИЖНИЕ МАЛ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "БРИДЖИ МАЛ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "БРЮКИ НИЖНИЕ МАЛ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));

                //дев
                if (category == "ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ДЖЕМПЕР ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ФУФАЙКА ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "МАЙКА ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ТРУСЫ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "НОСКИ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ПИЖАМА ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "БРИДЖИ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ПЛАТЬЕ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "СОРОЧКА НОЧНАЯ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ЛЕГИНСЫ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ШОРТЫ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "БРЮКИ СПОРТ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "КОМПЛЕКТ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ХАЛАТ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ПАНТАЛОНЫ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "КАПРИ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ХАЛАТ ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ТУНИКА ДЕВ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));

                //дет
                if (category == "ТРУСЫ ДЕТ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ФУФАЙКА ДЕТ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "КОЛГОТКИ ДЕТ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ЖАКЕТ ДЕТ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "НОСКИ ДЕТ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ПОЛУЧУЛКИ ДЕТ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "ПОЛУКОМБИНЕЗОН ДЕТ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));
                if (category == "КОФТОЧКА ДЕТ") wAREHOUSE_DATA = wAREHOUSE_DATA.Where(q => q.NGPR.Contains(category));*/
            }
            return View(wAREHOUSE_DATA.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: WAREHOUSE_DATA/Details/5
        [Authorize]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WAREHOUSE_DATA wAREHOUSE_DATA = db.WAREHOUSE_DATA.Find(id);
            if (wAREHOUSE_DATA == null)
            {
                return HttpNotFound();
            }
            return View(wAREHOUSE_DATA);
        }

        // GET: WAREHOUSE_DATA/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.WAREHOUSE_MAIN_ID = new SelectList(db.WAREHOUSE_MAIN, "ID", "NAME");
            return View();
        }

        // POST: WAREHOUSE_DATA/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,WAREHOUSE_MAIN_ID,KOD_IZD,KOL,NCW,RST,RZM,RZM_PRINT,SRT,NOT1,MASSA,CNP,CNO,CNR,CNV,NDS,EAN,KOD,SAR,NAR,NGPR,BREND,KOMPLEKT,FAS")] WAREHOUSE_DATA wAREHOUSE_DATA)
        {
            if (ModelState.IsValid)
            {
                db.WAREHOUSE_DATA.Add(wAREHOUSE_DATA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WAREHOUSE_MAIN_ID = new SelectList(db.WAREHOUSE_MAIN, "ID", "NAME", wAREHOUSE_DATA.WAREHOUSE_MAIN_ID);
            return View(wAREHOUSE_DATA);
        }

        // GET: WAREHOUSE_DATA/Edit/5
        [Authorize]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WAREHOUSE_DATA wAREHOUSE_DATA = db.WAREHOUSE_DATA.Find(id);
            if (wAREHOUSE_DATA == null)
            {
                return HttpNotFound();
            }
            ViewBag.WAREHOUSE_MAIN_ID = new SelectList(db.WAREHOUSE_MAIN, "ID", "NAME", wAREHOUSE_DATA.WAREHOUSE_MAIN_ID);
            return View(wAREHOUSE_DATA);
        }

        // POST: WAREHOUSE_DATA/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,WAREHOUSE_MAIN_ID,KOD_IZD,KOL,NCW,RST,RZM,RZM_PRINT,SRT,NOT1,MASSA,CNP,CNO,CNR,CNV,NDS,EAN,KOD,SAR,NAR,NGPR,BREND,KOMPLEKT,FAS")] WAREHOUSE_DATA wAREHOUSE_DATA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wAREHOUSE_DATA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WAREHOUSE_MAIN_ID = new SelectList(db.WAREHOUSE_MAIN, "ID", "NAME", wAREHOUSE_DATA.WAREHOUSE_MAIN_ID);
            return View(wAREHOUSE_DATA);
        }

        // GET: WAREHOUSE_DATA/Delete/5
        [Authorize]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WAREHOUSE_DATA wAREHOUSE_DATA = db.WAREHOUSE_DATA.Find(id);
            if (wAREHOUSE_DATA == null)
            {
                return HttpNotFound();
            }
            return View(wAREHOUSE_DATA);
        }

        // POST: WAREHOUSE_DATA/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            WAREHOUSE_DATA wAREHOUSE_DATA = db.WAREHOUSE_DATA.Find(id);
            db.WAREHOUSE_DATA.Remove(wAREHOUSE_DATA);
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
