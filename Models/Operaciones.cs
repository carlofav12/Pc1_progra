using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practica1.Models
{
    public class Operaciones
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public DateTime FechaOperacion { get; set; }
        public List<string>? Operacion { get; set; }
        public decimal MontoAbono { get; set; }
    }
}