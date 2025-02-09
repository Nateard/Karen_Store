using Microsoft.AspNetCore.Http;

namespace Karen_Store.Application.Services.Products.Commands.AddNewProduct
{
    public class RequestAddProductDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public long CategoryId { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<AddNewProduct_Features> Features { get; set; }

    }
}
