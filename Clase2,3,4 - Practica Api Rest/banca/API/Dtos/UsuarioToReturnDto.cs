using System;
using System.Collections.Generic;
using Core.Entities;

namespace API.Dtos
{
    public class UsuarioToReturnDto
    {
        private int _edad;
        public int Id { get; set; }
        public int Cedula { get; set; }
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

        public int GetEdad(){
            var today = DateTime.Today;
            var age = today.Year - this.FechaNacimiento.Year;
            if (this.FechaNacimiento.Date > today.AddYears(-age)) 
            age--;
            return age;
        }

        public string Clave { get; set; }  
        public IReadOnlyList<CuentaToReturnDto> Cuentas { get; set; }    
    }
}