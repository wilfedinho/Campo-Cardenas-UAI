﻿using BLL;
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
    public partial class FormCambiarClave : Form ,  iObserverLenguaje
    {
        UsuarioBLL GestorUsuario;
        public FormCambiarClave()
        {
            InitializeComponent();
            GestorUsuario = new UsuarioBLL();
            ActualizarLenguaje();
        }


        public void ActualizarLenguaje()
        {
            RecorrerControles(this);
        }

        public void RecorrerControles(Control control)
        {
            foreach (Control c in control.Controls)
            {
                // Aquí puedes hacer lo que quieras con cada control.
                c.Text = Traductor.TraductorSG.Traducir(c.Name);

                // Llamada recursiva para recorrer controles hijos (anidados).
                if (c.HasChildren)
                {
                    RecorrerControles(c);
                }
            }
        }

        private void BT_ADMINISTRAR_Click(object sender, EventArgs e)
        {
            if (GestorUsuario.VerificarCambioClave(TB_ClaveNueva.Text,TB_ConfirmarClave.Text))
            {
                MessageBox.Show(labelCambioExitoso.Text);
            }
            else
            {
                MessageBox.Show(labelCambioErroneo.Text);
            }
        }

        private void FormCambiarClave_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
