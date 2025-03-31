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
    public partial class FormLogin : Form
    {
        List<Usuario> ListaUsuario;
        UsuarioBLL GestorUsuario;
        public FormLogin()
        {
            InitializeComponent();
            GestorUsuario = new UsuarioBLL();
            ListaUsuario = GestorUsuario.DevolverUsuariosPorConsulta();
        }

        private void BT_LOGIN_Click(object sender, EventArgs e)
        {
            Usuario usuarioIniciarSesion = ListaUsuario.Find(x => x.Username == TB_Username.Text);
            if (usuarioIniciarSesion != null)
            {
                if(usuarioIniciarSesion.IsBloqueado == false)
                {
                   if(usuarioIniciarSesion.Contraseña == Cifrador.GestorCifrador.EncriptarIrreversible(TB_Contrasena.Text))
                   {
                        SesionManager.GestorSesion.Login(usuarioIniciarSesion);
                        PermisoBLL GestorPermiso = new PermisoBLL();
                        GestorPermiso.AsignarRolSesion(SesionManager.GestorSesion.UsuarioSesion.Rol);
                        BitacoraBLL GestorBitacora = new BitacoraBLL();
                        GestorBitacora.AltaEvento("Inicio de Sesion", "Entrada al Sistema", 4);
                        GestorForm.gestorFormSG.DefinirEstado(new EstadoMenu());
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
            GestorForm.gestorFormSG.DefinirEstado(new EstadoCerrarAplicacion());
        }
    }
}
