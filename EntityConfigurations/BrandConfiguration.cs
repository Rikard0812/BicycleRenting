using System;
using System.Collections.Generic;
using System.Text;
using BicycleRenting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleRenting.EntityConfigurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                .HasKey(brands => brands.BicycleBrand);
            builder
                .Property(brands => brands.BicycleBrand)
                .IsRequired();

            builder
                .HasMany(x => x.Bicycles)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandForeignKey);
        }
    }
}
