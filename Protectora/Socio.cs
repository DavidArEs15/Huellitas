using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    class Socio
    {

        public string Nombre { set; get; }
        public string Apellidos { set; get; }
        public string Email { set; get; }
        public string Dni { set; get; }
        public string Domicilio { set; get; }
        public string Telefono { set; get; }
        public string NombreBanco { set; get; }
        public string NumeroCuenta { get; set; }
        public string CuantiaAyuda { set; get; }
        public string FormaPago { set; get; }
        public Uri Imagen { set; get; }
        public Socio(string nombre, string apellidos, string email, string
        dni, string domicilio, string telefono, string nombreBanco, string numeroCuenta, string cuantiaAyuda, string formaPago, Uri imagen)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Dni = dni;
            Domicilio = domicilio;
            Telefono = telefono;
            NombreBanco = nombreBanco;
            NumeroCuenta = numeroCuenta;
            CuantiaAyuda = cuantiaAyuda;
            FormaPago = formaPago;
            Imagen = imagen;
        }

    }
}
