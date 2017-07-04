using Store_of__goods.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store_of__goods.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}