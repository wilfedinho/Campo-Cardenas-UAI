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
        UsuarioBLL490WC GestorUsuario490WC;
        FormMenu490WC menu490WC;
        public FormABMUsuario490WC(FormMenu490WC menuOrigen490WC)
        {
            InitializeComponent();
            MostrarUsuarioPorConsulta490WC();
            GestorUsuario490WC = new UsuarioBLL490WC();
            BT_CANCELAR.Enabled = false;
            BT_APLICAR.Enabled = false;
            menu490WC = menuOrigen490WC;
            BT_DESBLOQUEAR_USUARIO.Enabled = false;
            RellenarCombobox490WC();
        }

        public void MostrarUsuarioPorConsulta490WC(string tipoConsulta490WC = "", string itemSeleccionado490WC = "", string itemValor490WC = "", string itemValor2490WC = "")
        {
            GestorUsuario490WC = new UsuarioBLL490WC();
            dgvUsuario.Rows.Clear();
            int indiceRow490WC = 0;
            foreach (Usuario490WC usuario490WC in GestorUsuario490WC.DevolverUsuariosPorConsulta490WC(tipoConsulta490WC,itemSeleccionado490WC,itemValor490WC, itemValor2490WC))
            {
               
                if(checkBoxMostrarDesactivados.Checked || usuario490WC.IsHabilitado490WC == true)
                {
                  indiceRow490WC = dgvUsuario.Rows.Add(usuario490WC.Username490WC,usuario490WC.Nombre490WC,usuario490WC.Apellido490WC,usuario490WC.DNI490WC,usuario490WC.Email490WC,usuario490WC.Rol490WC,usuario490WC.IsBloqueado490WC, usuario490WC.IsHabilitado490WC);
                }
                if(usuario490WC.IsHabilitado490WC == false && dgvUsuario.Rows.Count > 0 && checkBoxMostrarDesactivados.Checked)
                {
                    dgvUsuario.Rows[indiceRow490WC].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }
        public void VaciarTextBox490WC(Control contenedor490WC)
        {
            foreach (Control control490WC in contenedor490WC.Controls)
            {
              if (control490WC is TextBox textBox490WC)
              {
                textBox490WC.Clear();
              }
              else if(control490WC is ComboBox cb490WC)
              {
                cb490WC.SelectedIndex = -1;
              }
              else if (control490WC.HasChildren)
              {
                VaciarTextBox490WC(control490WC);                
              }
            }  
        }
        private void BT_ALTA_USUARIO_Click(object sender, EventArgs e)
        {
            string username490WC = TB_Usuario.Text;
            string nombre490WC = TB_NOMBRE.Text;
            string apellido490WC = TB_APELLIDO.Text;
            string dni490WC = TB_DNI.Text;
            string contraseña490WC = dni490WC+apellido490WC;
            string email490WC = TB_EMAIL.Text;
            string rol490WC = CB_ROL.SelectedItem.ToString();
            string idioma490WC = "Español";
            if (GestorUsuario490WC.VerificarDNI490WC(dni490WC) == true && GestorUsuario490WC.VerificarDNIDuplicado490WC(dni490WC) == false && GestorUsuario490WC.VerificarEmail490WC(email490WC) == true && GestorUsuario490WC.VerificarEmailDuplicado490WC(email490WC) == false && GestorUsuario490WC.VerificarUsernameDuplicado490WC(username490WC) == false)
            {
                Usuario490WC usuario490WC = new Usuario490WC(username490WC,nombre490WC,apellido490WC,dni490WC,contraseña490WC,email490WC,rol490WC,idioma490WC);
                GestorUsuario490WC.Alta490WC(usuario490WC);
                MostrarUsuarioPorConsulta490WC();
                BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
                GestorBitacora490WC.AltaEvento490WC("Gestion de Usuario", "Alta de Usuario", 5);
                VaciarTextBox490WC(this);
            }
            else
            {
                VaciarTextBox490WC(this);
              
            }
        }
        private void BT_BAJA_USUARIO_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario490WC UsuarioEliminar490WC = GestorUsuario490WC.DevolverUsuariosPorConsulta490WC().Find(x => x.Username490WC == (dgvUsuario.SelectedRows[0].Cells[0].Value.ToString()));
                GestorUsuario490WC.Baja490WC(UsuarioEliminar490WC);
                MostrarUsuarioPorConsulta490WC();
                BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
                GestorBitacora490WC.AltaEvento490WC("Gestion de Usuario", "Baja de Usuario", 5);
                VaciarTextBox490WC(this);

            }
            catch { MessageBox.Show(labelDebeborrar.Text); }
        }
        private void dgvUsuario_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TB_Usuario.Text = dgvUsuario.SelectedRows[0].Cells[0].Value.ToString();
            TB_NOMBRE.Text = dgvUsuario.SelectedRows[0].Cells[1].Value.ToString();
            TB_APELLIDO.Text = dgvUsuario.SelectedRows[0].Cells[2].Value.ToString();
            TB_DNI.Text = dgvUsuario.SelectedRows[0].Cells[3].Value.ToString();
            TB_EMAIL.Text = dgvUsuario.SelectedRows[0].Cells[4].Value.ToString();
            CB_ROL.SelectedItem = dgvUsuario.SelectedRows[0].Cells[5].Value.ToString();
            if (dgvUsuario.SelectedRows[0].Cells[7].Value.ToString() == "True")
            {
                BT_ACTIVAR_USUARIO.Name = "BT_DESACTIVAR_USUARIO";
                ActualizarLenguaje490WC();
            }
            else
            {
                BT_ACTIVAR_USUARIO.Name = "BT_ACTIVAR_USUARIO";
                ActualizarLenguaje490WC();
            }
            if (dgvUsuario.SelectedRows[0].Cells[6].Value.ToString() == "True") 
            {
              BT_DESBLOQUEAR_USUARIO.Enabled = true;
            }
            else 
            {
             BT_DESBLOQUEAR_USUARIO.Enabled = false;
            }
        }
        private void BT_USUARIO_MODIFICAR_Click(object sender, EventArgs e)
        {
            BT_ALTA_USUARIO.Enabled = false;
            BT_BAJA_USUARIO.Enabled = false;
            BT_MODIFICAR_USUARIO.Enabled = false;
            BT_DESBLOQUEAR_USUARIO.Enabled = false;
            BT_SALIR.Enabled = false;
            BT_ACTIVAR_USUARIO.Enabled = false;
            BT_APLICAR.Enabled = true;
            BT_CANCELAR.Enabled = true;
            TB_Usuario.Enabled = false;
        }
        private void BT_APLICAR_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario490WC UsuarioModificar490WC = GestorUsuario490WC.DevolverUsuariosPorConsulta490WC().Find(x => x.Username490WC == (dgvUsuario.SelectedRows[0].Cells[0].Value.ToString()));
                UsuarioModificar490WC.Nombre490WC = TB_NOMBRE.Text;
                //UsuarioModificar490WC.Username490WC = TB_Usuario.Text;
                UsuarioModificar490WC.Apellido490WC = TB_APELLIDO.Text;
                UsuarioModificar490WC.Email490WC = TB_EMAIL.Text;
                UsuarioModificar490WC.Rol490WC = CB_ROL.SelectedItem.ToString();
                GestorUsuario490WC.Modificar490WC(UsuarioModificar490WC);
                MostrarUsuarioPorConsulta490WC();
                BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
                GestorBitacora490WC.AltaEvento490WC("Gestion de Usuario", "Modificacion de Usuario", 5);
                VaciarTextBox490WC(this);
                BT_ALTA_USUARIO.Enabled = true;
                BT_BAJA_USUARIO.Enabled = true;
                BT_MODIFICAR_USUARIO.Enabled = true;
                BT_DESBLOQUEAR_USUARIO.Enabled = true;
                BT_SALIR.Enabled = true;
                BT_ACTIVAR_USUARIO.Enabled = true;
                BT_APLICAR.Enabled = false;
                BT_CANCELAR.Enabled = false;
                TB_Usuario.Enabled = true;
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
            BT_ACTIVAR_USUARIO.Enabled=true;
            TB_Usuario.Enabled = true;
            BT_APLICAR.Enabled = false;
            BT_CANCELAR.Enabled = false;
            VaciarTextBox490WC(this);
        }

     

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MostrarUsuarioPorConsulta490WC();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormABMUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            VaciarTextBox490WC(this);
        }


        public void ActualizarLenguaje490WC()
        {
            RecorrerControles490WC(this);
        }

        public void RecorrerControles490WC(Control control490WC)
        {
            foreach (Control c490WC in control490WC.Controls)
            {
                if((c490WC is TextBox tb490WC) == false) 
                {
                 
                   c490WC.Text = Traductor490WC.TraductorSG490WC.Traducir490WC(c490WC.Name);

                  
                   if (c490WC.HasChildren)
                   {
                      RecorrerControles490WC(c490WC);
                   }
                    if(c490WC is DataGridView dgv490WC) 
                    {
                       foreach (DataGridViewColumn columna490WC in dgv490WC.Columns)
                       {
                           columna490WC.HeaderText = Traductor490WC.TraductorSG490WC.Traducir490WC(columna490WC.Name);
                       }
                    }
                
                }
            }
        }

        public void RellenarCombobox490WC() 
        {
            CB_ROL.Items.Clear();
            PermisoBLL490WC GestorPermiso490WC = new PermisoBLL490WC();
            foreach (var rol490WC in GestorPermiso490WC.ObtenerRoles490WC()) 
            {
                CB_ROL.Items.Add(rol490WC.obtenerPermisoNombre490WC());
            
            }
        }

        private void BT_Activar_Usuario_Click(object sender, EventArgs e)
        {
        
            Usuario490WC UsuarioModificar490WC = GestorUsuario490WC.DevolverUsuariosPorConsulta490WC().Find(x => x.Username490WC == (dgvUsuario.SelectedRows[0].Cells[0].Value.ToString()));

            if (dgvUsuario.SelectedRows[0].Cells[7].Value.ToString() == "True")
            {
                UsuarioModificar490WC.IsHabilitado490WC = false;
                GestorUsuario490WC.Modificar490WC(UsuarioModificar490WC);
                BT_ACTIVAR_USUARIO.Text = "TD_Desactivar";
                BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
                GestorBitacora490WC.AltaEvento490WC("Gestion de Usuario", "Activar Usuario", 5);
                ActualizarLenguaje490WC();
            }
            else
            {
                UsuarioModificar490WC.IsHabilitado490WC = true;
                GestorUsuario490WC.Modificar490WC(UsuarioModificar490WC);
                BT_ACTIVAR_USUARIO.Text = "TD_Activar";
                BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
                GestorBitacora490WC.AltaEvento490WC("Gestion de Usuario", "Desactivar Usuario", 5);
                ActualizarLenguaje490WC();
            }
            MostrarUsuarioPorConsulta490WC();
        
        }

        private void BT_DESBLOQUEAR_USUARIO_Click(object sender, EventArgs e)
        {
            Usuario490WC UsuarioModificar490WC = GestorUsuario490WC.DevolverUsuariosPorConsulta490WC().Find( x => x.Username490WC == (dgvUsuario.SelectedRows[0].Cells[0].Value.ToString()));
            UsuarioModificar490WC.IsBloqueado490WC = false;
            GestorUsuario490WC.Modificar490WC(UsuarioModificar490WC);
            BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
            GestorBitacora.AltaEvento490WC("Gestion de Usuario","Desbloquear Usuario",5);
            BT_DESBLOQUEAR_USUARIO.Enabled = false;
            MostrarUsuarioPorConsulta490WC();
        }
    }
}
