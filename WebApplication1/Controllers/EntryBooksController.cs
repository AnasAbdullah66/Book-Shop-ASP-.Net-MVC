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
    public class EntryBooksController : Controller
    {
        private BookShopDbContext db = new BookShopDbContext();

        // GET: EntryBooks
        public ActionResult Index()
        {
            var entryBooks = db.EntryBooks.Include(e => e.Book).Include(e => e.Customer);
            return View(entryBooks.ToList());
        }

        // GET: EntryBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntryBook entryBook = db.EntryBooks.Find(id);
            if (entryBook == null)
            {
                return HttpNotFound();
            }
            return View(entryBook);
        }

        // GET: EntryBooks/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: EntryBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookId,CustomerId")] EntryBook entryBook)
        {
            if (ModelState.IsValid)
            {
                db.EntryBooks.Add(entryBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", entryBook.BookId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", entryBook.CustomerId);
            return View(entryBook);
        }

        // GET: EntryBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntryBook entryBook = db.EntryBooks.Find(id);
            if (entryBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", entryBook.BookId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", entryBook.CustomerId);
            return View(entryBook);
        }

        // POST: EntryBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookId,CustomerId")] EntryBook entryBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entryBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", entryBook.BookId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", entryBook.CustomerId);
            return View(entryBook);
        }

        // GET: EntryBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntryBook entryBook = db.EntryBooks.Find(id);
            if (entryBook == null)
            {
                return HttpNotFound();
            }
            return View(entryBook);
        }

        // POST: EntryBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntryBook entryBook = db.EntryBooks.Find(id);
            db.EntryBooks.Remove(entryBook);
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
