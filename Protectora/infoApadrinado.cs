using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    class InfoApadrinado
    {

        public string Nombre { set; get; }
        public string Email { set; get; }
        public string Dni { set; get; }
        public string Domicilio { set; get; }
        public string Telefono { set; get; }
        public DateTime FechaNacimiento { set; get; }
        public string NumeroCuenta { get; set; }
        public string CuantiaAyuda { set; get; }
        public string FormaPago { set; get; }
        public DateTime FechaApadrinamiento { set; get; }
        public InfoApadrinado(string nombre, string email, string
        dni, string domicilio, string telefono, DateTime fechaNacimiento, string numeroCuenta, string cuantiaAyuda, string formaPago, DateTime fechaApadrinamiento)
        {
            Nombre = nombre;
            Email = email;
            Dni = dni;
            Domicilio = domicilio;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            NumeroCuenta = numeroCuenta;
            CuantiaAyuda = cuantiaAyuda;
            FormaPago = formaPago;
            FechaApadrinamiento = fechaApadrinamiento;
        }

    }
}
