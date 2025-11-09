using System;

namespace CajeroLite
{
    internal static class Operaciones
    {
        public static void Menu()
        {
            bool salir = false;

            while (!salir)
            {
                IO.MostrarEncabezado("Menú Principal");

                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Salir");
                Console.WriteLine();

                string opcion = IO.CapturarEntrada("Seleccione una opción: ");

                if (!Utilidades.ValidarOpcionMenu(opcion, 4))
                {
                    Utilidades.PausarEjecucion();
                    continue; // vuelve al menú
                }

                switch (opcion)
                {
                    case "1":
                        ConsultarSaldo();
                        break;
                    case "2":
                        Depositar();
                        break;
                    case "3":
                        Retirar();
                        break;
                    case "4":
                        IO.MostrarMensaje("Gracias por usar el Cajero Lite. ¡Hasta luego!");
                        salir = true;
                        break;
                }

                if (!salir) Utilidades.PausarEjecucion();
            }
        }

        private static void ConsultarSaldo()
        {
            IO.MostrarEncabezado("Consulta de saldo");
            decimal saldo = Data.Saldos[Program.indiceUsuario];
            IO.MostrarMensaje($"Su saldo actual es: {saldo:C}");
        }

        private static void Depositar()
        {
            IO.MostrarEncabezado("Depósito de dinero");

            string entrada = IO.CapturarEntrada("Ingrese el monto a depositar: ");
            if (decimal.TryParse(entrada, out decimal monto) && Utilidades.ValidarMonto(monto))
            {
                Data.Saldos[Program.indiceUsuario] += monto;
                IO.MostrarMensaje($"Depósito exitoso. Nuevo saldo: {Data.Saldos[Program.indiceUsuario]:C}");
            }
            else
            {
                IO.MostrarMensaje("Monto inválido.", true);
            }
        }

        private static void Retirar()
        {
            IO.MostrarEncabezado("Retiro de dinero");

            string entrada = IO.CapturarEntrada("Ingrese el monto a retirar: ");
            if (decimal.TryParse(entrada, out decimal monto) && Utilidades.ValidarMonto(monto))
            {
                if (monto <= Data.Saldos[Program.indiceUsuario])
                {
                    Data.Saldos[Program.indiceUsuario] -= monto;
                    IO.MostrarMensaje($"Retiro exitoso. Nuevo saldo: {Data.Saldos[Program.indiceUsuario]:C}");
                }
                else
                {
                    IO.MostrarMensaje("Saldo insuficiente.", true);
                }
            }
            else
            {
                IO.MostrarMensaje("Monto inválido.", true);
            }
        }
    }
}
