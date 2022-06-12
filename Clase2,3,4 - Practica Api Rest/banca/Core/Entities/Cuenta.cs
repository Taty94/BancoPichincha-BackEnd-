using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cuenta : BaseEntity
    {
        public string NumCuenta { get; set; }
        public int Tipo { get; set; } //Ahorros=1;
        public decimal Saldo { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}