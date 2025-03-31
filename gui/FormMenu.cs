using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class FormMenu : Form , iObserverLenguaje
    {
        FormABMUsuario formABMUSUARIO;
        FormCambiarClave formCambiarClave;
        FormCambiarIdioma formCambiarIdioma;
        FormBitacoraDeEventos formBitacoraDeEventos;
        FormPermisos formPermisos;
        
        public FormMenu()
        {
            InitializeComponent();
            LabelNombreUsuarioa.AutoSize = false;
            LabelNombreUsuarioa.MaximumSize = new Size(panelPrincipal.Width, 0);


            LabelNombreUsuarioa.Height = LabelNombreUsuarioa.PreferredHeight; // Ajusta la altura automáticamente

            LabelRolUsuario.AutoSize = false;
            LabelRolUsuario.MaximumSize = new Size(panelPrincipal.Width, 0);
            LabelRolUsuario.Height = LabelRolUsuario.PreferredHeight; // Ajusta la altura automáticamente
            SuscribirFormularios();

            Traductor.TraductorSG.Notificar();



            LabelNombreUsuarioa.Height = LabelNombreUsuarioa.PreferredHeight; // Ajusta la altura automáticamente
            LabelRolUsuario.Height = LabelRolUsuario.PreferredHeight; // Ajusta la altura automáticamente

            VerificarAccesibilidadDeTodosLosControles();

            Diseno();
        }
        public void SuscribirFormularios()
        {
            formABMUSUARIO = new FormABMUsuario(this);
            formCambiarClave = new FormCambiarClave();
            formCambiarIdioma = new FormCambiarIdioma();
            formBitacoraDeEventos = new FormBitacoraDeEventos();
            formPermisos = new FormPermisos();
            
            Traductor.TraductorSG.Suscribir(this);
            Traductor.TraductorSG.Suscribir(formABMUSUARIO);
            Traductor.TraductorSG.Suscribir(formCambiarClave);
            Traductor.TraductorSG.Suscribir(formCambiarIdioma);
            Traductor.TraductorSG.Suscribir(formBitacoraDeEventos);
            Traductor.TraductorSG.Suscribir(formPermisos);

        }
        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            SesionManager.GestorSesion.Logout();
            GestorForm.gestorFormSG.DefinirEstado(new EstadoCerrarAplicacion());
        }
        #region Diseno
        //Prueba Botones Nuevo Diseño Del Menu
        private void Diseno()
        {
            panelAdministrarSubmenu.Visible = false;
            panelSubmenuPrueba2.Visible = false;
            panelSubmenuPrueba3.Visible = false;
            panelSubmenuPrueba.Visible = false;
        }

        private void hideSubmenu()
        {
            if(panelAdministrarSubmenu.Visible == true)
            {
                panelAdministrarSubmenu.Visible = false;
            }
            if(panelSubmenuPrueba2.Visible == true)
            {
                panelSubmenuPrueba2.Visible = false;
            }
            if(panelSubmenuPrueba3.Visible == true)
            {
                panelSubmenuPrueba3.Visible = false;
            }
            if(panelSubmenuPrueba.Visible == true)
            {
                panelSubmenuPrueba.Visible=false;
            }
        }
        private void showSubmenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        #endregion

        #region Button Click

        private void BT_ADMINISTRAR_Click(object sender, EventArgs e)
        {
            showSubmenu(panelAdministrarSubmenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            formABMUSUARIO.ShowDialog();
           
            hideSubmenu();
            
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formBitacoraDeEventos.ShowDialog();
            hideSubmenu();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formPermisos.ShowDialog();
            hideSubmenu();
            this.Show();
        }

        private void BT_Prueba_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubmenuPrueba);
        }

        private void BT_Prueba2_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubmenuPrueba2);
        }

        private void BT_Prueba3_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubmenuPrueba3);
        }

        private void button8_Click(object sender, EventArgs e)
        {

            formCambiarClave.ShowDialog();
            
            hideSubmenu();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BitacoraBLL GestorBitacora = new BitacoraBLL();
            GestorBitacora.AltaEvento("Inicio de Sesion", "Salida del Sistema", 4);
            SesionManager.GestorSesion.Logout();
            GestorForm.gestorFormSG.DefinirEstado(new EstadoIniciarSesion());
            hideSubmenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            formCambiarIdioma.ShowDialog();
       
            hideSubmenu();
          
            this.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            SesionManager.GestorSesion.Logout();
            GestorForm.gestorFormSG.DefinirEstado(new EstadoCerrarAplicacion());
            hideSubmenu();
        }
        #endregion

        public void ActualizarLenguaje()
        {
            RecorrerControles(this);
        }

        public void RecorrerControles(Control control)
        {
            foreach (Control c in control.Controls)
            {
                // Aquí puedes hacer lo que quieras con cada control.
                c.Text = Traductor.TraductorSG.Traducir(c.Name);
                if(c.Name == LabelNombreUsuarioa.Name) 
                {
                    string a = LabelNombreUsuarioa.Text;
                    a = a.Replace("{SesionManager.GestorSesion.UsuarioSesion.Nombre}", $"{SesionManager.GestorSesion.UsuarioSesion.Nombre}");
                    LabelNombreUsuarioa.Text = a;
                    LabelNombreUsuarioa.Height = LabelNombreUsuarioa.PreferredHeight; // Ajusta la altura automáticamente
                   
                }

                if(c.Name == LabelRolUsuario.Name) 
                {
                    string b = LabelRolUsuario.Text;
                    b = b.Replace("{SesionManager.GestorSesion.UsuarioSesion.Rol}", $"{SesionManager.GestorSesion.UsuarioSesion.Rol}"); 
                    LabelRolUsuario.Text = b;
                    LabelRolUsuario.Height = LabelRolUsuario.PreferredHeight;
                }

                // Llamada recursiva para recorrer controles hijos (anidados).
                if (c.HasChildren)
                {
                    RecorrerControles(c);
                }
            }
        }

        #region Logica de Permisos Para Habilitar Accesos
        public void VerificarAccesibilidadDeTodosLosControles() 
        {
            PermisoBLL GestorPermiso = new PermisoBLL();
            VerificarAccesibilidadRecursivo(Controls, GestorPermiso);
        }

        public void VerificarAccesibilidadRecursivo(Control.ControlCollection controles, PermisoBLL GestorPermiso) 
        {
            foreach(Control c in controles) 
            {
                VerificarAccesibilidad(c, GestorPermiso);


                if(c.HasChildren) 
                {
                    VerificarAccesibilidadRecursivo(c.Controls,GestorPermiso);
                }
            }
        
        }

        public void VerificarAccesibilidad(Control control, PermisoBLL GestorPermiso, bool estadoSecundario = true) 
        {
            
               control.Visible = GestorPermiso.ConfigurarControl(control.Tag?.ToString(),estadoSecundario);
            
        
        }
        #endregion

    }
}
