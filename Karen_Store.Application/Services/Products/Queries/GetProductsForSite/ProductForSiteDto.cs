﻿namespace Karen_Store.Application.Services.Products.Queries.GetProductsForSite
{
    public class ProductForSiteDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? ImageSrc { get; set; }
        public int Star {  get; set; }
        public int Price { get; set; }  
    }
}
