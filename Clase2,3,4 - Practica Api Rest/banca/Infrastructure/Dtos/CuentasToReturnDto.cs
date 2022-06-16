using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class CuentasToReturnDto
    {
        public int Id { get; set; }
        public string NumCuenta { get; set; }
        public int Tipo { get; set; } //Ahorros=1;
        public decimal Saldo { get; set; }
        public string Propietario { get; set; }
        public string Cedula { get; set; }
    }
}