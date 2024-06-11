using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIAndreVehicles.Operation.Data
{
    public class APIAndreVehiclesOperationContext : DbContext
    {
        public APIAndreVehiclesOperationContext (DbContextOptions<APIAndreVehiclesOperationContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Car { get; set; } = default!;
        public DbSet<Models.Operation> Operations { get; set; } = default!;

        public DbSet<Models.CarOperation>? CarOperations { get; set; }
    }
}
