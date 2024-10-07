using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_rentals.Models
{
    public class VehiculoPrecio
    {
        public long Id { get; set; }
        public long IdVehiculo { get; set; }
        public string? Tipo { get; set; }
        public float Costo { get; set; }
    }
}