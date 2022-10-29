using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    class Perdido
    {

        public string Nombre { set; get; }
        public string Sexo { set; get; }
        public string Raza { set; get; }
        public string Color { set; get; }
        public string Pelo { set; get; }
        public bool Collar { set; get; }
        public string ColorCollar { set; get; }
        public DateTime FechaPerdida { set; get; }
        public string ZonaPerdida { get; set; }
        public string NombreDueño { get; set; }
        public string ApellidosDueño { get; set; }
        public string EmailDueño { get; set; }
        public string DNIDueño { get; set; }
        public string DomicilioDueño { get; set; }
        public string TelefonoDueño { get; set; }
        public Uri UrlImagen { set; get; }
        public Perdido(string nombre, string sexo, string raza, string
        color, string pelo, bool collar, string colorCollar, DateTime fechaPerdida, string zonaPerdida, string nombreDueño, string apellidosDueño, string emailDueño, string dniDueño, string domicilioDueño, string telefonoDueño, Uri urlImagen)
        {
            Nombre = nombre;
            Sexo = sexo;
            Raza = raza;
            Color = color;
            Pelo = pelo;
            Collar = collar;
            ColorCollar = colorCollar;
            FechaPerdida = fechaPerdida;
            ZonaPerdida = zonaPerdida;
            NombreDueño = nombreDueño;
            ApellidosDueño = apellidosDueño;
            EmailDueño = emailDueño;
            DNIDueño = dniDueño;
            DomicilioDueño = domicilioDueño;
            TelefonoDueño = telefonoDueño;
            UrlImagen = urlImagen;
        }

    }
}
