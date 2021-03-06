﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnSearch.Web.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        //[MaxLength(100)]
        //public string Address { get; set; }

        [Display(Name = "Número de Telefono")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Imagen")]
        public Guid ImageId { get; set; }

        [Display(Name = "Imagen")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44327/images/noimage.png"
            : $"https://onsale.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "Imagen")]
        public IFormFile ImageFile { get; set; }

    }

}
