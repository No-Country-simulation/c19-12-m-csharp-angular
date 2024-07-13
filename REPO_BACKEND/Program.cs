using backnc.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotNetEnv;

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
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
