using Catalog.Application.Mappers;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data.Contexts;
using Catalog.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


#region Application

// AutoMapper Configration
builder.Services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBrandRepository, ProductRepository>();
builder.Services.AddScoped<ITypeRepository, ProductRepository>();

#endregion

/* to apiVersion cofigration 
install asp.apiVersion.Mvc from NuGet

*/
builder.Services.AddApiVersioning(options => {
        
options.ReportApiVersions= true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);

});

// Swagger configration


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{
        Title = "Catalog API",
        Version = "v1",
         Description ="this is catalog project inside the ecommerce big ecommerce",

         Contact = new Microsoft.OpenApi.Models.OpenApiContact{ Name = "Mohamed Zidan",
         Email ="mohamedzidan6846@gmail.com",
         Url = new Uri( "https://amtaraqar.com")
         }


    });
});

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseAuthorization();

app.MapControllers();

app.Run();
