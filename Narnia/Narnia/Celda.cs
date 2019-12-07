using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narnia {
    class Celda : Button {
        public Boolean paredNorte;
        public Boolean paredEste;
        public Boolean paredOeste;
        public Boolean paredSur;
        private int posX;
        private int posY;

        public Celda() {
            paredNorte = true;
            paredEste = true;
            paredOeste = true;
            paredSur = true;
        }
        public Celda(int x, int y) {
            paredNorte = true;
            paredEste = true;
            paredOeste = true;
            paredSur = true;
            this.PosX = x;
            this.PosY = y;
        }

        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }
    }
}
