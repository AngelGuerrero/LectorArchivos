namespace LecturaDeArchivos
{
    public class Server
    {
        public string IdLocalidad { get; set; }

        public string Localidad { get; set; }

        public string Name { get; set; }

        public string DataBase { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public Server()
        {
            IdLocalidad = "";
            Localidad = "";
            Name = "";
            DataBase = "";
            User = "";
            Password = "";
        }
         public Server(string pIdLocalidad, string pLocalidad, string pNombreServidor, string pNombreBD)
        {
            IdLocalidad = pIdLocalidad;
            Localidad = pLocalidad;
            Name = pNombreServidor;
            DataBase = pNombreBD;
        }
    }
}
