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
    public class ORDEsController : Controller
    {
        private ImaginamosDBEntities db = new ImaginamosDBEntities();

        // GET: ORDEs
        public ActionResult Index()
        {
            var oRDE = db.ORDE.Include(o => o.AspNetUsers);
            return View(oRDE.ToList());
        }

        // GET: ORDEs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDE oRDE = db.ORDE.Find(id);
            if (oRDE == null)
            {
                return HttpNotFound();
            }
            return View(oRDE);
        }

        // GET: ORDEs/Create
        public ActionResult Create()
        {
            ViewBag.CUSTOMERID = new SelectList(db.AspNetUsers, "Id", "Identification");
            return View();
        }

        // POST: ORDEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ORDERNUMBER,CUSTOMERID,GTOTAL")] ORDE oRDE)
        {
            try
            {
                //Order table
                if (oRDE.ID == 0)
                    db.ORDE.Add(oRDE);
                else
                    db.Entry(oRDE).State = EntityState.Modified;

                //OrderItems table
                foreach (var item in oRDE.ORDERPRODUCT)
                {
                    if (item.ID == 0)
                        db.ORDERPRODUCT.Add(item);
                    else
                        db.Entry(item).State = EntityState.Modified;
                }
                db.SaveChanges();

                return View(oRDE);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return View(oRDE);
        }

        // GET: ORDEs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDE oRDE = db.ORDE.Find(id);
            if (oRDE == null)
            {
                return HttpNotFound();
            }
            ViewBag.CUSTOMERID = new SelectList(db.AspNetUsers, "Id", "Identification", oRDE.CUSTOMERID);
            return View(oRDE);
        }

        // POST: ORDEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ORDERNUMBER,CUSTOMERID,GTOTAL")] ORDE oRDE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUSTOMERID = new SelectList(db.AspNetUsers, "Id", "Identification", oRDE.CUSTOMERID);
            return View(oRDE);
        }

        // GET: ORDEs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDE oRDE = db.ORDE.Find(id);
            if (oRDE == null)
            {
                return HttpNotFound();
            }
            return View(oRDE);
        }

        // POST: ORDEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ORDE oRDE = db.ORDE.Find(id);
            db.ORDE.Remove(oRDE);
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
