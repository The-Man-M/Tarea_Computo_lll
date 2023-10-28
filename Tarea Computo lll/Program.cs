using Sistema;
using Usuario;
namespace Tarea_Computo_lll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SQLite basededatos = new SQLite();

            int menu = 0;
          
            do
            {
                Console.WriteLine("menu\n1. Menu de cliente ejecutivo\n3. Menu de cliente normal\n5. Salir");
                menu = num_rango(1, 3);

                switch (menu)
                {
                    case 1:
                        basededatos.mostrarMenuEjecutivo();
                        break;
                    case 2:
                        basededatos.mostrarMenu();
                        break;
                }
            } while (menu != 3);
        }
        static int num_rango(int num_min, int num_max)
        {

            int numero;

            do
            {

                Console.Write($"\nIngresa un número entre {num_min} y {num_max}: ");

            } while (!int.TryParse(Console.ReadLine(), out numero) || !Numero_ran(numero, num_min, num_max));
            return numero;

            static bool Numero_ran(int numero, int num_min, int num_max)
            {
                if (numero >= num_min)
                {
                    if (numero <= num_max)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;

            }
        }
    }
}