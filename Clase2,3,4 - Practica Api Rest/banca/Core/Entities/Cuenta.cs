using System;

namespace Core.Entities
{
    public class Cuenta : BaseEntity
    {
        private string _numcuenta;
        public string NumCuenta { get; set; }
        public int Tipo { get; set; } //Ahorros=1;
        public decimal Saldo { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public void GetNumCuenta(){
            Random rnd = new Random();
            var random = rnd.Next(10000,99999);
            this.NumCuenta = "22055"+random.ToString();
        }

    }
}