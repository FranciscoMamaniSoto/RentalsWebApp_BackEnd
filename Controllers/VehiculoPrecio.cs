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
    public class VehiculoPreciosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

    public VehiculoPreciosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/VehiculoPrecios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehiculoPrecio>>> GetVehiculoPrecios()
    {
        return await _context.VehiculoPrecio.ToListAsync();
    }

    // GET: api/VehiculoPrecios/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VehiculoPrecio>> GetVehiculoPrecio(int id)
    {
        var vehiculoPrecio = await _context.VehiculoPrecio.FindAsync(id);

        if (vehiculoPrecio == null)
        {
            return NotFound();
        }

        return vehiculoPrecio;
    }

    // PUT: api/VehiculoPrecios/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVehiculoPrecio(int id, VehiculoPrecio vehiculoPrecio)
    {
        if (id != vehiculoPrecio.Id)
        {
            return BadRequest();
        }

        _context.Entry(vehiculoPrecio).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VehiculoPrecioExists(id))
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

    // POST: api/VehiculoPrecios
    [HttpPost]
    public async Task<ActionResult<VehiculoPrecio>> PostVehiculoPrecio(VehiculoPrecio vehiculoPrecio)
    {
        _context.VehiculoPrecio.Add(vehiculoPrecio);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVehiculoPrecio", new { id = vehiculoPrecio.Id }, vehiculoPrecio);
    }

    // DELETE: api/VehiculoPrecios/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehiculoPrecio(int id)
    {
        var vehiculoPrecio = await _context.VehiculoPrecio.FindAsync(id);
        if (vehiculoPrecio == null)
        {
            return NotFound();
        }

        _context.VehiculoPrecio.Remove(vehiculoPrecio);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VehiculoPrecioExists(int id)
    {
        return _context.VehiculoPrecio.Any(e => e.Id == id);
    }
    }
}