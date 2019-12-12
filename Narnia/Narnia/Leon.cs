using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia {
    class Leon : Personaje{
        // Lista simplemente enlazada que guarda los ratones que ha salvado
        private readonly Lista<String> ratonesSalvados;

        public Leon() {
            ratonesSalvados = new Lista<string>();
        }

        internal Lista<string> RatonesSalvados => ratonesSalvados;
    }
}
