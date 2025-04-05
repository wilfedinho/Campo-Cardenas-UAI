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
    public partial class FormMenu490WC : Form , iObserverLenguaje490WC
    {
        FormABMUsuario490WC formABMUSUARIO490WC;
        FormCambiarClave490WC formCambiarClave490WC;
        FormCambiarIdioma490WC formCambiarIdioma490WC;
        FormBitacoraDeEventos490WC formBitacoraDeEventos490WC;
        FormPermisos490WC formPermisos490WC;
        
        public FormMenu490WC()
        {
            InitializeComponent();
            LabelNombreUsuarioa.AutoSize = false;
            LabelNombreUsuarioa.MaximumSize = new Size(panelPrincipal.Width, 0);


            LabelNombreUsuarioa.Height = LabelNombreUsuarioa.PreferredHeight; 

            LabelRolUsuario.AutoSize = false;
            LabelRolUsuario.MaximumSize = new Size(panelPrincipal.Width, 0);
            LabelRolUsuario.Height = LabelRolUsuario.PreferredHeight; 
            SuscribirFormularios490WC();

            Traductor490WC.TraductorSG490WC.Notificar490WC();



            LabelNombreUsuarioa.Height = LabelNombreUsuarioa.PreferredHeight; 
            LabelRolUsuario.Height = LabelRolUsuario.PreferredHeight; 

            VerificarAccesibilidadDeTodosLosControles490WC();

            Diseno490WC();
        }
        public void SuscribirFormularios490WC()
        {
            formABMUSUARIO490WC = new FormABMUsuario490WC(this);
            formCambiarClave490WC = new FormCambiarClave490WC();
            formCambiarIdioma490WC = new FormCambiarIdioma490WC();
            formBitacoraDeEventos490WC = new FormBitacoraDeEventos490WC();
            formPermisos490WC = new FormPermisos490WC();
            
            Traductor490WC.TraductorSG490WC.Suscribir490WC(this);
            Traductor490WC.TraductorSG490WC.Suscribir490WC(formABMUSUARIO490WC);
            Traductor490WC.TraductorSG490WC.Suscribir490WC(formCambiarClave490WC);
            Traductor490WC.TraductorSG490WC.Suscribir490WC(formCambiarIdioma490WC);
            Traductor490WC.TraductorSG490WC.Suscribir490WC(formBitacoraDeEventos490WC);
            Traductor490WC.TraductorSG490WC.Suscribir490WC(formPermisos490WC);

        }
        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            SesionManager490WC.GestorSesion490WC.Logout490WC();
            GestorForm490WC.gestorFormSG490WC.DefinirEstado490WC(new EstadoCerrarAplicacion490WC());
        }
        #region Diseno
    
        private void Diseno490WC()
        {
            panelAdministrarSubmenu.Visible = false;
            panelSubmenuPrueba2.Visible = false;
            panelSubmenuPrueba3.Visible = false;
            panelSubmenuPrueba.Visible = false;
        }

        private void hideSubmenu490WC()
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
        private void showSubmenu490WC(Panel subMenu490WC)
        {
            if(subMenu490WC.Visible == false)
            {
                hideSubmenu490WC();
                subMenu490WC.Visible = true;
            }
            else
            {
                subMenu490WC.Visible = false;
            }
        }
        #endregion

        #region Button Click

        private void BT_ADMINISTRAR_Click(object sender, EventArgs e)
        {
            showSubmenu490WC(panelAdministrarSubmenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            formABMUSUARIO490WC.ShowDialog();
           
            hideSubmenu490WC();
            
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formBitacoraDeEventos490WC.ShowDialog();
            hideSubmenu490WC();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formPermisos490WC.ShowDialog();
            hideSubmenu490WC();
            this.Show();
        }

        private void BT_Prueba_Click(object sender, EventArgs e)
        {
            showSubmenu490WC(panelSubmenuPrueba);
        }

        private void BT_Prueba2_Click(object sender, EventArgs e)
        {
            showSubmenu490WC(panelSubmenuPrueba2);
        }

        private void BT_Prueba3_Click(object sender, EventArgs e)
        {
            showSubmenu490WC(panelSubmenuPrueba3);
        }

        private void button8_Click(object sender, EventArgs e)
        {

            formCambiarClave490WC.ShowDialog();
            
            hideSubmenu490WC();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
            GestorBitacora490WC.AltaEvento490WC("Inicio de Sesion", "Salida del Sistema", 4);
            SesionManager490WC.GestorSesion490WC.Logout490WC();
            GestorForm490WC.gestorFormSG490WC.DefinirEstado490WC(new EstadoIniciarSesion490WC());
            hideSubmenu490WC();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            formCambiarIdioma490WC.ShowDialog();
       
            hideSubmenu490WC();
          
            this.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hideSubmenu490WC();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hideSubmenu490WC();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hideSubmenu490WC();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            hideSubmenu490WC();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            hideSubmenu490WC();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            hideSubmenu490WC();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            SesionManager490WC.GestorSesion490WC.Logout490WC();
            GestorForm490WC.gestorFormSG490WC.DefinirEstado490WC(new EstadoCerrarAplicacion490WC());
            hideSubmenu490WC();
        }
        #endregion

        public void ActualizarLenguaje490WC()
        {
            RecorrerControles490WC(this);
        }

        public void RecorrerControles490WC(Control control490WC)
        {
            foreach (Control c490WC in control490WC.Controls)
            {
             
                c490WC.Text = Traductor490WC.TraductorSG490WC.Traducir490WC(c490WC.Name);
                if(c490WC.Name == LabelNombreUsuarioa.Name) 
                {
                    string a = LabelNombreUsuarioa.Text;
                    a = a.Replace("{SesionManager.GestorSesion.UsuarioSesion.Nombre}", $"{SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.Nombre490WC}");
                    LabelNombreUsuarioa.Text = a;
                    LabelNombreUsuarioa.Height = LabelNombreUsuarioa.PreferredHeight; 
                   
                }

                if(c490WC.Name == LabelRolUsuario.Name) 
                {
                    string b490WC = LabelRolUsuario.Text;
                    b490WC = b490WC.Replace("{SesionManager.GestorSesion.UsuarioSesion.Rol}", $"{SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.Rol490WC}"); 
                    LabelRolUsuario.Text = b490WC;
                    LabelRolUsuario.Height = LabelRolUsuario.PreferredHeight;
                }

                
                if (c490WC.HasChildren)
                {
                    RecorrerControles490WC(c490WC);
                }
            }
        }

        #region Logica de Permisos Para Habilitar Accesos
        public void VerificarAccesibilidadDeTodosLosControles490WC() 
        {
            PermisoBLL490WC GestorPermiso490WC = new PermisoBLL490WC();
            VerificarAccesibilidadRecursivo490WC(Controls, GestorPermiso490WC);
        }

        public void VerificarAccesibilidadRecursivo490WC(Control.ControlCollection controles490WC, PermisoBLL490WC GestorPermiso490WC) 
        {
            foreach(Control c490WC in controles490WC) 
            {
                VerificarAccesibilidad(c490WC, GestorPermiso490WC);


                if(c490WC.HasChildren) 
                {
                    VerificarAccesibilidadRecursivo490WC(c490WC.Controls,GestorPermiso490WC);
                }
            }
        
        }

        public void VerificarAccesibilidad(Control control490WC, PermisoBLL490WC GestorPermiso490WC, bool estadoSecundario490WC = true) 
        {
            
               control490WC.Visible = GestorPermiso490WC.ConfigurarControl490WC(control490WC.Tag?.ToString(),estadoSecundario490WC);
            
        
        }
        #endregion

    }
}
