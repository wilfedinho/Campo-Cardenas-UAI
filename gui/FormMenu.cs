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
        
        public FormMenu()
        {
            InitializeComponent();
            LabelNombreUsuarioa.AutoSize = false;
            LabelNombreUsuarioa.MaximumSize = new Size(panelPrincipal.Width, 0);
            LabelNombreUsuarioa.Text = $"Bienvenido {SesionManager.GestorSesion.UsuarioSesion.Nombre} a Fertech!!! \n\n\n";
            LabelNombreUsuarioa.Height = LabelNombreUsuarioa.PreferredHeight; // Ajusta la altura automáticamente

            LabelRolUsuario.AutoSize = false;
            LabelRolUsuario.MaximumSize = new Size(panelPrincipal.Width, 0);
            LabelRolUsuario.Text = $"Puedo ver que Posees un Rol {SesionManager.GestorSesion.UsuarioSesion.Rol}, Así que podrás acceder a estas funciones!!";
            LabelRolUsuario.Height = LabelRolUsuario.PreferredHeight; // Ajusta la altura automáticamente
            SuscribirFormularios();

            Traductor.TraductorSG.Notificar();

            Diseno();
        }
        public void SuscribirFormularios()
        {
            formABMUSUARIO = new FormABMUsuario();
            formCambiarClave = new FormCambiarClave();
            Traductor.TraductorSG.Suscribir(this);
            Traductor.TraductorSG.Suscribir(formABMUSUARIO);
            Traductor.TraductorSG.Suscribir(formCambiarClave);
        }

        /*    private void BT_CERRARSESION_Click(object sender, EventArgs e)
        {
            //RECORDAR CUANDO SE IMPLEMENTE EL SESION MANAGER LIMPIAR LA SESION Y CON LOS PERMISOS MOSTRAR LOS BOTONES CORRESPONDIENTES
            BitacoraBLL GestorBitacora = new BitacoraBLL();
            GestorBitacora.AltaEvento("Inicio de Sesion", "Salida del Sistema", 4);
            SesionManager.GestorSesion.Logout();
            GestorForm.gestorFormSG.DefinirEstado(new EstadoIniciarSesion());
        }
        */
        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            SesionManager.GestorSesion.Logout();
            GestorForm.gestorFormSG.DefinirEstado(new EstadoCerrarAplicacion());
        }

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

        private void BT_ADMINISTRAR_Click(object sender, EventArgs e)
        {
            showSubmenu(panelAdministrarSubmenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            formABMUSUARIO.ShowDialog();
            this.Hide();
            hideSubmenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hideSubmenu();
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
            this.Hide();
            hideSubmenu();
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
            hideSubmenu();
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

        public void ActualizarLenguaje()
        {
             //Forma Peluche Foreach para recorrer todos los controles
           BT_ADMINISTRAR.Text = Traductor.TraductorSG.Traducir(BT_ADMINISTRAR.Text);
        }
    }
}
