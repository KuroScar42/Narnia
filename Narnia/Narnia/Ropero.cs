using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narnia {
    class Ropero : Personaje{
        // declarar cola de ratones
        private Cola<Raton> ratones;
        private List<string> nombres;

        public Ropero() {
            ratones = new Cola<Raton>();
            nombres = new List<string>();
            nombres.Add("Azgalor");
            nombres.Add("Burial");
            nombres.Add("Brood");
            nombres.Add("Calis");
            nombres.Add("CopyCat");
            nombres.Add("Dalar");
            nombres.Add("Darkness");
            nombres.Add("Dorin");
            nombres.Add("Eternity");
            nombres.Add("Exodial");
            nombres.Add("Furion");
            nombres.Add("Gradius");
            nombres.Add("Griggle");
            nombres.Add("Hancock");
            nombres.Add("Jake");
            nombres.Add("Kazil");
            nombres.Add("Lizzard");
            nombres.Add("Mylus");
            nombres.Add("Necros");
            nombres.Add("Nilas");
            nombres.Add("Raven");
            nombres.Add("Ryuran");
            nombres.Add("Stonebull");
            nombres.Add("Tojara");
            nombres.Add("Umi");
            nombres.Add("Volkano");
            nombres.Add("Zain");
        }

        public Ropero(int numRatones, int casillaSize) :this() {
            Random r = new Random();
            int num = 0;
            for (int i = 0;i < numRatones;i++) {
                num = r.Next(0, nombres.Count);
                string nombre = nombres[num];
                ratones.Push(new Raton(nombre,casillaSize, this.Location));
                nombres.RemoveAt(num);
                Console.WriteLine(nombre + " " + nombres.Count);
            }
        }

        public Raton SacarRaton() {
            return this.ratones.Pop();
        }

        public bool IsEmpty() {
            return ratones.Count() > 0;
        }
    }
}
