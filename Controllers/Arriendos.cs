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
    public class ArriendosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

    public ArriendosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Arriendos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Arriendos>>> GetArriendos()
    {
        return await _context.Arriendos.ToListAsync();
    }

    // GET: api/Arriendos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Arriendos>> GetArriendo(int id)
    {
        var arriendo = await _context.Arriendos.FindAsync(id);

        if (arriendo == null)
        {
            return NotFound();
        }

        return arriendo;
    }

    // PUT: api/Arriendos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutArriendo(int id, Arriendos arriendo)
    {
        if (id != arriendo.Id)
        {
            return BadRequest();
        }

        _context.Entry(arriendo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ArriendoExists(id))
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

    // POST: api/Arriendos
    [HttpPost]
    public async Task<ActionResult<Arriendos>> PostArriendo(Arriendos arriendo)
    {
        _context.Arriendos.Add(arriendo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetArriendo", new { id = arriendo.Id }, arriendo);
    }

    // DELETE: api/Arriendos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArriendo(int id)
    {
        var arriendo = await _context.Arriendos.FindAsync(id);
        if (arriendo == null)
        {
            return NotFound();
        }

        _context.Arriendos.Remove(arriendo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ArriendoExists(int id)
    {
        return _context.Arriendos.Any(e => e.Id == id);
    }
    }
}