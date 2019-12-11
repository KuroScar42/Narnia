using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narnia {
    class Personaje : PictureBox{
        private int posX;
        private int posY;

        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }

        public void Dibujar() {
            this.Location = new Point(PosX,PosY);
        }
    }
}
