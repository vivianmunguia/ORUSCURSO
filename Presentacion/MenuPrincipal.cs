﻿using Oruscurso.Datos;
using Oruscurso.Logica;
using System;
using System.Data;
using System.Windows.Forms;

namespace Oruscurso.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        public int Idusuario;
        public string LoginV;
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            panelBienvenida.Dock = DockStyle.Fill;
            ValidarPermisos();
        }

        private void ValidarPermisos()
        {
            DataTable dt = new DataTable();
            Dpermisos funcion = new Dpermisos();
            Lpermisos parametros = new Lpermisos();
            parametros.IdUsuario = Idusuario;
            funcion.MostrarPermisos(ref dt, parametros);
            btnConsultas.Enabled = false;
            btnPersonal.Enabled = false;
            btnRegistro.Enabled = false;
            btnUsuarios.Enabled = false;
            btnRestaurarBD.Enabled = false;
            btnRespaldos.Enabled = false;

            foreach (DataRow rowPermisos in dt.Rows)
            {
                string Modulo = Convert.ToString(rowPermisos["Modulo"]);
                if (Modulo == "PrePlanillas")
                {
                    btnConsultas.Enabled = true;
                }
                if (Modulo == "Usuarios")
                {
                    btnUsuarios.Enabled = true;
                }
                if (Modulo == "Usuarios")
                {
                    btnUsuarios.Enabled = true;
                    btnRegistro.Enabled = true;
                }
                if (Modulo == "Personal")
                {
                    btnPersonal.Enabled = true;
                }
                if (Modulo == "Respaldos")
                {
                    btnRespaldos.Enabled= true;
                    btnRestaurarBD.Enabled = true;
                }
            }
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            PanelPadre.Controls.Clear();
            Personal control = new Personal();
            control.Dock = DockStyle.Fill;
            PanelPadre.Controls.Add(control);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            PanelPadre.Controls.Clear();
            CtlUsuarios control = new CtlUsuarios();
            control.Dock = DockStyle.Fill;
            PanelPadre.Controls.Add(control);
        }
    }
}
