using System;
using System.Collections.Generic;
using Core.Entities;

namespace API.Dtos
{
    public class UsuarioToReturnDto
    {
        private int _edad;
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; } 
        public int Edad 
        {
            get
            {
                return GetEdad();
            }
            set
            {
                _edad = value;
            }
        }

        private int GetEdad(){
            var today = DateTime.Today;
            var age = today.Year - this.FechaNacimiento.Year;
            if (this.FechaNacimiento.Date > today.AddYears(-age)) 
            age--;
            return age;
        }

        public string Clave { get; set; }  
        public ICollection<Cuenta> Cuentas { get; set; }    
    }
}