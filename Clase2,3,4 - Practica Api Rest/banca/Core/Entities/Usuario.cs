using System.Collections.Generic;
using System;

namespace Core.Entities
{
    public class Usuario : Persona
    {
        public string Clave { get; set; }
        public int TipoCuenta { get; set; }
        public ICollection<Cuenta> Cuentas { get; set; }

        //como manejar fecha
        //modificadores
        //enum en cuenta para el tipo
        //usuario y idusuario en cuenta
        //lista de cuentas en usuario
        
        
    }
    
}