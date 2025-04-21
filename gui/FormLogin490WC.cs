using BE;
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class FormLogin490WC : Form
    {
        List<Usuario490WC> ListaUsuario490WC;
        UsuarioBLL490WC GestorUsuario490WC;
        public FormLogin490WC()
        {
            InitializeComponent();
            GestorUsuario490WC = new UsuarioBLL490WC();
            ListaUsuario490WC = GestorUsuario490WC.DevolverUsuariosPorConsulta490WC();
        }

        private void BT_LOGIN_Click(object sender, EventArgs e)
        {
            Usuario490WC usuarioIniciarSesion490WC = ListaUsuario490WC.Find(x => x.Username490WC == TB_Username.Text);
            if (usuarioIniciarSesion490WC != null)
            {
                if(usuarioIniciarSesion490WC.IsBloqueado490WC == false && usuarioIniciarSesion490WC.IsHabilitado490WC == true)
                {
                   if(usuarioIniciarSesion490WC.Contraseña490WC == Cifrador490WC.GestorCifrador490WC.EncriptarIrreversible490WC(TB_Contrasena.Text))
                   {
                        SesionManager490WC.GestorSesion490WC.Login490WC(usuarioIniciarSesion490WC);
                        PermisoBLL490WC GestorPermiso490WC = new PermisoBLL490WC();
                        GestorPermiso490WC.AsignarRolSesion490WC(SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.Rol490WC);
                        BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
                        GestorBitacora490WC.AltaEvento490WC("Inicio de Sesion", "Entrada al Sistema", 4);
                        GestorForm490WC.gestorFormSG490WC.DefinirEstado490WC(new EstadoMenu490WC());
                        usuarioIniciarSesion490WC.Intentos490WC = 0;
                        GestorUsuario490WC.Modificar490WC(usuarioIniciarSesion490WC);
                   }
                   else
                   {
                        
                        if(usuarioIniciarSesion490WC.Intentos490WC >= 3 && usuarioIniciarSesion490WC.Rol490WC != "Admin")
                        {
                            usuarioIniciarSesion490WC.IsBloqueado490WC = true;
                        }
                        else
                        {
                            usuarioIniciarSesion490WC.Intentos490WC += 1;
                        }
                        GestorUsuario490WC.Modificar490WC(usuarioIniciarSesion490WC);
                        MessageBox.Show($"Datos Ingresados Incorrectos!!!");
                   }
                }
                else
                {
                  MessageBox.Show($"El Usuario {usuarioIniciarSesion490WC.Nombre490WC} está Bloqueado o Desactivado!!!");
                }
            }
            else
            {
                MessageBox.Show($"Datos Ingresados Incorrectos!!!");
            }
        }
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorForm490WC.gestorFormSG490WC.DefinirEstado490WC(new EstadoCerrarAplicacion490WC());
        }
    }
}
