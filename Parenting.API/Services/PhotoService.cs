using Parenting.Server.Data;
using Parenting.Server.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Parenting.Server.Dto;
using Parenting.Server.Interfaces;

namespace Parenting.Server.Services
{
	public class PhotoService:IPhotoService
	{
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PhotoService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetPhotoDto> AddPhoto(Photo newPhoto)
        {
            if (newPhoto is not null)
            {
                _context.Photos.Add(newPhoto);

                await _context.SaveChangesAsync();
            }
            return _mapper.Map<GetPhotoDto>(newPhoto);
        }

        public async Task<List<GetPhotoDto>> DeletePhoto(int id)
        {
            var photo = await _context.Photos
              .FirstOrDefaultAsync(e => e.Id == id);
            if (photo is null)
                throw new Exception("$\"Product with Id '{updateCategory.Id}' is not found.\"");
            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();

            var photos = await _context.Photos.ToListAsync();
            return photos.Select(e => _mapper.Map<GetPhotoDto>(e)).ToList();
        }

        public async Task<GetPhotoDto> UpdateProductPhoto(Photo photoupdate)
        {
            var photo = await _context.Photos
                .FirstOrDefaultAsync(e => e.Id == photoupdate.Id );

            if (photo is null)
                throw new Exception("$\"Photo with Id '{updateCategory.Id}' is not found.\"");


            photo.FileName = photoupdate.FileName;
            photo.FileExtension = photoupdate.FileExtension;
            photo.Size = photoupdate.Size;
           
        await _context.SaveChangesAsync();
            return _mapper.Map<GetPhotoDto>(photo);
        }
    }
}

