using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parenting.Server.Models;

namespace Parenting.Server.Data;

    class SubCategoryTableConfiguration:IEntityTypeConfiguration<SubCategory>
	{
		public void Configure(EntityTypeBuilder<SubCategory> builder)
		{

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.HasMany(e => e.Products)
         .WithOne(e => e.SubCategory)
         .HasForeignKey(e => e.SubCategoryId)
         .HasPrincipalKey(e => e.Id);


    }
	}


