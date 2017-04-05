using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using exam.Models;

namespace exam.Controllers
{
    public class examController : Controller
    {

        public static int EmpI = 0;
     
        private ExamDBEntities db = new ExamDBEntities();
        //
        // GET: /exam/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult employeelist()
        {
            var empListy=(from item in db.Employees select item);
            return View(empListy.ToList());
        }

        public ActionResult addEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addEmployee(Employee emp, string FullName, string Gender, string Address)
        {
            emp.FullName = FullName;
            emp.Gender = Gender;
            emp.Address = Address;
            db.Employees.Add(emp);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult EmployeeUpdate(int id = 0)
        {
            EmpI = id;
            Employee bc = db.Employees.FirstOrDefault(s => s.EmpI == EmpI);
            if (bc == null)
            {
                return HttpNotFound();
            }
            ViewBag.GetFullName = bc.FullName;
            ViewBag.GetGender = bc.Gender;
            ViewBag.GetAddress = bc.Address;
            return View(bc);
        }
        [HttpPost]
        public ActionResult EmployeeUpdate(Employee bc, int id = 0)
        {
            Employee bc1 = db.Employees.FirstOrDefault(s => s.EmpI == EmpI);
            bc1.FullName = bc.FullName;
            bc1.Gender = bc.Gender;
            bc1.Address = bc.Address;
    
            if (bc1 == null)
            {
                return HttpNotFound();
            }
            db.SaveChanges();
            //ViewBag.PatientID = new SelectList(db.tbl_PatientInfo, "PatientID", "PatientName");
            ViewBag.Messages = "Update Successfully";
            //return RedirectToAction(" patientSchedulelist");
            return View(bc1);

        }

        public JsonResult DeleteEmployee(int id = 0)
        {
            Employee course = db.Employees.Where(x => x.EmpI == id).FirstOrDefault();
            db.Employees.Remove(course);
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }
	}
}