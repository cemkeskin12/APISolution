using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Entity.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email adresi zorunlu")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunlu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
