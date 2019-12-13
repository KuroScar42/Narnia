using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narnia {
    public partial class Final : Form {
        private Lista<string> ratones_Leon;
        private Pila<String> ratones_Bruja;

        public Final() {
            InitializeComponent();
            ratones_Bruja = new Pila<string>();
            ratones_Leon = new Lista<string>();
        }

        public Final(Lista<string> ratones_Leon, Pila<String> ratones_Bruja):this() {
            this.ratones_Leon = ratones_Leon;
            this.ratones_Bruja = ratones_Bruja;

            for (int i = 0;i < ratones_Bruja.Count();i++) {
                Label nombre = new Label();
                nombre.ForeColor = Color.White;
                nombre.Visible = true;
                nombre.AutoSize = true;
                nombre.Text = ratones_Bruja.Pop();
                RatonesCongelados.Controls.Add(nombre);
            }

            for (int i = 0;i < ratones_Leon.Count();i++) {
                Label nombre = new Label();
                nombre.ForeColor = Color.White;
                nombre.Visible = true;
                nombre.AutoSize = true;
                nombre.Text = ratones_Leon.getDato();
                RatonesCongelados.Controls.Add(nombre);
            }

        }
        
        private void Final_Load(object sender, EventArgs e) {

        }

        private void volverButton_Click(object sender, EventArgs e) {
            this.Close();
            Application.OpenForms[0].Show();
        }
    }
}
