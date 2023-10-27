namespace Usuario
{
    class Cliente
    {
        protected string Nombre;
        protected string Apellido;
        protected int Edad;
        protected string User;
        protected string Pass;
        protected bool clienteEjecutivo = false;

        public Cliente() { }

        public Cliente(string nombre, string apellido, int edad, string user, string pass)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            User = user;
            Pass = pass;
        }
        public Cliente(string nombre, string apellido, int edad, string user, string pass, bool clienteejecutivo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            User = user;
            Pass = pass;
            clienteEjecutivo = clienteejecutivo;
        }
        ClienteEjecutivo ClienteEjecutivo { get; set; }
        ClienteNormal ClienteNormal { get; set; }

        public bool inicioDesecion(string pass, string user)
        {
            if (clienteEjecutivo)
            {
                return ClienteEjecutivo.login(pass,user);
            }
            return false;
        }
        public void mostrardatos(int indice)
        {
            if (!this.clienteEjecutivo)
            {
                Console.WriteLine($"{indice} - Nombre: {Nombre}, Apellido: {Apellido}, Edad: {Edad}, Usuario: {User} ");
            }
        }
    }

    class ClienteNormal : Cliente
    {
        public bool consultardatos(string pass, string user)
        {
            bool acceso = false;
            if (this.User == user)
            {
                if (this.Pass == pass)
                {
                    acceso = true;
                }
            }
            return acceso;
        }
    }
    class ClienteEjecutivo : Cliente
    {
        public bool login(string pass, string user)
        {
            bool acceso = false;
            if (this.User == user)
            {
                if (this.Pass == pass)
                {
                    acceso = true;
                }
            }
            return acceso;
        }

    }

}