using BLL;
using BLL.Services;
using DAL.EF;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<DepartmentRepo>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<Sm26AContext>(opt => { 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
