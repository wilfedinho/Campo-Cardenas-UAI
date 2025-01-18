using BE;
using BLL;
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
    public partial class FormABMUsuario : Form
    {
        public FormABMUsuario()
        {
            InitializeComponent();
            MostrarUsuarioPorConsulta();
        }

        public void MostrarUsuarioPorConsulta(string query = "")
        {
            dgvUsuario.Rows.Clear();

            foreach(Usuario usuario in UsuarioBLL.GestorUsuarioBLLSG.DevolverUsuariosPorConsulta(query))
            {
                dgvUsuario.Rows.Add(usuario.ID_Usuario,usuario.Nombre,usuario.Apellido,usuario.DNI,usuario.Contraseña,usuario.Email,usuario.Rol,usuario.Intentos,usuario.IsBloqueado);
            }
        }

        private void BT_ALTA_USUARIO_Click(object sender, EventArgs e)
        {

        }

        private void BT_BAJA_USUARIO_Click(object sender, EventArgs e)
        {
            Usuario UsuarioEliminar = UsuarioBLL.GestorUsuarioBLLSG.DevolverUsuariosPorConsulta().Find(x => x.ID_Usuario == (int.Parse(dgvUsuario.SelectedRows[0].Cells[0].Value.ToString())));
            UsuarioBLL.GestorUsuarioBLLSG.Baja(UsuarioEliminar);
            MostrarUsuarioPorConsulta();
        }

        private void BT_USUARIO_MODIFICAR_Click(object sender, EventArgs e)
        {

        }
    }
}
