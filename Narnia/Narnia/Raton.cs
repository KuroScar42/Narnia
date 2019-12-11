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

        public Raton(String nombre, int casillaSize, Point point) {
            this.nombre = nombre;
            this.estatua = false;
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string nombreArchivo;
            nombreArchivo = Path.Combine(dir, @"..\..\Resources\rat.png");
            Image image = Image.FromFile(nombreArchivo);
            this.Image = image;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = new Size(casillaSize, casillaSize);
            this.Location = point;
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool Estatua { get => estatua; set => estatua = value; }
    }
}
