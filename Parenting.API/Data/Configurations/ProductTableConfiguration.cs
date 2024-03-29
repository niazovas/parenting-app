﻿using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parenting.Server.Models;

namespace Parenting.Server.Data;

class ProductTableConfiguration:IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.HasMany(e => e.Photos)
     .WithOne(e => e.Product)
     .HasForeignKey(e => e.ProductId)
     .HasPrincipalKey(e => e.Id);

    }

}

