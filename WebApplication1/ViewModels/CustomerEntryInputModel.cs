using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class CustomerEntryInputModel
    {
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }


        [Display(Name = "Picture")]
        public HttpPostedFileBase Picture { get; set; }

        public long MobileNo { get; set; }

        public System.DateTime SellDate { get; set; }

        public List<BookModel> Books { get; set; } = new List<BookModel>();
    }
}