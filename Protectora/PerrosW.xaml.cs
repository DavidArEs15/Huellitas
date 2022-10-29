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
    /// Lógica de interacción para PerrosW.xaml
    /// </summary>
    public partial class PerrosW : Window
    {
        private Window madre;
        private List<Perro> listadoPerros;
        public PerrosW(Window ventana_menu)
        {
            InitializeComponent();
            madre = ventana_menu;
            listadoPerros = LeerXML();
            DataContext = listadoPerros;
            LbPerros.ItemsSource = listadoPerros;

        }

        private List<Perro> LeerXML()
        {
            List<Perro> listadoPerros = new List<Perro>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/Perros.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoPerro = new Perro("", "", "", "", 0, 0, DateTime.Now, false, false, false, false, false, "", "", null, "", "", "", false, "");
                nuevoPerro.Nombre = node.Attributes["NombreP"].Value;
                nuevoPerro.Sexo = node.Attributes["SexoP"].Value;
                nuevoPerro.Raza = node.Attributes["Raza"].Value;
                nuevoPerro.Tamano = node.Attributes["Tamanyo"].Value;
                nuevoPerro.Peso = Convert.ToInt32(node.Attributes["Peso"].Value);
                nuevoPerro.Edad = Convert.ToInt32(node.Attributes["EdadP"].Value);
                nuevoPerro.FechaEntrada = Convert.ToDateTime(node.Attributes["Entrada"].Value);
                nuevoPerro.Chip = Convert.ToBoolean(node.Attributes["Chip"].Value);
                nuevoPerro.Cachorro = Convert.ToBoolean(node.Attributes["Cachorro"].Value);
                nuevoPerro.PPP = Convert.ToBoolean(node.Attributes["PPP"].Value);
                nuevoPerro.Vacunado = Convert.ToBoolean(node.Attributes["Vacunado"].Value);
                nuevoPerro.Esterilizado = Convert.ToBoolean(node.Attributes["Esterilizado"].Value);
                nuevoPerro.Enfermedades = node.Attributes["Enfermedades"].Value;
                nuevoPerro.Tratamientos = node.Attributes["Tratamientos"].Value;
                nuevoPerro.EnlaceImag = new Uri(node.Attributes["Enlaces"].Value, UriKind.Absolute);
                nuevoPerro.Descripcion = node.Attributes["Descripcion"].Value;
                nuevoPerro.Caracteristicas = node.Attributes["Caracteristicas"].Value;
                nuevoPerro.Estado = node.Attributes["Estado"].Value;
                nuevoPerro.Apadrinado = Convert.ToBoolean(node.Attributes["Apadrinado"].Value);
                nuevoPerro.NombrePadrino = node.Attributes["NombrePadrino"].Value;

                listadoPerros.Add(nuevoPerro);
            }
            return listadoPerros;
        }

        private void btnEliminarPerro_Click(object sender, RoutedEventArgs e)
        {
            listadoPerros.RemoveAt(LbPerros.SelectedIndex);
            LbPerros.Items.Refresh();
            TbPeso.Text = "0";
            TbEdad.Text = "0";
            DPEntrada.SelectedDate = DateTime.Now;
        }

        Uri enlace = new Uri("imagenes/notFound.png", UriKind.Relative);


        private void btnAnadirPerro_Click(object sender, RoutedEventArgs e)
        {
            String nuevo_nombre = TbNombrePerro.Text;
            String nuevo_sexo = TbSexo.Text;
            String nuevo_raza = tbRaza.Text;
            String nuevo_tamanyo = TbTamanyo.Text;
            int nuevo_peso = Convert.ToInt32(TbPeso.Text);
            int nuevo_edad = Convert.ToInt32(TbEdad.Text);
            DateTime nueva_fechaEntrada = (DateTime)DPEntrada.SelectedDate;
            bool nuevo_chip = (bool)CBchip.IsChecked;
            bool nuevo_cachorro = (bool)CBcachorro.IsChecked;
            bool nuevo_ppp = (bool)CBppp.IsChecked;
            bool nuevo_vacunado = (bool)CBvacunado.IsChecked;
            bool nuevo_esterilizado = (bool)CBesterilizado.IsChecked;
            String nuevo_enfermedades = TbEnfermedades.Text;
            String nuevo_tratamientos = tbTratamientos.Text;
            String nuevo_descripcion = TbDescripcion.Text;
            String nuevo_caracteristicas = TbCaracteristicas.Text;
            String nuevo_estado = TbEstado.Text;
            bool nuevo_apadrinado = (bool)CBApadrinado.IsChecked;
            String nuevo_nombrepadrino = TbNombrePadrino.Text;

            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            abrirDialog.Title = "Por favor, seleccione la Imagen del nuevo Perro: ";
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
            var nuevoPerro = new Perro(nuevo_nombre, nuevo_sexo, nuevo_raza, nuevo_tamanyo, nuevo_peso, nuevo_edad, nueva_fechaEntrada, nuevo_chip, nuevo_cachorro, nuevo_ppp, nuevo_vacunado, nuevo_esterilizado, nuevo_enfermedades, nuevo_tratamientos, enlace, nuevo_descripcion, nuevo_caracteristicas, nuevo_estado, nuevo_apadrinado, nuevo_nombrepadrino);
            listadoPerros.Add(nuevoPerro);
            LbPerros.Items.Refresh();
        }


        private void btnAtrasP_Click(object sender, RoutedEventArgs e)
        {
            madre.Show();
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LbPerros.SelectedIndex = -1;
            TbNombrePerro.Text = String.Empty;
            TbSexo.Text = String.Empty;
            tbRaza.Text = String.Empty;
            TbTamanyo.Text = String.Empty;
            TbPeso.Text = "0";
            TbEdad.Text = "0";
            DPEntrada.SelectedDate = DateTime.Now;
            CBchip.IsChecked = false;
            CBcachorro.IsChecked = false;
            CBppp.IsChecked = false;
            CBvacunado.IsChecked = false;
            CBesterilizado.IsChecked = false;
            TbEnfermedades.Text = String.Empty;
            tbTratamientos.Text = String.Empty;
            TbDescripcion.Text = String.Empty;
            TbCaracteristicas.Text = String.Empty;
            TbEstado.Text = String.Empty;
            CBApadrinado.IsChecked = false;
            TbNombrePadrino.Text = String.Empty;
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LbPerros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            bool apadrinado = (bool)CBApadrinado.IsChecked;
            if (apadrinado == false)
            {
                btnApadrinado.IsEnabled = false;
                TbNombrePadrino.IsEnabled = false;
                TbNombrePadrino.Text = "-";
            }
            else
            {
                TbNombrePadrino.IsEnabled = true;
                btnApadrinado.IsEnabled = true;
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            TbPeso.Text = "0";
            TbEdad.Text = "0";
            DPEntrada.SelectedDate = DateTime.Now;
        }

        private void CBApadrinado_Checked(object sender, RoutedEventArgs e)
        {
            TbNombrePadrino.IsEnabled = true;
            btnApadrinado.IsEnabled = true;
        }

        private void CBApadrinado_Unchecked(object sender, RoutedEventArgs e)
        {
            TbNombrePadrino.IsEnabled = false;
            TbNombrePadrino.Text = "-";
            btnApadrinado.IsEnabled = false;
        }

        private void btnApadrinado_Click(object sender, RoutedEventArgs e)
        {
            InfoApadrinadoW apadrinadoW = new InfoApadrinadoW(this, TbNombrePadrino);

            apadrinadoW.Show();
            this.Effect = new BlurEffect();
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            AyudaW ayudaW = new AyudaW(this);
            this.Effect = new BlurEffect();

            ayudaW.Show();
        }

        private void btnAumentar_Click(object sender, RoutedEventArgs e)
        {
            lbInfoPerro.FontSize = 22;
            lblNombreP.FontSize = 20;
            lblCaracteristicasP.FontSize = 20;
            lblDescripcionP.FontSize = 20;
            lblEdadP.FontSize = 20;
            lblEnfermedadesP.FontSize = 20;
            lblEstadoP.FontSize = 20;
            lblFentradaP.FontSize = 20;
            lblListadoP.FontSize = 22;
            lblPadrino.FontSize = 20;
            lblPesoP.FontSize = 20;
            lblRazaP.FontSize = 20;
            lblSexoP.FontSize = 20;
            lblTamanyoP.FontSize = 20;
            lblTratamientos.FontSize = 20;
            TbNombrePerro.FontSize = 20;
            TbCaracteristicas.FontSize = 20;
            TbDescripcion.FontSize = 20;
            TbEdad.FontSize = 20;
            TbEnfermedades.FontSize = 20;
            TbEstado.FontSize = 20;
            DPEntrada.FontSize = 20;
            LbPerros.FontSize = 20;
            TbNombrePadrino.FontSize = 20;
            TbPeso.FontSize = 20;
            tbRaza.FontSize = 20;
            TbSexo.FontSize = 20;
            TbTamanyo.FontSize = 20;
            tbTratamientos.FontSize = 20;
            CBApadrinado.FontSize = 20;
            CBcachorro.FontSize = 20;
            CBchip.FontSize = 20;
            CBesterilizado.FontSize = 20;
            CBppp.FontSize = 20;
            CBvacunado.FontSize = 20;
            btnLimpiarCampos.FontSize = 20;
            btnApadrinado.FontSize = 20;
            btnAumentar.Visibility = Visibility.Hidden;
            btnReducir.Visibility = Visibility.Visible;
        }

        private void btnReducir_Click(object sender, RoutedEventArgs e)
        {
            lbInfoPerro.FontSize = 14;
            lblNombreP.FontSize = 12;
            lblCaracteristicasP.FontSize = 12;
            lblDescripcionP.FontSize = 12;
            lblEdadP.FontSize = 12;
            lblEnfermedadesP.FontSize = 12;
            lblEstadoP.FontSize = 12;
            lblFentradaP.FontSize = 12;
            lblListadoP.FontSize = 14;
            lblPadrino.FontSize = 12;
            lblPesoP.FontSize = 12;
            lblRazaP.FontSize = 12;
            lblSexoP.FontSize = 12;
            lblTamanyoP.FontSize = 12;
            lblTratamientos.FontSize = 12;
            TbNombrePerro.FontSize = 12;
            TbCaracteristicas.FontSize = 12;
            TbDescripcion.FontSize = 12;
            TbEdad.FontSize = 12;
            TbEnfermedades.FontSize = 12;
            TbEstado.FontSize = 12;
            DPEntrada.FontSize = 12;
            LbPerros.FontSize = 12;
            TbNombrePadrino.FontSize = 12;
            TbPeso.FontSize = 12;
            tbRaza.FontSize = 12;
            TbSexo.FontSize = 12;
            TbTamanyo.FontSize = 12;
            tbTratamientos.FontSize = 12;
            CBApadrinado.FontSize = 12;
            CBcachorro.FontSize = 12;
            CBchip.FontSize = 12;
            CBesterilizado.FontSize = 12;
            CBppp.FontSize = 12;
            CBvacunado.FontSize = 12;
            btnLimpiarCampos.FontSize = 12;
            btnApadrinado.FontSize = 12;
            btnReducir.Visibility = Visibility.Hidden;
            btnAumentar.Visibility = Visibility.Visible;
        }
    }
}
