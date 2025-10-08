using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class MedicoController : ControllerBase
{
    private readonly AppDbContext _context;

    public MedicoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
    {
        var medicos = await _context.Medicos
            .Include(m => m.Consultas)
            .ToListAsync();
        return Ok(medicos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Medico>> GetMedico(int id)
    {
        var medico = await _context.Medicos
            .Include(m => m.Consultas)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (medico == null)
        {
            return NotFound();
        }

        return Ok(medico);
    }

    [HttpPost]
    public async Task<ActionResult<Medico>> CreateMedico(Medico medico)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Medicos.Add(medico);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetMedico),
            new { id = medico.Id },
            medico
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMedico(int id, Medico medico)
    {
        if (id != medico.Id)
        {
            return BadRequest();
        }

        _context.Entry(medico).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MedicoExists(id))
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
    public async Task<IActionResult> DeleteMedico(int id)
    {
        var medico = await _context.Medicos.FindAsync(id);
        if (medico == null)
        {
            return NotFound();
        }

        _context.Medicos.Remove(medico);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MedicoExists(int id)
    {
        return _context.Medicos.Any(e => e.Id == id);
    }
}
