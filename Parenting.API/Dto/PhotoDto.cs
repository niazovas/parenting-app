using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parenting.Server.Dto
{
    public class GetPhotoDto
    {
        public int Id { get; set; }
        public string FileExtension { get; set; }
        public decimal Size { get; set; }
        public string FileName { get; set; }
        public int ProductId { get; set; }
    }


    public class AddPhotoDto
    {
        public int ProductId { get; set; }
        [FromForm]
        [NotMapped]
        public IFormFile File { get; set; }
    }


    public class UpdatePhotoDto
    {
        public int Id { get; set; }
        [FromForm]
        [NotMapped]
        public IFormFile File { get; set; }
    }
}

