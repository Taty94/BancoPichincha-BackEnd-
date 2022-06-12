using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase6
{
    interface IOperaciones<T>
    {
        T Sumar(T num1, T num2);
        T Restar(T num1, T num2);
        T Producto(T num1, T num2);
        T Division(T num1, T num2);
    }
}
