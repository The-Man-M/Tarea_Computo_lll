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
            string user="", pass="";
            int indice = 0;
            int menu = 0;
            bool acceso = false;
            for (int i = 0; i < clientes.Count; i++)
            {
               acceso = clientes[i].inicioDesecion(pass,user);
            }
            if (acceso)
            {

                Console.WriteLine();
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
            int edad;
            if (!int.TryParse(Console.ReadLine(), out edad))
            {
                Console.WriteLine("La edad ingresada no es válida. Se establecerá como 0.");
                edad = 0;
            }

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

            clientes.Remove(clientes[i - 1]);
        }
    }
}