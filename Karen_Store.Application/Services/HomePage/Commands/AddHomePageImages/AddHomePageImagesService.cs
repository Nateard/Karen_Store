using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common;
using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Hosting;
namespace Karen_Store.Application.Services.HomePages.AddHomePageImages
{
    public class AddHomePageImagesService : IAddHomePageImagesService
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddHomePageImagesService(IDatabaseContext context, IHostingEnvironment hosting)
        {
            _context = context;
            _environment = hosting;
        }
        public ResultDto Execute(requestAddHomePageImagesDto request, string saveTo)
        {

            var resultUpload = request.file.ImageUpload(_environment, saveTo);

            HomePageImages homePageImages = new HomePageImages()
            {
                Link = request.Link,
                Src = resultUpload.Data.FileNameAddress,
                Location = request.ImageLocation,
            };
            _context.HomePageImage.Add(homePageImages);
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }


        //private UploadDto UploadFile(IFormFile file)
        //{
        //    if (file != null)
        //    {
        //        string folder = $@"images\HomePages\Slider\";
        //        var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
        //        if (!Directory.Exists(uploadsRootFolder))
        //        {
        //            Directory.CreateDirectory(uploadsRootFolder);
        //        }


        //        if (file == null || file.Length == 0)
        //        {
        //            return new UploadDto()
        //            {
        //                Status = false,
        //                FileNameAddress = "",
        //            };
        //        }

        //        string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
        //        var filePath = Path.Combine(uploadsRootFolder, fileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            file.CopyTo(fileStream);
        //        }

        //        return new UploadDto()
        //        {
        //            FileNameAddress = folder + fileName,
        //            Status = true,
        //        };
        //    }
        //    return null;
        //}
    }
}
