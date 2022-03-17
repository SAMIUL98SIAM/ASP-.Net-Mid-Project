using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ebook_Store.Models.Entities
{
    public class AdminModel
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public string Phone { get; set; }
       
        public string Address { get; set; }
        [Required(ErrorMessage = "Password Field is  required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }
        public string Gender { get; set; }
        
        public DateTime DOB { get; set; }
        public int S_Admin_Id { get; set; }

        public SuperAdminModel SuperAdmin { get; set; }
    }
}