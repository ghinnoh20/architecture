using Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.Data;
using Repository.Interfaces;
using Repository.Implementations;
using Service.Interfaces;
using Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddScoped(typeof(ISchoolRepository<>), typeof(SchoolRepository<>));
builder.Services.AddScoped(typeof(IStudentService), typeof(StudentService));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
