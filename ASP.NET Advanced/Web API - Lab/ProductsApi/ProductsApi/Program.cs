namespace ProductsApi
{
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OpenApi.Models;

    using ProductsApi.Data;
    using ProductsApi.Services;
    using ProductsApi.Services.Contracts;

    using System.Reflection;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(o =>
            {
                    o.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                    o.OutputFormatters.RemoveType<StringOutputFormatter>();
            })
                .AddXmlSerializerFormatters();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(s =>
            {
                s.IncludeXmlComments("ProductsApi.xml");
            });

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAll", builder =>
            //    {
            //        builder.AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader();
            //    });
            //});

            builder.Services.AddDbContext<ProductDbContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IProductService, ProductService>();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.UseCors("AllowAll");

            app.MapControllers();

            app.Run();
        }
    }
}