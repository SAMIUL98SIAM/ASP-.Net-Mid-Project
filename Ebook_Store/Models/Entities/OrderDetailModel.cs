using Ebook_Store.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebook_Store.Models.Entities
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public double Unitprice { get; set; }
        public int Product_Id { get; set; }
        public int Order_Id { get; set; }

        public Order Order { get; set; }
        public  ProductBook ProductBook { get; set; }

 

    }
}