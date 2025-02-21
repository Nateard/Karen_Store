using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Application.Validation.ProductValidation;
using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace Karen_Store.Application.Services.Products.Commands.AddNewProduct
{
    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewProductService(IDataBaseContext Context, IHostingEnvironment hostingEnvironment)
        {
            _context = Context;
            _environment = hostingEnvironment;
        }

        public ResultDto Execute(RequestAddProductDto request)
        {
            try
            {
                var validator = new RequestAddProductValidation();
                var validationResult = validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = string.Join(", ", errorMessages)
                    };
                }
                var category = _context.Categories.Find(request.CategoryId);
                if (category != null)
                {
                    Product product = new Product()
                    {
                        Name = request.Name,
                        Brand = request.Brand,
                        Category = category,
                        Description = request.Description,
                        Displayed = request.Displayed,
                        Inventory = request.Inventory,
                        Price = request.Price,

                    };
                    _context.Products.Add(product);

                    List<ProductImages> productImages = new List<ProductImages>();
                    foreach (var item in request.Images)
                    {
                        var uploadedResult = UploadFile(item);
                        productImages.Add(new ProductImages
                        {
                            Product = product,
                            Src = uploadedResult.FileNameAddress,
                        });
                    }
                    _context.ProductImages.AddRange(productImages);

                    List<ProductFeatures> productFeatures = new List<ProductFeatures>();
                    foreach (var item in request.Features)
                    {
                        productFeatures.Add(new ProductFeatures
                        {
                            DisplayName = item.DisplayName,
                            Value = item.Value,
                            Product = product,
                        });
                    }
                    _context.ProductFeatures.AddRange(productFeatures);
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "محصول با موفقیت به محصولات فروشگاه اضافه شد",
                    };
                }
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "دسته بندی انتخاب شده یافت نشد"
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }

                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }


        public class UploadDto
        {
            public long Id { get; set; }
            public bool Status { get; set; }
            public string FileNameAddress { get; set; }
        }
    }
}
