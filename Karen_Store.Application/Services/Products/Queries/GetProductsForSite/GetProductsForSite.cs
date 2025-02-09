using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common;
using Karen_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Karen_Store.Application.Services.Products.Queries.GetProductsForSite
{
    public class GetProductsForSite : IGetProductsForSite
    {
        private readonly IDatabaseContext _context;
        public GetProductsForSite(IDatabaseContext context)
        {
            _context=context;   
        }
        public ResultDto<ResultProductForSiteDto> Execute(OrderBy orderBy, string searchKey, int page,int pageSize, long? CatId)
        {
            try
            {  
            int totalRows = 0;
                var productQuery = _context.Products.Where(p => p.Displayed != false)
                    .Include(x => x.ProductImages).AsQueryable();
                if (CatId != null)
                {
                    productQuery = productQuery.Where (p=> p.CategoryId == CatId || p.Category.ParentCategoryId == CatId).AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchKey))
                {
                    productQuery = productQuery.Where(p => p.Name.Contains(searchKey.ToString())|| p.Brand.Contains(searchKey) ).AsQueryable();
                }
                switch (orderBy)
                {
                    case OrderBy.NotOrder:
                        productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                        break;
                    case OrderBy.MostVisited:
                        productQuery = productQuery.OrderByDescending(p => p.ViewCount).AsQueryable();
                        break;
                    case OrderBy.Bestselling:
                        productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                        break;
                    case OrderBy.MostPopular:
                        productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                        break;
                    case OrderBy.theNewest:
                        productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                        break;
                    case OrderBy.Cheapest:
                        productQuery = productQuery.OrderBy(p => p.Price).AsQueryable();
                        break;
                    case OrderBy.theMostExpensive:
                        productQuery = productQuery.OrderByDescending(p => p.Price).AsQueryable();
                        break;
                    default:
                        break;
                }
                var product = productQuery.ToPaged(page, pageSize, out totalRows);
                if (product.Any())
            {
                return new ResultDto<ResultProductForSiteDto>
                {
                    IsSuccess = true,
                    Message = "successful",
                    Data = new ResultProductForSiteDto
                    {
                        TotalRows = totalRows,
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
