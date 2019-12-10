using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    class Nodo{
        private Nodo sig=null;
        private Fila fila;

        internal Nodo Sig { get => sig; set => sig = value; }
        internal Fila Fila { get => fila; set => fila = value; }

        public Nodo(Nodo sig,Fila fila)
        {
            this.sig = sig;
            this.fila = fila;
        }

        
    }
}
