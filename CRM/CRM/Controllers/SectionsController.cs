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
    public class SectionsController : Controller
    {
        private SectionRepository _sectionRepository;

        public SectionsController()
        {
            _sectionRepository = new SectionRepository();
        }


        // GET: Sections
        public ActionResult Index()
        {
            return View(_sectionRepository.GetWhere(x => x.Id > 0));
        }

        // GET: Sections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = _sectionRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();

            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // GET: Sections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SectionName,Job")] Section section)
        {
            if (ModelState.IsValid)
            {
                _sectionRepository.Create(section);
               
                return RedirectToAction("Index");
            }

            return View(section);
        }

        // GET: Sections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = _sectionRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Section section)
        {
            if (ModelState.IsValid)
            {
                _sectionRepository.Update(section);
              
                return RedirectToAction("Index");
            }
            return View(section);
        }

        // GET: Sections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = _sectionRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Section section = _sectionRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _sectionRepository.Delete(section);
           
            return RedirectToAction("Index");
        }

      
    }
}
