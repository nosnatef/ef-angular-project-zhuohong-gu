using HotelManagement.Core;
using HotelManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Infrastructure.Data
{
    public class HotelManagementDbContext : DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomType>(ConfigureRoomType);
            modelBuilder.Entity<Room>(ConfigureRoom);
            modelBuilder.Entity<Service>(ConfigureService);
            modelBuilder.Entity<Customer>(ConfigureCustomer);
        }

        private void ConfigureRoomType(EntityTypeBuilder<RoomType> builder)
        {
            builder.ToTable("RoomType");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Description).HasMaxLength(256);
            builder.Property(r => r.Rent).HasColumnType("money");
        }

        private void ConfigureRoom(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Status).HasDefaultValue(true);
            builder.HasOne(r => r.RoomType).WithMany(r => r.Rooms).HasForeignKey(r => r.RoomTypeId);
        }

        private void ConfigureService(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Description).HasMaxLength(50);
            builder.Property(r => r.Amount).HasColumnType("money");
            builder.Property(r => r.ServiceDate).HasDefaultValueSql("getdate()");
            builder.HasOne(r => r.Room).WithMany(r => r.Services).HasForeignKey(r => r.RoomId);
        }

        private void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).HasMaxLength(20);
            builder.Property(r => r.Phone).HasMaxLength(20);
            builder.Property(r => r.Address).HasMaxLength(100);
            builder.Property(r => r.Phone).HasMaxLength(20);
            builder.Property(r => r.Email).HasMaxLength(40);
            builder.Property(r => r.Checkin).HasDefaultValueSql("getdate()");
            builder.Property(r => r.Advance).HasColumnType("money");
        }

        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
