using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia {
    class Bruja : Personaje{
        //pila para los ratones que se van congelando
        private Pila<Raton> ratonesCongelados;


        public Bruja() {
            RatonesCongelados = new Pila<Raton>();
        }

        internal Pila<Raton> RatonesCongelados { get => ratonesCongelados; set => ratonesCongelados = value; }

        public void removerRaton(String nombre) {
            Pila<Raton> auxiliar = new Pila<Raton>();
            if (RatonesCongelados.Count() > 0) {
                while (RatonesCongelados.Tope().Nombre != nombre) {
                    auxiliar.Push(ratonesCongelados.Pop());
                }
                ratonesCongelados.Pop();
                while (auxiliar.Tope() != null) {
                    RatonesCongelados.Push(auxiliar.Pop());
                }
            }
        }
    }
}
