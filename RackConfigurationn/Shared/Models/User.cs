using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RackConfigurationn.Shared.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        public string Username { get; set; }

      
        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }

       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // 6. Rol (Örn: "Admin", "Customer")
        // Kimin hangi sayfaya erişebileceğini belirlemek için kullanılır.
        public string Role { get; set; } = "Customer";

        // 7. Kayıt Tarihi
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
