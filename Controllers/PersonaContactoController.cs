using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_rentals.Data;
using backend_rentals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_rentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaContactosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

    public PersonaContactosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/PersonaContactos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonaContacto>>> GetPersonaContactos()
    {
        return await _context.PersonaContacto.ToListAsync();
    }

    // GET: api/PersonaContactos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PersonaContacto>> GetPersonaContacto(int id)
    {
        var personaContacto = await _context.PersonaContacto.FindAsync(id);

        if (personaContacto == null)
        {
            return NotFound();
        }

        return personaContacto;
    }

    // PUT: api/PersonaContactos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPersonaContacto(int id, PersonaContacto personaContacto)
    {
        if (id != personaContacto.Id)
        {
            return BadRequest();
        }

        _context.Entry(personaContacto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonaContactoExists(id))
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

    // POST: api/PersonaContactos
    [HttpPost]
    public async Task<ActionResult<PersonaContacto>> PostPersonaContacto(PersonaContacto personaContacto)
    {
        _context.PersonaContacto.Add(personaContacto);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPersonaContacto", new { id = personaContacto.Id }, personaContacto);
    }

    // DELETE: api/PersonaContactos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonaContacto(int id)
    {
        var personaContacto = await _context.PersonaContacto.FindAsync(id);
        if (personaContacto == null)
        {
            return NotFound();
        }

        _context.PersonaContacto.Remove(personaContacto);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PersonaContactoExists(int id)
    {
        return _context.PersonaContacto.Any(e => e.Id == id);
    }
    }
}