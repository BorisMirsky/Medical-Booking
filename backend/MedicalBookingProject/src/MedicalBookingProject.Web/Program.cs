using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.DataAccess;
using MedicalBookingProject.DataAccess.Repo;
//using MedicalBookingProject.DataAccess.Repo;
using MedicalBookingProject.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<MedicalBookingDbContext>(options => options.UseSqlite(connection));
builder.Services.AddScoped<ISheduleService, SheduleService>();
builder.Services.AddScoped<ISheduleRepo, ShedulesRepo>();
builder.Services.AddScoped<IUsersDoctorService, UserDoctorService>();




builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;           
})
.AddJwtBearer(opt =>
{                          
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = true;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(builder.Configuration["JWT:SecretKey"]!)),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"]!,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"]!,
        ValidateLifetime = true,
    };
});

builder.Services.AddAuthorization();





var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:3000");
    x.WithMethods().AllowAnyMethod();
});

app.UseAuthorization();
app.MapControllers();


//app.MapControllerRoute(
//    name: "Auth",
//    pattern: "{controller=auth}/{action=login}");

app.Run();

//  "applicationUrl": "http://localhost:5032",
