using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnSearch.Web.Entities
{
    public class Product
    {

        public int Id { get; set; }

        // TODO: REFERENCIAR CON LA EMPRESA
        public string UserF { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [DisplayName("En Stock?")]
        public bool IsActive { get; set; }

        [Display(Name = "Categoría")]
        public Category Category { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        [DisplayName("Número de imagenes")]
        public int ProductImagesNumber => ProductImages == null ? 0 : ProductImages.Count;

        [Display(Name = "Imagen")]
        public string ImageFullPath => ProductImages == null || ProductImages.Count == 0
            ? $"https://localhost:44327/images/noimage.png"
            : ProductImages.FirstOrDefault().ImageFullPath;

        //public User User { get; set; }
        //public Company Company { get; set; }
      
    }
}
