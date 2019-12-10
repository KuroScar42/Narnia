using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narnia {
    public partial class JuegoForm : Form {
        private readonly int laberintoSize = 20;
        private readonly int casillaSize = 12;
        Nodo cabeza = null;
        Graphics tablero;
        Pen lapiz;
        Random randGen;

        Pila<Celda> camino;

        unsafe struct nodo {
            public int num;
            public nodo* sig;


            public nodo(int num, nodo* sig) {
                this.num = num;
                this.sig = sig;
            }
        }

        public JuegoForm() {
            InitializeComponent();
            tablero = pBoxTablero.CreateGraphics();
            lapiz = new Pen(Color.Black);
            camino = new Pila<Celda>();
            randGen = new Random();
            pBoxTablero.SizeChanged += PBoxTablero_SizeChanged;
            pBoxTablero.Size = new Size(laberintoSize * casillaSize + 1, laberintoSize * casillaSize + 1);
            this.Size = new Size(laberintoSize * casillaSize + 25, laberintoSize * casillaSize + 119);
            panel1.BackColor = Color.Aquamarine;


            //Iniciar();
        }

        //unsafe nodo* AgregarLista(nodo* ini, int numero) {
        //    if (ini == null) {
        //        ini = new nodo(5, null);
        //    }
        //    return null;
        //}

        private void PBoxTablero_SizeChanged(object sender, EventArgs e) {
            //button1.Location = new Point(pBoxTablero.Size.Width + 18, 12);
            //button2.Location = new Point(pBoxTablero.Size.Width + 18, 12);
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
            //Iniciar();
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
            return randGen.Next(1, max);
        }

        private void Iniciar() {
            camino.Clear();
            int fila = laberintoSize;
            int columna = laberintoSize;
            for (int i = 0;i < fila;i++) {
                for (int j = 0;j < columna;j++) {
                    setDato(i, j, CrearCelda((i * casillaSize), (j * casillaSize)));
                }
            }
            //for (int i = 0;i < laberintoSize;i++) {
            //    for (int j = 0;j < laberintoSize;j++) {
            //        Celda celda = CrearCelda((i * casillaSize), (j * casillaSize));
            //        int numX = i * casillaSize;
            //        int numY = j * casillaSize;
            //        mat[i, j] = celda;
            //        //dibujarParedes(celda);
            //    }
            //}
            Celda inicio = getDato(0,0);
            inicio.Visitada = true;
            camino.Push(inicio);
            CrearLaberinto();
            dibujarLaberinto();
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

        private Label CrearLabel(int x, int y, int i) {
            Label lbl1 = new Label {
                Text = "nel" + i,
                Location = new Point(x, y),
                ForeColor = Color.Blue,
                BackColor = Color.Transparent

            };
            lbl1.Click += (s, e) => {
                Console.WriteLine(s.ToString());
            };
            lbl1.AutoSize = true;
            return lbl1;
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
        }

        private void timer1_Tick(object sender, EventArgs e) {
            Console.WriteLine("nel");
        }

        private void button2_Click(object sender, EventArgs e) {
            tablero.Clear(Color.White);
            Celda celda = getDato(5, 4);
            Console.WriteLine(celda.PosX + " " + celda.PosY);
            pBoxTablero.Controls.Add(new Button());
        }

        public void CrearLaberinto() {
            while (camino.Count() > 0) {
                Celda actual = camino.Tope();
                bool valid = false;
                int checks = 0;
                while (!valid && checks < 10) {
                    checks++;
                    int direccion = GetRandNum(5);
                    switch (direccion) {
                        // Norte
                        case 1:
                            if ((actual.PosY / casillaSize) - 1 >= 0) {
                                //Celda siguiente = mat[actual.PosX / casillaSize, (actual.PosY / casillaSize) - 1];
                                Celda siguiente = getDato(actual.PosX / casillaSize, (actual.PosY / casillaSize) - 1);
                                if (!siguiente.Visitada) {
                                    siguiente.paredSur = false;
                                    actual.paredNorte = false;
                                    //mat[actual.PosX / casillaSize, actual.PosY / casillaSize - 1] = siguiente;
                                    //mat[actual.PosX / casillaSize, actual.PosY / casillaSize ] = actual;
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

        private void dibujarLaberinto() {
            tablero.Clear(Color.White);
            for (int i = 0;i < laberintoSize;i++) {
                for (int j = 0;j < laberintoSize;j++) {
                    dibujarParedes(getDato(i,j));
                }
            }
        }
    }
}
