using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia {
    class Raton : Personaje{
        private string nombre;
        private Boolean estatua;

        public Raton(String nombre) {
            this.nombre = nombre;
            this.estatua = false;
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool Estatua { get => estatua; set => estatua = value; }
    }
}
