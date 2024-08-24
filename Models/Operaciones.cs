using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace practica1.Models
{
    public class Operaciones
    {
        public Operaciones()
        {
            Operacion = new List<string>();
            Resultados = new List<ResultadoOper>();
        }

        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public DateTime FechaOperacion { get; set; }
        public List<string> Operacion { get; set; }
        public decimal MontoAbono { get; set; }
        public decimal TotalPag { get; private set; }

        public List<ResultadoOper> Resultados { get; private set; }
        public void CalcularInversion()
        {
            decimal igv = 0.18m;
            decimal totPag = 0;
            decimal igvMonto = MontoAbono * igv;
            totPag += igvMonto + MontoAbono;

            foreach (var instrumento in Operacion ?? new List<string>())
            {
                decimal precio = instrumento switch
                {
                    "S&P 500" => 500,
                    "Dow jones" => 300,
                    "Bonos US" => 120,
                    _ => 0
                };

                decimal igvIns = precio * igv;
                decimal montoIns = Math.Round(precio, 2);

                Resultados.Add(new ResultadoOper
                {
                    Nombre = instrumento,
                    Monto = montoIns,
                    Igv = igvIns,
                    FechaOperacion = FechaOperacion
                });

                //comision
                decimal comision = MontoAbono <= 300 ? 3 : 1;
                totPag += comision;

                TotalPag = totPag;
            }
        }

    }

    public class ResultadoOper
    {
        public string? Nombre { get; set; }
        public decimal Igv { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaOperacion { get; set; }
    }
}