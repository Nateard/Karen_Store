using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Karen_Store.Application.Services.Products.Queries.GetProducDetailsForSite
{
    public class GetProducDetailsForSite : IGetProducDetailsForSite
    {
        private readonly IDatabaseContext _context;

        public GetProducDetailsForSite(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductForSiteDto> Execute(long id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p=> p.ProductImages)
                .Include (p=> p.ProductFeatures)
                .FirstOrDefault(p=> p.Id == id);
            if (product == null)
            {
                return new ResultDto<ProductForSiteDto>()
                {
                    IsSuccess = false,  
                    Message = "محصول یافت نشد",
                };
            }
            product.ViewCount++;
            _context.SaveChanges();
            return new ResultDto<ProductForSiteDto>
            {
                IsSuccess = true,  
                Data = new ProductForSiteDto
                {
                    Brand = product.Brand,
                    Category = $"{product.Category.ParentCategory.Name} - {product.Category.Name} ",
                    Description = product.Description,
                    Features = product.ProductFeatures.Select(p => new ProductDetailsForSize_FeaturesDto
                    {
                        DisplayText = p.DisplayName,
                        Value = p.Value,
                    }).ToList(),
                    Images = product.ProductImages.Select(p => p.Src).ToList(),
                    Price = product.Price,
                    Title = product.Name,
                    Id = product.Id
                }
                
            };
            
        }
        

    }
}
