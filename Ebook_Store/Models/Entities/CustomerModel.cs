using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ebook_Store.Models.Entities
{
    public class CustomerModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone Number required")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Date of Birth required")]
        public DateTime DOB { get; set; }



    }
}