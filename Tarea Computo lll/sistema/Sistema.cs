using Usuario;
namespace Sistema
{
    interface IBaseDeDatos
    {
        public void verCliente();
        public void agregarCliente(Cliente cliente);
        public void eliminarCliente(Cliente cliente);
    }
    class SQLite : IBaseDeDatos
    {
        private List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente("Carlos","Melendez",18,"manuelmv15","1234") ,
            new Cliente("juan","zanches",35,"c","1",true),
         new Cliente("María", "López", 25, "marialpz", "5678"),
         new Cliente("Juan", "Pérez", 30, "juan123", "abcd"),
         new Cliente("Luis", "García", 22, "luisgarcia", "efgh"),
         new Cliente("Ana", "Rodríguez", 28, "anarodriguez", "ijkl"),
         new Cliente("Pedro", "Gómez", 35, "pedrogomez", "mnop"),
         new Cliente("Laura", "Martínez", 40, "lauramtz", "qrst"),
         new Cliente("Sofía", "Hernández", 27, "sofiahernandez", "uvwxyz"),
         new Cliente("Diego", "Sánchez", 33, "diegosanchez", "1111"),
         new Cliente("Isabella", "Díaz", 19, "isabelladiaz", "2222"),

        };



        public void mostrarMenuEjecutivo()
        {
            int clienteEjecutivo = 0;
            string user = "c", pass = "1";
            int indice = 1;
            int menu = 0;
            bool acceso = false;


            Console.WriteLine("Ingrese el usuario");
            user = Console.ReadLine();

            Console.WriteLine("Ingrese la contraseña");
            Console.WriteLine();
            pass = Console.ReadLine();

            Console.WriteLine("Buscando...");
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].clienteEjecutivo)
                {
                    clienteEjecutivo = i;
                    acceso = clientes[i].inicioDesecion(pass, user);
                }
            }

            if (acceso)
            {
                do
                {

                    Console.WriteLine("Menu de cliente ejecutivo\n1. Ver clientes\n2. Agregar clientes\n3. Eliminar clientes\n4. Salir");
                    menu = num_rango(1, 4);

                    switch (menu)
                    {
                        case 1: verCliente(); break;
                        case 2:
                            indice = clientes.Count - 1;
                            agregarCliente(clientes[indice]); break;
                        case 3:
                            verCliente();
                            eliminarCliente(clientes[indice]);
                            break;

                    }
                } while (menu != 4);
            }
            Console.ReadKey();
            Console.Clear();
        }
        public void mostrarMenu()
        {
            string user = "", pass = "";
            int menu = 0;
            do
            {

                Console.WriteLine("Menu cliente normal\n1. Mostrar datos \n2. salir");
                menu = num_rango(1, 2);
                if (menu == 1)
                {
                    Console.WriteLine("Ingrese el usuario");
                    user = Console.ReadLine();

                    Console.WriteLine("Ingrese la contraseña");
                    Console.WriteLine();
                    pass = Console.ReadLine();
                    for (int i = 0; i < clientes.Count; i++)
                    {
                        if (clientes[i].iniciodesecion(user, pass))
                        {
                            clientes[i].mostrardatos(1);
                            break;
                        }
                    }
                }
            } while (menu != 2);
        }
        public void verCliente()
        {
            Console.WriteLine("Lista de clientes registrados:");
            for (int i = 0; i < clientes.Count; i++)
            {
                clientes[i].mostrardatos(i);
            }
        }
        public void agregarCliente(Cliente cliente)
        {
            Console.WriteLine("Ingrese el nombre del cliente:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del cliente:");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese la edad del cliente:");
            int edad = num_po();

            Console.WriteLine("Ingrese el nombre de usuario del cliente:");
            string usuario = Console.ReadLine();

            Console.WriteLine("Ingrese la contraseña del cliente:");
            string contraseña = Console.ReadLine();

            clientes.Add(new Cliente(nombre, apellido, edad, usuario, contraseña));

        }
        public void eliminarCliente(Cliente cliente)
        {
            int i = 0;
            verCliente();
            Console.WriteLine("Ingrese el índice del cliente a eliminar");
            i = num_rango(1, clientes.Count);
            clientes.Remove(clientes[i - 1]);
        }
        static int num_po()
        {
            int numero;

            do
            {
                Console.Write("Ingrese la edad: ");

            } while (!int.TryParse(Console.ReadLine(), out numero) || !Numero_Po(numero));
            return numero;
            static bool Numero_Po(int numero)
            {
                return numero > 0;
            }

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