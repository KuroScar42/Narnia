using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia {
    public class Lista<T>: Elemento<T> {

        private Elemento<T> ini = null;

        private int cantElementos = 0;

        public void Add(T dato) {
            Elemento<T> nuevo = new Elemento<T>();
            nuevo.Sig = null;
            nuevo.Dato = dato;
            if (ini == null) {
                ini = nuevo;
                cantElementos++;
            } else {
                Elemento<T> aux = ini;
                while (aux.Sig != null) {
                    aux = aux.Sig;
                }
                aux.Sig = nuevo;
                cantElementos++;
            }
        }

        public void Clear() {
            ini = null;
            cantElementos = 0;
        }

        public int Count() {
            return cantElementos;
        }

        public void Remove(T dato) {
            Elemento<T> aux = ini;
            if (ini != null) {
                if (ini.Dato.Equals(dato)) {
                    ini = ini.Sig;
                } else {
                    Elemento<T> auxAtras = null;
                    while (aux != null && !aux.Dato.Equals(dato)) {
                        auxAtras = aux;
                        aux = aux.Sig;
                    }
                    if (aux != null) {
                        auxAtras.Sig = aux.Sig;
                    }
                }
            } else {
                throw new NullReferenceException();
            }
        }

        public T getDato() {
            if (ini == null) {
                return default(T);
            } else {
                Elemento<T> aux = ini;
                ini = ini.Sig;
                return aux.Dato;
            }
        }

    }
}
