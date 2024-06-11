using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIAndreVehicles.Buy.Data
{
    public class APIAndreVehiclesBuyContext : DbContext
    {
        public APIAndreVehiclesBuyContext (DbContextOptions<APIAndreVehiclesBuyContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Car { get; set; } = default!;
        public DbSet<Models.Buy> Buys { get; set; } = default!;
    }
}
