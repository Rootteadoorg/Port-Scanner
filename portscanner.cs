using System;
using System.Linq;
using System.Net.Sockets;

namespace PortScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("******************************************");
                Console.WriteLine("*                                        *");
                Console.WriteLine("*   Port-Scanner by: Rootr | MortenTod   *");
                Console.WriteLine("*                                        *");
                Console.WriteLine("*                                        *");
                Console.WriteLine("*                                        *");
                Console.WriteLine("*     created in: C# / @AnonymousCRI     *");
                Console.WriteLine("******************************************\n");

                // Pregunta si el usuario desea continuar o salir de la tool.
                Console.WriteLine("Si desea salir de la herramienta sin ejecutarla (Escriba 'Si') si NO desea salir, (Escriba 'No') y siga las instrucciones de la herramienta :");
                string initialInput = Console.ReadLine().Trim().ToLower();

                if (initialInput == "si")
                {
                    Console.WriteLine("Saliendo de Port-Scanner...");
                    Console.WriteLine("Gracias por usar Port-Scanner " +
                      "| X: @anonymousCRI - X: @elZtanomas |");

                    // Sirve para cerrar la tool.
                    Environment.Exit(0);
                }
                else if (initialInput != "no")
                {
                    Console.WriteLine("Opción no válida. Volviendo al menú principal...\n");
                    continue;
                }

                Console.WriteLine("                           ");
                Console.WriteLine("NOTA: Si escanea una IP de x servidor y escanea varios puertos tenga en cuenta que la herramienta está diseñada para que dure 1s en tiempo de respuesta para verificar si un puerto está abierto o no, entendido esto si desea escanear un rango de puertos extensos puede implicar que tarde mucho el proceso.");
                Console.WriteLine("                                        ");
                Console.WriteLine("                                        ");
                Console.WriteLine("Ingrese la dirección IP que desea escanear:");
                string ipAddress = Console.ReadLine();

                Console.WriteLine("Ingrese el rango de puertos a escanear (por ejemplo, 1-65535):");
                string portRangeInput = Console.ReadLine();

                // Hacee que valide que la entrada no esté vacía y contenga un guion.
                if (string.IsNullOrWhiteSpace(portRangeInput) || !portRangeInput.Contains('-'))
                {
                    Console.WriteLine("Rango de puertos inválido. Asegúrese de ingresar el rango en el formato correcto (por ejemplo, 1-65535).");
                    continue;
                }

                string[] portRange = portRangeInput.Split('-');

                // Verificar que el rango de puertos tenga dos elementos después de dividir.
                if (portRange.Length != 2 || !int.TryParse(portRange[0], out int startPort) || !int.TryParse(portRange[1], out int endPort))
                {
                    Console.WriteLine("Rango de puertos inválido. Asegúrese de ingresar números válidos.");
                    continue;
                }

                Console.WriteLine($"Escaneando puertos de {startPort} a {endPort} en {ipAddress}...");

                bool foundOpenPort = false;

                for (int port = startPort; port <= endPort; port++)
                {
                    if (IsPortOpen(ipAddress, port, 1000))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"[+] Puerto {port} está abierto.");
                        Console.ResetColor();
                        foundOpenPort = true;
                    }
                }

                if (!foundOpenPort)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se encontró ningún puerto abierto en el rango especificado.");
                    Console.ResetColor();
                }

                Console.WriteLine("Escaneo completado.");

                // Pregunta si desea salir de la tool después de que se ejecute.
                Console.WriteLine("¿Quiere salir de Port-Scanner? (Escriba 'Si' para salir de la herramienta, 'No' para seguir en el menú) :");
                string userInput = Console.ReadLine().Trim().ToLower();

                if (userInput == "si")
                {
                    Console.WriteLine("Saliendo de Port-Scanner...");
                    Console.WriteLine("Gracias por usar Port-Scanner " +
                      "| X: @anonymousCRI - X: @elZtanomas |");
                    Console.WriteLine("              ");
                    Console.WriteLine("   ||   ||");
                    Console.WriteLine("   |\\_/|");
                    Console.WriteLine("  // O O \\\\ ");
                    Console.WriteLine(" ||  (_)  ||");
                    Console.WriteLine("  \\\\     // ");
                    Console.WriteLine("   | || | ");
                    Console.WriteLine("   |_| |_| ");
                    Console.WriteLine("   (  ) (  ) ");
                    Console.WriteLine("   |  | |  | ");
                    Console.WriteLine("   |  | |  | ");
                    Console.WriteLine("  (___| |___) ");

                    break;
                }
                else if (userInput == "no")
                {
                    Console.WriteLine("Volviendo al menú principal...\n");
                    continue;
                }
                else
                {
                    Console.WriteLine("Opción no válida. Volviendo al menú principal...\n");
                    continue;
                }
            }
        }

        static bool IsPortOpen(string ipAddress, int port, int timeout)
        {
            try
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    tcpClient.ReceiveTimeout = timeout;
                    tcpClient.SendTimeout = timeout;
                    tcpClient.Connect(ipAddress, port);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}