using System;
using System.Collections.Generic;
using System.Text;
using BicycleRenting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleRenting.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.CustomerId);
            builder
                .Property(c => c.CustomerId)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder
                .Property(c => c.FirstName)
                .IsRequired();
            builder
                .Property(c => c.LastName)
                .IsRequired();
            builder
                .Property(c => c.DateOfBirth)
                .IsRequired();
            builder
                .Property(c => c.Email)
                .IsRequired();
            builder
                .Property(c => c.PhoneNumber)
                .IsRequired(false);
            builder
                .HasMany(c => c.Reservations)
                .WithOne(r => r.Customer);
        }
    }
}
