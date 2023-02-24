using Data.Repositories;
using DataInterfaces;
using FormatAPI.Infrastructure.Handlers;
using FormatAPI.Infrastructure.Handlers.Interfaces;
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
           // builder.Services.AddSwaggerGen();
        
            builder.Services.AddAutoMapper(typeof(EmployeeToDTOMapping).Assembly);
           

            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddTransient<IEmployeeHandler,EmployeeHandler>();  
            builder.Services.AddTransient<IEmployeeServiceHandler,EmployeeServiceHandler>();
            builder.Services.AddTransient<IEmployeeBuilder, EmployeeBuilder>();
            builder.Services.AddTransient<IEmployeeService,EmployeeService>();
            builder.Services.AddCustomDatabase(builder.Configuration);
            builder.Services.AddOpenApiDocument(c=>
            {
                c.DocumentName = "v1";
                c.PostProcess = doc =>
                {
                    doc.Info.Version = "v1";
                    doc.Info.Title = "Employee Details Web API";
                    doc.Info.Description = "This is Employee Details API where You can create , update , read and delete the info of employees.";
                    doc.Info.License = new NSwag.OpenApiLicense()
                    {
                        Name = "Employee Details",
                    };
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Aman Singh",
                        Email = "aman.singh@abjima.com"
                    };
                };
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                  app.UseOpenApi();
                  app.UseSwaggerUi3();
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}