using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_rentals.Models
{
    public class Vehiculo
    {
        public long Id { get; set; }
        public string? Patente { get; set; }
        public string? NumeroInterno { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? NumeroChasis { get; set; }
        public string? NumeroMotor { get; set; }
        public int Ano { get; set; }
        public string? Descripcion { get; set; }
        public string? Tipo { get; set; }
        public DateTime? CtrlFechaCreacion { get; set; }
        public DateTime? CtrlFechaModificacion { get; set; }
        public string? CtrlUsuarioCreacion { get; set; }
        public string? CtrlUsuarioModificacion { get; set; }
    }
}