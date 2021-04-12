using System;
using System.Collections.Generic;
using System.Text;
using BicycleRenting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleRenting.EntityConfigurations
{
    public class BicycleConfiguration : IEntityTypeConfiguration<Bicycle>
    {
        public void Configure(EntityTypeBuilder<Bicycle> builder)
        {
            builder
                .HasKey(b => b.BicycleId);
            builder
                .Property(b => b.BicycleId)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder
                .HasMany(b => b.Reservations)
                .WithMany(r => r.Bicycles);

            builder
                .HasOne(b => b.Brand)
                .WithMany(br => br.Bicycles)
                .HasForeignKey(x => x.BrandForeignKey);
        }
    }
}
