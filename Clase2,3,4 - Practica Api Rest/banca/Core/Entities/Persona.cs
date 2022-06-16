using System.Collections.Generic;
using System;

namespace Core.Entities
{
    public class Persona : BaseEntity
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        
    }
    
}