using System;

namespace CajeroLite
{
    internal class Program
    {
        public static int indiceUsuario = -1;

        static void Main(string[] args)
        {
            int intentos = 0;
            int maxIntentos = 5;
            bool accesoConcedido = false;

            IO.MostrarEncabezado("Cajero Lite");

            while (intentos < maxIntentos && !accesoConcedido)
            {
                string usuario = IO.CapturarEntrada("Ingrese su usuario: ");
                string pin = IO.LeerPinOculto("Ingrese su PIN: ");

                indiceUsuario = Array.IndexOf(Data.Usuarios, usuario);

                if (indiceUsuario != -1 && Data.Pines[indiceUsuario] == pin)
                {
                    IO.MostrarMensaje($"Bienvenido al Cajero Lite, {usuario}.");
                    accesoConcedido = true;

                    Utilidades.PausarEjecucion();
                    Operaciones.Menu(); // abre el menú principal
                }
                else
                {
                    intentos++;
                    IO.MostrarMensaje($"Usuario o PIN incorrecto. Intento {intentos} de {maxIntentos}.", true);

                    if (intentos == maxIntentos)
                    {
                        IO.MostrarMensaje("Has superado el número máximo de intentos. El programa se cerrará.", true);
                        Utilidades.PausarEjecucion();
                        return;
                    }
                }
            }
        }
    }
}
