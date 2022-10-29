using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace Eventos
{
    /// <summary>
    /// Lógica de interacción para InfoApadrinadoW.xaml
    /// </summary>
    public partial class InfoApadrinadoW : Window
    {
        private Window madre;
        private List<InfoApadrinado> listadoInfoApadrinados;
        InfoApadrinado elemento_padrino;
        public InfoApadrinadoW(Window ventana_InfoApadrinados, TextBox TbPadrino)
        {
            InitializeComponent();
            madre = ventana_InfoApadrinados;
            string nombre_padrino = TbPadrino.Text;
            listadoInfoApadrinados = LeerXML(nombre_padrino);
          
            foreach(InfoApadrinado item in listadoInfoApadrinados)
            {
                if (string.Equals(nombre_padrino, item.Nombre)) { 
                    elemento_padrino = item; 
                }

            }
            if(elemento_padrino == null)
            {
                TbNombreAp.Text = String.Empty;
                tbEmailAp.Text = String.Empty;
                TbDniAP.Text = String.Empty;
                TbDomicilioAp.Text = String.Empty;
                TbTelefonoAp.Text = String.Empty;
                DPfechaNac.SelectedDate = DateTime.Now;
                TbCuentaAp.Text = String.Empty;
                TbApMenAp.Text = String.Empty;
                TbFormaPagoAp.Text = String.Empty;
                DPfechaAp.SelectedDate = DateTime.Now;
            }
            else
            {
                TbNombreAp.Text = elemento_padrino.Nombre;
                tbEmailAp.Text = elemento_padrino.Email;
                TbDniAP.Text = elemento_padrino.Dni;
                TbDomicilioAp.Text = elemento_padrino.Domicilio;
                TbTelefonoAp.Text = elemento_padrino.Telefono;
                DPfechaNac.SelectedDate = elemento_padrino.FechaNacimiento;
                TbCuentaAp.Text = elemento_padrino.NumeroCuenta;
                TbApMenAp.Text = elemento_padrino.CuantiaAyuda;
                TbFormaPagoAp.Text = elemento_padrino.FormaPago;
                DPfechaAp.SelectedDate = elemento_padrino.FechaApadrinamiento;
            }


        }

        private List<InfoApadrinado> LeerXML(string nombrePa)
        {
            List<InfoApadrinado> listadoInfoApadrinados = new List<InfoApadrinado>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/Padrino.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoInfoApadrinado = new InfoApadrinado("", "", "", "", "", DateTime.Now, "", "", "", DateTime.Now);
                nuevoInfoApadrinado.Nombre = node.Attributes["Nombre"].Value;
                nuevoInfoApadrinado.Email = node.Attributes["Email"].Value;
                nuevoInfoApadrinado.Dni = node.Attributes["DNI"].Value;
                nuevoInfoApadrinado.Domicilio = node.Attributes["Domicilio"].Value;
                nuevoInfoApadrinado.Telefono = node.Attributes["Telefono"].Value;
                nuevoInfoApadrinado.FechaNacimiento = Convert.ToDateTime(node.Attributes["FechaNacimiento"].Value);
                nuevoInfoApadrinado.NumeroCuenta = node.Attributes["NumCuenta"].Value;
                nuevoInfoApadrinado.CuantiaAyuda = node.Attributes["Cuantia"].Value;
                nuevoInfoApadrinado.FormaPago = node.Attributes["FormaPago"].Value;
                nuevoInfoApadrinado.FechaApadrinamiento = Convert.ToDateTime(node.Attributes["Fecha"].Value);
  
                listadoInfoApadrinados.Add(nuevoInfoApadrinado);
            }
            return listadoInfoApadrinados;
        }



        private void btnAtrasAp_Click(object sender, RoutedEventArgs e)
        {
            madre.Effect = null;
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            madre.Effect = null;
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            TbNombreAp.Text = String.Empty;
            tbEmailAp.Text = String.Empty;
            TbDniAP.Text = String.Empty;
            TbDomicilioAp.Text = String.Empty;
            TbTelefonoAp.Text = String.Empty;
            DPfechaNac.SelectedDate = DateTime.Now;
            TbCuentaAp.Text = String.Empty;
            TbApMenAp.Text = String.Empty;
            TbFormaPagoAp.Text = String.Empty;
            DPfechaAp.SelectedDate = DateTime.Now;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {

        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {

            AyudaW ayudaW = new AyudaW(this);
            this.Effect = new BlurEffect();

            ayudaW.Show();
        }
    }
}
