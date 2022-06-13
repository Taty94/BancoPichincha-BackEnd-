using System.Collections.Generic;
using System;

namespace Core.Entities
{
    public class Persona : BaseEntity
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        private int Edad { get; set; }
        
    }
    
}