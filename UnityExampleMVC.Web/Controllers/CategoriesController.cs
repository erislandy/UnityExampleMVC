using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnityExampleMVC.Data;
using UnityExampleMVC.DataImpl;
using UnityExampleMVC.Domain;

namespace UnityExampleMVC.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IRepository _repository;

        public CategoriesController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: Categories
        public ActionResult Index()
        {
            return View(_repository.GetList<Category>().ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _repository.GetEntity<Category>(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                var uow = _repository.UoW;
                uow.BeginTransaction();
                _repository.AddEntity<Category>(category);
                uow.CommitTransaction();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _repository.GetEntity<Category>(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                var uow = _repository.UoW;
                uow.BeginTransaction();
                _repository.UpdateEntity<Category>(category);
                uow.CommitTransaction();

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _repository.GetEntity<Category>(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _repository.GetEntity<Category>(id);
            var uow = _repository.UoW;
            uow.BeginTransaction();
            _repository.DeleteEntity<Category>(category);
            uow.CommitTransaction();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                (_repository.UoW.Orm as DbContext).Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
