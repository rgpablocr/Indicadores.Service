using Indicadores.DA.Class;
using Indicadores.DA.Interface;

var builder = WebApplication.CreateBuilder(args);

//INYECCION DE DEPENDENCIAS
builder.Services.AddScoped<IConnectionManager, ConnectionManager>();
//

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

app.UseAuthorization();

app.MapControllers();

app.Run();
