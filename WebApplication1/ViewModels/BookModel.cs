using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class BookModel
    {
        [Required]
        public int BookId { get; set; }

        [Required, Display(Name = "Price")]
        public decimal BookPrice { get; set; }
    }
}