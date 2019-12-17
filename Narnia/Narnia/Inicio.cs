using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narnia {
    public partial class Inicio : Form {

        private SoundPlayer player;
        public Inicio() {
            InitializeComponent();
            player = new SoundPlayer();
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string nombreArchivo;
            nombreArchivo = Path.Combine(dir, @"..\..\Resources\Intro.wav");
            player.SoundLocation = nombreArchivo;
            player.PlayLooping();
        }

        private void Inicio_Load(object sender, EventArgs e) {
            btnJugar.AutoSize = true;
            btnSalir.AutoSize = true;

        }


        private void btnJugar_OnMouseClick(object sender, MouseEventArgs e) {
            this.Hide();
            JuegoForm juego = new JuegoForm();
            juego.Show();
            //this.Close();
        }

        private void btnSalir_OnMouseClick(object sender, MouseEventArgs e) {
            this.Close();

        }

        private void btnJugar_OnMouseEnter(object sender, EventArgs e) {
            btnJugar.ForeColor = Color.Aquamarine;

        }

        private void btnJugar_OnMouseLeave(object sender, EventArgs e) {
            btnJugar.ForeColor = Color.White;

        }

        private void btnSalir_OnMouseEnter(object sender, EventArgs e) {
            btnSalir.ForeColor = Color.Aquamarine;

        }

        private void btnSalir_OnMouseLeave(object sender, EventArgs e) {
            btnSalir.ForeColor = Color.White;
        }

        private void CerrarPrograma(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
