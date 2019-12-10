using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia {
    class Elemento<T> {
        T dato;
        Elemento<T> sig = null;


        public T Dato { get => dato; set => dato = value; }
        internal Elemento<T> Sig { get => sig; set => sig = value; }
    }
}
