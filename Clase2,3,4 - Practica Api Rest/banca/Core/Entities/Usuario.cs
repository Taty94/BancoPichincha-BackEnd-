using System.Collections.Generic;

namespace Core.Entities
{
    public class Usuario : BaseEntity
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Datetime FechaNacimiento { get; set; }
        private int Edad { get; set; }
        public string Clave { get; set; }
        public int TipoCuenta { get; set; }
        //public IReadOnlyList<Cuenta> Cuentas { get; set; }

        //como manejar fecha
        //modificadores
        //enum en cuenta para el tipo
        //usuario y idusuario en cuenta
        //lista de cuentas en usuario
        
        
    }
    
}