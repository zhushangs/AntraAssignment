using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ClientInformationDBContext : DbContext
    {
        public ClientInformationDBContext(DbContextOptions<ClientInformationDBContext> options) : base(options)
        {

        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Interactions> Interactions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employees>(ConfigureEmployees);
            builder.Entity<Clients>(ConfigureClients);
            builder.Entity<Interactions>(ConfigureInteractions);
        }
        private void ConfigureInteractions(EntityTypeBuilder<Interactions> builder)
        {
            builder.ToTable("Interactions");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.IntType).HasMaxLength(1);
            builder.Property(i => i.IntDate).HasDefaultValueSql("getdate()");
            builder.Property(i => i.Remarks).HasMaxLength(500);
            builder.HasOne(i => i.Employees).WithMany().HasForeignKey(c => c.EmpId);
            builder.HasOne(i => i.Clients).WithMany().HasForeignKey(c => c.ClientId);
        }

        private void ConfigureEmployees(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Password).HasMaxLength(10);
            builder.Property(e => e.Designation).HasMaxLength(50);
        }

        private void ConfigureClients(EntityTypeBuilder<Clients> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Email).HasMaxLength(50);
            builder.Property(c => c.Phones).HasMaxLength(30);
            builder.Property(c => c.Address).HasMaxLength(100);
            builder.Property(c => c.AddedOn).HasDefaultValueSql("getdate()");
            builder.HasOne(c=> c.Employees).WithMany().HasForeignKey(c=>c.AddedBy);
        }
    }
}
