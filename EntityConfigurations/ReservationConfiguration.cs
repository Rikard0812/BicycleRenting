using System;
using System.Collections.Generic;
using System.Text;
using BicycleRenting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleRenting.EntityConfigurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .HasKey(r => r.ReservationId);
            builder
                .Property(r => r.ReservationId)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder
                .Property(r => r.StartDate)
                .IsRequired();
            builder
                .Property(r => r.StartDate)
                .IsRequired();
            builder
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations);
            builder
                .HasMany(r => r.Bicycles)
                .WithMany(b => b.Reservations);
        }
    }
}
