using College.Application.Services;
using College.Domain.Repositories;
using College.Infrastructure.Data;
using College.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using College.Application.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CollegeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var claveSecreta = builder.Configuration["JwtSettings:ClaveSecreta"] ?? "ClaveSecretaMuySeguraParaJWT2024CollegeApi";
var key = Encoding.UTF8.GetBytes(claveSecreta);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"] ?? "CollegeApi",
            ValidAudience = builder.Configuration["JwtSettings:Audience"] ?? "CollegeApiUsuarios",
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();

builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
