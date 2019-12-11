using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narnia {
    class Raton : Personaje{
        private string nombre;
        private Boolean estatua;
        private Timer movimiento;

        public Raton(String nombre, int casillaSize) {
            this.nombre = nombre;
            this.estatua = false;
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string nombreArchivo;
            nombreArchivo = Path.Combine(dir, @"..\..\Resources\rat.png");
            Image image = Image.FromFile(nombreArchivo);
            this.Image = image;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = new Size(casillaSize, casillaSize);
            this.Location = new Point(5,5);
            this.movimiento = new Timer();
            this.movimiento.Enabled = false;
            this.movimiento.Interval = 500;
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool Estatua { get => estatua; set => estatua = value; }
        public Timer Movimiento { get => movimiento; set => movimiento = value; }
    }
}
