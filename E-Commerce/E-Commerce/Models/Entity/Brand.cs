using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Product> Products { get; set; }
    }
}