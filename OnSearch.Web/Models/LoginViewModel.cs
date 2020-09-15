using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnSearch.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Debe ser un correo Válido")]
        public string Username { get; set; }

        [Required]
        [MinLength(6 , ErrorMessage ="Debe tener mínimo 6 caracteres")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

}
