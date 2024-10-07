using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_rentals.Models;
using Microsoft.EntityFrameworkCore;


namespace backend_rentals.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vehiculo> Vehiculo { get; set; }

    public DbSet<Persona> Persona { get; set; }

    public DbSet<PersonaContacto> PersonaContacto { get; set; }

    public DbSet<VehiculoDocumentos> VehiculoDocumentos { get; set; }

    public DbSet<VehiculoPrecio> VehiculoPrecio { get; set; }

    public DbSet<Arriendos> Arriendos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Additional configurations if necessary
    }
    }
}