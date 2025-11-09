using System;

namespace CajeroLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese su usuario: ");
            string usuario = Console.ReadLine();
            Console.WriteLine("Ingrese su PIN: ");
            string pin = Console.ReadLine();

            

            int indiceUsuario = Array.IndexOf(Data.Usuarios, usuario);

            if (indiceUsuario != -1 && Data.Pines[indiceUsuario] == pin)
            {
                Console.WriteLine($"Bienvenido al Cajero Lite, {usuario}");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Salir");
                Console.Write("Elige una opción: ");
            }
            else

            {
                int Intentos = 0;
                int IntentosMaximos = 5;
                Console.WriteLine("Usuario o PIN incorrecto. Acceso denegado.");
                if(Intentos < IntentosMaximos)
                {
                    Intentos++;
                    Console.WriteLine($"Intento {Intentos} de {IntentosMaximos}");
                }
                else
                {
                    Console.WriteLine("Has excedido el número máximo de intentos. La cuenta ha sido bloqueada.");
                }

            }

            Console.ReadKey();
        }
    }
}
