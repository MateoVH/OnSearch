﻿using Microsoft.AspNetCore.Http;
using OnSearch.Web.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnSearch.Web.Models
{
    public class CategoryViewModel : Category
    {
        [Display(Name = "Imagen")]
        public IFormFile ImageFile { get; set; }
    }

}
