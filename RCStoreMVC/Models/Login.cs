using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RCStoreMVC.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        
        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}