using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adı")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadı")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Geçersiz Email...")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Parola")]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="Parolalarınız Uyuşmuyor...")]
        [DisplayName("Parola Tekrar")]
        public string RePassword { get; set; }

    }
}