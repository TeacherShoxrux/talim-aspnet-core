
using Microsoft.EntityFrameworkCore;
using Talim.Data;
using Talim.Data.Seed;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options => options
        .UseSqlite(builder.Configuration
        .GetConnectionString("DefaultConnection")));

var app = builder.Build();
Seed.SeedData(builder.Services.BuildServiceProvider().GetRequiredService<ApplicationDbContext>());

if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();
