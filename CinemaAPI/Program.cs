using CinemaAPI.Database;
using CinemaAPI.Repository;
using CinemaAPI.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IRepositoryUsers, UsersRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddDbContext<ConnectionContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema v1"));
}

app.MapControllers();
app.Run();

