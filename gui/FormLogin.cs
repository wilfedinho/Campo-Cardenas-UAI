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
        public FormLogin()
        {
            InitializeComponent();
            ListaUsuario = UsuarioBLL.GestorUsuarioBLLSG.DevolverUsuariosPorConsulta();
        }

        private void BT_LOGIN_Click(object sender, EventArgs e)
        {
            Usuario usuarioIniciarSesion = ListaUsuario.Find(x => x.Email == TB_Email.Text);
            if (usuarioIniciarSesion != null)
            {
                if(usuarioIniciarSesion.IsBloqueado == false)
                {
                   if(usuarioIniciarSesion.Contraseña == TB_Contrasena.Text)
                   {
                      SesionManager.GestorSesion.Login(usuarioIniciarSesion);
                      GestorForm.gestorFormSG.DefinirEstado(new EstadoMenu());
                   }
                   else
                   {
                        
                        if(usuarioIniciarSesion.Intentos >= 3)
                        {
                            usuarioIniciarSesion.IsBloqueado = true;
                        }
                        else
                        {
                            usuarioIniciarSesion.Intentos += 1;
                        }
                        UsuarioBLL.GestorUsuarioBLLSG.Modificar(usuarioIniciarSesion);
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
