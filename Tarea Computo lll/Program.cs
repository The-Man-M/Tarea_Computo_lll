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
            string[] bienvenido = { "B", "i", "e", "n", "v", "e", "n", "i", "d", "o", " ", ".", ".", "." };

            for (int i = 0; i < bienvenido.Length; i++)
            {
                Console.Write(bienvenido[i]);
                Thread.Sleep(200);
            }
            Thread.Sleep(1000);

            Console.Clear();

            do
            {
                Console.WriteLine("Menu\n1. Menu de cliente ejecutivo\n2. Menu de cliente normal\n3. Salir");
                menu = num_rango(1, 3);

                switch (menu)
                {
                    case 1:
                       
                        basededatos.mostrarMenuEjecutivo(); Console.Clear();
                        break;
                    case 2:
                        
                        basededatos.mostrarMenu(); Console.Clear();
                        break;
                }
            } while (menu != 3);


            Console.Clear();
            
            Console.WriteLine("ADIOS... ");
            
            Thread.Sleep(500);
            
            string[] texto = { "H", "a", "s", "t", "a", " ", "p", "r", "o", "n", "t", "o", " ", ".", ".", "." };
            
            for (int i = 0; i < texto.Length; i++)
            {
                Console.Write(texto[i]);
                Thread.Sleep(200);
            }
            Thread.Sleep(1000);

            Console.Clear() ;
        }

        static int num_rango(int num_min, int num_max)
        {

            int numero;

            do
            {

                Console.Write($"Ingresa un número entre {num_min} y {num_max}: ");

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