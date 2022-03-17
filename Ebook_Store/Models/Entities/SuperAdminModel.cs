using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ebook_Store.Models.Entities
{

    public class SuperAdminModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        [Required(ErrorMessage = "SuperAdmin Password required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "SuperAdmin Email required")]
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
    }
}