using AppDiaria.Aplication.Interfaces;

using AppDiaria.Infreaestructure.DB;
using AppDiaria.Infreaestructure.Repositorios;
using Microsoft.EntityFrameworkCore;
using AppDiaria.Aplication.DI_Container;
using AppDiaria.Infraestructure;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///controlador
builder.Services.AddControllers();

/*builder.Services.AddScoped<AppDiariaContext>(); ya no se necesita porque ahora usamos migraciones
builder.Services.AddDbContext<AppDiariaContext>(options =>
    options.UseSqlite("Data Source=AppDiaria.sqlite")
);*/
builder.Services.AddDbContext<AppDiariaContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);





////servicios y repo  
builder.Services.AddApplication(); //para el DI-container
builder.Services.AddInfrastructure();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapControllers();


app.Run();


record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
