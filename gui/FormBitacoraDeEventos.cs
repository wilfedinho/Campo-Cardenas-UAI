using BE;
using BLL;
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
    public partial class FormBitacoraDeEventos : Form
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
        }
        public void Mostrar()
        {
            int indiceRow = 0;
            int criticidad = 0;
            dgvBitacora.Rows.Clear();
            foreach(BitacoraBE bitacora in GestorBitacora.ObtenerBitacoraPorConsulta())
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
    }
}
