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
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

    public VehiculoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Vehiculo
    [HttpGet] //Decorador. Investigar async. Task va ligado a async. Investigar await, etc
    public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculos()
    {
        return await _context.Vehiculo.ToListAsync();
    }

    // GET: api/Vehiculo/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
    {
        var vehiculo = await _context.Vehiculo.FindAsync(id);

        if (vehiculo == null)
        {
            return NotFound();
        }

        return vehiculo;
    }

    // POST: api/Vehiculo
    [HttpPost]
    public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
    {
        _context.Vehiculo.Add(vehiculo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVehiculo), new { id = vehiculo.Id }, vehiculo);
    }

    // PUT: api/Vehiculo/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVehiculo(int id, Vehiculo vehiculo)
    {
        if (id != vehiculo.Id)
        {
            return BadRequest();
        }

        _context.Entry(vehiculo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VehiculoExists(id))
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

    // DELETE: api/Vehiculo/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehiculo(long id)
    {
        var vehiculo = await _context.Vehiculo.FindAsync(id);
        if (vehiculo == null)
        {
            return NotFound();
        }

        _context.Vehiculo.Remove(vehiculo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VehiculoExists(int id)
    {
        return _context.Vehiculo.Any(e => e.Id == id);
    }
    }
}
