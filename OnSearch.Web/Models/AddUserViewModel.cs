using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnSearch.Web.Models
{
    public class AddUserViewModel : EditUserViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [MaxLength(100, ErrorMessage = "El {0} campo debe estar entre {2} y {1} Caracteres")]
        [EmailAddress]
        public string Username { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe estar entre {2} y {1} Caracteres")]
        public string Password { get; set; }

        [Display(Name = "Confirma Contraseña")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe estar entre {2} y {1} Caracteres")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }

}
