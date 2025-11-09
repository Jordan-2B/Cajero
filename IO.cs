using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CajeroLite.Program;

namespace CajeroLite
{
    internal static class IO
    {
        // Método para mostrar mensajes informativos o de error
        public static void MostrarMensaje(string mensaje, bool esError = false)
        {
            if (esError)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(mensaje);
            Console.ResetColor();
        }

        // Método para capturar texto o valores con reintentos
        public static string CapturarEntrada(string mensaje, int maxIntentos = 3)
        {
            int intentos = 0;
            string entrada = "";

            while (intentos < maxIntentos)
            {
                Console.Write(mensaje);
                entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                    return entrada;

                intentos++;
                MostrarMensaje($"Entrada inválida. Intento {intentos} de {maxIntentos}.", true);
            }

            MostrarMensaje("Se superó el número máximo de intentos.", true);
            return "";
        }

        // Método para leer PIN (ocultando los caracteres ingresados)
        public static string LeerPinOculto(string mensaje = "Ingrese su PIN: ")
        {
            Console.Write(mensaje);
            string pin = "";
            ConsoleKeyInfo tecla;

            do
            {
                tecla = Console.ReadKey(true);

                if (tecla.Key == ConsoleKey.Enter)
                    break;

                if (tecla.Key == ConsoleKey.Backspace && pin.Length > 0)
                {
                    pin = pin.Substring(0, pin.Length - 1);
                    Console.Write("\b \b");
                }
                else if (char.IsDigit(tecla.KeyChar))
                {
                    pin += tecla.KeyChar;
                    Console.Write("*");
                }
            } while (true);

            Console.WriteLine();
            return pin;
        }

        // Método para presentar un encabezado o título para una sección
        public static void MostrarEncabezado(string titulo)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==============================");
            Console.WriteLine($"         {titulo.ToUpper()}");
            Console.WriteLine("==============================");
            Console.ResetColor();
        }

        // Método para pausar la ejecución (esperar una tecla)
        public static void Pausar()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Presione una tecla para continuar...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
 

    }
}
