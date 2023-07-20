using System;
using Parenting.Server.Models;
using Parenting.Server.Dto;


namespace Parenting.Server.Interfaces
{
	public interface IPhotoService
	{
        Task<List<GetPhotoDto>> DeletePhoto(int id);
        Task<GetPhotoDto> UpdateProductPhoto(Photo photo);
        Task<GetPhotoDto> AddPhoto(Photo newPhoto);
    }
}

