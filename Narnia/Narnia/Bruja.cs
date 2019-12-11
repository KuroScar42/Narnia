using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia {
    class Bruja : Personaje{
        //pila para los ratones que se van congelando
        private Pila<Raton> ratonesCongelados;


        public Bruja() {
            RatonesCongelados = new Pila<Raton>();
        }

        internal Pila<Raton> RatonesCongelados { get => ratonesCongelados; set => ratonesCongelados = value; }
    }
}
