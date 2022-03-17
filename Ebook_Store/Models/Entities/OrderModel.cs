using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebook_Store.Models.Entities
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int Customer_Id { get; set; }

        public CustomerModel Customer { get; set; }
    }
}