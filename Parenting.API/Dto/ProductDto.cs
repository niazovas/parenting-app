using System;
namespace Parenting.Server.Dto
{
	public class ProductDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public IFormFile ImagePath { get; set; }
        public int SubCategoryId { get; set; }
    }
    public class ProductResponceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string ImagePath { get; set; }
        public int SubCategoryId { get; set; }
    }
}

