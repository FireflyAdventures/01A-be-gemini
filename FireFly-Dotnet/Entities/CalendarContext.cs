using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Calendar_Dotnet.Entities
{
    public partial class CalendarContext : DbContext
    {
        public CalendarContext()
        {
        }

        public CalendarContext(DbContextOptions<CalendarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Events> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=34.123.144.175;Database=calendar;User Id=sqlserver;Password=Fireflydeveloper;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>(entity =>
            {
                entity.ToTable("Events");

                // You might want to use appropriate data types instead of MaxLength
                entity.Property(e => e.startDate).HasColumnType("datetime2(7)");
                entity.Property(e => e.endDate).HasColumnType("datetime2(7)");
                entity.Property(e => e.title).HasMaxLength(255);
                entity.Property(e => e.location).HasMaxLength(255);
                entity.Property(e => e.description).HasMaxLength(255);
                entity.Property(e => e.createDate).HasColumnType("datetime2(7)");
                entity.Property(e => e.createId).HasColumnType("int");
                entity.Property(e => e.modifyDate).HasColumnType("datetime2(7)");
                entity.Property(e => e.modifyId).HasColumnType("int");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
