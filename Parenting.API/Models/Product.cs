using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parenting.Server.Models   
{
	public class Product
	{
		
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }
        public ICollection<Photo> Photos { get; set; }

    }

}

