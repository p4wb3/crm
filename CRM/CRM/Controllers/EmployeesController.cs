using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRM.Repository;

namespace CRM.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeRepository _employeeRepository;
        private SectionRepository _sectionRepository;

        public EmployeesController()
        {
            _employeeRepository = new EmployeeRepository();
            _sectionRepository= new SectionRepository();
        }
        // GET: Employees
        public ActionResult Index()
        {
           
            return View(_employeeRepository.GetWhere(x=>x.Id>0));
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Create(employee);
                
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeRepository.GetWhere(x => x.Id == id).FirstOrDefault();

            if (employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.SectionId = new SelectList(_sectionRepository.GetWhere(x => x.Id > 0), "Id", "SectionName");
             return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(employee);
                return RedirectToAction("Index");
            }
           return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeRepository.GetWhere(x => x.Id == id).FirstOrDefault();

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _employeeRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _employeeRepository.Delete(employee);
            return RedirectToAction("Index");
        }

       
    }
}
