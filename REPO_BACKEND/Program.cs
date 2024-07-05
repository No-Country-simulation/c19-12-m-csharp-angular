using backnc.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Hago una cadena de conexión que va a servir para enlazarse con el appsettings.json.
string connectionString = builder.Configuration.GetConnectionString("defaultConnection");
//Hago una variable llamada ServerVersion.
var ServerVersion = new MySqlServerVersion(new Version(8, 0, 33));
//En la siguiente linea hago la conexión.
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString , ServerVersion));



// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

//CONFIG DE SWAGGER
if(app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
