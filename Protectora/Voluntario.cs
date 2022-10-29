using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    class Voluntario
    {
        public string Nombre { set; get; }
        public string Apellidos { set; get; }
        public string Email { set; get; }
        public string Dni { set; get; }
        public string Telefono { set; get; }
        public string Horario { set; get; }
        public string Zona { get; set; }
        public bool ConocimientosVet { set; get; }
        public Uri UrlImagen { set; get; }
        public Voluntario(string nombre, string apellidos, string email, string
        dni, string telefono, string horario, string zona, bool conocimientosVet, Uri urlImagen)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Dni = dni;
            Telefono = telefono;
            Horario = horario;
            Zona = zona;
            ConocimientosVet = conocimientosVet;
            UrlImagen = urlImagen;
        }
    }
}
