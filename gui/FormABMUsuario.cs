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
                dgvUsuario.Rows.Add(usuario.ID_Usuario,usuario.Nombre,usuario.Apellido,usuario.DNI,usuario.Email,usuario.Rol,usuario.IsBloqueado);
            }
        }
        public void VaciarTextBox(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
              if (control is TextBox textBox)
              {
                textBox.Clear();
              }
              else if(control is ComboBox cb)
              {
                cb.SelectedIndex = -1;
              }
              else if (control.HasChildren)
              {
                VaciarTextBox(control);                
              }
            }  
        }

        private void BT_ALTA_USUARIO_Click(object sender, EventArgs e)
        {
            string nombre = TB_NOMBRE.Text;
            string apellido = TB_APELLIDO.Text;
            string dni = TB_DNI.Text;
            string contraseña = dni + apellido;
            string email = TB_EMAIL.Text;
            string rol = CB_ROL.SelectedItem.ToString();
            int intentos = 0;
            bool isBloqueado = false;
            Usuario usuario = new Usuario(0,nombre,apellido,dni,contraseña,email,rol);
            UsuarioBLL.GestorUsuarioBLLSG.Alta(usuario);
            MostrarUsuarioPorConsulta();
            VaciarTextBox(this);
        }

        private void BT_BAJA_USUARIO_Click(object sender, EventArgs e)
        {
            Usuario UsuarioEliminar = UsuarioBLL.GestorUsuarioBLLSG.DevolverUsuariosPorConsulta().Find(x => x.ID_Usuario == (int.Parse(dgvUsuario.SelectedRows[0].Cells[0].Value.ToString())));
            UsuarioBLL.GestorUsuarioBLLSG.Baja(UsuarioEliminar);
            MostrarUsuarioPorConsulta();
        }

        private void BT_USUARIO_MODIFICAR_Click(object sender, EventArgs e)
        {
            Usuario UsuarioModificar = UsuarioBLL.GestorUsuarioBLLSG.DevolverUsuariosPorConsulta().Find(x => x.ID_Usuario == (int.Parse(dgvUsuario.SelectedRows[0].Cells[0].Value.ToString())));
            UsuarioModificar.Nombre = TB_NOMBRE.Text;
            UsuarioModificar.Apellido = TB_APELLIDO.Text;
            UsuarioModificar.DNI = TB_DNI.Text;
            UsuarioModificar.Email = TB_EMAIL.Text;
            UsuarioModificar.Rol = CB_ROL.SelectedItem.ToString();
            UsuarioBLL.GestorUsuarioBLLSG.Modificar(UsuarioModificar);
            MostrarUsuarioPorConsulta();
            VaciarTextBox(this);
        }
        private void dgvUsuario_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TB_NOMBRE.Text = dgvUsuario.SelectedRows[0].Cells[1].Value.ToString();
            TB_APELLIDO.Text = dgvUsuario.SelectedRows[0].Cells[2].Value.ToString();
            TB_DNI.Text = dgvUsuario.SelectedRows[0].Cells[3].Value.ToString();
            TB_EMAIL.Text = dgvUsuario.SelectedRows[0].Cells[4].Value.ToString();
            CB_ROL.SelectedItem = dgvUsuario.SelectedRows[0].Cells[5].Value.ToString();
        }
    }
}
