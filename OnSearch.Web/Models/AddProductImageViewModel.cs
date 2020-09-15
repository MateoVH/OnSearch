using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnSearch.Web.Models
{
    public class AddProductImageViewModel
    {
        public int ProductId { get; set; }

        [Display(Name = "Imagen")]
        [Required]
        public IFormFile ImageFile { get; set; }
    }

}
