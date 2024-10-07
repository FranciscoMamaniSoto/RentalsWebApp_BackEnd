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
    public class VehiculoDocumentosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

    public VehiculoDocumentosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/VehiculoDocumentos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehiculoDocumentos>>> GetVehiculoDocumentos()
    {
        return await _context.VehiculoDocumentos.ToListAsync();
    }

    // GET: api/VehiculoDocumentos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VehiculoDocumentos>> GetVehiculoDocumento(int id)
    {
        var vehiculoDocumento = await _context.VehiculoDocumentos.FindAsync(id);

        if (vehiculoDocumento == null)
        {
            return NotFound();
        }

        return vehiculoDocumento;
    }

    // PUT: api/VehiculoDocumentos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVehiculoDocumento(int id, VehiculoDocumentos vehiculoDocumento)
    {
        if (id != vehiculoDocumento.Id)
        {
            return BadRequest();
        }

        _context.Entry(vehiculoDocumento).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VehiculoDocumentoExists(id))
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

    // POST: api/VehiculoDocumentos
    [HttpPost]
    public async Task<ActionResult<VehiculoDocumentos>> PostVehiculoDocumento(VehiculoDocumentos vehiculoDocumento)
    {
        _context.VehiculoDocumentos.Add(vehiculoDocumento);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVehiculoDocumento", new { id = vehiculoDocumento.Id }, vehiculoDocumento);
    }

    // DELETE: api/VehiculoDocumentos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehiculoDocumento(int id)
    {
        var vehiculoDocumento = await _context.VehiculoDocumentos.FindAsync(id);
        if (vehiculoDocumento == null)
        {
            return NotFound();
        }

        _context.VehiculoDocumentos.Remove(vehiculoDocumento);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VehiculoDocumentoExists(int id)
    {
        return _context.VehiculoDocumentos.Any(e => e.Id == id);
    }
    }
}
