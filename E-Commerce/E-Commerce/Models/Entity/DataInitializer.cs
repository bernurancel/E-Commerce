using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using E_Commerce.Models.Entity;

namespace E_Commerce.Entity
{
    public class DataInitializer: DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){Name="Kamera",Description="Kamera Ürünleri"},
                new Category(){Name="Telefon",Description="Telefon Ürünleri"},
                new Category(){Name="Bilgisayar",Description="Bilgisayar Ürünleri"}
            };
            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();
            var markalar = new List<Brand>()
            {
                new Brand(){Name="Samsung",Image="tb1.jpg"},
                new Brand(){Name="IPhone",Image="tb9.jpg"},
                new Brand(){Name="Monster",Image="tb8.jpg"},
                new Brand(){Name="Canon",Image="tb2.jpg"},
                new Brand(){Name="Asus",Image="tb6.jpg"},
                new Brand(){Name="Lenova",Image="tb7.png"}
            };
            foreach (var marka in markalar)
            {
                context.Brands.Add(marka);
            }
            context.SaveChanges();
            var urunler = new List<Product>()
            {
                new Product(){Name="Canon 1567  abra5 ",Description="Kamera Ürünleri", Price=2500,Stock=125,CategoryID=1,Slider=false,IsApproved=true,BrandID=4,Image="1.jpg"},
                new Product(){Name="Asus pro5",Description="Bilgisayar Ürünleri", Price=200,Stock=100,CategoryID=3,Slider=true,IsApproved=true,BrandID=5,Image="2.jpg"},
                new Product(){Name="Lenova thinkpad seri7",Description="Bilgisayar Ürünleri", Price=3500,Stock=50,CategoryID=3,Slider=false,IsApproved=true,BrandID=6,Image="3.jpg"},
                new Product(){Name="Samsung note 6s",Description="Telefon Ürünleri", Price=5000,Stock=150,CategoryID=2,Slider=true,IsApproved=true,BrandID=1,Image="4.jpg"}
            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();

            var kargo = new List<Shipper>()
            {
                new Shipper(){CompanyName="Aras Kargo",price=10},
                new Shipper(){CompanyName="MNG Kargo",price=10}
            };
            foreach (var item in kargo)
            {
                context.Shippers.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}