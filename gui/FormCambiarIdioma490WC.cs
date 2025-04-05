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
    public partial class FormCambiarIdioma490WC : Form, iObserverLenguaje490WC
    {
        public FormCambiarIdioma490WC()
        {
            InitializeComponent();
            LlenarComboBox490WC();
            ActualizarLenguaje490WC();
            string a490WC = labelIdiomaActual.Text;
            a490WC = a490WC.Replace("{SesionManager.GestorSesion.UsuarioSesion.IdiomaUsuario}", $"{SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.IdiomaUsuario490WC}");
            labelIdiomaActual.Text = a490WC;

        }


        public void LlenarComboBox490WC()
        { 
            foreach(string idioma490WC in Traductor490WC.TraductorSG490WC.DevolverIdiomasDisponibles490WC())
            {

                if(!(CB_IdiomasDisponibles.Items.Contains(idioma490WC)) && SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.IdiomaUsuario490WC != idioma490WC)
                {
                    CB_IdiomasDisponibles.Items.Add(idioma490WC);
                }
            }
        }

        private void BT_CambiarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBLL490WC GestorUsuario490WC = new UsuarioBLL490WC();
                GestorUsuario490WC.CambiarIdioma490WC(CB_IdiomasDisponibles.SelectedItem.ToString());
                ActualizarLenguaje490WC();
                CB_IdiomasDisponibles.SelectedIndex = -1;
                LlenarComboBox490WC();
            }
            catch { }
        }

        public void ActualizarLenguaje490WC()
        {
            RecorrerControles490WC(this);
            string a490WC = labelIdiomaActual.Text;
            a490WC = a490WC.Replace("{SesionManager.GestorSesion.UsuarioSesion.IdiomaUsuario}", $"{SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.IdiomaUsuario490WC}");
            labelIdiomaActual.Text = a490WC;
        }

        public void RecorrerControles490WC(Control control490WC)
        {
            foreach (Control c490WC in control490WC.Controls)
            {
              
                if(!(c490WC is ComboBox))
                {
                   c490WC.Text = Traductor490WC.TraductorSG490WC.Traducir490WC(c490WC.Name);
                }
              
                if (c490WC.HasChildren)
                {
                    RecorrerControles490WC(c490WC);
                }
            }
        }


        private void FormCambiarIdioma_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
