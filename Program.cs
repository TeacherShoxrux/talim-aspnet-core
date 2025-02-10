
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Talim.Data;
using Talim.Data.Entity;
using Talim.Data.Seed;
using Talim.DTOs;
using Talim.Repositories;
using Talim.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Allow any origin
              .AllowAnyMethod() // Allow any HTTP method (GET, POST, PUT, DELETE, etc.)
              .AllowAnyHeader(); // Allow any headers
    });
});
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
    builder.Services.AddScoped<IEducationTypeService,EducationTypeService>();
    builder.Services.AddScoped<IEducationDirectionService,EducationDirectionService>();
    builder.Services.AddScoped<ISubjectService,SubjectService>();
    builder.Services.AddScoped<IThemeService,ThemeService>();
    builder.Services.AddScoped<IFileService,FileService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options
        .UseSqlite(builder.Configuration
        .GetConnectionString("DefaultConnection")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    Seed.SeedData(context);
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var dir= builder.Configuration["StoragePath"]??Path.Combine(Directory.GetCurrentDirectory(), "Static");
System.Console.WriteLine(dir);
System.Console.WriteLine("-----------------------");
if (!File.Exists(dir))
{
    Directory.CreateDirectory(dir);
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(dir),
    RequestPath = "/files"
});

app.UseDefaultFiles();
app.MapControllers();


app.Run();
