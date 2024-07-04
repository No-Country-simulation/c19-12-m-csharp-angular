using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

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
