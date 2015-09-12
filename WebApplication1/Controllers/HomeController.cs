using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ProcedureDBContext procdb = new ProcedureDBContext();
        private DoctorDBContext docdb = new DoctorDBContext();
        private SetupDBContext setupdb = new SetupDBContext();

        public ActionResult Index()
        {
            ViewModel vm = new ViewModel();
            vm.Doctors = docdb.Doctors.ToList();
            vm.Procedures = procdb.Procedures.ToList();
            vm.Setups = setupdb.Setups.ToList();

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Find()
        {
            return View();
        }

        [Authorize]
        public ActionResult ChooseDoctor()
        {
            ViewModel vm = new ViewModel();
            vm.Doctors = docdb.Doctors.GroupBy(d => d.DoctorName).Select(d => d.FirstOrDefault()).OrderBy(a => a.DoctorName).ToList();
            vm.Setups = setupdb.Setups.GroupBy(d => d.Doctor).Select(d => d.FirstOrDefault()).OrderBy(a => a.Doctor).ToList();
            vm.Procedures = procdb.Procedures.GroupBy(d => d.ProcedureName).Select(d => d.FirstOrDefault()).OrderBy(a => a.ProcedureName).ToList();
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChooseDoctor(int? id)
        {

            var doc = Request["Doctor"];

            Doctor docQuery = docdb.Doctors.Where(d => d.DoctorName == doc).FirstOrDefault();

            ViewModel vm = new ViewModel();

            if (ModelState.IsValid)
            {
                return RedirectToAction("DisplayDocsProcs/" + docQuery.ID);
            }

            return View(vm);       
        }

        [Authorize]
        public ActionResult ChooseProcedure()
        {
            ViewModel vm = new ViewModel();
            vm.Doctors = docdb.Doctors.OrderBy(a => a.DoctorName).ToList();
            vm.Setups = setupdb.Setups.OrderBy(a => a.Doctor).ToList();
            vm.Procedures = procdb.Procedures.OrderBy(a => a.ProcedureName).ToList();
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChooseProcedure(int? id)
        {

            var proc = Request["Procedure"];

            Procedure procQuery = procdb.Procedures.Where(p => p.ProcedureName == proc).FirstOrDefault();

            ViewModel vm = new ViewModel();

            if (ModelState.IsValid)
            {
                return RedirectToAction("DisplayProcDocs/" + procQuery.ID);
            }

            return View(vm);
        }

        [Authorize]
        public ActionResult DisplayDocsProcs(int? id)
        {
            Doctor doctor = docdb.Doctors.Find(id);

            ViewModel vm = new ViewModel();
            vm.Doctors = docdb.Doctors.Where(s => s.DoctorName == doctor.DoctorName).ToList();

            if (doctor == null)
            {
                return Content("doctor none");
            }
            else
            {
                vm.Setups = setupdb.Setups.Where(s => s.Doctor == doctor.DoctorName).OrderBy(s => s.Procedure).ToList();
            }

            if (vm == null)
            {
                return Content("vm None");
            }
            else
            {
                return View(vm);
            }
        }

        [Authorize]
        public ActionResult DisplayProcDocs(int? id)
        {
            Procedure proc = procdb.Procedures.Find(id);

            ViewModel vm = new ViewModel();
            vm.Procedures = procdb.Procedures.Where(p => p.ProcedureName == proc.ProcedureName).ToList();

            if (proc == null)
            {
                return Content("doctor none");
            }
            else
            {
                vm.Setups = setupdb.Setups.Where(p => p.Procedure == proc.ProcedureName).OrderBy(s => s.Doctor).ToList();
            }

            if (vm == null)
            {
                return Content("vm None");
            }
            else
            {
                return View(vm);
            }
        }

        [Authorize]
        public ActionResult Result(int? id)
        {
            Setup setup = setupdb.Setups.Find(id);
            ViewModel vm = new ViewModel();
            vm.Doctors = docdb.Doctors.Where(s => s.DoctorName == setup.Doctor).ToList();
            if (setup == null)
            {
                return Content("None");
            }
            else
            {
                vm.Setups = setupdb.Setups
                    .Where(s => s.Doctor == setup.Doctor && s.Procedure == setup.Procedure)
                    .ToList();
            }

            if (vm == null)
            {
                return Content("None");
            }
            else
            {
                return View(vm);
            }
        }
    }
}