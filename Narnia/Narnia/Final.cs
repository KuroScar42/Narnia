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

            while(!ratones_Bruja.Empty()){
                Label nombre = new Label();
                nombre.BackColor = Color.DimGray;
                nombre.ForeColor = Color.White;
                nombre.Visible = true;
                nombre.AutoSize = true;
                nombre.Text = ratones_Bruja.Pop();
                RatonesCongelados.Controls.Add(nombre);
            }

            while(!ratones_Leon.Empty()) {
                Label nombre = new Label();
                nombre.BackColor = Color.DimGray;
                nombre.ForeColor = Color.White;
                nombre.Visible = true;
                nombre.AutoSize = true;
                nombre.Text = ratones_Leon.getDato();
                RatonesSalvados.Controls.Add(nombre);
            }

        }
        
        private void Final_Load(object sender, EventArgs e) {

        }

        private void volverButton_Click(object sender, EventArgs e) {
            foreach (Form item in Application.OpenForms) {
                if (item is Inicio) {
                    item.Show();
                    break;
                }
            }
            this.Hide();
        }

        private void CerrarPrograma(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
