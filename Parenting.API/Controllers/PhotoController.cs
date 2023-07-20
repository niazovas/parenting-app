using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parenting.Server.Dto;
using Parenting.Server.Interfaces;
using Parenting.Server.Models;

namespace Parenting.Server.Controllers
{
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IPhotoService _photoService;

        public PhotoController(IWebHostEnvironment environment, IPhotoService photoService)
        {
            _photoService = photoService;
            _environment = environment;
        }

        [HttpPost]
        public async Task<GetPhotoDto> CreatePhoto([FromForm] AddPhotoDto photoAdd)
        {
            Photo photo = null;
            var formFile = photoAdd.File;
            {
                using (var memoryStream = new MemoryStream())
                {
                    await formFile.CopyToAsync(memoryStream);

                    if (memoryStream.Length < 2097152)
                    {
                        await SaveFile(memoryStream, formFile.FileName);
                        photo = new Photo()
                        {
                            FileExtension = Path.GetExtension(formFile.FileName),
                            Size = formFile.Length,
                            ProductId = photoAdd.ProductId,
                            FileName = formFile.FileName
                        };
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                }
            }
            return await _photoService.AddPhoto(photo);
        }




        [HttpPut]
        public async Task<GetPhotoDto> UpdatePhoto(UpdatePhotoDto photoUpdate)
        {
            Photo photo = null;
            var formFile = photoUpdate.File;

            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);

                if (memoryStream.Length < 2097152)
                {
                    await SaveFile(memoryStream, formFile.FileName);
                    photo = new Photo()
                    {
                        Id = photoUpdate.Id,
                        FileExtension = Path.GetExtension(formFile.FileName),
                        Size = formFile.Length,
                        FileName = formFile.FileName
                    };

                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }

            }
            return await _photoService.UpdateProductPhoto(photo);
        }



        [HttpDelete("{photoId}")]
        public Task<List<GetPhotoDto>> DeletePhoto(int photoId)
        {
            return _photoService.DeletePhoto(photoId);
        }



        private async Task SaveFile(Stream stream, string fileName)
        {
            var fullName = Path.Combine(_environment.WebRootPath, "images", fileName);

            await using FileStream fileStream = new(fullName, FileMode.OpenOrCreate);
            var buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = await stream.ReadAsync(buffer)) > 0)
            {
                await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead));
            }
        }
    }
}

