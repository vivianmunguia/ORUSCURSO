using System;
using System.Windows.Forms;

namespace Oruscurso.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            panelBienvenida.Dock = DockStyle.Fill;
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            PruebaForm frm = new PruebaForm();
            frm.ShowDialog();
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            PruebasControl Control = new PruebasControl();
            panel2.Controls.Clear();
            Control.Dock = DockStyle.Fill;
            panel2.Controls.Add(Control);
        }
    }
}
