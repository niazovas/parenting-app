using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using Parenting.Server.Models;

namespace Parenting.Server.Dto
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int SubCategoryId { get; set; }

    }
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int SubCategoryId { get; set; }

    }
    public class AddProductDto
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public int SubCategoryId { get; set; }




    }
}

