﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Narnia {
    public partial class JuegoView : Form {
        private int contador = 0;
        private readonly int laberintoSize = 5;
        private readonly int casillaSize = 50;
        Graphics tablero;
        Pen lapiz;
        Celda[,] mat;
        Random randGen;

        Stack<Celda> camino;

        unsafe struct nodo {
            int num;
            nodo* sig;
            
            nodo(int num, nodo* sig) {
                this.num = num;
                this.sig = sig;
            }
        }


        public JuegoView() {
            InitializeComponent();
            tablero = pBoxTablero.CreateGraphics();
            lapiz = new Pen(Color.Black);
            mat = new Celda[laberintoSize, laberintoSize];
            camino = new Stack<Celda>();
            randGen = new Random();
            Llenar();
        }

        private void JuegoView_Load(object sender, EventArgs e) {
            Llenar();
        }

        private int GetRandNum(int max) {
            return randGen.Next(1, max);
        }

        private void Llenar() {
            camino.Clear();
            for (int i = 0;i < laberintoSize;i++) {
                for (int j = 0;j < laberintoSize;j++) {
                    Celda celda = CrearBoton((i * casillaSize), (j * casillaSize));
                    int numX = i * casillaSize;
                    int numY = j * casillaSize;
                    mat[i, j] = celda;
                    dibujarParedes(celda);
                    //tablero.DrawLine(lapiz, numX, numY, numX, numY + casillaSize); ya
                    //tablero.DrawLine(lapiz, numX, numY, numX + casillaSize, numY); ya 
                    //tablero.DrawLine(lapiz, numX + casillaSize, numY + casillaSize, numX + casillaSize, numY); ya 
                    //tablero.DrawLine(lapiz, numX + casillaSize, numY + casillaSize, numX , numY + casillaSize);
                    tablero.FillRectangle(new SolidBrush(Color.Black), 0, 0, 10, 10);
                    //pBoxTablero.Controls.Add(celda);
                }
            }
            Celda inicio = mat[0, 0];
            inicio.Visitada = true;
            camino.Push(inicio);
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

        private Celda CrearBoton(int x, int y) {
            //Button btn = new Button
            Celda btn = new Celda {
                PosX = x,
                PosY = y
            };

            return btn;
        }

        private void button1_Click_1(object sender, EventArgs e) {
            //tablero.FillRectangle(new SolidBrush(Color.Black), 0, 0, 10, 10);
            Llenar();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            Console.WriteLine("nel");
        }

        private void button2_Click(object sender, EventArgs e) {
            Laberinto();
            tablero.Clear(Color.White);
            for (int i = 0;i < laberintoSize;i++) {
                for (int j = 0;j < laberintoSize;j++) {
                    dibujarParedes(mat[i, j]);
                }
            }
        }

        public void Laberinto() {
            
            while (camino.Count > 0) {
                Celda actual = camino.Peek();
                bool valid = false;
                int checks = 0;
                while(!valid && checks < 10) {
                    checks++;
                    int direccion = GetRandNum(5);
                    switch (direccion) {
                        // Norte
                        case 1:
                            if ((actual.PosY / casillaSize) - 1 >= 0) {
                                Celda siguiente = mat[actual.PosX / casillaSize, (actual.PosY / casillaSize) - 1];
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
                                Celda siguiente = mat[(actual.PosX / casillaSize) + 1, actual.PosY / casillaSize];
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
                                Celda siguiente = mat[(actual.PosX / casillaSize) - 1, actual.PosY / casillaSize];
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
                                Celda siguiente = mat[actual.PosX / casillaSize, (actual.PosY / casillaSize) + 1];
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
    }
}
