
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Talim.Data;
using Talim.Data.Entity;
using Talim.Data.Seed;
using Talim.Repositories;
using Talim.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSwaggerGen(
    c=>c.SwaggerDoc("v1",new OpenApiInfo{Title="Aspnet Core Api", Version="v1"})
);
// Add Auhentication JWT token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option=>{
    option.TokenValidationParameters=new TokenValidationParameters{
        ValidateAudience=true,
        ValidateIssuer=true,
        ValidateLifetime=true,
        ValidateIssuerSigningKey=true,
        ValidIssuer=builder.Configuration["Jwt:Issuer"],
        ValidAudience=builder.Configuration["Jwt:Audience"],
        ClockSkew=TimeSpan.Zero,
        IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    }; 
});
    builder.Services.AddScoped<IJWTService,JWTService>();
    builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
    builder.Services.AddScoped<IUserService,UserService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options
        .UseSqlite(builder.Configuration
        .GetConnectionString("DefaultConnection")));

var app = builder.Build();
Seed.SeedData(builder.Services.BuildServiceProvider().GetRequiredService<ApplicationDbContext>());
app.UseHttpsRedirection();
if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
