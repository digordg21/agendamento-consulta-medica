using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Paciente> Pacientes { get; set; }

    public DbSet<Medico> Medicos { get; set; }

    public DbSet<Consulta> Consulta { get; set; }
}