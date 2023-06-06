using System;
using Parenting.Server.Models;

namespace Parenting.Server.Dto
{
	public class SubCategoryDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
       

        public int CategoryId { get; set; }
    }
}

