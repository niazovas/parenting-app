using System;
namespace Parenting.Server.Dto
{
	public class GetCategoryDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AddCategoryDto
    {
        public string Name { get; set; }
    }
}

