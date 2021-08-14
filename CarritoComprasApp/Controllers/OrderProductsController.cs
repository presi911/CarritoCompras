using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelImplementation.ModelDb;

namespace CarritoComprasApp.Controllers
{
    public class OrderProductsController : Controller
    {
        private ImaginamosDBEntities db = new ImaginamosDBEntities();

        // GET: OrderProducts
        public ActionResult Index()
        {
            var oRDERPRODUCT = db.ORDERPRODUCT.Include(o => o.ORDE).Include(o => o.PRODUCT);
            return View(oRDERPRODUCT.ToList());
        }

        // GET: OrderProducts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERPRODUCT oRDERPRODUCT = db.ORDERPRODUCT.Find(id);
            if (oRDERPRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(oRDERPRODUCT);
        }

        // GET: OrderProducts/Create
        public ActionResult Create()
        {
            ViewBag.ORDERID = new SelectList(db.ORDE, "ID", "ORDERNUMBER");
            ViewBag.PRODUCTID = new SelectList(db.PRODUCT, "ID", "NAME");
            return View();
        }

        // POST: OrderProducts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ORDERID,PRODUCTID,QUANTITY")] ORDERPRODUCT oRDERPRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.ORDERPRODUCT.Add(oRDERPRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ORDERID = new SelectList(db.ORDE, "ID", "ORDERNUMBER", oRDERPRODUCT.ORDERID);
            ViewBag.PRODUCTID = new SelectList(db.PRODUCT, "ID", "NAME", oRDERPRODUCT.PRODUCTID);
            return View(oRDERPRODUCT);
        }

        // GET: OrderProducts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERPRODUCT oRDERPRODUCT = db.ORDERPRODUCT.Find(id);
            if (oRDERPRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ORDERID = new SelectList(db.ORDE, "ID", "ORDERNUMBER", oRDERPRODUCT.ORDERID);
            ViewBag.PRODUCTID = new SelectList(db.PRODUCT, "ID", "NAME", oRDERPRODUCT.PRODUCTID);
            return View(oRDERPRODUCT);
        }

        // POST: OrderProducts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ORDERID,PRODUCTID,QUANTITY")] ORDERPRODUCT oRDERPRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDERPRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ORDERID = new SelectList(db.ORDE, "ID", "ORDERNUMBER", oRDERPRODUCT.ORDERID);
            ViewBag.PRODUCTID = new SelectList(db.PRODUCT, "ID", "NAME", oRDERPRODUCT.PRODUCTID);
            return View(oRDERPRODUCT);
        }

        // GET: OrderProducts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERPRODUCT oRDERPRODUCT = db.ORDERPRODUCT.Find(id);
            if (oRDERPRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(oRDERPRODUCT);
        }

        // POST: OrderProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ORDERPRODUCT oRDERPRODUCT = db.ORDERPRODUCT.Find(id);
            db.ORDERPRODUCT.Remove(oRDERPRODUCT);
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
