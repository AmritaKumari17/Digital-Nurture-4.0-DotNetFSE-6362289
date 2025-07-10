using EmployeeApiDemo.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>(); // Global exception filter
});
builder.Services.AddScoped<CustomAuthFilter>();  // Register Auth filter
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Swagger Demo",
        Version = "v1",
        Description = "Custom Employee WebAPI",
        Contact = new OpenApiContact
        {
            Name = "John Doe",
            Email = "john@xyzmail.com",
            Url = new Uri("https://example.com")
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
