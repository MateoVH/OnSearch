using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnSearch.Web.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe estar entre {2} y {1} Caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe estar entre {2} y {1} Caracteres")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Token { get; set; }
    }

}
