using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public bool Slider { get; set; }
        public bool IsApproved { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }

    }
}