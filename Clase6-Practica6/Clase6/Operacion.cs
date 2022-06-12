using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase6
{
    class Operacion<T> : IOperaciones<T>
    {
        public T Sumar(T operand1, T operand2)
        {
            return (dynamic) operand1 + operand2;
        }

        public T Restar(T num1, T num2)
        {
            return (dynamic)num1 - num2;
        }

        public T Producto(T num1, T num2)
        {
            return (dynamic)num1 * num2;
        }

        public T Division(T num1, T num2)
        {
            if((dynamic) num2 == 0){
                var resp = 0;
                return (dynamic) resp;
            }
            else
            {
                return (dynamic)num1 / num2;
            }
            
        }
            
        
    }
}
