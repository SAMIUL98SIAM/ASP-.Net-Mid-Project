using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ebook_Store.Models.Entities
{
    public class AboutModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }
    }
}