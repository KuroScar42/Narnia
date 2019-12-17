using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia {
    /// <summary>
    /// Es una clase creada para manejar Pilas más sencillamente
    /// </summary>
    /// <typeparam name="T"> El tipo que se desea guardar en la pila</typeparam>
    public class Pila<T> : Elemento<T> {

        private Elemento<T> ini = null;


        public void Push(T dato) {
            Elemento<T> nuevo = new Elemento<T>();
            nuevo.Dato = dato;
            nuevo.Sig = ini;
            ini = nuevo;
        }

        public T Pop() {
            if (ini == null) {
                return default(T);
            }
            Elemento<T> aux = ini;
            ini = ini.Sig;
            return aux.Dato;
        }

        public int Count() {
            int cont = 0;
            Elemento<T> aux=ini;
            while (aux != null) {
                cont++;
                aux = aux.Sig;
            }
            return cont;
        }
        public void Clear() {
            ini = null;
        }

        public T Tope() {
            if (ini != null) {
                return ini.Dato;
            }
            return default(T);
        }

        public Boolean Empty() {
            if (ini == null) {
                return true;
            } else {
                return false;
            }
        }

    }
}
