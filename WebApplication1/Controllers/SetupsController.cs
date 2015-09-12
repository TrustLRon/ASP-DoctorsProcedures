using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Users = "admin")]
    public class SetupsController : Controller
    {
        private SetupDBContext db = new SetupDBContext();
        private ProcedureDBContext procdb = new ProcedureDBContext();
        private DoctorDBContext docdb = new DoctorDBContext();

        // GET: Setups
        public ActionResult Index()
        {
            return View(db.Setups.OrderBy(a => a.Doctor).ThenBy(a => a.Procedure).ToList());
        }

        // GET: Setups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setup setup = db.Setups.Find(id);
            if (setup == null)
            {
                return HttpNotFound();
            }
            return View(setup);
        }

        // GET: Setups/Create
        public ActionResult Create()
        {

            Setup vm = new Setup();
            vm.Doctors = docdb.Doctors.OrderBy(a => a.DoctorName).ToList();
            vm.Procedures = procdb.Procedures.OrderBy(a => a.ProcedureName).ToList();
            vm.Setups = db.Setups.ToList();


            return View(vm);
        }

        // POST: Setups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Doctor,Procedure,Modality,Orientation,Bilateral,NeedleDrawingUp,NeedleOrange,NeedleWhite,NeedleGrey,NeedleSpinal,NeedleGauge,Syringe1ml,Syringe3ml,Syringe5ml,Syringe10ml,Lignocaine,Bupivacaine,Steroid,SteroidAmount,Contrast,OtherEquipment,Comments")] Setup setup)
        {
            if (ModelState.IsValid)
            {
                db.Setups.Add(setup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setup);
        }

        // GET: Setups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setup setup = db.Setups.Find(id);
            setup.Doctors = docdb.Doctors.ToList();
            setup.Procedures = procdb.Procedures.ToList();
            setup.Setups = db.Setups.ToList();
            

            if (setup == null)
            {
                return HttpNotFound();
            }
            return View(setup);
        }

        // POST: Setups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Doctor,Procedure,Modality,Orientation,Bilateral,NeedleDrawingUp,NeedleOrange,NeedleWhite,NeedleGrey,NeedleSpinal,NeedleGauge,Syringe1ml,Syringe3ml,Syringe5ml,Syringe10ml,Lignocaine,Bupivacaine,Steroid,SteroidAmount,Contrast,OtherEquipment,Comments")] Setup setup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setup);
        }

        // GET: Setups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setup setup = db.Setups.Find(id);
            if (setup == null)
            {
                return HttpNotFound();
            }
            return View(setup);
        }

        // POST: Setups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Setup setup = db.Setups.Find(id);
            db.Setups.Remove(setup);
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
