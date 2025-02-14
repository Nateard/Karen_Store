using Karen_Store.Application.Services.Common.Commands;
using Karen_Store.Common.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Karen_Store.Common
{
    public static class ImageUploadExtensions
    {
        public static ResultDto<UploadDto> ImageUpload (this IFormFile file, IHostingEnvironment environment, string fileSaveTo)
        {
            if (file != null)
            {
                string folder = string.IsNullOrEmpty(fileSaveTo) ? "images" : Path.Combine("images", fileSaveTo);
                var uploadsRootFolder = Path.Combine(environment.WebRootPath, folder);

                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }

                if (file.Length == 0)
                {
                    return new ResultDto<UploadDto>
                    {
                        IsSuccess = false,
                        Message = "Upload Failed"
                    };
                }

                string fileName = DateTime.Now.Ticks + Path.GetFileName(file.FileName);
                var filePath = Path.Combine(uploadsRootFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new ResultDto<UploadDto>
                {
                    IsSuccess = true,
                    Data = new UploadDto
                    {
                        FileNameAddress = Path.Combine(folder, fileName)
                    }
                };
            }
            return null;
        }
    }
}
