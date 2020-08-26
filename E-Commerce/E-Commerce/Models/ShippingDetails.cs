using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class ShippingDetails
    {
        public string UserName { get; set; }
        [Required(ErrorMessage ="Lütfen Adres Girin.")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen Şehir Girin.")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen Semt Girin.")]
        public string Semt { get; set; }
        [Required(ErrorMessage = "Lütfen Mahalle Girin.")]
        public string Mahalle { get; set; }
        [Required(ErrorMessage = "Lütfen Posta Kodu Girin.")]
        public string PostaKodu { get; set; }
    }
}