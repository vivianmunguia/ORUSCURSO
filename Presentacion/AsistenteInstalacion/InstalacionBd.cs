using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Oruscurso.Logica;

namespace Oruscurso.Presentacion.AsistenteInstalacion
{
    public partial class InstalacionBd : Form
    {
        string NombreDelEquipoUsuario;
        public static int milisegundo;
        public static int segundos;
        private AES aes = new AES();
        string ruta;
        public InstalacionBd()
        {
            InitializeComponent();
        }

        private void InstalacionBd_Load(object sender, EventArgs e)
        {
            CentrarPaneles();
            Reemplazar();
            comprobar_si_ya_hay_servidor_instalado_SQL_EXPRESS();
        }

        private void CentrarPaneles()
        {
            Panel2.Location = new Point((Width - Panel2.Width) / 2, (Height - Panel2.Height) / 2); //Panel2
            NombreDelEquipoUsuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Cursor = Cursors.WaitCursor; //El cursor obtiene la forma de un reloj de arena que significa que hay un proceso corriendo
            Panel5.Visible = false; //Panel4
            Panel5.Dock = DockStyle.None; //Panel4
        }

        private void Reemplazar()
        {
            //Solo modificar este campo
            txtCrearProcedimientos.Text = txtCrearProcedimientos.Text.Replace("ORUS369", txtBaseDeDatos.Text);

            txtEliminarBase.Text = txtEliminarBase.Text.Replace("BASEADACURSO", txtBaseDeDatos.Text);
            txtCrearUsuarioDb.Text = txtCrearUsuarioDb.Text.Replace("ada369", txtUsuario.Text);
            txtCrearUsuarioDb.Text = txtCrearUsuarioDb.Text.Replace("BASEADA", txtBaseDeDatos.Text);
            txtCrearUsuarioDb.Text = txtCrearUsuarioDb.Text.Replace("softwarereal", lblcontraseña.Text);
            //Adjuntando al textbox que contiene los procedimientos almacenados
            txtCrearProcedimientos.Text = txtCrearProcedimientos.Text + Environment.NewLine + txtCrearUsuarioDb.Text;
        }

        private void comprobar_si_ya_hay_servidor_instalado_SQL_EXPRESS()
        {
            txtservidor.Text = @".\" + lblnombredeservicio.Text;
            ejecutar_scrypt_ELIMINARBase_comprobacion_de_inicio();
            ejecutar_scrypt_crearBase_comprobacion_De_inicio();
        }

        private void ejecutar_scrypt_ELIMINARBase_comprobacion_de_inicio()
        {
            string str;
            SqlConnection myConn = new SqlConnection("Data source=" + txtservidor.Text + ";Initial Catalog=master;Integrated Security=True");
            str = txtEliminarBase.Text;
            SqlCommand myCommand = new SqlCommand(str, myConn);

            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        private void ejecutar_scrypt_crearBase_comprobacion_De_inicio()
        {
            SqlConnection cnn = new SqlConnection("Server=" + txtservidor.Text + "; " + "database=master; integrated security=yes");
            string s = "CREATE DATABASE " + txtBaseDeDatos.Text;
            var cmd = new SqlCommand(s, cnn);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                SaveToXML(aes.Encrypt("Data Source=" + txtservidor.Text + ";Initial Catalog=" + txtBaseDeDatos.Text + ";integrated security=true", Desencryptacion.appPwdUnique, int.Parse("256")));
                EjecutarScript();
                Panel4.Visible = true; //Panel4
                Panel4.Dock = DockStyle.Fill; //Panel4
                label1.Text = @"Instancia encontrada, no cierre esta ventana, se cerrará automáticamente cuando todo esté listo";
                Panel6.Visible = false;
                timer4.Start();
            }
            catch (Exception)
            {

            }
        }

        private void EjecutarScript()
        {
            ruta = Path.Combine(Directory.GetCurrentDirectory(), txtnombre_scrypt.Text + ".txt");
            //FileInfo fi = new FileInfo(ruta);//Sirve para crear archivos
            StreamWriter sw;
            try
            {
                if (File.Exists(ruta) == false)
                {
                    sw = File.CreateText(ruta);
                    sw.WriteLine(txtCrearProcedimientos.Text);
                    sw.Flush();
                    sw.Close();
                }
                else if (File.Exists(ruta) == true)
                {
                    File.Delete(ruta);
                    sw = File.CreateText(ruta);
                    sw.WriteLine(txtCrearProcedimientos.Text);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception)
            {
            }

            try
            {
                Process Pross = new Process();
                Pross.StartInfo.FileName = "sqlcmd";
                Pross.StartInfo.Arguments = " -S " + txtservidor.Text + " -i " + txtnombre_scrypt.Text + ".txt";
                Pross.Start();
            }
            catch (Exception)
            {

            }
        }

        private void SaveToXML(object dbcnString)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                root.Attributes[0].Value = Convert.ToString(dbcnString);
                XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
                writer.Close();
            }
            catch (Exception e)
            {

            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            milisegundo += 1;
            mil3.Text = milisegundo.ToString();
            if (milisegundo == 60)
            {
                segundos += 1;
                seg3.Text = segundos.ToString();
                milisegundo = 0;
            }
            if (segundos == 15)
            {
                timer4.Stop();
                try
                {
                    File.Delete(ruta);
                }
                catch (Exception ex)
                {

                }
                Dispose();
            }
        }
    }
}
