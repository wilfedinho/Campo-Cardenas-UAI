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
    public partial class FormABMUsuario : Form
    {
        UsuarioBLL GestorUsuario;
        public FormABMUsuario()
        {
            InitializeComponent();
            MostrarUsuarioPorConsulta();
            GestorUsuario = new UsuarioBLL();
            BT_CANCELAR.Enabled = false;
            BT_APLICAR.Enabled = false;
        }

        public void MostrarUsuarioPorConsulta(string tipoConsulta = "", string itemSeleccionado = "", string itemValor = "", string itemValor2 = "")
        {
            GestorUsuario = new UsuarioBLL();
            dgvUsuario.Rows.Clear();
            int indiceRow = 0;
            foreach (Usuario usuario in GestorUsuario.DevolverUsuariosPorConsulta(tipoConsulta,itemSeleccionado,itemValor, itemValor2))
            {
                if(checkBox1.Checked || usuario.IsBloqueado == false)
                {
                  indiceRow = dgvUsuario.Rows.Add(usuario.ID_Usuario,usuario.Username,usuario.Nombre,usuario.Apellido,usuario.DNI,usuario.Email,usuario.Rol,usuario.IsBloqueado);
                }
                if(usuario.IsBloqueado == true && dgvUsuario.Rows.Count > 0)
                {
                    dgvUsuario.Rows[indiceRow].DefaultCellStyle.BackColor = Color.LightCoral;
                }
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
            string username = TB_Usuario.Text;
            string apellido = TB_APELLIDO.Text;
            string dni = TB_DNI.Text;
            string contraseña = dni+apellido;
            string email = TB_EMAIL.Text;
            string rol = CB_ROL.SelectedItem.ToString();
            if(GestorUsuario.VerificarDNI(dni) == true && GestorUsuario.VerificarDNIDuplicado(dni) == false && GestorUsuario.VerificarEmail(email) == true && GestorUsuario.VerificarEmailDuplicado(email) == false)
            {
              Usuario usuario = new Usuario(0,username,nombre,apellido,dni,contraseña,email,rol);
                GestorUsuario.Alta(usuario);
              MostrarUsuarioPorConsulta();
                BitacoraBLL GestorBitacora = new BitacoraBLL();
                GestorBitacora.AltaEvento("Gestion de Usuario", "Alta de Usuario", 5);
                VaciarTextBox(this);
            }
            else
            {
                VaciarTextBox(this);
                MessageBox.Show("Valores Ingresados Incorrectos!!");
            }
        }
        private void BT_BAJA_USUARIO_Click(object sender, EventArgs e)
        {
            Usuario UsuarioEliminar = GestorUsuario.DevolverUsuariosPorConsulta().Find(x => x.ID_Usuario == (int.Parse(dgvUsuario.SelectedRows[0].Cells[0].Value.ToString())));
            GestorUsuario.Baja(UsuarioEliminar);
            MostrarUsuarioPorConsulta();
            BitacoraBLL GestorBitacora = new BitacoraBLL();
            GestorBitacora.AltaEvento("Gestion de Usuario", "Baja de Usuario", 5);
            VaciarTextBox(this);
        }
        private void BT_USUARIO_MODIFICAR_Click(object sender, EventArgs e)
        {
            BT_ALTA_USUARIO.Enabled = false;
            BT_BAJA_USUARIO.Enabled = false;
            BT_MODIFICAR_USUARIO.Enabled = false;
            BT_DESBLOQUEAR_USUARIO.Enabled = false;
            BT_SALIR.Enabled = false;
            BT_APLICAR.Enabled = true;
            BT_CANCELAR.Enabled = true;
        }
        private void dgvUsuario_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TB_Usuario.Text = dgvUsuario.SelectedRows[0].Cells[1].Value.ToString();
            TB_NOMBRE.Text = dgvUsuario.SelectedRows[0].Cells[2].Value.ToString();
            TB_APELLIDO.Text = dgvUsuario.SelectedRows[0].Cells[3].Value.ToString();
            TB_DNI.Text = dgvUsuario.SelectedRows[0].Cells[4].Value.ToString();
            TB_EMAIL.Text = dgvUsuario.SelectedRows[0].Cells[5].Value.ToString();
            CB_ROL.SelectedItem = dgvUsuario.SelectedRows[0].Cells[6].Value.ToString();
            if (dgvUsuario.SelectedRows[0].Cells[7].Value.ToString() == "True")
            {
                BT_DESBLOQUEAR_USUARIO.Text = "Desbloquear";
            }
            else
            {
                BT_DESBLOQUEAR_USUARIO.Text = "Bloquear";
            }
        }
        private void BT_APLICAR_Click(object sender, EventArgs e)
        {
            Usuario UsuarioModificar = GestorUsuario.DevolverUsuariosPorConsulta().Find(x => x.ID_Usuario == (int.Parse(dgvUsuario.SelectedRows[0].Cells[0].Value.ToString())));
            UsuarioModificar.Nombre = TB_NOMBRE.Text;
            UsuarioModificar.Username = TB_Usuario.Text;
            UsuarioModificar.Apellido = TB_APELLIDO.Text;
            UsuarioModificar.Email = TB_EMAIL.Text;
            UsuarioModificar.Rol = CB_ROL.SelectedItem.ToString();
            GestorUsuario.Modificar(UsuarioModificar);
            MostrarUsuarioPorConsulta();
            BitacoraBLL GestorBitacora = new BitacoraBLL();
            GestorBitacora.AltaEvento("Gestion de Usuario", "Modificacion de Usuario", 5);
            VaciarTextBox(this);
        }
        private void BT_CANCELAR_Click(object sender, EventArgs e)
        {
            BT_ALTA_USUARIO.Enabled = true;
            BT_BAJA_USUARIO.Enabled = true;
            BT_MODIFICAR_USUARIO.Enabled = true;
            BT_DESBLOQUEAR_USUARIO.Enabled = true;
            BT_SALIR.Enabled = true;
            BT_APLICAR.Enabled = false;
            BT_CANCELAR.Enabled = false;
            VaciarTextBox(this);
        }

        private void BT_DESBLOQUEAR_USUARIO_Click(object sender, EventArgs e)
        {
            Usuario UsuarioModificar = GestorUsuario.DevolverUsuariosPorConsulta().Find(x => x.ID_Usuario == (int.Parse(dgvUsuario.SelectedRows[0].Cells[0].Value.ToString())));
           
            if (dgvUsuario.SelectedRows[0].Cells[7].Value.ToString() == "True")
            {
                UsuarioModificar.IsBloqueado = false;
                GestorUsuario.Modificar(UsuarioModificar);
                BT_DESBLOQUEAR_USUARIO.Text = "Bloquear";
                BitacoraBLL GestorBitacora = new BitacoraBLL();
                GestorBitacora.AltaEvento("Gestion de Usuario", "Desbloqueo de Usuario", 5);
            }
            else
            {
                UsuarioModificar.IsBloqueado = true;
                GestorUsuario.Modificar(UsuarioModificar);
                BT_DESBLOQUEAR_USUARIO.Text = "Desbloquear";
                BitacoraBLL GestorBitacora = new BitacoraBLL();
                GestorBitacora.AltaEvento("Gestion de Usuario", "Bloqueo de Usuario", 5);
            }
            MostrarUsuarioPorConsulta();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MostrarUsuarioPorConsulta();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            GestorForm.gestorFormSG.DefinirEstado(new EstadoMenu());
        }

        private void FormABMUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorForm.gestorFormSG.DefinirEstado(new EstadoMenu());
        }
    }
}
