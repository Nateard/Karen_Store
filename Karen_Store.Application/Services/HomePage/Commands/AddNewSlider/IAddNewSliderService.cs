using Karen_Store.Application.Interfaces.Context;
using Karen_Store.Common.Dto;
using Karen_Store.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Karen_Store.Application.Services.HomePage.Commands.AddNewSlider
{
    public interface IAddNewSliderService
    {
        ResultDto Execute(IFormFile file, string link ,string name);
    }

    public class AddNewSliderService : IAddNewSliderService
    {
        public readonly IHostingEnvironment _environment;
        private readonly IDatabaseContext _context;
        public AddNewSliderService(IDatabaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDto Execute(IFormFile file, string link, string name)
        {
            try
            {
                var resultUpload = UploadFile(file);
                Slider slider = new Slider()
                {
                    Name = name,
                    Src = resultUpload.FileNameAddress,
                    Link = link              
                };
                _context.Sliders.Add(slider);
                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
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
                string folder = $@"images\HomePage\Slider\";
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
