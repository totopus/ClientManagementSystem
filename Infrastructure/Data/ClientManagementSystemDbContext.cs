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
    public class ClientManagementSystemDbContext : DbContext
    {
        public ClientManagementSystemDbContext(DbContextOptions<ClientManagementSystemDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //specify Fluent API rules for your Entities

            modelBuilder.Entity<Interaction>(ConfigureInteraction);


        }

        private void ConfigureInteraction(EntityTypeBuilder<Interaction> builder)
        {
            builder.ToTable("Interaction");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.IntType).HasMaxLength(1);
            builder.Property(e => e.Remarks).HasMaxLength(500);
            builder.HasOne(u => u.Client).WithMany(r => r.Interactions).HasForeignKey(u => u.ClientId);
            builder.HasOne(r => r.Employee).WithMany(u => u.Interactions).HasForeignKey(r => r.EmpId);

        }

        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
