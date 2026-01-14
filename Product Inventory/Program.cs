
using ProductInventory.APPLICATION.Interfaces;
using ProductInventory.APPLICATION.Services;
using ProductInventory.INFRASTRUCTURE.Data;
using ProductInventory.INFRASTRUCTURE.Repository;

namespace Product_Inventory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<DapperContext>();

            builder.Services.AddScoped<IStockRepository, StockRepository>();
            builder.Services.AddScoped<IStockService, StockService>();
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
