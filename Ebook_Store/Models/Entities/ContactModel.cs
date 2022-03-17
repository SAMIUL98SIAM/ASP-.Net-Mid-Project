using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ebook_Store.Models.Entities
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "To Require")]
        [EmailAddress]
        public string Too { get; set; }
        [Required(ErrorMessage = "Subject Require")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Body Require")]
        public string Body { get; set; }
        
    }
}