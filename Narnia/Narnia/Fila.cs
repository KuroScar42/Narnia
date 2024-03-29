﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia
{
    class Fila
    {
        private Fila sig=null;
        private Celda celda;

            internal Fila Sig { get => sig; set => sig = value; }
            internal Celda Celda { get => celda; set => celda = value; }

        public Fila(Fila sig, Celda celda)
        {
            this.sig = sig;
            this.celda = celda;
        }
        public Fila()
        {

        }

        public Fila llenarFila(Fila cabeza, Celda celda)
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

