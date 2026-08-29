var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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
