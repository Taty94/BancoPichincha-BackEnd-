using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase5
{
    class Carro : IAcciones
    {
        public int llantas { get; set; }
        public string motor { get; set; }
        public int listrosTanque { get; set; }
        public string marca { get; set; }

        public Carro(string motor, int litros, string marca)
        {
            llantas = 4;
            this.motor = motor;
            this.listrosTanque = litros;
            this.marca = marca;
        }

        public int distanciaSinRecarga()
        {
            int constGas;
            if (this.motor == "M8")
            {
                constGas = 2;
            }else if (this.motor == "M6")
            {
                constGas = 5;
            }
            else
            {
                constGas = 10;
            }
            int distancia = this.listrosTanque * constGas;
            return distancia;
        }

        public int viaje(int distA, int distB)
        {
            return  distB - distA;
        }

        public int velocidad(int distancia, int tiempo) 
        {
            int cambioVelocidad = 4;
            return (distancia / tiempo) / cambioVelocidad;
             
        }

    }
}
