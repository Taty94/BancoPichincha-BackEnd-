using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase6
{
    class Program
    {
        static void Main(string[] args)
        {
            Operacion <decimal> o = new Operacion<decimal>();
            Console.WriteLine("Introduzca un numero1: ");
            var num1 = Convert.ToDecimal( Console.ReadLine());
            Console.WriteLine("Introduzca un numero2: ");
            var num2 = Convert.ToDecimal(Console.ReadLine());
            var respuesta = o.Division(num1, num2);
            Console.WriteLine("Respuesta: "+ respuesta);
            Console.ReadLine();
        }
    }
}
