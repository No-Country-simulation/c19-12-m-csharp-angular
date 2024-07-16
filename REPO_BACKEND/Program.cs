using backnc.Data.Context;
using backnc.Data.Interface;
using backnc.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotNetEnv;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using backnc.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables de entorno desde archivo .env
Env.Load();

// Obtener la cadena de conexión del archivo de configuración
string connectionString = builder.Configuration.GetConnectionString("defaultConnection");

// Reemplazar las variables de entorno en la cadena de conexión
connectionString = connectionString.Replace("${DB_SERVER}", Env.GetString("DB_SERVER"))
                                   .Replace("${DB_NAME}", Env.GetString("DB_NAME"));
								   
// Configurar el DbContext con la cadena de conexión
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Agregar otros servicios al contenedor
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IProvinceSerivce, ProvinceService>();
builder.Services.AddScoped<IAppDbContext, AppDbContext>();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

//CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//        builder =>
//        {
//            builder.WithOrigins("http://localhost:4200")
//                   .AllowAnyHeader()
//                   .AllowAnyMethod();
//        });
//});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
