using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narnia {
    public partial class JuegoForm : Form {
        private readonly int laberintoSize = 15;
        private readonly int casillaSize = 45;
        private readonly int lapizWidth = 5;
        private Nodo cabeza = null;
        // variables para dibujar
        private Graphics tablero;
        private Pen lapiz;
        private Random randGen;
        private Pila<Celda> camino; // es para crear el camino dentro del laberinto

        private Bruja bruja;
        private Ropero ropero;
        private Leon leon;
        private Boolean isPause = false;
        List<Raton> ratonera;

        public JuegoForm() {
            InitializeComponent();
            // se inicializan variables
            tablero = pBoxTablero.CreateGraphics();
            lapiz = new Pen(Color.FromKnownColor(KnownColor.YellowGreen));
            lapiz.Width = lapizWidth;
            camino = new Pila<Celda>();
            randGen = new Random();
            bruja = new Bruja();
            ropero = new Ropero((laberintoSize / 2) + 1, casillaSize - 10);
            leon = new Leon();
            ratonera = new List<Raton>();
            RoperoTimer.Interval = (((laberintoSize * laberintoSize) * 1000) / 60) + 5000;
            // se añaden algunas caractristicas
            pBoxTablero.SizeChanged += PBoxTablero_SizeChanged;
            pBoxTablero.Size = new Size(laberintoSize * casillaSize, laberintoSize * casillaSize + 1);
            this.Size = new Size(laberintoSize * casillaSize + 144, laberintoSize * casillaSize + 65);


            panel1.BackColor = Color.Transparent;
        }

        private void PBoxTablero_SizeChanged(object sender, EventArgs e) {
            button1.Location = new Point(pBoxTablero.Size.Width + 18, 12);
            button2.Location = new Point(pBoxTablero.Size.Width + 18, 35);
        }

        private void JuegoView_Load(object sender, EventArgs e) {
            for (int i = 0;i < laberintoSize;i++) {
                Fila ini = new Fila();
                for (int j = 0;j < laberintoSize;j++) {
                    ini = ini.llenarFila(ini, new Celda());
                }
                ini = ini.Sig;
                cabeza = llenarNodo(cabeza, ini);
            }
        }

        private Nodo llenarNodo(Nodo cabeza, Fila fila) {
            Nodo aux;
            aux = cabeza;

            if (cabeza == null) {
                cabeza = new Nodo(null, fila);
            } else {
                while (aux.Sig != null) {
                    aux = aux.Sig;
                }
                aux.Sig = new Nodo(null, fila);

            }
            return cabeza;
        }

        private Nodo asignarNodo(Nodo cabeza, Fila ini) {
            Nodo aux = cabeza;

            if (cabeza == null) {
                Console.WriteLine("No hay lista");
            } else {
                while (aux.Sig != null) {
                    aux = aux.Sig;
                }

                aux.Fila = ini;
            }
            return cabeza;
        }

        private void setDato(int fila, int columna, Celda celda) {
            Nodo aux = cabeza;
            int f = 0, c = 0;
            while (aux != null) {
                Fila filaC = aux.Fila;
                c = 0;
                while (filaC != null) {
                    if (f == fila && c == columna) {
                        filaC.Celda = celda;
                    }
                    c++;
                    filaC = filaC.Sig;
                }
                f++;
                aux = aux.Sig;
            }
        }


        private void imprimirLista() {
            Nodo aux = cabeza;
            while (aux != null) {
                Fila aux2 = aux.Fila;
                while (aux2 != null) {
                    Console.WriteLine(" " + aux2.Celda.PosX + " " + aux2.Celda.PosY);
                    aux2 = aux2.Sig;
                }
                Console.WriteLine("");
                Console.WriteLine("");
                aux = aux.Sig;
            }
        }

        private Celda getDato(int fila, int columna) {
            Nodo aux = cabeza;
            int f = 0, c = 0;
            while (aux != null) {
                Fila filaC = aux.Fila;
                c = 0;
                while (filaC != null) {
                    if (f == fila && c == columna) {
                        return filaC.Celda;
                    }
                    c++;
                    filaC = filaC.Sig;
                }
                f++;
                aux = aux.Sig;
            }
            return null;
        }

        private int GetRandNum(int max) {
            return randGen.Next(1, max + 1);
        }

        private void Iniciar() {
            camino.Clear();
            int fila = laberintoSize;
            int columna = laberintoSize;
            pBoxTablero.Controls.Clear();
            for (int i = 0;i < fila;i++) {
                for (int j = 0;j < columna;j++) {
                    setDato(i, j, CrearCelda((i * casillaSize), (j * casillaSize)));
                }
            }
            Celda inicio = getDato(0,0);
            inicio.Visitada = true;
            isPause = false;
            camino.Push(inicio);
            CrearLaberinto();
            DibujarLaberinto();
        }

        private void dibujarParedes(Celda celda) {
            if (celda.paredOeste) {
                tablero.DrawLine(lapiz, celda.PosX, celda.PosY, celda.PosX, celda.PosY + casillaSize);
            }
            if (celda.paredNorte) {
                tablero.DrawLine(lapiz, celda.PosX, celda.PosY, celda.PosX + casillaSize, celda.PosY);
            }
            if (celda.paredEste) {
                tablero.DrawLine(lapiz, celda.PosX + casillaSize, celda.PosY + casillaSize, celda.PosX + casillaSize, celda.PosY);
            }
            if (celda.paredSur) {
                tablero.DrawLine(lapiz, celda.PosX + casillaSize, celda.PosY + casillaSize, celda.PosX, celda.PosY + casillaSize);
            }


        }
        private void AjustarTamano(int tamano, int laberSize) {
            this.Size = new Size(tamano * laberSize, tamano * laberSize);
        }

        private Celda CrearCelda(int x, int y) {
            Celda btn = new Celda {
                PosX = x,
                PosY = y
            };

            return btn;
        }

        private void button1_Click_1(object sender, EventArgs e) {
            Iniciar();
            AgregarPersonajes();
            MoverPersonaje(bruja, 0, 0);
            MoverPersonaje(leon, laberintoSize - 1 , laberintoSize - 1);
            int mitad = laberintoSize / 2;
            MoverPersonaje(ropero, mitad, mitad);
            this.Focus();
            BrujaTimer.Start();
            RoperoTimer.Start();
            button1.Enabled = false;
            button2.Enabled = false;
        }


        

        private void button2_Click(object sender, EventArgs e) {
            //tablero.Clear(Color.White);
        }

        public void CrearLaberinto() {
            while (camino.Count() > 0) {
                Celda actual = camino.Tope();
                bool valid = false;
                int checks = 0;
                while (!valid && checks < 10) {
                    checks++;
                    int direccion = GetRandNum(4);
                    switch (direccion) {
                        // Norte
                        case 1:
                            if ((actual.PosY / casillaSize) - 1 >= 0) {
                                Celda siguiente = getDato(actual.PosX / casillaSize, (actual.PosY / casillaSize) - 1);
                                if (!siguiente.Visitada) {
                                    siguiente.paredSur = false;
                                    actual.paredNorte = false;
                                    siguiente.Visitada = true;
                                    camino.Push(siguiente);
                                    valid = true;
                                }
                            }
                            break;
                        // Este   
                        case 2:
                            if ((actual.PosX / casillaSize) + 1 < (laberintoSize)) {
                                Celda siguiente = getDato((actual.PosX / casillaSize) + 1, actual.PosY / casillaSize);
                                if (!siguiente.Visitada) {
                                    siguiente.paredOeste = false;
                                    actual.paredEste = false;
                                    siguiente.Visitada = true;
                                    camino.Push(siguiente);
                                    valid = true;
                                }
                            }
                            break;
                        // Oeste
                        case 3:
                            if ((actual.PosX / casillaSize) - 1 >= 0) {
                                Celda siguiente = getDato((actual.PosX / casillaSize) - 1, actual.PosY / casillaSize);
                                if (!siguiente.Visitada) {
                                    siguiente.paredEste = false;
                                    actual.paredOeste = false;
                                    siguiente.Visitada = true;
                                    camino.Push(siguiente);
                                    valid = true;
                                }
                            }
                            break;
                        // Sur
                        case 4:
                            if ((actual.PosY / casillaSize) + 1 < (laberintoSize)) {
                                Celda siguiente = getDato(actual.PosX / casillaSize, (actual.PosY / casillaSize) + 1);
                                if (!siguiente.Visitada) {
                                    siguiente.paredNorte = false;
                                    actual.paredSur = false;
                                    siguiente.Visitada = true;
                                    camino.Push(siguiente);
                                    valid = true;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (!valid) {
                    camino.Pop();
                }
            }
        }

        private void DibujarLaberinto() {
            pBoxTablero.Refresh();
            for (int i = 0;i < laberintoSize;i++) {
                for (int j = 0;j < laberintoSize;j++) {
                    dibujarParedes(getDato(i,j));
                }
            }
            
        }

        private void AgregarPersonajes() {
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string nombreArchivo;
            nombreArchivo = Path.Combine(dir, @"..\..\Resources\witch.png");
            bruja.Image = Image.FromFile(nombreArchivo);
            bruja.SizeMode = PictureBoxSizeMode.StretchImage;
            bruja.Size = new Size(casillaSize - 10, casillaSize - 10);
            bruja.Location = new Point(5, 5);
            pBoxTablero.Controls.Add(bruja);
            nombreArchivo = Path.Combine(dir, @"..\..\Resources\lion.png");
            leon.Image = Image.FromFile(nombreArchivo);
            leon.Size = new Size(casillaSize - 10, casillaSize - 10);
            leon.SizeMode = PictureBoxSizeMode.StretchImage;
            leon.Location = new Point(5, 5);
            pBoxTablero.Controls.Add(leon);
            nombreArchivo = Path.Combine(dir, @"..\..\Resources\closet.png");
            ropero.Image = Image.FromFile(nombreArchivo);
            ropero.Size = new Size(casillaSize - 10, casillaSize - 10);
            ropero.SizeMode = PictureBoxSizeMode.StretchImage;
            ropero.Location = new Point(5, 5);
            pBoxTablero.Controls.Add(ropero);
        }

        private void MoverPersonaje(Personaje personaje, int x, int y) {
            Celda celda = getDato(x, y);
            if (personaje is Bruja) {
                if (!(celda.Personaje is Leon)) {
                    int posX = (personaje.PosX - 5) / casillaSize;
                    int posY = (personaje.PosY - 5) / casillaSize;
                    Celda c = getDato(posX, posY);
                    c.Personaje = null;
                    personaje.PosX = (x * casillaSize) + 5;
                    personaje.PosY = (y * casillaSize) + 5;
                    personaje.Dibujar();
                    celda.Personaje = personaje;
                }
            }else if (personaje is Leon) {
                if (!(celda.Personaje is Bruja)) {
                    int posX = (personaje.PosX - 5) / casillaSize;
                    int posY = (personaje.PosY - 5) / casillaSize;
                    Celda c = getDato(posX, posY);
                    c.Personaje = null;
                    personaje.PosX = (x * casillaSize) + 5;
                    personaje.PosY = (y * casillaSize) + 5;
                    personaje.Dibujar();
                    celda.Personaje = personaje;
                }
            } else if(personaje is Ropero){
                personaje.PosX = (x * casillaSize) + 5;
                personaje.PosY = (y * casillaSize) + 5;
                personaje.Dibujar();
            } else if (personaje is Raton) {
                if (!(celda.Personaje is Bruja) && !(celda.Personaje is Leon) && !(celda.Personaje is Raton)) {
                    int posX = (personaje.PosX - 5) / casillaSize;
                    int posY = (personaje.PosY - 5) / casillaSize;
                    Celda c = getDato(posX, posY);
                    c.Personaje = null;
                    personaje.PosX = (x * casillaSize) + 5;
                    personaje.PosY = (y * casillaSize) + 5;
                    personaje.Dibujar();
                    celda.Personaje = personaje;
                }
            }

        }

        private void avanzar(Personaje personaje,int direction) {
            int x = (personaje.PosX - 5) / casillaSize;
            int y = (personaje.PosY - 5) / casillaSize;
            Celda celda = getDato(x,y);
            if (celda != null) {
                switch (direction) {
                    //Norte
                    case 1:
                        if (!celda.paredNorte) {
                            MoverPersonaje(personaje, x, y - 1);
                        }
                        break;
                    //Este
                    case 2:
                        if (!celda.paredEste) {
                            MoverPersonaje(personaje, x + 1, y);
                        }
                        break;
                    //Oeste
                    case 3:
                        if (!celda.paredOeste) {
                            MoverPersonaje(personaje, x - 1, y);
                        }
                        break;
                    //Sur
                    case 4:
                        if (!celda.paredSur) {
                            MoverPersonaje(personaje, x, y + 1);
                        }
                        break;
                    default:
                        break;

                }
            }
            
        }

        private void PausarJuego(Boolean pausa) {
            if (pausa) {
                BrujaTimer.Stop();
                RoperoTimer.Stop();
                foreach (Raton raton in ratonera) {
                    raton.Movimiento.Stop();
                }
                
            } else {
                BrujaTimer.Start();
                RoperoTimer.Start();
                Timer t = new Timer();
                float num = (2f / (float)ratonera.Count);
                t.Interval = Convert.ToInt32( num * 1000f);
                foreach (Raton raton in ratonera) {
                    t.Tick += (a, b)=>{
                        raton.Movimiento.Start();
                    };
                    
                }
                t.Start();
            }
            button1.Enabled = pausa;
            button2.Enabled = pausa;
        }


        private void DetectarTecla(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.P) {
                isPause = !isPause;
                PausarJuego(isPause);
            }
            if (!isPause) {
                if (e.KeyData == Keys.Up) {
                    avanzar(leon, 1);
                } else if (e.KeyData == Keys.Right) {
                    avanzar(leon, 2);
                } else if (e.KeyData == Keys.Left) {
                    avanzar(leon, 3);
                } else if (e.KeyData == Keys.Down) {
                    avanzar(leon, 4);
                }
            }
        }
        private void BrujaMovement(object sender, EventArgs e) {
            moverAleatorio(bruja);
        }

        void moverAleatorio(Personaje personaje) {
            List<int> lados = new List<int>();
            int x = (personaje.PosX - 5) / casillaSize;
            int y = (personaje.PosY - 5) / casillaSize;
            Celda celda = getDato(x, y);
            if (!celda.paredNorte)
                lados.Add(1);
            if (!celda.paredEste)
                lados.Add(2);
            if (!celda.paredOeste)
                lados.Add(3);
            if (!celda.paredSur)
                lados.Add(4);

            int dir = GetRandNum(lados.Count());
            avanzar(personaje, lados[dir - 1]);
        }

        private void RoperoAction(object sender, EventArgs e) {
            if (ropero.IsEmpty()) {
                List<int> lados = new List<int>();
                int x = (ropero.PosX - 5) / casillaSize;
                int y = (ropero.PosY - 5) / casillaSize;
                Celda celda = getDato(x, y);
                if (!celda.paredNorte)
                    lados.Add(1);
                if (!celda.paredEste)
                    lados.Add(2);
                if (!celda.paredOeste)
                    lados.Add(3);
                if (!celda.paredSur)
                    lados.Add(4);

                int dir = GetRandNum(lados.Count());
                Raton raton = ropero.SacarRaton();
                raton.Movimiento.Tick += (s, ev) =>{
                    moverAleatorio(raton);
                };
                
                switch (lados[dir - 1]) {
                    //Norte
                    case 1:
                        pBoxTablero.Controls.Add(raton);
                        MoverPersonaje(raton, x, y - 1);
                        break;
                    //Este
                    case 2:
                        pBoxTablero.Controls.Add(raton);
                        MoverPersonaje(raton, x + 1, y);
                        break;
                    //Oeste
                    case 3:
                        pBoxTablero.Controls.Add(raton);
                        MoverPersonaje(raton, x - 1, y);
                        break;
                    //Sur
                    case 4:
                        pBoxTablero.Controls.Add(raton);
                        MoverPersonaje(raton, x, y + 1);
                        break;
                    default:
                        break;

                }
                ratonera.Add(raton);
                raton.Movimiento.Start();
            }
        }

    }
}
