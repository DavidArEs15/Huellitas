using Microsoft.Win32;
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
    /// </summary>

    public partial class SociosW : Window
    {
        private Window madre;
        private List<Socio> listadoSocios;
        public SociosW(Window ventana_menu)
        {
            InitializeComponent();
            madre = ventana_menu;
            listadoSocios = LeerXML();
            DataContext = listadoSocios;
            LbSocios.ItemsSource=listadoSocios;
        }

        private List<Socio> LeerXML()
        {
            List<Socio> listadoSocios = new List<Socio>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/Socios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoSocio = new Socio("", "", "", "", "", "", "", "", "", "", null);
                nuevoSocio.Nombre = node.Attributes["NombreSocio"].Value;
                nuevoSocio.Apellidos = node.Attributes["ApellidosSocio"].Value;
                nuevoSocio.Email = node.Attributes["EmailSocio"].Value;
                nuevoSocio.Dni = node.Attributes["DNISocio"].Value;
                nuevoSocio.Domicilio = node.Attributes["DomicilioSocio"].Value;
                nuevoSocio.Telefono = node.Attributes["TelefonoSocio"].Value;
                nuevoSocio.NombreBanco = node.Attributes["NombreBanco"].Value;
                nuevoSocio.NumeroCuenta = node.Attributes["NumCuenta"].Value;
                nuevoSocio.CuantiaAyuda = node.Attributes["Cuantia"].Value;
                nuevoSocio.FormaPago = node.Attributes["FormaPago"].Value;
                nuevoSocio.Imagen = new Uri(node.Attributes["Enlace"].Value, UriKind.Absolute);

                listadoSocios.Add(nuevoSocio);
            }
            return listadoSocios;
        }

        private void btnAtrasS_Click(object sender, RoutedEventArgs e)
        {
            madre.Show();
            this.Hide();
        }

        private void btnEliminarSocio_Click(object sender, RoutedEventArgs e)
        {
            listadoSocios.RemoveAt(LbSocios.SelectedIndex);
            LbSocios.Items.Refresh();
            TbDniSocio.Background = Brushes.White;
            lbFalloDni.Visibility = Visibility.Hidden;
        }

        Uri enlace = new Uri("imagenes/notFound.png", UriKind.Relative);


        private void btnAnadirSocio_Click(object sender, RoutedEventArgs e)
        {
            String nuevo_nombre = TbNombreSocio.Text;
            String nuevo_apellidos = TbApellidosSocio.Text;
            String nuevo_email = tbEmailSocio.Text;
            String nuevo_dni = TbDniSocio.Text;
            String nuevo_domicilio = TbDomicilioSocio.Text;
            String nuevo_telefono = TbTelefonoSocio.Text;
            String nuevo_nombre_banco = TbNomBancoSocio.Text;
            String nuevo_cuenta = TbCuentaSocio.Text;
            String nuevo_cuantia_ayuda = TbCAyudaSocio.Text;
            String nuevo_formaPago = TbFormaPagoSocio.Text;

            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            abrirDialog.Title = "Por favor, seleccione la Imagen del nuevo Socio: ";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    enlace = new Uri(abrirDialog.FileName, UriKind.Absolute);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                    enlace = new Uri("imagenes/notFound.png", UriKind.Relative);
                }
            }
            var nuevoSocio = new Socio(nuevo_nombre, nuevo_apellidos, nuevo_email, nuevo_dni, nuevo_domicilio, nuevo_telefono, nuevo_nombre_banco, nuevo_cuenta, nuevo_cuantia_ayuda, nuevo_formaPago, enlace);
            listadoSocios.Add(nuevoSocio);
            LbSocios.Items.Refresh();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LbSocios.SelectedIndex = -1;
            TbNombreSocio.Text = String.Empty;
            TbApellidosSocio.Text = String.Empty;
            tbEmailSocio.Text = String.Empty;
            TbDniSocio.Text = String.Empty;
            TbDomicilioSocio.Text = String.Empty;
            TbTelefonoSocio.Text = String.Empty;
            TbNomBancoSocio.Text = String.Empty;
            TbCuentaSocio.Text = String.Empty;
            TbCAyudaSocio.Text = String.Empty;
            TbFormaPagoSocio.Text = String.Empty;
            TbDniSocio.Background = Brushes.White;
            lbFalloDni.Visibility = Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnAyuda_Click_1(object sender, RoutedEventArgs e)
        {
            AyudaW ayudaW = new AyudaW(this);
            this.Effect = new BlurEffect();

            ayudaW.Show();
        }

        private void TbDniSocio_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(TbDniSocio.Text.Length != 9)
            {
                TbDniSocio.Background = Brushes.LightSalmon;
                lbFalloDni.Visibility = Visibility.Visible;

            }
            else
            {
                TbDniSocio.Background = Brushes.White;
                lbFalloDni.Visibility = Visibility.Hidden;
            }
        }

        private void btnAumentar_Click(object sender, RoutedEventArgs e)
        {
            lblNombre.FontSize = 20;
            lblApellidos.FontSize = 20;
            lblEmail.FontSize = 20;
            lblDni.FontSize = 20;
            lblDomicilio.FontSize = 20;
            lblTelefono.FontSize = 20;
            lblNombreBanco.FontSize = 20;
            lblCuenta.FontSize = 20;
            lblCuantia.FontSize = 20;
            lblPago.FontSize = 20;
            lbInfoSocio.FontSize = 22;
            lblListado.FontSize = 22;
            btnLimpiar.FontSize = 20;
            TbNombreSocio.FontSize = 20;
            TbApellidosSocio.FontSize = 20;
            tbEmailSocio.FontSize = 20;
            TbDniSocio.FontSize = 20;
            TbDomicilioSocio.FontSize = 20;
            TbTelefonoSocio.FontSize = 20;
            TbNomBancoSocio.FontSize = 20;
            TbCuentaSocio.FontSize = 20;
            TbCAyudaSocio.FontSize = 20;
            TbFormaPagoSocio.FontSize = 20;
            LbSocios.FontSize = 20;

            btnAumentar.Visibility = Visibility.Hidden;
            btnReducir.Visibility = Visibility.Visible;
        }

        private void btnReducir_Click(object sender, RoutedEventArgs e)
        {

            lblNombre.FontSize = 12;
            lblApellidos.FontSize = 12;
            lblEmail.FontSize = 12;
            lblDni.FontSize = 12;
            lblDomicilio.FontSize = 12;
            lblTelefono.FontSize = 12;
            lblNombreBanco.FontSize = 12;
            lblCuenta.FontSize = 12;
            lblCuantia.FontSize = 12;
            lblPago.FontSize = 12;
            lbInfoSocio.FontSize = 14;
            lblListado.FontSize = 14;
            btnLimpiar.FontSize = 12;
            TbNombreSocio.FontSize = 12;
            TbApellidosSocio.FontSize = 12;
            tbEmailSocio.FontSize = 12;
            TbDniSocio.FontSize = 12;
            TbDomicilioSocio.FontSize = 12;
            TbTelefonoSocio.FontSize = 12;
            TbNomBancoSocio.FontSize = 12;
            TbCuentaSocio.FontSize = 12;
            TbCAyudaSocio.FontSize = 12;
            TbFormaPagoSocio.FontSize = 12;
            LbSocios.FontSize = 12;

            btnReducir.Visibility = Visibility.Hidden;
            btnAumentar.Visibility = Visibility.Visible;

        }
    }
}
