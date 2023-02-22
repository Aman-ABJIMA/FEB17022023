using AutoMapper.Internal.Mappers;
using Data;
using Data.Repositories;
using DataInterfaces;
using Domain;
using FormatAPI.Infrastructure.Handlers;
using FormatAPI.Infrastructure.Handlers.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceInterfaces;
using Services.Infrastructure;
using Services.Infrastructure.Builders;
using Services.Infrastructure.Builders.Interfaces;
using Services.Infrastructure.Builders.Mapper;
using Services.Infrastructure.Handlers;
using Services.Infrastructure.Handlers.Interfaces;

namespace FormatAPI
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
            //builder.Services.AddDbContext<AppDbContext>(options=>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});
            builder.Services.AddAutoMapper(typeof(EmployeeToDTOMapping).Assembly);
           

            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddTransient<IEmployeeHandler,EmployeeHandler>();  
            builder.Services.AddTransient<IEmployeeServiceHandler,EmployeeServiceHandler>();
            builder.Services.AddTransient<IEmployeeBuilder, EmployeeBuilder>();
            builder.Services.AddTransient<IEmployeeService,EmployeeService>();
            builder.Services.AddCustomDatabase(builder.Configuration);
           
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