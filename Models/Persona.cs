using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_rentals.Models
{
    public class Persona
    {
        public long Id { get; set; }
        public string? Rut { get; set; }
        public string? TipoPersona { get; set; }
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? RazonSocial { get; set; }
        public string? NombreFantasia { get; set; }
        public DateTime CtrlFechaCreacion { get; set; }
        public DateTime CtrlFechaModificacion { get; set; }
        public string? CtrlUsuarioCreacion { get; set; }
        public string? CtrlUsuarioModificacion { get; set; }
    }
}