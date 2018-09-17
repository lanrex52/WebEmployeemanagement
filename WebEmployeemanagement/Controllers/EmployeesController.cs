using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEmployeemanagement.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()

        {
            EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();

         var employees =   db.Employees.ToList();
            ViewBag.allemployees = employees;
            return View();
        }
        
        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Create( string fname, string lname, string sex, string age, string salary, string address)
        {
            EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();
            Employee empObj = new Employee();
            empObj.FirstName = fname;
            empObj.LastName = lname;
            empObj.Sex = sex;
            empObj.Age = int.Parse(age);
            empObj.Salary = decimal.Parse(salary);
            empObj.Address = address;

            db.Employees.Add(empObj);
            db.SaveChanges();

            //TempData[key] persists for the next HHP request and 
            TempData["successmsg"] = "Employee Successfully Created";

           // ViewBag.successmsg = "Employee Successfully Created";
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();
            Employee employee = db.Employees.Find(id);
            ViewBag.employeedata = employee;
        
            return View();
        }
        [HttpPost]
        public ActionResult Edit(string Id,string fname, string lname, string sex, string age, string salary, string address)
        {
            EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();
            Employee empObj = new Employee();
            empObj.id = int.Parse(Id);
            empObj.FirstName = fname;
            empObj.LastName = lname;
            empObj.Sex = sex;
            empObj.Age = int.Parse(age);
            empObj.Salary = decimal.Parse(salary);
            empObj.Address = address;

            db.Entry(empObj).State = EntityState.Modified;
           
            db.SaveChanges();
            //TempData[key] persists for the next HTTzP request and 
            TempData["successmsg"] = "Employee Modified Successfully ";


            // ViewBag.successmsg = "Employee Modified Successfully ";
            return RedirectToAction("index");

        }
        public ActionResult Delete( int id)
        {
            EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();
            Employee employeeToDelete = db.Employees.Find(id);
            ViewBag.employeedata = employeeToDelete;
            //To delete the employee
            db.Employees.Remove(employeeToDelete);
            db.SaveChanges();
            //Send a Success message back to the user
            TempData["successmsg"] = "Employee Deleted Successfully ";

            return RedirectToAction("Index");
            
        }
    }
}