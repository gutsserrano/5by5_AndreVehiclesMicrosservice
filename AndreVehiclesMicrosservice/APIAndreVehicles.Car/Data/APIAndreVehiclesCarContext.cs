using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIAndreVehicles.Car.Data
{
    public class APIAndreVehiclesCarContext : DbContext
    {
        public APIAndreVehiclesCarContext (DbContextOptions<APIAndreVehiclesCarContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Car { get; set; } = default!;
    }
}
