using Oruscurso.Datos;
using Oruscurso.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Oruscurso.Presentacion
{
    public partial class CtlUsuarios : UserControl
    {
        int Idusuario;
        string login;
        string estado;
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
            txtUsuario.Enabled = true;
            dataListadoModulos.Enabled = true;
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
            dataListadoModulos.Columns[1].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                if (!string.IsNullOrEmpty(txtUsuario.Text))
                {
                    if (!string.IsNullOrEmpty(txtContraseña.Text))
                    {
                        if (lblAnuncioIcono.Visible == false) //Cuando se agregue la imagen quedará encima del label, por eso si es visible significa que el usuario aún no escoge la imagen
                        {
                            InsertarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un icono");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese la contraseña");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el usuario");
                }
            }
            else
            {
                MessageBox.Show("Ingrese el nombre");
            }
        }

        private void InsertarUsuarios()
        {
            Lusuarios parametros = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            parametros.Nombre = txtNombre.Text;
            parametros.Login = txtUsuario.Text;
            parametros.Password = txtContraseña.Text;
            MemoryStream ms = new MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            parametros.Icono = ms.GetBuffer();

            if (funcion.InsertarUsuarios(parametros) == true)
            {
                ObtenerIdUsuario();
                InsertarPermisos();
            }
        }

        private void InsertarPermisos()
        {
            foreach (DataGridViewRow row in dataListadoModulos.Rows)
            {
                int IdModulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                bool marcado = Convert.ToBoolean(row.Cells["Marcar"].Value);

                if (marcado == true)
                {
                    Lpermisos parametros = new Lpermisos();
                    Dpermisos funcion = new Dpermisos();
                    parametros.IdModulo = IdModulo;
                    parametros.IdUsuario = Idusuario;

                    funcion.InsertarPermisos(parametros);
                }
            }

            MostrarUsuarios();
            panelRegistro.Visible = false;
        }

        private void MostrarUsuarios()
        {
            DataTable dt = new DataTable();
            Dusuarios funcion = new Dusuarios();
            funcion.MostrarUsuarios(ref dt);
            dataListadoUsuarios.DataSource = dt;
            DiseñarDtvUsuarios();
        }

        private void DiseñarDtvUsuarios()
        {
            Bases.DiseñoDtv(ref dataListadoUsuarios);
            Bases.DiseñoDtvEliminar(ref dataListadoUsuarios);
            dataListadoUsuarios.Columns[2].Visible = false;
            dataListadoUsuarios.Columns[5].Visible = false;
            dataListadoUsuarios.Columns[6].Visible = false;
        }

        private void ObtenerIdUsuario()
        {
            Dusuarios funcion = new Dusuarios();
            funcion.ObtenerIdUsuario(ref Idusuario, txtUsuario.Text);
        }

        private void lblAnuncioIcono_Click(object sender, EventArgs e)
        {
            MostrarPanelIcono();
        }

        private void MostrarPanelIcono()
        {
            panelIcono.Visible = true;
            panelIcono.Dock = DockStyle.Fill;
            panelIcono.BringToFront();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox3.Image;
            OcultarPanelIconos();
        }

        private void OcultarPanelIconos()
        {
            panelIcono.Visible = false;
            lblAnuncioIcono.Visible = false;
            Icono.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox4.Image;
            OcultarPanelIconos();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox5.Image;
            OcultarPanelIconos();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox6.Image;
            OcultarPanelIconos();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox7.Image;
            OcultarPanelIconos();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox8.Image;
            OcultarPanelIconos();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox9.Image;
            OcultarPanelIconos();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox10.Image;
            OcultarPanelIconos();
        }

        private void AgregarIconoPC_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = ""; //El directorio inicial será en el último en el que se haya estado
            dlg.Filter = "Imagenes|*.jpg;*.png"; //Se buscan archivos de tipo jpg y png
            dlg.FilterIndex = 2; //Cantidad de filtros que se tienen
            dlg.Title = "Cargador de imágenes";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Icono.BackgroundImage = null; //Se limpia la imagen que había
                Icono.Image = new Bitmap(dlg.FileName);
                OcultarPanelIconos();
            }
        }

        private void Icono_Click(object sender, EventArgs e)
        {
            MostrarPanelIcono();
        }

        private void CtlUsuarios_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = false;
        }

        private void btnVolverIcono_Click(object sender, EventArgs e)
        {
            OcultarPanelIconos();
            if (Icono.Image == null)
            {
                panelIcono.Visible = false;
                lblAnuncioIcono.Visible = true;
            }
        }

        private void dataListadoUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListadoUsuarios.Columns["Editar"].Index)
            {
                ObtenerEstado();
                if(estado == "ELIMINADO")
                {
                    DialogResult resultado = MessageBox.Show("Este usuario se eliminó, ¿desea volver a habilitarlo?", "Restauración de registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (resultado == DialogResult.OK) 
                    {
                        RestaurarUsuario();
                    }
                }
                else
                {
                    ObtenerDatos();
                }
            }
            if (e.ColumnIndex == dataListadoUsuarios.Columns["Eliminar"].Index)
            {
                DialogResult resultado = MessageBox.Show("¿Realmente desea eliminar este registro?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                {
                    CapturarIdUsuario();
                    EliminarUsuarios();
                }
            }
        }

        private void EliminarUsuarios()
        {
            Lusuarios parametros = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            parametros.IdUsuario = Idusuario;
            parametros.Login = login;
            if (funcion.EliminarUsuario(parametros) == true)
            {
                MostrarUsuarios();
            }
        }

        private void CapturarIdUsuario()
        {
            Idusuario = Convert.ToInt32(dataListadoUsuarios.SelectedCells[2].Value);
            login = dataListadoUsuarios.SelectedCells[4].Value.ToString();
        }

        private void RestaurarUsuario()
        {
            CapturarIdUsuario();
            Lusuarios parametros = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            parametros.IdUsuario = Idusuario;
            if (funcion.RestaurarUsuario(parametros) == true)
            {
                MostrarUsuarios();
            }
        }

        private void ObtenerEstado()
        {
            estado = dataListadoUsuarios.SelectedCells[7].Value.ToString();
        }

        private void ObtenerDatos()
        {
            CapturarIdUsuario();
            txtNombre.Text = dataListadoUsuarios.SelectedCells[3].Value.ToString();
            txtUsuario.Text = dataListadoUsuarios.SelectedCells[4].Value.ToString();

            if (txtUsuario.Text == "admin")
            {
                txtUsuario.Enabled = false;
                dataListadoModulos.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled = true;
                dataListadoModulos.Enabled = true;
            }

            txtContraseña.Text = dataListadoUsuarios.SelectedCells[5].Value.ToString();

            Icono.BackgroundImage = null;
            byte[] b = (byte[])(dataListadoUsuarios.SelectedCells[6].Value);
            MemoryStream ms = new MemoryStream(b);
            Icono.Image = Image.FromStream(ms);
            panelRegistro.Visible = true;
            panelRegistro.Dock = DockStyle.Fill;
            lblAnuncioIcono.Visible = false;
            btnActualizar.Visible = true;
            btnGuardar.Visible = false;
            MostrarModulos();
            MostrarPermisos();
        }

        public void MostrarPermisos()
        {
            DataTable dt = new DataTable();
            Dpermisos funcion = new Dpermisos();
            Lpermisos parametros = new Lpermisos();
            parametros.IdUsuario = Idusuario;
            funcion.MostrarPermisos(ref dt, parametros);
            foreach (DataRow rowPermisos in dt.Rows)
            {
                int idModuloPermisos = Convert.ToInt32(rowPermisos["IdModulo"]);
                foreach (DataGridViewRow rowModulos in dataListadoModulos.Rows)
                {
                    int Idmodulo = Convert.ToInt32(rowModulos.Cells["IdModulo"].Value);
                    if (idModuloPermisos == Idmodulo)
                    {
                        rowModulos.Cells[0].Value = true;
                    }
                }
            }
        }
    }
}
