using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    class Perro
    {
        public string Nombre { set; get; }
        public string Sexo { set; get; }
        public string Raza { set; get; }
        public string Tamano { set; get; }
        public int Peso { set; get; }
        public int Edad { set; get; }
        public DateTime FechaEntrada { set; get; }
        public bool Chip { get; set; }
        public bool Cachorro { get; set; }
        public bool PPP { get; set; }
        public bool Vacunado { get; set; }
        public bool Esterilizado { get; set; }
        public string Enfermedades { set; get; }
        public string Tratamientos { set; get; }
        public Uri EnlaceImag { set; get; }
        public string Descripcion { set; get; }
        public string Caracteristicas { set; get; }
        public string Estado { set; get; }
        public bool Apadrinado { set; get; }
        public string NombrePadrino { set; get; }
        public Perro(string nombre, string sexo, string raza, string
        tamano, int peso, int edad, DateTime fechaEntrada, bool chip, bool cachorro, bool ppp, bool vacunado, bool esterilizado, string enfermedades, string tratamientos, Uri enlaceImag, string descripcion, string caracteristicas, string estado, bool apadrinado, string nombrePadrino)
        {
            Nombre = nombre;
            Sexo = sexo;
            Raza = raza;
            Tamano = tamano;
            Peso = peso;
            Edad = edad;
            FechaEntrada = fechaEntrada;
            Chip = chip;
            Cachorro = cachorro;
            PPP = ppp;
            Vacunado = vacunado;
            Esterilizado = esterilizado;
            Enfermedades = enfermedades;
            Tratamientos = tratamientos;
            EnlaceImag = enlaceImag;
            Descripcion = descripcion;
            Caracteristicas = caracteristicas;
            Estado = estado;
            Apadrinado = apadrinado;
            NombrePadrino = nombrePadrino;
            
        }
    }
}
