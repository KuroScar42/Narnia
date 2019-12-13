namespace Narnia {
    partial class Final {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RatonesCongelados = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RatonesSalvados = new System.Windows.Forms.FlowLayoutPanel();
            this.volverButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::Narnia.Properties.Resources.dim_gray;
            this.groupBox1.Controls.Add(this.RatonesCongelados);
            this.groupBox1.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bruja - Congelados";
            // 
            // RatonesCongelados
            // 
            this.RatonesCongelados.BackgroundImage = global::Narnia.Properties.Resources.dim_gray;
            this.RatonesCongelados.ForeColor = System.Drawing.Color.White;
            this.RatonesCongelados.Location = new System.Drawing.Point(6, 19);
            this.RatonesCongelados.Name = "RatonesCongelados";
            this.RatonesCongelados.Size = new System.Drawing.Size(764, 137);
            this.RatonesCongelados.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = global::Narnia.Properties.Resources.dim_gray;
            this.groupBox2.Controls.Add(this.RatonesSalvados);
            this.groupBox2.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox2.Location = new System.Drawing.Point(12, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 174);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Leon - Descongelados";
            // 
            // RatonesSalvados
            // 
            this.RatonesSalvados.BackgroundImage = global::Narnia.Properties.Resources.dim_gray;
            this.RatonesSalvados.Location = new System.Drawing.Point(6, 19);
            this.RatonesSalvados.Name = "RatonesSalvados";
            this.RatonesSalvados.Size = new System.Drawing.Size(764, 137);
            this.RatonesSalvados.TabIndex = 0;
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(695, 372);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(93, 23);
            this.volverButton.TabIndex = 2;
            this.volverButton.Text = "Menú Principal";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // Final
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Narnia.Properties.Resources.dim_gray;
            this.ClientSize = new System.Drawing.Size(800, 403);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Final";
            this.Text = "Final";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CerrarPrograma);
            this.Load += new System.EventHandler(this.Final_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel RatonesCongelados;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel RatonesSalvados;
        private System.Windows.Forms.Button volverButton;
    }
}