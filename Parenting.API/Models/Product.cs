using System;
namespace Parenting.Server.Models
{
	public class Product
	{
		
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string ImagePath { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }

}

