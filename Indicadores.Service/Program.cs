using Indicadores.DA.Class;
using Indicadores.DA.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//se agrega jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))//valida firma del token
        };
    });

//INYECCION DE DEPENDENCIAS
builder.Services.AddScoped<IConnectionManager, ConnectionManager>();
builder.Services.AddScoped<IIndicadorDA, IndicadorDA>();
builder.Services.AddScoped<ICuentaCatalogoDA, CuentaCatalogoDA>();
builder.Services.AddScoped<IPeriodicidadDA, PeriodicidadDA>();
builder.Services.AddScoped<IEstadoDA, EstadoDA>();
builder.Services.AddScoped<IMetaDataDA, MetaDataDA>();
builder.Services.AddScoped<IUnidadDeMedidaDA, UnidadDeMedidaDA>();
builder.Services.AddScoped<IPosValorDA, PosValorDA>();
builder.Services.AddScoped<ITokenUsuarioDA, TokenUsuarioDA>();
//

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Ingrese el token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    }); //se agrega tag de auth

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
