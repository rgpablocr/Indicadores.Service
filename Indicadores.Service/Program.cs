using Indicadores.DA.Class;
using Indicadores.DA.Interface;

var builder = WebApplication.CreateBuilder(args);

//INYECCION DE DEPENDENCIAS
builder.Services.AddScoped<IConnectionManager, ConnectionManager>();
builder.Services.AddScoped<IIndicadorDA, IndicadorDA>();
builder.Services.AddScoped<ICuentaCatalogoDA, CuentaCatalogoDA>();
builder.Services.AddScoped<IPeriodicidadDA, PeriodicidadDA>();
builder.Services.AddScoped<IEstadoDA, EstadoDA>();
builder.Services.AddScoped<IMetaDataDA, MetaDataDA>();

builder.Services.AddScoped<IUnidadDeMedidaDA, UnidadDeMedidaDA>();
builder.Services.AddScoped<IPosValorDA, PosValorDA>();
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
