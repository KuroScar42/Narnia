namespace Narnia {
    partial class JuegoForm {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.BrujaTimer = new System.Windows.Forms.Timer(this.components);
            this.RoperoTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.TamanoLaberinto = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pBoxTablero = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.contenedor = new System.Windows.Forms.GroupBox();
            this.nomRats = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxTablero)).BeginInit();
            this.contenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // BrujaTimer
            // 
            this.BrujaTimer.Interval = 500;
            this.BrujaTimer.Tick += new System.EventHandler(this.BrujaMovement);
            // 
            // RoperoTimer
            // 
            this.RoperoTimer.Tick += new System.EventHandler(this.RoperoAction);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BackgroundImage = global::Narnia.Properties.Resources.dim_gray;
            this.panel1.Controls.Add(this.contenedor);
            this.panel1.Controls.Add(this.TamanoLaberinto);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.pBoxTablero);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1344, 721);
            this.panel1.TabIndex = 0;
            // 
            // TamanoLaberinto
            // 
            this.TamanoLaberinto.FormattingEnabled = true;
            this.TamanoLaberinto.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.TamanoLaberinto.Location = new System.Drawing.Point(759, 71);
            this.TamanoLaberinto.Name = "TamanoLaberinto";
            this.TamanoLaberinto.Size = new System.Drawing.Size(99, 21);
            this.TamanoLaberinto.TabIndex = 6;
            this.TamanoLaberinto.Text = "Tamaño";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(758, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Menu Pricipal";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pBoxTablero
            // 
            this.pBoxTablero.Image = global::Narnia.Properties.Resources.cecilie_johnsen_hk3695TrMZA_edited;
            this.pBoxTablero.Location = new System.Drawing.Point(12, 12);
            this.pBoxTablero.Name = "pBoxTablero";
            this.pBoxTablero.Size = new System.Drawing.Size(740, 697);
            this.pBoxTablero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxTablero.TabIndex = 4;
            this.pBoxTablero.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(758, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Crear Laberinto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // contenedor
            // 
            this.contenedor.Controls.Add(this.nomRats);
            this.contenedor.ForeColor = System.Drawing.Color.Aqua;
            this.contenedor.Location = new System.Drawing.Point(759, 87);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(176, 351);
            this.contenedor.TabIndex = 7;
            this.contenedor.TabStop = false;
            this.contenedor.Text = "Ratones Capturados por la Bruja";
            // 
            // nomRats
            // 
            this.nomRats.Location = new System.Drawing.Point(6, 19);
            this.nomRats.Name = "nomRats";
            this.nomRats.Size = new System.Drawing.Size(164, 326);
            this.nomRats.TabIndex = 0;
            // 
            // JuegoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1344, 721);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(523, 430);
            this.Name = "JuegoForm";
            this.Text = "Narnia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cerrarPrograma);
            this.Load += new System.EventHandler(this.JuegoView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DetectarTecla);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxTablero)).EndInit();
            this.contenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pBoxTablero;
        private System.Windows.Forms.Timer BrujaTimer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer RoperoTimer;
        private System.Windows.Forms.ComboBox TamanoLaberinto;
        private System.Windows.Forms.GroupBox contenedor;
        private System.Windows.Forms.FlowLayoutPanel nomRats;
    }
}

