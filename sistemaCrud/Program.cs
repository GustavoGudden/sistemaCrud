using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using sistemaCrud.Data;
using sistemaCrud.interfaces;
using sistemaCrud.repositories;
using sistemaCrud.Services;

namespace sistemaCrud
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

            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<SistemaTarefasDBContext>(
                opstions => opstions.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                
                );

           
            builder.Services.AddScoped<IUserInterface, UserRepository>(); // Registre IUserInterface para UserRepository
            builder.Services.AddScoped<IUserServiceInterface, UserService>(); // Registre IUserServiceInterface para UserService



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