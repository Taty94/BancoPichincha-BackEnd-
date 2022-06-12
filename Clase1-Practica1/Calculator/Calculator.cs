using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        

        public double cantidadUno { get; set; }
        public double cantidadDos { get; set; }
        public double resultado { get; set; }

        public Calculator(double cantUno, double cantDos)
        {
            this.cantidadUno = cantUno;
            this.cantidadDos = cantDos;
        }

        public double getSuma()
        {
            this.resultado = this.cantidadUno + this.cantidadDos;
            return resultado;
        }

        public double getResta()
        {
            this.resultado = this.cantidadUno - this.cantidadDos;
            return resultado;
        }

        public double getMultiplicacion()
        {
            this.resultado = this.cantidadUno * this.cantidadDos;
            return resultado;
        }

        public string getDivision()
        {
            var respuesta = this.cantidadDos != 0? Math.Round(this.cantidadUno / this.cantidadDos,2).ToString():"error";
            this.resultado = respuesta == "error" ? 0 : Convert.ToDouble(respuesta);
            return respuesta;
        }
    }
}
