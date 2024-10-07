using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_rentals.Models
{
    public class PersonaContacto
    {
        public long Id { get; set; }
        public long IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public DateTime CtrlFechaCreacion { get; set; }
        public DateTime CtrlFechaModificacion { get; set; }
        public string? CtrlUsuarioCreacion { get; set; }
        public string? CtrlUsuarioModificacion { get; set; }
    }
}