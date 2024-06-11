using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIAndreVehicles.DataBaseManager.Data
{
    public class APIAndreVehiclesDataBaseManagerContext : DbContext
    {
        public APIAndreVehiclesDataBaseManagerContext (DbContextOptions<APIAndreVehiclesDataBaseManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Car { get; set; } = default!;
        public DbSet<Models.Operation> Operations { get; set; } = default!;
        public DbSet<Models.CarOperation> CarOperations { get; set; } = default!;
        public DbSet<Models.Person>? People { get; set; } = default!;
        public DbSet<Models.Client>? Clients { get; set; } = default!;
        public DbSet<Models.Employee>? Employees { get; set; } = default!;
        public DbSet<Models.Buy>? Buys { get; set; } = default!;
        public DbSet<Models.Card>? Card { get; set; } = default!;
        public DbSet<Models.BankSlip>? BankSlips { get; set; } = default!;
        public DbSet<Models.Pix>? Pixes { get; set; } = default!;
        public DbSet<Models.PixType>? PixTypes { get; set; } = default!;
        public DbSet<Models.Payment>? Payments { get; set; } = default!;
        public DbSet<Models.Sell>? Sells { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>()
                .ToTable("Address");

            modelBuilder.Entity<Car>()
                .ToTable("Car");

            modelBuilder.Entity<Operation>()
                .ToTable("Operations");

            modelBuilder.Entity<CarOperation>()
                .ToTable("CarOperations");

            modelBuilder.Entity<CarOperation>()
                .HasOne<Car>()
                .WithMany();

            modelBuilder.Entity<CarOperation>()
                .HasOne<Operation>()
                .WithMany();

            modelBuilder.Entity<Person>()
                .ToTable("People");

            modelBuilder.Entity<Person>()
                .HasKey(p => p.Document);

            modelBuilder.Entity<Client>()
                .ToTable("Client");

            modelBuilder.Entity<Employee>()
                .ToTable("Employee");

            modelBuilder.Entity<Position>()
                .ToTable("Position");

            modelBuilder.Entity<Buy>()
                .ToTable("Buys");

            modelBuilder.Entity<Card>()
                .ToTable("Card");

            modelBuilder.Entity<BankSlip>()
                .ToTable("BankSlips");

            modelBuilder.Entity<Pix>()
                .ToTable("Pixes");

            modelBuilder.Entity<Pix>()
                .HasOne<PixType>()
                .WithMany();

            modelBuilder.Entity<PixType>()
                .ToTable("PixTypes");

            modelBuilder.Entity<Payment>()
                .ToTable("Payments");

            modelBuilder.Entity<Sell>()
                .ToTable("Sells");

        }
    }
}
