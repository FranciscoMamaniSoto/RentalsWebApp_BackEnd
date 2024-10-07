using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_rentals.Models
{
    public class VehiculoDocumentos
    {
        public long Id { get; set; }
        public long IdVehiculo { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
    }
}