namespace Narnia {
    partial class Inicio {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnJugar = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnJugar
            // 
            this.btnJugar.AutoSize = true;
            this.btnJugar.BackColor = System.Drawing.Color.Transparent;
            this.btnJugar.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnJugar.Location = new System.Drawing.Point(329, 137);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(168, 32);
            this.btnJugar.TabIndex = 0;
            this.btnJugar.Text = "Play Game";
            this.btnJugar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnJugar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnJugar_OnMouseClick);
            this.btnJugar.MouseEnter += new System.EventHandler(this.btnJugar_OnMouseEnter);
            this.btnJugar.MouseLeave += new System.EventHandler(this.btnJugar_OnMouseLeave);
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = true;
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Location = new System.Drawing.Point(367, 248);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(83, 32);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Exit";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSalir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSalir_OnMouseClick);
            this.btnSalir.MouseEnter += new System.EventHandler(this.btnSalir_OnMouseEnter);
            this.btnSalir.MouseLeave += new System.EventHandler(this.btnSalir_OnMouseLeave);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Narnia.Properties.Resources.Diseño_sin_título1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(845, 534);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnJugar);
            this.DoubleBuffered = true;
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btnJugar;
        private System.Windows.Forms.Label btnSalir;
    }
}