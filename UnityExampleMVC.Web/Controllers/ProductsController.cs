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
    public class ProductsController : Controller
    {
        private readonly IRepository _repository;

        public ProductsController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: Products
        public ActionResult Index()
        {
            var products = _repository.GetList<Product>().Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.GetEntity<Product>(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_repository.GetList<Category>(), "Id", "Description");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,CategoryId,Amount")] Product product)
        {
            if (ModelState.IsValid)
            {
                var uow = _repository.UoW;
                uow.BeginTransaction();
                _repository.AddEntity<Product>(product);
                uow.CommitTransaction();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_repository.GetList<Category>(), "Id", "Description", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.GetEntity<Product>(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_repository.GetList<Category>(), "Id", "Description", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,CategoryId,Amount")] Product product)
        {
            if (ModelState.IsValid)
            {
                var uow = _repository.UoW;
                uow.BeginTransaction();
                _repository.UpdateEntity<Product>(product);
                uow.CommitTransaction();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_repository.GetList<Category>(), "Id", "Description", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.GetEntity<Product>(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _repository.GetEntity<Product>(id);
            var uow = _repository.UoW;
            uow.BeginTransaction();
            _repository.AddEntity<Product>(product);
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
