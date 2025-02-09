using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common;
using Karen_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Karen_Store.Application.Services.Products.Queries.GetProductsForSite
{
    public class GetProductsForSite : IGetProductsForSite
    {
        private readonly IDatabaseContext _context;
        public GetProductsForSite(IDatabaseContext context)
        {
            _context=context;   
        }
        public ResultDto<ResultProductForSiteDto> Execute(string searchKey, int page, long? CatId)
        {
            try
            {  
            int tottalrow = 0;
                var productquery = _context.Products.Where(p => p.Displayed != false)
                    .Include(x => x.ProductImages).AsQueryable();
                if (CatId != null)
                {
                    productquery = productquery.Where (p=> p.CategoryId == CatId || p.Category.ParentCategoryId == CatId).AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchKey))
                {
                    productquery = productquery.Where(p => p.Name.Contains(searchKey.ToString())|| p.Brand.Contains(searchKey) ).AsQueryable();
                }
                var product = productquery.ToPaged(page, 5, out tottalrow);
                if (product.Any())
            {
                return new ResultDto<ResultProductForSiteDto>
                {
                    IsSuccess = true,
                    Message = "successful",
                    Data = new ResultProductForSiteDto
                    {
                        TottalRows = tottalrow,
                        Products = product.Select(p => new ProductForSiteDto
                        {
                            Id = p.Id,
                            Title = p.Name,
                            Price=p.Price,
                            ImageSrc = p.ProductImages.FirstOrDefault().Src
                        }).ToList(),
                    }
                };
            }
            return new ResultDto<ResultProductForSiteDto>
            {
                IsSuccess = false,
                Message = "محصولی یافت نشد"
            };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
