using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroAPI.Data;
using SistemaDeCadastroAPI.Repositorios;
using SistemaDeCadastroAPI.Repositorios.Intefaces;

namespace SistemaDeCadastroAPI
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
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaCadastroDBContex>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );
            builder.Services.AddEntityFrameworkSqlServer()
               .AddDbContext<DB_testeContext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
               );
            builder.Services.AddScoped<IUsuarioRepositorio,UsuarioRepositorio>();
            builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            

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