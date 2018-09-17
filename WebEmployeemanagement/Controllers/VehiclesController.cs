using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEmployeemanagement.Controllers
{
    public class VehiclesController : Controller
    {
        // GET: Vehicles
        public ActionResult Index()
        {
            EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();
            var allVehicles = db.Vehicles.ToList();
           
            return View(allVehicles);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]//store in the database
        public ActionResult Create(Vehicle v)
        {
            EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();
            db.Vehicles.Add(v);
            db.SaveChanges();

            //TempDate[] persists for the next HttpRequest and is disposed automaticaly by asp.net
            TempData["successmsg"] = "Vehicle Created Sucessfully";
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();
            Vehicle a = db.Vehicles.Find(id);

            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(Vehicle e)
        {
            EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            //TempDate[] persists for the next HttpRequest and is disposed automaticaly by asp.net
            TempData["successmsg"] = "Vehicle Edited Sucessfully";
            return RedirectToAction("Edit");
        }
        public ActionResult Delete(int id)
        {
            EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();
            Vehicle vehicleToDelete = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicleToDelete);
            db.SaveChanges();
            //TempDate[] persists for the next HttpRequest and is disposed automaticaly by asp.net
            TempData["successmsg"] = "Employee Deleted Successfully ";

            return RedirectToAction("Index");

        }

    }
}