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
        private List<Cliente> clientes = new List<Cliente>();

        public void mostrarMenuEjecutivo()
        {
            int clienteEjecutivo = 0;
            string user = "", pass = "";
            int indice = 0;
            int menu = 0;
            bool acceso = false;


            Console.WriteLine("Ingrese el usuario");
            user = Console.ReadLine();

            Console.WriteLine("Ingrese la contraseña");
            Console.WriteLine();
            pass = Console.ReadLine();


            for (int i = 0; i < clientes.Count; i++)
            {
                acceso = clientes[i].inicioDesecion(pass, user);
                if (clientes[i].clienteEjecutivo) clienteEjecutivo = i; break;
            }
            if (acceso)
            {

                Console.WriteLine("Menu de cliente ejecutivo\n1. Ver clientes\n2. Agregar clientes\n3. Eliminar clientes\n4. Salir");
                menu = num_rango(1, 4);
                
                switch (menu)
                {
                    case 1: verCliente(); break;
                    case 2:
                        indice = clientes.Count + 1;
                        agregarCliente(clientes[indice]); break;
                    case 3:
                        verCliente();
                        eliminarCliente(clientes[indice]);
                        break;

                }
            }

        }
        public void mostrarMenu()
        {
            string user = "", pass = "";
            int menu = 0;
         
            menu = num_rango(1, 2);
            if (menu == 1)
            {
                Console.WriteLine("Ingrese el usuario");
                user = Console.ReadLine();

                Console.WriteLine("Ingrese la contraseña");
                Console.WriteLine();
                pass = Console.ReadLine();
                for (int i = 0;i < clientes.Count;i++)
                {
                    if(clientes[i].iniciodesecion(user, pass))
                    {
                        clientes[i].mostrardatos(1);
                        break;
                    }
                }
            }
            else { }
        }
        public void verCliente()
        {
            Console.WriteLine("Lista de clientes registrados:");
            for (int i = 0; i < clientes.Count; i++)
            {
                clientes[i].mostrardatos(i + 1);
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
            Console.WriteLine("Ingrese el indice del cliente a eliminar");
            i = num_rango(1, clientes.Count) - 1;
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