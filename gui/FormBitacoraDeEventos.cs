using BE;
using BLL;
using SERVICIOS;
using System;
using System.Collections;
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
    public partial class FormBitacoraDeEventos : Form, iObserverLenguaje
    {
        BitacoraBLL GestorBitacora;
        UsuarioBLL GestorUsuario;
        List<Usuario> ListaUsuario;
        public FormBitacoraDeEventos()
        {
            InitializeComponent();
            GestorBitacora = new BitacoraBLL();
            GestorUsuario = new UsuarioBLL();
            ListaUsuario = GestorUsuario.DevolverUsuariosPorConsulta();
            Mostrar();
            LLenarCB();
            monthCalendarFechaInicio.Enabled = false;
            monthCalendarFechaFin.Enabled = false;
            labelUsuario.Text = $"Usuario: ";
            labelNombre.Text = $"Nombre: ";
            labelApellido.Text = $"Apellido: ";
            labelDNI.Text = $"DNI: ";
        }
        public void Mostrar(string usuarioFiltrar = "", string moduloFiltrar = "", string descripcionFiltrar = "", string criticidadFiltrar = "", DateTime? fechaInicioFiltrar = null, DateTime? fechaFinFiltrar = null)
        {
            int indiceRow = 0;
            int criticidad = 0;
            dgvBitacora.Rows.Clear();
            foreach(BitacoraBE bitacora in GestorBitacora.ObtenerBitacoraPorConsulta(usuarioFiltrar,moduloFiltrar, descripcionFiltrar, criticidadFiltrar, fechaInicioFiltrar, fechaFinFiltrar))
            {
               indiceRow = dgvBitacora.Rows.Add(bitacora.Username,bitacora.Fecha,bitacora.Hora,bitacora.Modulo, bitacora.Descripcion, bitacora.Criticidad);
                criticidad = bitacora.Criticidad;
                if (dgvBitacora.Rows.Count > 0)
                {
                    switch (criticidad)
                    {
                        case 1:
                            dgvBitacora.Rows[indiceRow].DefaultCellStyle.BackColor = Color.GreenYellow;
                            break;
                        case 2:
                            dgvBitacora.Rows[indiceRow].DefaultCellStyle.BackColor = Color.Coral;
                            break;
                        case 3:
                            dgvBitacora.Rows[indiceRow].DefaultCellStyle.BackColor = Color.Orange;
                            break;
                        case 4:
                            dgvBitacora.Rows[indiceRow].DefaultCellStyle.BackColor = Color.OrangeRed;
                            break;
                        case 5:
                            dgvBitacora.Rows[indiceRow].DefaultCellStyle.BackColor = Color.Firebrick;
                            break;
                    }
                }
            }
        }
        public void LLenarCB()
        {
            foreach (BitacoraBE bitacora in GestorBitacora.ObtenerBitacoraPorConsulta())
            {
                
                if (CB_Usuario.Items.Count == 0 || !CB_Usuario.Items.Contains(bitacora.Username))
                    CB_Usuario.Items.Add(bitacora.Username);

                if (CB_Modulo.Items.Count == 0 || !CB_Modulo.Items.Contains(bitacora.Modulo))
                    CB_Modulo.Items.Add(bitacora.Modulo);

                if (CB_Descripcion.Items.Count == 0 || !CB_Descripcion.Items.Contains(bitacora.Descripcion))
                    CB_Descripcion.Items.Add(bitacora.Descripcion);

                if (CB_Criticidad.Items.Count == 0 || !CB_Criticidad.Items.Contains(bitacora.Criticidad.ToString()))
                    CB_Criticidad.Items.Add(bitacora.Criticidad.ToString());
            }
        }

        public void LimpiarCB()
        {
            CB_Usuario.SelectedIndex = -1;
            CB_Modulo.SelectedIndex = -1;
            CB_Descripcion.SelectedIndex = -1;
            CB_Criticidad.SelectedIndex = -1;
            monthCalendarFechaInicio.SelectionStart = DateTime.MinValue;
            monthCalendarFechaFin.SelectionStart = DateTime.MinValue;
        }
        private void BT_Filtrar_Click(object sender, EventArgs e)
        {
            string usuarioFiltrar = "";
            string moduloFiltrar = "";
            string descripcionFiltrar = "";
            string criticidadFiltrar = "";

          
            if (CB_Usuario.SelectedIndex >= 0)
                usuarioFiltrar = CB_Usuario.SelectedItem.ToString();
            if (CB_Modulo.SelectedIndex >= 0)
                moduloFiltrar = CB_Modulo.SelectedItem.ToString();
            if (CB_Descripcion.SelectedIndex >= 0)
                descripcionFiltrar = CB_Descripcion.SelectedItem.ToString();
            if (CB_Criticidad.SelectedIndex >= 0)
                criticidadFiltrar = CB_Criticidad.SelectedItem.ToString();

          
            if (checkBoxFecha.Checked == false)
            {
                Mostrar(usuarioFiltrar, moduloFiltrar, descripcionFiltrar, criticidadFiltrar, DateTime.MinValue, DateTime.MaxValue);
            }
            else
            {
                DateTime fechaInicioFiltrar = monthCalendarFechaInicio.SelectionStart;
                DateTime fechaFinFiltrar = monthCalendarFechaFin.SelectionStart;
                if (fechaInicioFiltrar != fechaFinFiltrar)
                {
                    Mostrar(usuarioFiltrar, moduloFiltrar, descripcionFiltrar, criticidadFiltrar, fechaInicioFiltrar, fechaFinFiltrar);
                }
            }
            LimpiarCB();
        }


        private void dgvBitacora_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Usuario usuario = ListaUsuario.Find(x => x.Username == dgvBitacora.SelectedRows[0].Cells[0].Value.ToString());
            if(usuario != null)
            {
              labelUsuario.Text = $"Usuario: {usuario.Username}";
              labelNombre.Text = $"Nombre: {usuario.Nombre}";
              labelApellido.Text = $"Apellido: {usuario.Apellido}";
              labelDNI.Text = $"DNI: {usuario.DNI}";
            }
            else
            {
                labelUsuario.Text = $"Usuario: Error";
                labelNombre.Text = $"Nombre: Error";
                labelApellido.Text = $"Apellido: Error";
                labelDNI.Text = $"DNI: Error";
            }
        }

        private void BT_LimpiarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarCB();
            Mostrar();
            labelUsuario.Text = $"Usuario: ";
            labelNombre.Text = $"Nombre: ";
            labelApellido.Text = $"Apellido: ";
            labelDNI.Text = $"DNI: ";
        }

        private void checkBoxFecha_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxFecha.Checked == true)
            {
              monthCalendarFechaInicio.Enabled = true;
              monthCalendarFechaFin.Enabled = true;
            }
            else
            {
                monthCalendarFechaInicio.Enabled = false;
                monthCalendarFechaFin.Enabled = false;
            }
        }

        private void FormBitacoraDeEventos_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void FormBitacoraDeEventos_Load(object sender, EventArgs e)
        {

        }

        private void labelCBUsuario_Click(object sender, EventArgs e)
        {

        }

        public void ActualizarLenguaje()
        {
            
        }

        private void CB_Usuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
