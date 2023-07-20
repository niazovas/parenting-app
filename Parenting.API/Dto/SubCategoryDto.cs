using System;
using Parenting.Server.Models;

namespace Parenting.Server.Dto
{
    public class UpdateSubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }

    public class AddSubCategoryDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }

    public class GetSubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}

