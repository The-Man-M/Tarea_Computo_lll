using System.Globalization;

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
        public Cliente()
        {

        }
        public Cliente(string nombre, string apellido, int edad, string user, string pass)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            User = user;
            Pass = pass;
        }
       ClienteEjecutivo ClienteEjecutivo { get; set; }

        public bool inicioDesecion()
        {
            if (clienteEjecutivo)
            {

                return ClienteEjecutivo.login();

            }
            return false;
        }
        public void mostrardatos(int indice)
        {
            Console.WriteLine($"{indice} - Nombre: {Nombre}, Apellido: {Apellido}, Edad: {Edad}, Usuario: {User} ");
        }



    }

    class ClienteNormal : Cliente
    {

        public bool consultardatos()
        {
            string pass = "";
            string user = "";
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

        public bool login()
        {
            string pass = "";
            string user = "";
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