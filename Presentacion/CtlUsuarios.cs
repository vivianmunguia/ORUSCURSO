﻿using Oruscurso.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Oruscurso.Presentacion
{
    public partial class CtlUsuarios : UserControl
    {
        public CtlUsuarios()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarPaneles();
            MostrarModulos();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtContraseña.Clear();
            txtUsuario.Clear();
        }

        private void HabilitarPaneles()
        {
            panelRegistro.Visible = true;
            lblAnuncioIcono.Visible = true;
            panelIcono.Visible = false;
            panelRegistro.Dock = DockStyle.Fill;
            panelRegistro.BringToFront();
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;
        }
        private void MostrarModulos()
        {
            Dmodulos funcion = new Dmodulos();
            DataTable dt = new DataTable();
            funcion.MostrarModulos(ref dt);
            dataListadoModulos.DataSource = dt;
        }
    }
}
