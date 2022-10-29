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
    /// Lógica de interacción para Perdidos.xaml
    /// </summary>
    public partial class Perdidos : Window
    {
        private Window madre;
        private List<Perdido> listadoPerdidos;
        public Perdidos(Window ventana_menu)
        {
            InitializeComponent();
            madre = ventana_menu;
            listadoPerdidos = LeerXML();
            DataContext = listadoPerdidos;
            LbPerrosPerdidos.ItemsSource = listadoPerdidos;
        }

        private List<Perdido> LeerXML()
        {
            List<Perdido> listadoPerdidos = new List<Perdido>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/perros_perdidos.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoPerdido = new Perdido("", "", "", "", "", false, "", DateTime.Now, "", "", "", "", "", "", "", null);
                nuevoPerdido.Nombre = node.Attributes["NombreP"].Value;
                nuevoPerdido.Sexo = node.Attributes["SexoP"].Value;
                nuevoPerdido.Raza = node.Attributes["Raza"].Value;
                nuevoPerdido.Color = node.Attributes["Color"].Value;
                nuevoPerdido.Pelo = node.Attributes["Pelo"].Value;
                nuevoPerdido.Collar = Convert.ToBoolean(node.Attributes["Collar"].Value);
                nuevoPerdido.ColorCollar = node.Attributes["ColorCollar"].Value;
                nuevoPerdido.FechaPerdida = Convert.ToDateTime(node.Attributes["FechaPerdida"].Value);
                nuevoPerdido.ZonaPerdida = node.Attributes["ZonaPerdida"].Value;
                nuevoPerdido.NombreDueño = node.Attributes["NombreDueño"].Value;
                nuevoPerdido.ApellidosDueño = node.Attributes["ApellidosDueño"].Value;
                nuevoPerdido.EmailDueño = node.Attributes["EmailDueño"].Value;
                nuevoPerdido.DNIDueño = node.Attributes["DNIDueño"].Value;
                nuevoPerdido.DomicilioDueño = node.Attributes["DomicilioDueño"].Value;
                nuevoPerdido.TelefonoDueño = node.Attributes["TelefonoDueño"].Value;
                nuevoPerdido.UrlImagen = new Uri(node.Attributes["Enlaces"].Value, UriKind.Absolute);

                listadoPerdidos.Add(nuevoPerdido);
            }
            return listadoPerdidos;
        }

        Uri enlace = new Uri("imagenes/notFound.png", UriKind.Relative);


        private void btnAtrasPd_Click(object sender, RoutedEventArgs e)
        {
            madre.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LbPerrosPerdidos.SelectedIndex = -1;
            TbNombrePerro.Text = String.Empty;
            TbSexo.Text = String.Empty;
            tbRaza.Text = String.Empty;
            TbColor.Text = String.Empty;
            TbPelo.Text = String.Empty;
            CBCollar.IsChecked = false;
            TbColorCollar.Text = String.Empty;
            DPFechaPerdida.SelectedDate = DateTime.Now;
            TbZonaPerdida.Text = String.Empty;
            TbNombreD.Text = String.Empty;
            TbApellidosD.Text = String.Empty;
            tbEmailD.Text = String.Empty;
            TbDniD.Text = String.Empty;
            TbDomicilioD.Text = String.Empty;
            TbTelefonoD.Text = String.Empty;
           
        }

        private void btnAnadirPerdido_Click(object sender, RoutedEventArgs e)
        {
            String nuevo_nombre = TbNombrePerro.Text;
            String nuevo_sexo = TbSexo.Text;
            String nuevo_raza = tbRaza.Text;
            String nuevo_color = TbColor.Text;
            String nuevo_pelo = TbPelo.Text;
            bool collar = (bool)CBCollar.IsChecked;
            String nuevo_colorCollar = TbColorCollar.Text;
            DateTime nueva_fechaPerdida = (DateTime)DPFechaPerdida.SelectedDate;
            String nuevo_zonaPerdida = TbZonaPerdida.Text;
            String nuevo_nombreDueño = TbNombreD.Text;
            String nuevo_apellidosDueño = TbApellidosD.Text;
            String nuevo_emailDueño = tbEmailD.Text;
            String nuevo_dniDueño = TbDniD.Text;
            String nuevo_domicilioDueño = TbDomicilioD.Text;
            String nuevo_telefonoDueño = TbTelefonoD.Text;


            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            abrirDialog.Title = "Por favor, seleccione una imagen del perro perdido para el aviso: ";
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
            var nuevoPerdido = new Perdido(nuevo_nombre, nuevo_sexo, nuevo_raza, nuevo_color, nuevo_pelo, collar, nuevo_colorCollar, nueva_fechaPerdida, nuevo_zonaPerdida, nuevo_nombreDueño, nuevo_apellidosDueño, nuevo_emailDueño, nuevo_dniDueño, nuevo_domicilioDueño, nuevo_telefonoDueño, enlace);
            listadoPerdidos.Add(nuevoPerdido);
            LbPerrosPerdidos.Items.Refresh();

        }

        private void btnEliminarPerdido_Click(object sender, RoutedEventArgs e)
        {
            listadoPerdidos.RemoveAt(LbPerrosPerdidos.SelectedIndex);
            LbPerrosPerdidos.Items.Refresh();
            DPFechaPerdida.SelectedDate = DateTime.Now;
        }

        private void LbPerrosPerdidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBCollar.IsChecked == false)
            {
                TbColorCollar.IsEnabled = false;
                TbColorCollar.Text = "-";
            }
            else
            {
                TbColorCollar.IsEnabled = true;
            }
        }

        private void CBCollar_Checked(object sender, RoutedEventArgs e)
        {
            TbColorCollar.IsEnabled = true;
        }

        private void CBCollar_Unchecked(object sender, RoutedEventArgs e)
        {
            TbColorCollar.IsEnabled = false;
            TbColorCollar.Text = "-";
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            DPFechaPerdida.SelectedDate = DateTime.Now;
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            AyudaW ayudaW = new AyudaW(this);
            this.Effect = new BlurEffect();

            ayudaW.Show();
        }

        private void btnAumentar_Click(object sender, RoutedEventArgs e)
        {

            lblNombre.FontSize = 20;
            lblSexo.FontSize = 20;
            lblRaza.FontSize = 20;
            lblColor.FontSize = 20;
            lblPelo.FontSize = 20;
            CBCollar.FontSize = 20;
            lblColorCollar.FontSize = 20;
            lblFechaPerdida.FontSize = 20;
            lblZona.FontSize = 20;
            lblNombreDueno.FontSize = 20;
            lblApellidosDueno.FontSize = 20;
            lblEmailDueno.FontSize = 20;
            lblDniDueno.FontSize = 20;
            lblDomicilioDueno.FontSize = 20;
            lblTelefonoDueno.FontSize = 20;
            lbInfoDueno.FontSize = 22;
            lbInfoPerro.FontSize = 22;
            lblListado.FontSize = 22;
            btnLimpiar.FontSize = 20;
            TbNombrePerro.FontSize = 20;
            TbSexo.FontSize = 20;
            tbRaza.FontSize = 20;
            TbColor.FontSize = 20;
            TbPelo.FontSize = 20;
            TbColorCollar.FontSize = 20;
            DPFechaPerdida.FontSize = 20;
            TbZonaPerdida.FontSize = 20;
            TbNombreD.FontSize = 20;
            TbApellidosD.FontSize = 20;
            tbEmailD.FontSize = 20;
            TbDniD.FontSize = 20;
            TbDomicilioD.FontSize = 20;
            TbTelefonoD.FontSize = 20;
            LbPerrosPerdidos.FontSize = 20;

            btnAumentar.Visibility = Visibility.Hidden;
            btnReducir.Visibility = Visibility.Visible;
        }

        private void btnReducir_Click(object sender, RoutedEventArgs e)
        {
            lblNombre.FontSize = 12;
            lblSexo.FontSize = 12;
            lblRaza.FontSize = 12;
            lblColor.FontSize = 12;
            lblPelo.FontSize = 12;
            CBCollar.FontSize = 12;
            lblColorCollar.FontSize = 12;
            lblFechaPerdida.FontSize = 12;
            lblZona.FontSize = 12;
            lblNombreDueno.FontSize = 12;
            lblApellidosDueno.FontSize = 12;
            lblEmailDueno.FontSize = 12;
            lblDniDueno.FontSize = 12;
            lblDomicilioDueno.FontSize = 12;
            lblTelefonoDueno.FontSize = 12;
            lbInfoDueno.FontSize = 14;
            lbInfoPerro.FontSize = 14;
            lblListado.FontSize = 14;
            btnLimpiar.FontSize = 12;
            TbNombrePerro.FontSize = 12;
            TbSexo.FontSize = 12;
            tbRaza.FontSize = 12;
            TbColor.FontSize = 12;
            TbPelo.FontSize = 12;
            TbColorCollar.FontSize = 12;
            DPFechaPerdida.FontSize = 12;
            TbZonaPerdida.FontSize = 12;
            TbNombreD.FontSize = 12;
            TbApellidosD.FontSize = 12;
            tbEmailD.FontSize = 12;
            TbDniD.FontSize = 12;
            TbDomicilioD.FontSize = 12;
            TbTelefonoD.FontSize = 12;
            LbPerrosPerdidos.FontSize = 12;

            btnReducir.Visibility = Visibility.Hidden;
            btnAumentar.Visibility = Visibility.Visible;
        }
    }
}
