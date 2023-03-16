using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill

        BookShopDbContext db = new BookShopDbContext();
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.Books = db.Books.ToList();
            var data = new CustomerEntryInputModel();
            data.Books.Add(new BookModel());
            return View(data);
        }

        [HttpPost]
        public ActionResult Create(CustomerEntryInputModel model, int[] BookId)
        {
            if (ModelState.IsValid)
            {
                var et = new Customer
                {
                    CustomerName = model.CustomerName,
                    MobileNo = model.MobileNo,
                    SellDate = model.SellDate,
                };
                foreach (var x in BookId)
                {
                    et.EntryBooks.Add(new EntryBook { BookId = x });
                }
                if (model.Picture.ContentLength > 0)
                {
                    string ext = Path.GetExtension(model.Picture.FileName);
                    string fileName = Guid.NewGuid() + ext;
                    model.Picture.SaveAs(Path.Combine(Server.MapPath("~/Uploads"), fileName));
                    et.Picture = fileName;
                }
                db.Customers.Add(et);
                db.SaveChanges();
                return PartialView("_success");
            }
            ViewBag.Books = db.Books.ToList();

            return PartialView("_error");
        }

        public JsonResult GetPrice(int id)
        {
            var t = db.Books.FirstOrDefault(x => x.BookId == id);
            return Json(t == null ? 0 : t.BookPrice);
        }

        public ActionResult CreateNewField(CustomerEntryInputModel data)
        {
            ViewBag.Book = db.Books.ToList();
            data.Books.Add(new BookModel());
            return PartialView(data);
        }
        public PartialViewResult CreateBookEntry()
        {
            ViewBag.Books = db.Books.ToList();

            return PartialView("_BookEntry");
        }
    }
}
