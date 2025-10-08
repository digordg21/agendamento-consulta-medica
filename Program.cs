 using Microsoft.EntityFrameworkCore;
using System.Text;
using Data;
using Models;

var builder = WebApplication.CreateBuilder(args);


// Adicionar suporte a controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configurar EF Core com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=agendamento-consultas.db"));

// builder.Services.AddScoped<PacienteRepository>();
// builder.Services.AddScoped<MedicoRepository>();
// builder.Services.AddScoped<ConsultaRepository>();

var app = builder.Build();


// Configurar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); // 👈 Habilita Controllers

app.Run();
