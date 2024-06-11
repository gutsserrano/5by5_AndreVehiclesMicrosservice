using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIAndreVehicles.Client.Data
{
    public class APIAndreVehiclesClientContext : DbContext
    {
        public APIAndreVehiclesClientContext (DbContextOptions<APIAndreVehiclesClientContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Person>? People { get; set; } = default!;
        public DbSet<Models.Client> Clients { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>()
                .ToTable("Address");

            modelBuilder.Entity<Person>()
                .ToTable("People");

            modelBuilder.Entity<Person>()
                .HasKey(p => p.Document);

            modelBuilder.Entity<Models.Client>()
                .ToTable("Client");

        }
    }
}
