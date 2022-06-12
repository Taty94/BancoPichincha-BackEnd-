using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase5
{
    class Program
    {
        static void Main(string[] args)
        {
            Carro c = new Carro("M8", 10, "Fiat");
            Console.WriteLine($"Información carro \n");
            Console.WriteLine($"->Motor : {c.motor} \n->Litros Combustible : {c.listrosTanque} \n->Marca: {c.marca} \n");
            var distSinRecarga = c.distanciaSinRecarga();
            Console.WriteLine($"El carro recorre una distancia de {distSinRecarga} km sin recarga de diesel");
            var total = c.viaje(9,20);
            Console.WriteLine($"Tu viaje tiene {total} kilometros de recorrido \n\n\n ");

            CarroElectrico ce = new CarroElectrico(80, "Electry");
            Console.WriteLine($"Información Carro Electrico \n");
            Console.WriteLine($"->Bateria : {c.listrosTanque} \n->Marca: {c.marca} \n");
            var distSinRecargaCE = ce.distanciaSinRecarga();
            var totalCE = c.viaje(9, 20);
            var velocidadCE = ce.velocidad(10,15,ce.bateria);

            Console.WriteLine($"El carro electrico recorre una distancia de {distSinRecargaCE} km sin recarga de bateria");
            Console.WriteLine($"Tu viaje tiene {totalCE} kilometros de recorrido ");
            Console.WriteLine($"El auto electrico recorre con una valocidad de {velocidadCE} km/h");


            Console.ReadLine();
        }
    }
}
