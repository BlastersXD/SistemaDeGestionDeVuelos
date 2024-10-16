using System;

class Program
{
    static int[,] vuelos = new int[10, 60];
    static int cantidadVuelos = 0;

    static void Main(string[] args)
    {
        bool salir = false;
        while (!salir)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nBienvenido a CODESKY");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ----------------------------------------------");
            Console.WriteLine("| 1. Crear un vuelo.                           |");
            Console.WriteLine("| 2. Reservar asientos.                        |");
            Console.WriteLine("| 3. Cancelar una reserva.                     |");
            Console.WriteLine("| 4. Mostrar estado actual del vuelo.          |");
            Console.WriteLine("| 5. Mostrar asientos disponibles y ocupados.  |");
            Console.WriteLine("| 6. Buscar un asiento.                        |");
            Console.WriteLine("| 7. Salir.                                    |");
            Console.WriteLine(" ----------------------------------------------\n");
            


            Console.Write("Seleccione una opción: ");
            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        CrearVuelo();
                        break;
                    case 2:
                        ReservarAsientos();
                        break;
                    case 3:
                        CancelarReserva();
                        break;
                    case 4:
                        MostrarEstadoVuelo();
                        break;
                    case 5:
                        MostrarCantidadAsientos();
                        break;
                    case 6:
                        BuscarAsiento();
                        break;
                    case 7:
                        Console.WriteLine("Gracias por utilizar CODESKY.");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intente nuevamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número.");
            }

            Console.WriteLine();
        }
    }

    static void CrearVuelo()
    {
        if (cantidadVuelos < 10)
        {
            for (int i = 0; i < 60; i++)
            {
                vuelos[cantidadVuelos, i] = 0;
            }
            Console.WriteLine($"Vuelo {cantidadVuelos + 1} creado.");
            cantidadVuelos++;
        }
        else
        {
            Console.WriteLine("No se pueden crear más vuelos.");
        }
    }

    static void ReservarAsientos()
    {
        int vuelo = ObtenerNumero("Ingrese el número de vuelo (1-10): ", 1, 10);
        if (vuelo <= cantidadVuelos)
        {
            int cantidad = ObtenerNumero("Ingrese la cantidad de asientos que desea reservar: ", 1, 60);
            int asientosReservados = 0;

            for (int i = 0; i < cantidad; i++)
            {
                int asiento = ObtenerNumero($"Ingrese el número de asiento ({i + 1}/{cantidad}) (1-60): ", 1, 60);
                if (vuelos[vuelo - 1, asiento - 1] == 0)
                {
                    vuelos[vuelo - 1, asiento - 1] = 1;
                    Console.WriteLine($"Asiento {asiento} reservado.");
                    asientosReservados++;
                }
                else
                {
                    Console.WriteLine($"El asiento {asiento} ya está ocupado.");
                }
            }

            Console.WriteLine($"Se han reservado {asientosReservados} asientos en el vuelo {vuelo}.");
        }
        else
        {
            Console.WriteLine("Número de vuelo no válido.");
        }
    }

    static void CancelarReserva()
    {
        int vuelo = ObtenerNumero("Ingrese el número de vuelo (1-10): ", 1, 10);
        if (vuelo <= cantidadVuelos)
        {
            int asiento = ObtenerNumero("Ingrese el número de asiento (1-60): ", 1, 60);
            if (vuelos[vuelo - 1, asiento - 1] == 1)
            {
                vuelos[vuelo - 1, asiento - 1] = 0;
                Console.WriteLine("Reserva cancelada.");
            }
            else
            {
                Console.WriteLine("El asiento no estaba reservado.");
            }
        }
        else
        {
            Console.WriteLine("Número de vuelo no válido.");
        }
    }

    static void MostrarEstadoVuelo()
    {
        int vuelo = ObtenerNumero("Ingrese el número de vuelo (1-10): ", 1, 10);
        if (vuelo <= cantidadVuelos)
        {
            Console.WriteLine($"Estado del vuelo {vuelo}:");
            for (int i = 0; i < 60; i++)
            {
                Console.WriteLine($"Asiento {i + 1}: {(vuelos[vuelo - 1, i] == 0 ? "Disponible" : "Ocupado")}");
            }
        }
        else
        {
            Console.WriteLine("Número de vuelo no válido.");
        }
    }

    static void MostrarCantidadAsientos()
    {
        int vuelo = ObtenerNumero("Ingrese el número de vuelo (1-10): ", 1, 10);
        if (vuelo <= cantidadVuelos)
        {
            int ocupados = 0, disponibles = 0;

            for (int i = 0; i < 60; i++)
            {
                if (vuelos[vuelo - 1, i] == 0)
                    disponibles++;
                else
                    ocupados++;
            }

            Console.WriteLine($"Vuelo {vuelo}: {disponibles} asientos disponibles, {ocupados} ocupados.");
        }
        else
        {
            Console.WriteLine("Número de vuelo no válido.");
        }
    }

    static void BuscarAsiento()
    {
        int vuelo = ObtenerNumero("Ingrese el número de vuelo (1-10): ", 1, 10);
        if (vuelo <= cantidadVuelos)
        {
            int asiento = ObtenerNumero("Ingrese el número de asiento (1-60): ", 1, 60);
            if (vuelos[vuelo - 1, asiento - 1] == 0)
            {
                Console.WriteLine($"Asiento {asiento} está disponible.");
            }
            else
            {
                Console.WriteLine($"Asiento {asiento} está ocupado.");
            }
        }
        else
        {
            Console.WriteLine("Número de vuelo no válido.");
        }
    }
    static int ObtenerNumero(string mensaje, int minimo, int maximo)
    {
        int numero;
        bool valido = false;

        do
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out numero) && numero >= minimo && numero <= maximo)
            {
                valido = true;
            }
            else
            {
                Console.WriteLine($"Por favor, ingrese un número entre {minimo} y {maximo}.");
            }
        } while (!valido);

        return numero;
    }
}