using Oruscurso.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace Oruscurso.Presentacion
{
    public partial class TomarAsistencias : Form
    {
        string Identificacion;
        int IdPersonal;
        int Contador;

        public TomarAsistencias()
        {
            InitializeComponent();
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarPersonalIdent();
            if (Identificacion == txtIdentificacion.Text)
            {

            }
        }

        private void BuscarPersonalIdent()
        {
            DataTable dt = new DataTable();
            Dpersonal funcion = new Dpersonal();
            funcion.BuscarPersonalIdentidad(ref dt, txtIdentificacion.Text);
            if (dt.Rows.Count > 0)
            {
                Identificacion = dt.Rows[0]["Identificacion"].ToString();
                IdPersonal = Convert.ToInt32(dt.Rows[0]["Id_personal"]);
                txtNombre.Text = dt.Rows[0]["Nombres"].ToString();
            }
        }
    }
}
