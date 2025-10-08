using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class PacienteController : ControllerBase
{
    private readonly AppDbContext _context;

    public PacienteController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
    {
        var pacientes = await _context.Pacientes.ToListAsync();
        return Ok(pacientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Paciente>> GetPaciente(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);

        if (paciente == null)
        {
            return NotFound();
        }

        return Ok(paciente);
    }

    [HttpPost]
    public async Task<ActionResult<Paciente>> CreatePaciente(Paciente paciente)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPaciente), new { id = paciente.Id }, paciente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePaciente(int id, Paciente paciente)
    {
        if (id != paciente.Id)
        {
            return BadRequest();
        }

        _context.Entry(paciente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PacienteExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePaciente(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);
        if (paciente == null)
        {
            return NotFound();
        }

        _context.Pacientes.Remove(paciente);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PacienteExists(int id)
    {
        return _context.Pacientes.Any(e => e.Id == id);
    }
}
