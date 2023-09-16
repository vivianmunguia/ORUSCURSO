using Oruscurso.Datos;
using Oruscurso.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Oruscurso.Presentacion.AsistenteInstalacion
{
    public partial class UsuarioPrincipal : Form
    {
        int idUsuario;
        public UsuarioPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                if (!string.IsNullOrEmpty(txtContrasena.Text))
                {
                    if (txtContrasena.Text == txtConfirmarContrasena.Text)
                    {
                        InsertarUsuarioDefecto();
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Falta ingresar la contraseña", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Falta ingresar el nombre", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void InsertarUsuarioDefecto()
        {
            Lusuarios parametros = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            parametros.Nombre = txtNombre.Text;
            parametros.Login = txtUsuario.Text;
            parametros.Password = txtContrasena.Text;
            MemoryStream ms = new MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            parametros.Icono = ms.GetBuffer();
            if (funcion.InsertarUsuarios(parametros) == true)
            {
                InsertarModulos();
                ObtenerIdUsuario();
                InsertarPermisos();
            }
        }

        private void ObtenerIdUsuario()
        {
            Dusuarios funcion = new Dusuarios();
            funcion.ObtenerIdUsuario(ref idUsuario, txtUsuario.Text);
        }

        private void InsertarPermisos()
        {
            DataTable dt = new DataTable();
            Dmodulos funcionModulos = new Dmodulos();
            funcionModulos.MostrarModulos(ref dt);
            foreach (DataRow row in dt.Rows)
            {
                int idModulo = Convert.ToInt32(row["IdModulo"]);
                Lpermisos parametros = new Lpermisos();
                Dpermisos funcion = new Dpermisos();
                parametros.IdModulo = idModulo;
                parametros.IdUsuario = idUsuario;
                if (funcion.InsertarPermisos(parametros) == true)
                {
                    MessageBox.Show("Listo, recuerda que para iniciar sesión tu usuario es " + txtUsuario.Text + "y tu contraseña es " + txtContrasena.Text, "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dispose();
                    Login frm = new Login();
                    frm.ShowDialog();
                }
            }
        }

        private void InsertarModulos()
        {
            Lmodulos parametros = new Lmodulos();
            Dmodulos funcion = new Dmodulos();
            var Modulos = new List<string> { "Usuarios", "Respaldos", "Personal", "PrePlanillas" };
            foreach (var Modulo in Modulos)
            {
                parametros.Modulo = Modulo;
                funcion.InsertarModulos(parametros);
            }
        }
    }
}
