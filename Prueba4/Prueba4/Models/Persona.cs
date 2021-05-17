using SQLite;

namespace LocalDatabase
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Perfil { get; set; }
        public string Pass { get; set; }
        public int Estado { get; set; }
    }

}