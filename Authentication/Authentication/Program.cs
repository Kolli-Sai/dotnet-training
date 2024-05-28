
using Authentication.Config.AutoMapper;
using Authentication.Core.Contracts.Repositories;
using Authentication.Core.Contracts.Services;
using Authentication.Core.Options;
using Authentication.Infrastructure.Contexts;
using Authentication.Infrastructure.Repositories;
using Authentication.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Authentication
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
            builder.Services.AddDbContext<AuthDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbCs")));

            builder.Services.Configure<JwtTokenOptions>(builder.Configuration.GetSection("JwtToken"));

            builder.Services.AddSingleton(AutoMapperConfiguration.InitializeAutoMapper());

            builder.Services.AddScoped<IPasswordHelperService, PasswordHelperService>();

            builder.Services.AddScoped<IUserRepository,UserRepository>();
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
