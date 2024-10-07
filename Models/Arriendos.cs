using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_rentals.Models
{
    public class Arriendos
    {
        public long Id { get; set; }
        public long IdPersonaMandante { get; set; }
        public long IdPersonaContratista { get; set; }
        public DateTime FechaInicioArriendo { get; set; }
        public DateTime FechaTerminoArriendo { get; set; }
        public float CostoEstimado { get; set; }
        public float CostoFacturado { get; set; }
        public DateTime CtrlFechaCreacion { get; set; }
        public DateTime CtrlFechaModificacion { get; set; }
        public string? CtrlUsuarioCreacion { get; set; }
        public string? CtrlUsuarioModificacion { get; set; }
        public long IdVehiculo { get; set; }
    }
}