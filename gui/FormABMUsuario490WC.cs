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
    public partial class FormABMUsuario490WC : Form, iObserverLenguaje490WC
    {
        UsuarioBLL490WC GestorUsuario;
        FormMenu490WC menu;
        public FormABMUsuario490WC(FormMenu490WC menuOrigen)
        {
            InitializeComponent();
            MostrarUsuarioPorConsulta();
            GestorUsuario = new UsuarioBLL490WC();
            BT_CANCELAR.Enabled = false;
            BT_APLICAR.Enabled = false;
            menu = menuOrigen;
            RellenarCombobox();
        }

        public void MostrarUsuarioPorConsulta(string tipoConsulta = "", string itemSeleccionado = "", string itemValor = "", string itemValor2 = "")
        {
            GestorUsuario = new UsuarioBLL490WC();
            dgvUsuario.Rows.Clear();
            int indiceRow = 0;
            foreach (Usuario490WC usuario in GestorUsuario.DevolverUsuariosPorConsulta(tipoConsulta,itemSeleccionado,itemValor, itemValor2))
            {
                if(checkBoxMostrarBloqueados.Checked || usuario.IsBloqueado == false)
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
            string idioma = "Español";
            if (GestorUsuario.VerificarDNI(dni) == true && GestorUsuario.VerificarDNIDuplicado(dni) == false && GestorUsuario.VerificarEmail(email) == true && GestorUsuario.VerificarEmailDuplicado(email) == false)
            {
                Usuario490WC usuario = new Usuario490WC(0,username,nombre,apellido,dni,contraseña,email,rol,idioma);
                GestorUsuario.Alta(usuario);
                MostrarUsuarioPorConsulta();
                BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
                GestorBitacora.AltaEvento("Gestion de Usuario", "Alta de Usuario", 5);
                VaciarTextBox(this);
            }
            else
            {
                VaciarTextBox(this);
              
            }
        }
        private void BT_BAJA_USUARIO_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario490WC UsuarioEliminar = GestorUsuario.DevolverUsuariosPorConsulta().Find(x => x.ID_Usuario == (int.Parse(dgvUsuario.SelectedRows[0].Cells[0].Value.ToString())));
                GestorUsuario.Baja(UsuarioEliminar);
                MostrarUsuarioPorConsulta();
                BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
                GestorBitacora.AltaEvento("Gestion de Usuario", "Baja de Usuario", 5);
                VaciarTextBox(this);

            }
            catch { MessageBox.Show(labelDebeborrar.Text); }
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
                BT_DESBLOQUEAR_USUARIO.Name = "BT_DESBLOQUEAR_USUARIO";
                ActualizarLenguaje();
            }
            else
            {
                BT_DESBLOQUEAR_USUARIO.Name = "BT_BLOQUEAR_USUARIO";
                ActualizarLenguaje();
            }
        }
        private void BT_APLICAR_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario490WC UsuarioModificar = GestorUsuario.DevolverUsuariosPorConsulta().Find(x => x.ID_Usuario == (int.Parse(dgvUsuario.SelectedRows[0].Cells[0].Value.ToString())));
                UsuarioModificar.Nombre = TB_NOMBRE.Text;
                UsuarioModificar.Username = TB_Usuario.Text;
                UsuarioModificar.Apellido = TB_APELLIDO.Text;
                UsuarioModificar.Email = TB_EMAIL.Text;
                UsuarioModificar.Rol = CB_ROL.SelectedItem.ToString();
                GestorUsuario.Modificar(UsuarioModificar);
                MostrarUsuarioPorConsulta();
                BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
                GestorBitacora.AltaEvento("Gestion de Usuario", "Modificacion de Usuario", 5);
                VaciarTextBox(this);
                BT_ALTA_USUARIO.Enabled = true;
                BT_BAJA_USUARIO.Enabled = true;
                BT_MODIFICAR_USUARIO.Enabled = true;
                BT_DESBLOQUEAR_USUARIO.Enabled = true;
                BT_SALIR.Enabled = true;
                BT_APLICAR.Enabled = false;
                BT_CANCELAR.Enabled = false;
            }
            catch { MessageBox.Show(labelDebeSeleccionar.Text); }
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
            Usuario490WC UsuarioModificar = GestorUsuario.DevolverUsuariosPorConsulta().Find(x => x.ID_Usuario == (int.Parse(dgvUsuario.SelectedRows[0].Cells[0].Value.ToString())));
           
            if (dgvUsuario.SelectedRows[0].Cells[7].Value.ToString() == "True")
            {
                UsuarioModificar.IsBloqueado = false;
                GestorUsuario.Modificar(UsuarioModificar);
                BT_DESBLOQUEAR_USUARIO.Text = "TD_Bloquear";
                BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
                GestorBitacora.AltaEvento("Gestion de Usuario", "Desbloqueo de Usuario", 5);
                ActualizarLenguaje();
            }
            else
            {
                UsuarioModificar.IsBloqueado = true;
                GestorUsuario.Modificar(UsuarioModificar);
                BT_DESBLOQUEAR_USUARIO.Text = "TD_Desbloquear";
                BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
                GestorBitacora.AltaEvento("Gestion de Usuario", "Bloqueo de Usuario", 5);
                ActualizarLenguaje();
            }
            MostrarUsuarioPorConsulta();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MostrarUsuarioPorConsulta();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormABMUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        public void ActualizarLenguaje()
        {
            RecorrerControles(this);
        }

        public void RecorrerControles(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if((c is TextBox tb) == false) 
                {
                 
                   c.Text = Traductor490WC.TraductorSG.Traducir(c.Name);

                  
                   if (c.HasChildren)
                   {
                      RecorrerControles(c);
                   }
                    if(c is DataGridView dgv) 
                    {
                       foreach (DataGridViewColumn columna in dgv.Columns)
                       {
                           columna.HeaderText = Traductor490WC.TraductorSG.Traducir(columna.Name);
                       }
                    }
                
                }
            }
        }

        public void RellenarCombobox() 
        {
            CB_ROL.Items.Clear();
            PermisoBLL490WC GestorPermiso = new PermisoBLL490WC();
            foreach (var rol in GestorPermiso.ObtenerRoles()) 
            {
                CB_ROL.Items.Add(rol.obtenerPermisoNombre());
            
            }
        }

    }
}
