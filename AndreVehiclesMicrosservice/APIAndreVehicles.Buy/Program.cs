using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIAndreVehicles.Buy.Data;
namespace APIAndreVehicles.Buy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<APIAndreVehiclesBuyContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("APIAndreVehiclesBuyContext") ?? throw new InvalidOperationException("Connection string 'APIAndreVehiclesBuyContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
