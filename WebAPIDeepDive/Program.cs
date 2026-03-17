var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // This adds all the services required for the contollers to work,
                                   // it then seperatly scans the entire assembly for controller suffix's
                                   // or attributes

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers(); // This has dependent services

app.Run();

