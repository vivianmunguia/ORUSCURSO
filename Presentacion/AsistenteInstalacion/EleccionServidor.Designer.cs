namespace Oruscurso.Presentacion.AsistenteInstalacion
{
    partial class EleccionServidor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EleccionServidor));
            panel1 = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            btnPrincipal = new System.Windows.Forms.Button();
            btnRemoto = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(29, 29, 29);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(889, 60);
            panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(142, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(63, 60);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Dock = System.Windows.Forms.DockStyle.Left;
            label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(142, 60);
            label1.TabIndex = 1;
            label1.Text = "Orus 369";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(231, 75);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(646, 371);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // btnPrincipal
            // 
            btnPrincipal.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            btnPrincipal.FlatAppearance.BorderSize = 0;
            btnPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPrincipal.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnPrincipal.ForeColor = System.Drawing.Color.White;
            btnPrincipal.Location = new System.Drawing.Point(44, 115);
            btnPrincipal.Name = "btnPrincipal";
            btnPrincipal.Size = new System.Drawing.Size(161, 56);
            btnPrincipal.TabIndex = 5;
            btnPrincipal.Text = "Principal";
            btnPrincipal.UseVisualStyleBackColor = false;
            btnPrincipal.Click += btnPrincipal_Click;
            // 
            // btnRemoto
            // 
            btnRemoto.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            btnRemoto.FlatAppearance.BorderSize = 0;
            btnRemoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRemoto.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRemoto.ForeColor = System.Drawing.Color.White;
            btnRemoto.Location = new System.Drawing.Point(12, 330);
            btnRemoto.Name = "btnRemoto";
            btnRemoto.Size = new System.Drawing.Size(213, 56);
            btnRemoto.TabIndex = 6;
            btnRemoto.Text = "Punto de Control";
            btnRemoto.UseVisualStyleBackColor = false;
            btnRemoto.Click += btnRemoto_Click;
            // 
            // EleccionServidor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            ClientSize = new System.Drawing.Size(889, 458);
            Controls.Add(btnRemoto);
            Controls.Add(btnPrincipal);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Name = "EleccionServidor";
            Text = "EleccionServidor";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnPrincipal;
        private System.Windows.Forms.Button btnRemoto;
    }
}