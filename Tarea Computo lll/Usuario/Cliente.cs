using System;

namespace Usuario
{
    class Cliente
    {
        protected string Nombre;
        protected string Apellido;
        protected int Edad;
        public string User;
        public string Pass;
        public bool clienteEjecutivo = false;

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





        public bool inicioDesecion(string pass, string user)
        {
            bool acseso = false;
            ClienteEjecutivo _ClienteEjecutivo = new ClienteEjecutivo();

            acseso = _ClienteEjecutivo.login(this.User, this.Pass, user, pass);

            return acseso;

        }
        public void mostrardatos(int indice)
        {

            if (!this.clienteEjecutivo)
            {
                Console.WriteLine($"{indice + 1} - Nombre: {Nombre}\n\tApellido: {Apellido}\n\tEdad: {Edad}\n\tUsuario: {User} ");
            }
        }
        public bool iniciodesecion(string user, string pass)
        {
            ClienteNormal _ClienteNormal = new ClienteNormal();
            return _ClienteNormal.consultardatos(this.User, this.Pass,user, pass);
        }
    }

    class ClienteNormal : Cliente
    {
        public bool consultardatos(string User, string Pass, string user, string pass)
        {
            
            bool acceso = false;
            if (User == user)
            {
                if (Pass == pass)
                {
                    acceso = true;
                   
                }
            }
            return acceso;
        }
    }
    class ClienteEjecutivo : Cliente
    {
        public bool login(string User, string Pass, string user, string pass)
        {
            bool acceso = false;
            if (User == user)
            {

                if (Pass == pass)
                {

                    acceso = true;
                }
            }
            return acceso;
        }
    }
}