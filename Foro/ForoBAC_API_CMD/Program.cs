using DataBaseModel;
using ForoBAC_API_CMD.Repository.Interfaces;
using ForoBAC_API_CMD.Repository.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContext_Foro>(o => o.UseSqlServer(ConexionSQL.Conexion()));

//Inyeccion de dependencias
builder.Services.AddScoped<IPregunta, PreguntaServices>();
builder.Services.AddScoped<IRespuesta, RespuestaServices>();
builder.Services.AddScoped<IUsuario, UsuarioServices>();



builder.Services.AddCors(o =>
{
    o.AddPolicy("policy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();

    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("policy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
