using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    class Nodo{
        private Nodo sig;
        private Fila fila;

        public Nodo(Nodo sig,Fila fila)
        {
            this.sig = sig;
            this.fila = fila;
        }

        public Nodo llenarColumna(Nodo cabeza, Fila fila)
        {
            Nodo aux;
            aux = cabeza;

            if (cabeza == null)
            {
                cabeza = new Nodo(null, fila);
            }
            else
            {
                while (aux.sig != null)
                {
                    aux = aux.sig;
                }
                aux.sig = new Nodo(null, fila);

            }
            return cabeza;
        }

        public Nodo asignarNodo(Nodo cabeza,Fila ini)
        {
            Nodo aux = cabeza;

            if (cabeza == null)
            {
                Console.WriteLine("No hay lista");
            }
            else
            {
                while (aux.sig != null)
                {
                    aux = aux.sig;
                }

                aux.fila=ini;
            }
            return cabeza;
        }
    }
}
