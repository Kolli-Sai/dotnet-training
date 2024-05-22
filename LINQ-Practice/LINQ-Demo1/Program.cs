
using LINQ_Demo1.Contracts;
using LINQ_Demo1.Data;
using LINQ_Demo1.Services;
using Microsoft.EntityFrameworkCore;

namespace LINQ_Demo1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add db context to services
            builder.Services.AddDbContext<LINQDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("LINQDemoCS")));
            builder.Services.AddScoped<ILinqMethodsServices, LinqMethodsServices>();

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
