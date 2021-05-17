using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LocalDatabase
{
    public class Categoria
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nombre { get; set; }

    }
}
