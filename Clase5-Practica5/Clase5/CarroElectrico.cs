using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase5
{
    class CarroElectrico : IAcciones
    {
        public int llantas { get; set; }
        public int bateria { get; set; }
        public string marca { get; set; }

        public CarroElectrico(int bateria,string marca)
        {
            this.llantas = 4;
            this.bateria = bateria;
            this.marca = marca;
        }


        public int distanciaSinRecarga()
        {
            if (this.bateria >= 75 || this.bateria <= 100)
            {
                return 30;
            }
            else if (this.bateria >= 35 || this.bateria <= 74)
            {
                return 25;
            }else
            {
                return 15;
            }
        }

        public int viaje(int distA, int distB) //default
        {
            return distB - distA;
        }


        //Sobrecarga de metodos
        public int velocidad(int distancia, int tiempo)
        {
            int cambioVelocidad = 4;
            return (distancia / tiempo) + cambioVelocidad;

        }

        public int velocidad(int distancia, int tiempo, int bateria)
        {
            int cambioVelocidad = 4;
            var speed= (distancia * tiempo) / (bateria/ cambioVelocidad);
            return speed;
        }
    }
}
