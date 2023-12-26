using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RCStoreMVC.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Ad zorunludur.")]
        [DisplayName("Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        [DisplayName("Soyad")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-Posta zorunludur.")]
        [DisplayName("E-Posta")]
        [EmailAddress(ErrorMessage ="E-Posta adresinizi düzgün giriniz.")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı zorunludur.")]
        [DisplayName("Şifre tekrar")]
        [Compare("Password", ErrorMessage ="Şifreler aynı değil!")]
        public string RePassword { get; set; }
    }
}