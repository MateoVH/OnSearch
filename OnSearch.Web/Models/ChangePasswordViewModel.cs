using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnSearch.Web.Models
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "Actual Contraseña")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe estar entre {2} y {1} Caracteres")]
        public string OldPassword { get; set; }

        [Display(Name = "Nueva Contraseña")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe estar entre {2} y {1} Caracteres")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirma Contraseña")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe estar entre {2} y {1} Caracteres")]
        [Compare("NewPassword")]
        public string Confirm { get; set; }
    }
}
