using System.Text;
using CinemaAPI.Database;
using CinemaAPI.Repository;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

string secretKey = builder.Configuration["Jwt:SecretKey"];
byte[]  key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
   {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(key),
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidAudience = builder.Configuration["Jwt:Audience"],
      ValidIssuer = builder.Configuration["Jwt:Issuer"],
      ValidateLifetime = true,
      ClockSkew = TimeSpan.Zero
   });

builder.Services.AddAuthorization();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.Scan(s => s.FromAssemblyOf<UserService>().AddClasses(c => c.InNamespaces("CinemaAPI.Service")).UsingRegistrationStrategy(RegistrationStrategy.Skip).AsSelf());
builder.Services.Scan(s =>
   s.FromAssemblyOf<IRepositoryUsers>().AddClasses(c => c.InNamespaces("CinemaAPI.Repository"))
      .AsImplementedInterfaces().WithScopedLifetime());

builder.Services.AddDbContext<ConnectionContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema v1"));
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

