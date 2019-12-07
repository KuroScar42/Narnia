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

        public Celda() {
            paredNorte = true;
            paredEste = true;
            paredOeste = true;
            paredSur = true;
        }

    }
}
