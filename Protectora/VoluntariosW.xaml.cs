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
    /// Lógica de interacción para VoluntariosW.xaml
    /// </summary>
    public partial class VoluntariosW : Window
    {
        private Window madre;
        private List<Voluntario> listadoVoluntarios;
        public VoluntariosW(Window ventana_menu)
        {
            InitializeComponent();
            madre = ventana_menu;
            listadoVoluntarios = LeerXML();
            DataContext = listadoVoluntarios;
            LbVoluntarios.ItemsSource = listadoVoluntarios;
        }

        private List<Voluntario> LeerXML()
        {
            List<Voluntario> listadoVoluntarios = new List<Voluntario>();
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/Voluntarios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoVoluntario = new Voluntario("", "", "", "", "", "", "", false, null);
                nuevoVoluntario.Nombre = node.Attributes["Nombre"].Value;
                nuevoVoluntario.Apellidos = node.Attributes["Apellidos"].Value;
                nuevoVoluntario.Email = node.Attributes["Email"].Value;
                nuevoVoluntario.Dni = node.Attributes["DNI"].Value;
                nuevoVoluntario.Telefono = node.Attributes["Telefono"].Value;
                nuevoVoluntario.Horario = node.Attributes["Horario"].Value;
                nuevoVoluntario.Zona = node.Attributes["Zona"].Value;
                nuevoVoluntario.ConocimientosVet = Convert.ToBoolean(node.Attributes["ConVeterinarios"].Value);
                nuevoVoluntario.UrlImagen = new Uri(node.Attributes["URL_imagen"].Value, UriKind.Absolute);

                listadoVoluntarios.Add(nuevoVoluntario);
            }
            return listadoVoluntarios;
        }

        private void btnEliminarVoluntario_Click(object sender, RoutedEventArgs e)
        {
            listadoVoluntarios.RemoveAt(LbVoluntarios.SelectedIndex);
            LbVoluntarios.Items.Refresh();
            TbDni.Background = Brushes.White;
            lbFalloDni.Visibility = Visibility.Hidden;
        }

        Uri enlace = new Uri("imagenes/notFound.png", UriKind.Relative);


        private void btnAnadirVoluntario_Click(object sender, RoutedEventArgs e)
        {
            String nuevo_nombre = TbNombreVoluntario.Text;
            String nuevo_apellidos = TbApellidos.Text;
            String nuevo_email = tbEmail.Text;
            String nuevo_dni = TbDni.Text;
            String nuevo_telefono = TbTelefono.Text;
            String nuevo_horario = TbHorario.Text;
            String nuevo_zona = TbZona.Text;
            bool nuevo_conocV = (bool)CBconocV.IsChecked;


            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            abrirDialog.Title = "Por favor, seleccione la Imagen del nuevo Voluntario: ";
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
            var nuevoVoluntario = new Voluntario(nuevo_nombre, nuevo_apellidos, nuevo_email, nuevo_dni, nuevo_telefono, nuevo_horario, nuevo_zona, nuevo_conocV, enlace);
            listadoVoluntarios.Add(nuevoVoluntario);
            LbVoluntarios.Items.Refresh();
        }

        private void btnAtrasV_Click(object sender, RoutedEventArgs e)
        {
            madre.Show();
            this.Hide();
        }


        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LbVoluntarios.SelectedIndex = -1;
            TbNombreVoluntario.Text = String.Empty;
            TbApellidos.Text = String.Empty;
            tbEmail.Text = String.Empty;
            TbDni.Text = String.Empty;
            TbTelefono.Text = String.Empty;
            TbHorario.Text = String.Empty;
            TbZona.Text = String.Empty;
            CBconocV.IsChecked = false;
            TbDni.Background = Brushes.White;
            lbFalloDni.Visibility = Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            AyudaW ayudaW = new AyudaW(this);
            this.Effect = new BlurEffect();

            ayudaW.Show();
        }

        private void TbDni_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TbDni.Text.Length != 9)
            {
                TbDni.Background = Brushes.LightSalmon;
                lbFalloDni.Visibility = Visibility.Visible;

            }
            else
            {
                TbDni.Background = Brushes.White;
                lbFalloDni.Visibility = Visibility.Hidden;
            }
        }

        private void btnAumentar_Click(object sender, RoutedEventArgs e)
        {
            lblNombreV.FontSize = 20;
            lblApellidosV.FontSize = 20;
            lblDniV.FontSize = 20;
            lblEmailV.FontSize = 20;
            lblHorarioV.FontSize = 20;
            lblTelefonoV.FontSize = 20;
            lblZonaV.FontSize = 20;
            lblInfoVoluntario.FontSize = 22;
            lblListaV.FontSize = 22;
            LbVoluntarios.FontSize = 20;
            CBconocV.FontSize = 20;
            btnLimpiar.FontSize = 20;
            TbNombreVoluntario.FontSize = 20;
            TbApellidos.FontSize = 20;
            tbEmail.FontSize = 20;
            TbDni.FontSize = 20;
            TbHorario.FontSize = 20;
            TbTelefono.FontSize = 20;
            TbZona.FontSize = 20;
            btnAumentar.Visibility = Visibility.Hidden;
            btnReducir.Visibility = Visibility.Visible;
        }

        private void btnReducir_Click(object sender, RoutedEventArgs e)
        {
            lblNombreV.FontSize = 12;
            lblApellidosV.FontSize = 12;
            lblDniV.FontSize = 12;
            lblEmailV.FontSize = 12;
            lblHorarioV.FontSize = 12;
            lblTelefonoV.FontSize = 12;
            lblZonaV.FontSize = 12;
            lblInfoVoluntario.FontSize = 14;
            lblListaV.FontSize = 14;
            LbVoluntarios.FontSize = 12;
            CBconocV.FontSize = 12;
            btnLimpiar.FontSize = 12;
            TbNombreVoluntario.FontSize = 12;
            TbApellidos.FontSize = 12;
            tbEmail.FontSize = 12;
            TbDni.FontSize = 12;
            TbHorario.FontSize = 12;
            TbTelefono.FontSize = 12;
            TbZona.FontSize = 12;
            btnReducir.Visibility = Visibility.Hidden;
            btnAumentar.Visibility = Visibility.Visible;
        }
    }
}
