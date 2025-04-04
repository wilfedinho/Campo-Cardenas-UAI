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
        List<Usuario490WC> ListaUsuario;
        UsuarioBLL490WC GestorUsuario;
        public FormLogin490WC()
        {
            InitializeComponent();
            GestorUsuario = new UsuarioBLL490WC();
            ListaUsuario = GestorUsuario.DevolverUsuariosPorConsulta();
        }

        private void BT_LOGIN_Click(object sender, EventArgs e)
        {
            Usuario490WC usuarioIniciarSesion = ListaUsuario.Find(x => x.Username == TB_Username.Text);
            if (usuarioIniciarSesion != null)
            {
                if(usuarioIniciarSesion.IsBloqueado == false)
                {
                   if(usuarioIniciarSesion.Contraseña == Cifrador490WC.GestorCifrador.EncriptarIrreversible(TB_Contrasena.Text))
                   {
                        SesionManager490WC.GestorSesion.Login(usuarioIniciarSesion);
                        PermisoBLL490WC GestorPermiso = new PermisoBLL490WC();
                        GestorPermiso.AsignarRolSesion(SesionManager490WC.GestorSesion.UsuarioSesion.Rol);
                        BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
                        GestorBitacora.AltaEvento("Inicio de Sesion", "Entrada al Sistema", 4);
                        GestorForm490WC.gestorFormSG.DefinirEstado(new EstadoMenu490WC());
                        usuarioIniciarSesion.Intentos = 0;
                        GestorUsuario.Modificar(usuarioIniciarSesion);
                   }
                   else
                   {
                        
                        if(usuarioIniciarSesion.Intentos >= 3 && usuarioIniciarSesion.Rol != "Admin")
                        {
                            usuarioIniciarSesion.IsBloqueado = true;
                        }
                        else
                        {
                            usuarioIniciarSesion.Intentos += 1;
                        }
                        GestorUsuario.Modificar(usuarioIniciarSesion);
                        MessageBox.Show($"Datos Ingresados Incorrectos!!!");
                   }
                }
                else
                {
                  MessageBox.Show($"El Usuario {usuarioIniciarSesion.Nombre} está Bloqueado!!!");
                }
            }
            else
            {
                MessageBox.Show($"Datos Ingresados Incorrectos!!!");
            }
        }
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorForm490WC.gestorFormSG.DefinirEstado(new EstadoCerrarAplicacion490WC());
        }
    }
}
