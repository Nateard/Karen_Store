﻿public class ProductForSiteDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public List<string> Images { get; set; }
        public List<ProductDetailsForSize_FeaturesDto> Features { get; set; }
    }
