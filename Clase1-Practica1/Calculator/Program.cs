using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escriba un número de la operación que quieres realizar:\n1 - Sumar\n2 - Restar\n3 - Multiplicar\n4 - Dividir");
            string opcion = Console.ReadLine();

            Console.WriteLine("Ingrese el primer numero");
            var num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese el segundo numero");
            var num2 = Convert.ToDouble(Console.ReadLine());

            Calculator objCalculator = new Calculator(num1, num2);
            switch (opcion)
            {
                case "1":
                    var suma = objCalculator.getSuma();
                    Console.WriteLine("El resultado de la suma es : " + suma);
                    break;
                case "2":
                    var resta = objCalculator.getResta();
                    Console.WriteLine("El resultado de la resta es : " + resta);
                    break;
                case "3":
                    var multiplicacion = objCalculator.getMultiplicacion();
                    Console.WriteLine("El resultado de la multiplicacion es : " + multiplicacion);
                    break;
                case "4":
                    var division = objCalculator.getDivision() == "error" ? "No se puede realizar divisines para cero" : objCalculator.getDivision();
                    Console.WriteLine("El resultado de la division es : " + division);
                    break;
                default:
                    Console.WriteLine("La opcion no es correcta");
                    break;
            }


            Console.ReadKey();

        }
    }
}
