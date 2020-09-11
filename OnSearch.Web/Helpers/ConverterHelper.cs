using OnSearch.Web.Data;
using OnSearch.Web.Entities;
using OnSearch.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnSearch.Web.Helpers
{
    public class ConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly CombosHelper _combosHelper;

        public ConverterHelper(
            DataContext dataContext,
            CombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }

        public Category ToCategory(CategoryViewModel model, Guid imageId, bool isNew)
        {
            return new Category
            {
                Id = isNew ? 0 : model.Id,
                ImageId = imageId,
                Name = model.Name
            };
        }

        public CategoryViewModel ToCategoryViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                ImageId = category.ImageId,
                Name = category.Name
            };
        }

        public async Task<Product> ToProductAsync(ProductViewModel model, bool isNew)
        {
            return new Product
            {
                Category = await _dataContext.Categories.FindAsync(model.CategoryId),
                Description = model.Description,
                Id = isNew ? 0 : model.Id,
                IsActive = model.IsActive,
                //IsStarred = model.IsStarred,
                Name = model.Name,
                Price = model.Price,
                ProductImages = model.ProductImages
            };
        }

        public ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Categories = _combosHelper.GetComboCategories(),
                Category = product.Category,
                CategoryId = product.Category.Id,
                Description = product.Description,
                Id = product.Id,
                IsActive = product.IsActive,
                //IsStarred = product.IsStarred,
                Name = product.Name,
                Price = product.Price,
                ProductImages = product.ProductImages
            };
        }

    }

}
