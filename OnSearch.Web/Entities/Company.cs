﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnSearch.Web.Entities
{
    public class Company
    {
        public int Id { get; set; }

        //public int UserId { get; set; }
        public string UserF { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name = "Local/Empresa")]
        public string Name { get; set; }

        [MaxLength(20)]
        [Required]
        [Display(Name = "NIT")]
        public string NIT { get; set; }

        [MaxLength(20)]
        [Required]
        [Display(Name = "Número de contacto")]
        public string Number { get; set; }

        //public User User { get; set; }
    }
}
