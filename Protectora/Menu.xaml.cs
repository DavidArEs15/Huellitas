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

namespace Eventos
{
    /// <summary>
    /// </summary>
    public partial class Menu : Window
    {
        private Window madre;
        public Menu(string nombre_usuario, object selectedItem, Window ventana_login)
        {
            InitializeComponent();
            String idioma = "en-UK";
            if(selectedItem == null)
            {
                App.DefineIdioma("en-UK");
                idioma = "en-UK";
            }
            else if (selectedItem.Equals("Español"))
            {
                App.DefineIdioma("es-ES");
                idioma = "es-ES";
            } else if (selectedItem.Equals("English"))
            {
                App.DefineIdioma("en-UK");
                idioma = "en-UK";
            }
            Resources.MergedDictionaries.Add(App.DefineIdioma(idioma));
            madre = ventana_login;
            if (nombre_usuario == "IV")
            {
                lblNombreUsuario.Content = "Isabel";
                lblApellidosUsuario.Content = "Gonzalez Vega";
                lblDniusuario.Content = "03584912A";
                lblEmailusuario.Content = "isabelGV@gmail.com";
                lblFechaNacUsuario.Content = "15/03/2000";
                lblFechaUltimoAcceso.Content = DateTime.Now;
            }

            if (nombre_usuario == "PD")
            {
                lblNombreUsuario.Content = "Patricia";
                lblApellidosUsuario.Content = "Diez Herguido";
                lblDniusuario.Content = "46384912A";
                lblEmailusuario.Content = "patriciaDH@gmail.com";
                lblFechaNacUsuario.Content = "10/11/2001";
                lblFechaUltimoAcceso.Content = DateTime.Now;
            }

            if(nombre_usuario == "Deivi15")
            {
                lblNombreUsuario.Content = "David";
                lblApellidosUsuario.Content = "Arias Escribano";
                lblDniusuario.Content = "06327282P";
                lblEmailusuario.Content = "davidArEs@gmail.com";
                lblFechaNacUsuario.Content = "15/06/2001";
                lblFechaUltimoAcceso.Content = DateTime.Now;
            }
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            madre.Show();
            this.Hide();
        }
        private void btnGestionV_Click(object sender, RoutedEventArgs e)
        {
            VoluntariosW voluntariosW = new VoluntariosW(this);

            voluntariosW.Show();
            this.Hide();
        }

        private void btnGestionP_Click(object sender, RoutedEventArgs e)
        {
            PerrosW perrosW = new PerrosW(this);

            perrosW.Show();
            this.Hide();
        }

        private void btnGestionS_Click(object sender, RoutedEventArgs e)
        {
            SociosW sociosW = new SociosW(this);

            sociosW.Show();
            this.Hide();
        }

        private void btnAvisosPerdidos_Click(object sender, RoutedEventArgs e)
        {
            Perdidos perdidos = new Perdidos(this);

            perdidos.Show();
            this.Hide();
        }

        private void Menu1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Ayuda_Click(object sender, RoutedEventArgs e)
        {
            AyudaW ayudaW = new AyudaW(this);
            this.Effect = new BlurEffect();

            ayudaW.Show();
        }

        private void btnAumentar_Click(object sender, RoutedEventArgs e)
        {
            lbl_opcionmenu.FontSize = 26;
            lblNombreUsuario.FontSize = 21;
            lblApellidosUsuario.FontSize = 21;
            lblDniusuario.FontSize = 21;
            lblEmailusuario.FontSize = 21;
            lblFechaNacUsuario.FontSize = 21;
            lblFechaUltimoAcceso.FontSize = 21;
            btnGestionS.FontSize = 21;
            btnGestionP.FontSize = 21;
            btnGestionV.FontSize = 21;
            btnAvisosPerdidos.FontSize = 21;
            lblMenu.FontSize = 46;
            btnAumentar.Visibility = Visibility.Hidden;
            btnReducir.Visibility = Visibility.Visible;
        }

        private void btnReducir_Click(object sender, RoutedEventArgs e)
        {
            lbl_opcionmenu.FontSize = 20;
            lblNombreUsuario.FontSize = 15;
            lblApellidosUsuario.FontSize = 15;
            lblDniusuario.FontSize = 15;
            lblEmailusuario.FontSize = 15;
            lblFechaNacUsuario.FontSize = 15;
            lblFechaUltimoAcceso.FontSize = 15;
            btnGestionS.FontSize = 15;
            btnGestionP.FontSize = 15;
            btnGestionV.FontSize = 15;
            btnAvisosPerdidos.FontSize = 15;
            lblMenu.FontSize = 40;
            btnReducir.Visibility = Visibility.Hidden;
            btnAumentar.Visibility = Visibility.Visible;
        }
    }
}
