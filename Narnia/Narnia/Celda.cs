﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narnia {
    class Celda {
        // los siguientes 4 parametros son utilizados para identificar en cada
        // celda cuales de la paredes se van a utilizar para formar el laberinto
        // como tal
        public Boolean paredNorte;
        public Boolean paredEste;
        public Boolean paredOeste;
        public Boolean paredSur;
        // este parametro será utilizado para hacer el recorrido del laberinto
        // y asi formarlo
        private Boolean visitada;
        // posicion de la celda en referencia al layout
        private int posX;
        private int posY;

        private Personaje personaje;
        private Raton raton;
        private Boolean salida;

        public Celda() {
            paredNorte = true;
            paredEste = true;
            paredOeste = true;
            paredSur = true;
            visitada = false;
            Salida = false;
        }
        public Celda(int x, int y) :this(){
            //paredNorte = true;
            //paredEste = true;
            //paredOeste = true;
            //paredSur = true;
            //visitada = false;
            this.PosX = x;
            this.PosY = y;
        }

        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }

        public Boolean Visitada { get => visitada; set => visitada = value; }
        public bool Salida { get => salida; set => salida = value; }
        internal Personaje Personaje { get => personaje; set => personaje = value; }
        internal Raton Raton { get => raton; set => raton = value; }
    }
}
