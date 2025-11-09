using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroLite
{
    internal static class Utilidades
    {
        // 1️⃣ Método: Validar si un monto es aceptable (para depósito o retiro)
        public static bool ValidarMonto(decimal monto)
        {
            if (monto <= 0)
            {
                IO.MostrarMensaje("El monto debe ser mayor que cero.", true);
                return false;
            }

            if (monto > 10000000)
            {
                IO.MostrarMensaje("El monto excede el límite permitido (10 millones).", true);
                return false;
            }

            return true;
        }

        // 2️⃣ Método: Validar si la opción del menú es válida
        public static bool ValidarOpcionMenu(string opcion, int totalOpciones)
        {
            if (int.TryParse(opcion, out int numero))
            {
                if (numero >= 1 && numero <= totalOpciones)
                {
                    return true;
                }
            }

            IO.MostrarMensaje("Opción no válida. Intente nuevamente.", true);
            return false;
        }

        // 3️⃣ Método: Pausar ejecución (versión consistente del cajero)
        public static void PausarEjecucion()
        {
            IO.MostrarMensaje("\nPresione cualquier tecla para continuar...");
            Console.ReadKey(true);
        }
    }
}
