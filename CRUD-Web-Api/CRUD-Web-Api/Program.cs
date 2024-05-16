
using CRUD_Web_Api.Models;

namespace CRUD_Web_Api
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
            //builder.Services.AddSingleton<Igetlist, gestlist>();
            //builder.Services.AddSingleton(typeof(Igetlist),typeof(getlist));
            builder.Services.AddSingleton<IStudentOperations>(new StudentOperations());
            //builder.Services.AddSingleton<IStudentOperations, StudentOperations>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
