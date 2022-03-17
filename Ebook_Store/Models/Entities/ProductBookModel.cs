using Ebook_Store.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ebook_Store.Models.Entities
{
    public class ProductBookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Product Price required")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Product Author required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Product Category required")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Product Quantity required")]
        public int Quantity { get; set; }
        public int Status { get; set; }
        public string Process { get; set; }
        [Required(ErrorMessage = "Date required")]
        public DateTime Date { get; set; }

        public int Admin_Id { get; set; }
        public int Seller_Id { get; set; }

        public Admin Admin { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public Seller Seller { get; set; }
    }
}