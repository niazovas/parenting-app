using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parenting.Server.Models
{
	public class Photo
	{
        public int Id { get; set; }
        public string FileExtension { get; set; }
        public decimal Size { get; set; }
        public string FileName { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}

