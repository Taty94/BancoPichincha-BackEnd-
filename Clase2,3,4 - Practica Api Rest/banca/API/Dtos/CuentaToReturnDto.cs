using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class CuentaToReturnDto
    {
        public int Id { get; set; }
        public string NumCuenta { get; set; }
        public int Tipo { get; set; } //Ahorros=1;
        public decimal Saldo { get; set; }
        public string Propietario { get; set; }
        public string Cedula { get; set; }
    }
}