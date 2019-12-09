using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    class Nodo{
        private Nodo sig;
        private Celda celda;

        public Nodo(Nodo sig,Celda celda)
        {
            this.sig = sig;
            this.celda = celda;
        }

        public Fila llenarColumna(Fila cabeza, Celda celda)
        {
            Fila aux;
            aux = cabeza;

            if (cabeza == null)
            {
                cabeza = new Fila(null, celda);
            }
            else
            {
                while (aux.sig != null)
                {
                    aux = aux.sig;
                }
                aux.sig = new Fila(null, celda);

            }
            return cabeza;
        }
    }
}
