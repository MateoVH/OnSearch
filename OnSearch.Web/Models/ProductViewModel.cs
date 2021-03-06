﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnSearch.Web.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnSearch.Web.Models
{
    public class ProductViewModel : Product
    {
        [Display(Name = "Categoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Categoria")]
        [Required]
        public int CategoryId { get; set; }

        public IFormFile ImageFile { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }        
    }

}
