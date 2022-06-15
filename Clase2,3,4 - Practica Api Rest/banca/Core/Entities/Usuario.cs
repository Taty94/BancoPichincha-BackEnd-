using System.Collections.Generic;
using System;

namespace Core.Entities
{
    public class Usuario : Persona
    {
        public string Clave { get; set; }
        public ICollection<Cuenta> Cuentas { get; set; }

    }
    
}