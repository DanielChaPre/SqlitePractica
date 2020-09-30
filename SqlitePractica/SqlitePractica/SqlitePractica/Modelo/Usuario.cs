using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaSQLite.Modelo
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string nombreusuario { get; set; }
        public string password { get; set; }
    }
}
