using Oruscurso.Datos;
using Oruscurso.Logica;
using Oruscurso.Presentacion.AsistenteInstalacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oruscurso.Presentacion
{
    public partial class Login : Form
    {
        string Usuario;
        int Idusuario;
        int Contador;
        string Indicador;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ValidarConexion();
        }

        private void ValidarConexion()
        {
            VerificarConexion();
            if (Indicador == "Correcto")
            {
                MostrarUsuarios();
                if (Contador == 0)
                {
                    Dispose();
                    UsuarioPrincipal frm = new UsuarioPrincipal();
                    frm.ShowDialog();
                }
                else
                {
                    DibujarUsuarios();
                }  
            }
            else
            {
                Dispose();
                EleccionServidor frm = new EleccionServidor();
                frm.ShowDialog();
            }
        }

        private void MostrarUsuarios()
        {
            DataTable dt = new DataTable();
            Dusuarios funcion = new Dusuarios();
            funcion.MostrarUsuarios(ref dt);
            Contador = dt.Rows.Count;
        }

        private void VerificarConexion()
        {
            Dusuarios funcion = new Dusuarios();
            funcion.VerificarUsuarios(ref Indicador);
        }

        private void DibujarUsuarios()
        {
            try
            {
                PanelUsuarios.Visible = true;
                PanelUsuarios.Dock = DockStyle.Fill;
                PanelUsuarios.BringToFront();
                DataTable dt = new DataTable();
                Dusuarios funcion = new Dusuarios();
                funcion.MostrarUsuarios(ref dt);
                foreach (DataRow rdr in dt.Rows)
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    PictureBox I1 = new PictureBox();
                    b.Text = rdr["Login"].ToString();
                    b.Name = rdr["idUsuario"].ToString();
                    b.Size = new Size(175, 25);
                    b.Font = new Font("Microsoft Sans Serif", 13);
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Color.White;
                    b.Dock = DockStyle.Bottom;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.Cursor = Cursors.Hand;

                    p1.Size = new Size(155, 167);
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(20, 20, 20);

                    I1.Size = new Size(175, 132);
                    I1.Dock = DockStyle.Top;
                    I1.BackgroundImage = null;
                    byte[] bi = (Byte[])rdr["Icono"];
                    MemoryStream ms = new MemoryStream(bi);
                    I1.Image = Image.FromStream(ms);
                    I1.SizeMode = PictureBoxSizeMode.Zoom;
                    I1.Tag = rdr["Login"].ToString();
                    I1.Cursor = Cursors.Hand; //El cursor tendrá el icono de una mano cuando esté encima del PictureBox

                    p1.Controls.Add(b);
                    p1.Controls.Add(I1);
                    b.BringToFront();

                    flowLayoutPanel2.Controls.Add(p1);

                    b.Click += MiEventoLabel; //b.Click += tabulador para crear el evento
                    I1.Click += MiEventoImagen;
                }
            }
            catch (Exception)
            {

            }
        }

        private void MiEventoImagen(object sender, EventArgs e)
        {
            Usuario = Convert.ToString(((PictureBox)sender).Tag);
            MostrarPanelPass();
        }

        private void MiEventoLabel(object sender, EventArgs e)
        {
            Usuario = ((Label)sender).Text;
            MostrarPanelPass();

        }

        private void MostrarPanelPass()
        {
            PanelIngresoContraseña.Visible = true;
            PanelIngresoContraseña.Location = new Point((Width - PanelIngresoContraseña.Width) / 2, (Height - PanelIngresoContraseña.Height) / 2);
            PanelUsuarios.Visible = false;
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            ValidarUsuarios();
        }

        private void ValidarUsuarios()
        {
            Lusuarios parametros = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            parametros.Password = txtContraseña.Text;
            parametros.Login = Usuario;
            funcion.ValidarUsuario(parametros, ref Idusuario);

            if (Idusuario > 0)
            {
                Dispose();
                MenuPrincipal frm = new MenuPrincipal();
                frm.ShowDialog();
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contraseña errónea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtContraseña.Text += "0";
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            txtContraseña.Clear();
        }

        private void btnBorrarDerecha_Click(object sender, EventArgs e)
        {
            int contador;
            contador = txtContraseña.Text.Count();

            if (contador > 0)
            {
                txtContraseña.Text = txtContraseña.Text.Substring(0, txtContraseña.Text.Count() - 1);
            }
        }
    }
}
