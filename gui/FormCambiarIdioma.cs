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
    public partial class FormCambiarIdioma : Form, iObserverLenguaje
    {
        public FormCambiarIdioma()
        {
            InitializeComponent();
            LlenarComboBox();
            ActualizarLenguaje();
            string a = labelIdiomaActual.Text;
            a = a.Replace("{SesionManager.GestorSesion.UsuarioSesion.IdiomaUsuario}", $"{SesionManager.GestorSesion.UsuarioSesion.IdiomaUsuario}");
            labelIdiomaActual.Text = a;

        }


        public void LlenarComboBox()
        { 
            foreach(string idioma in Traductor.TraductorSG.DevolverIdiomasDisponibles())
            {

                if(!(CB_IdiomasDisponibles.Items.Contains(idioma)) && SesionManager.GestorSesion.UsuarioSesion.IdiomaUsuario != idioma)
                {
                    CB_IdiomasDisponibles.Items.Add(idioma);
                }
            }
        }

        private void BT_CambiarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBLL GestorUsuario = new UsuarioBLL();
                GestorUsuario.CambiarIdioma(CB_IdiomasDisponibles.SelectedItem.ToString());
                ActualizarLenguaje();
                CB_IdiomasDisponibles.SelectedIndex = -1;
                LlenarComboBox();
            }
            catch { }
        }

        public void ActualizarLenguaje()
        {
            RecorrerControles(this);
            string a = labelIdiomaActual.Text;
            a = a.Replace("{SesionManager.GestorSesion.UsuarioSesion.IdiomaUsuario}", $"{SesionManager.GestorSesion.UsuarioSesion.IdiomaUsuario}");
            labelIdiomaActual.Text = a;
        }

        public void RecorrerControles(Control control)
        {
            foreach (Control c in control.Controls)
            {
                // Aquí puedes hacer lo que quieras con cada control.
                if(!(c is ComboBox))
                {
                   c.Text = Traductor.TraductorSG.Traducir(c.Name);
                }
                // Llamada recursiva para recorrer controles hijos (anidados).
                if (c.HasChildren)
                {
                    RecorrerControles(c);
                }
            }
        }


        private void FormCambiarIdioma_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
