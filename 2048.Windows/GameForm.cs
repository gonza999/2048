using _2048.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048.Windows
{
    public partial class GameForm : Form
    {
        Casilla[,] casillas = new Casilla[4, 4];
        PictureBox[,] tablero = new PictureBox[4, 4];
        int posY = 0;
        int posX = 0;
        Random random = new Random();
        int y = 0;
        int x = 0;
        public GameForm()
        {
            InitializeComponent();
        }

        public void CrearTablero()
        {
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    PictureBox pbx = new PictureBox();
                    pbx.Size = new Size(100, 100);
                    pbx.BackColor = Color.White;
                    pbx.BorderStyle = BorderStyle.Fixed3D;
                    pbx.SizeMode = PictureBoxSizeMode.StretchImage;
                    Casilla casilla = new Casilla();
                    casilla.Imagen = null;
                    casilla.Valor = 0;
                    pbx.Tag = casilla;
                    tablero[f, c] = pbx;
                }
            }

            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    tablero[f, c].Location = new Point(posX, posY);
                    panel1.Controls.Add(tablero[f, c]);
                    posX += 100;
                }
                posY += 100;
                posX = 0;
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            CrearTablero();
            AparecerRandom();
        }

        private void AparecerRandom()
        {
            x = random.Next(0, 4);
            y = random.Next(0, 4);
            Casilla casilla = (Casilla)tablero[x, y].Tag;
            if (casilla.Valor == 0)
            {
                casilla.Valor = 2;
                casilla.Imagen = Properties.Resources._0;
                tablero[x, y].Image = casilla.Imagen;
            }
            else
            {
                AparecerRandom();
            }
        }
        int sinMovimiento = 0;

        private void IsKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int f = 0; f < tablero.GetLength(0); f++)
                    {
                        for (int c = 0; c < tablero.GetLength(1); c++)
                        {
                            Casilla casilla = (Casilla)tablero[f, c].Tag;
                            if (casilla.Valor != 0)
                            {
                                if (f != 0)
                                {
                                    sinMovimiento++;
                                    if (((Casilla)tablero[f - 1, c].Tag).Valor == 0)
                                    {
                                        Casilla cambio = (Casilla)tablero[f - 1, c].Tag;
                                        tablero[f - 1, c].Tag = tablero[f, c].Tag;
                                        tablero[f, c].Tag = cambio;

                                    }
                                    else if (((Casilla)tablero[f - 1, c].Tag).Valor == casilla.Valor)
                                    {
                                        if (casilla.Valor == 2)
                                        {
                                            tablero[f - 1, c].Tag = new Casilla
                                            {
                                                Valor = 4,
                                                Imagen = Properties.Resources._1
                                            };
                                        }
                                        else if (casilla.Valor == 4)
                                        {
                                            tablero[f - 1, c].Tag = new Casilla
                                            {
                                                Valor = 8,
                                                Imagen = Properties.Resources._2
                                            };
                                        }
                                        else if (casilla.Valor == 8)
                                        {
                                            tablero[f - 1, c].Tag = new Casilla
                                            {
                                                Valor = 16,
                                                Imagen = Properties.Resources._3
                                            };
                                        }
                                        else if (casilla.Valor == 16)
                                        {
                                            tablero[f - 1, c].Tag = new Casilla
                                            {
                                                Valor = 32,
                                                Imagen = Properties.Resources._4
                                            };
                                        }
                                        else if (casilla.Valor == 32)
                                        {
                                            tablero[f - 1, c].Tag = new Casilla
                                            {
                                                Valor = 64,
                                                Imagen = Properties.Resources._5
                                            };
                                        }
                                        else if (casilla.Valor == 64)
                                        {
                                            tablero[f - 1, c].Tag = new Casilla
                                            {
                                                Valor = 128,
                                                Imagen = Properties.Resources._6
                                            };
                                        }
                                        else if (casilla.Valor == 128)
                                        {
                                            tablero[f - 1, c].Tag = new Casilla
                                            {
                                                Valor = 256,
                                                Imagen = Properties.Resources._7
                                            };
                                        }
                                        else if (casilla.Valor == 256)
                                        {
                                            tablero[f - 1, c].Tag = new Casilla
                                            {
                                                Valor = 512,
                                                Imagen = Properties.Resources._8
                                            };
                                        }
                                        else if (casilla.Valor == 512)
                                        {
                                            tablero[f - 1, c].Tag = new Casilla
                                            {
                                                Valor = 1024,
                                                Imagen = Properties.Resources._9
                                            };
                                        }
                                        else if (casilla.Valor == 1024)
                                        {
                                            tablero[f - 1, c].Tag = new Casilla
                                            {
                                                Valor = 2048,
                                                Imagen = Properties.Resources._10
                                            };
                                            Ganaste();
                                        }


                                        tablero[f, c].Tag = new Casilla
                                        {
                                            Valor = 0,
                                            Imagen = null
                                        };
                                    }
                                }
                            }
                        }
                    }
                }
                if (sinMovimiento != 0)
                {
                    AparecerRandom();
                }
                sinMovimiento = 0;
            }
            if (e.KeyCode == Keys.Down)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int f = 0; f < tablero.GetLength(0); f++)
                    {
                        for (int c = 0; c < tablero.GetLength(1); c++)
                        {
                            Casilla casilla = (Casilla)tablero[f, c].Tag;
                            if (casilla.Valor != 0)
                            {
                                if (f != 3)
                                {
                                    sinMovimiento++;
                                    if (((Casilla)tablero[f + 1, c].Tag).Valor == 0)
                                    {
                                        Casilla cambio = (Casilla)tablero[f + 1, c].Tag;
                                        tablero[f + 1, c].Tag = tablero[f, c].Tag;
                                        tablero[f, c].Tag = cambio;

                                    }
                                    else if (((Casilla)tablero[f + 1, c].Tag).Valor == casilla.Valor)
                                    {
                                        if (casilla.Valor == 2)
                                        {
                                            tablero[f + 1, c].Tag = new Casilla
                                            {
                                                Valor = 4,
                                                Imagen = Properties.Resources._1
                                            };
                                        }
                                        else if (casilla.Valor == 4)
                                        {
                                            tablero[f + 1, c].Tag = new Casilla
                                            {
                                                Valor = 8,
                                                Imagen = Properties.Resources._2
                                            };
                                        }
                                        else if (casilla.Valor == 8)
                                        {
                                            tablero[f + 1, c].Tag = new Casilla
                                            {
                                                Valor = 16,
                                                Imagen = Properties.Resources._3
                                            };
                                        }
                                        else if (casilla.Valor == 16)
                                        {
                                            tablero[f - 1, c].Tag = new Casilla
                                            {
                                                Valor = 32,
                                                Imagen = Properties.Resources._4
                                            };
                                        }
                                        else if (casilla.Valor == 32)
                                        {
                                            tablero[f + 1, c].Tag = new Casilla
                                            {
                                                Valor = 64,
                                                Imagen = Properties.Resources._5
                                            };
                                        }
                                        else if (casilla.Valor == 64)
                                        {
                                            tablero[f + 1, c].Tag = new Casilla
                                            {
                                                Valor = 128,
                                                Imagen = Properties.Resources._6
                                            };
                                        }
                                        else if (casilla.Valor == 128)
                                        {
                                            tablero[f + 1, c].Tag = new Casilla
                                            {
                                                Valor = 256,
                                                Imagen = Properties.Resources._7
                                            };
                                        }
                                        else if (casilla.Valor == 256)
                                        {
                                            tablero[f + 1, c].Tag = new Casilla
                                            {
                                                Valor = 512,
                                                Imagen = Properties.Resources._8
                                            };
                                        }
                                        else if (casilla.Valor == 512)
                                        {
                                            tablero[f + 1, c].Tag = new Casilla
                                            {
                                                Valor = 1024,
                                                Imagen = Properties.Resources._9
                                            };
                                        }
                                        else if (casilla.Valor == 1024)
                                        {
                                            tablero[f + 1, c].Tag = new Casilla
                                            {
                                                Valor = 2048,
                                                Imagen = Properties.Resources._10
                                            };
                                            Ganaste();
                                        }


                                        tablero[f, c].Tag = new Casilla
                                        {
                                            Valor = 0,
                                            Imagen = null
                                        };
                                    }
                                }
                            }
                        }
                    }
                }
                if (sinMovimiento != 0)
                {
                    AparecerRandom();
                }
                sinMovimiento = 0;
            }
            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int f = 0; f < tablero.GetLength(0); f++)
                    {
                        for (int c = 0; c < tablero.GetLength(1); c++)
                        {
                            Casilla casilla = (Casilla)tablero[f, c].Tag;
                            if (casilla.Valor != 0)
                            {
                                if (c != 3)
                                {
                                    sinMovimiento++;
                                    if (((Casilla)tablero[f, c + 1].Tag).Valor == 0)
                                    {
                                        Casilla cambio = (Casilla)tablero[f, c + 1].Tag;
                                        tablero[f, c + 1].Tag = tablero[f, c].Tag;
                                        tablero[f, c].Tag = cambio;

                                    }
                                    else if (((Casilla)tablero[f, c + 1].Tag).Valor == casilla.Valor)
                                    {
                                        if (casilla.Valor == 2)
                                        {
                                            tablero[f, c + 1].Tag = new Casilla
                                            {
                                                Valor = 4,
                                                Imagen = Properties.Resources._1
                                            };
                                        }
                                        else if (casilla.Valor == 4)
                                        {
                                            tablero[f, c + 1].Tag = new Casilla
                                            {
                                                Valor = 8,
                                                Imagen = Properties.Resources._2
                                            };
                                        }
                                        else if (casilla.Valor == 8)
                                        {
                                            tablero[f, c + 1].Tag = new Casilla
                                            {
                                                Valor = 16,
                                                Imagen = Properties.Resources._3
                                            };
                                        }
                                        else if (casilla.Valor == 16)
                                        {
                                            tablero[f, c + 1].Tag = new Casilla
                                            {
                                                Valor = 32,
                                                Imagen = Properties.Resources._4
                                            };
                                        }
                                        else if (casilla.Valor == 32)
                                        {
                                            tablero[f, c + 1].Tag = new Casilla
                                            {
                                                Valor = 64,
                                                Imagen = Properties.Resources._5
                                            };
                                        }
                                        else if (casilla.Valor == 64)
                                        {
                                            tablero[f, c + 1].Tag = new Casilla
                                            {
                                                Valor = 128,
                                                Imagen = Properties.Resources._6
                                            };
                                        }
                                        else if (casilla.Valor == 128)
                                        {
                                            tablero[f, c + 1].Tag = new Casilla
                                            {
                                                Valor = 256,
                                                Imagen = Properties.Resources._7
                                            };
                                        }
                                        else if (casilla.Valor == 256)
                                        {
                                            tablero[f, c + 1].Tag = new Casilla
                                            {
                                                Valor = 512,
                                                Imagen = Properties.Resources._8
                                            };
                                        }
                                        else if (casilla.Valor == 512)
                                        {
                                            tablero[f, c + 1].Tag = new Casilla
                                            {
                                                Valor = 1024,
                                                Imagen = Properties.Resources._9
                                            };
                                        }
                                        else if (casilla.Valor == 1024)
                                        {
                                            tablero[f, c + 1].Tag = new Casilla
                                            {
                                                Valor = 2048,
                                                Imagen = Properties.Resources._10
                                            };
                                            Ganaste();
                                        }


                                        tablero[f, c].Tag = new Casilla
                                        {
                                            Valor = 0,
                                            Imagen = null
                                        };
                                    }
                                }
                            }
                        }
                    }
                }
                if (sinMovimiento != 0)
                {
                    AparecerRandom();
                }
                sinMovimiento = 0;
            }
            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int f = 0; f < tablero.GetLength(0); f++)
                    {
                        for (int c = 0; c < tablero.GetLength(1); c++)
                        {
                            Casilla casilla = (Casilla)tablero[f, c].Tag;
                            if (casilla.Valor != 0)
                            {
                                if (c != 0)
                                {
                                    sinMovimiento++;
                                    if (((Casilla)tablero[f, c - 1].Tag).Valor == 0)
                                    {
                                        Casilla cambio = (Casilla)tablero[f, c - 1].Tag;
                                        tablero[f, c - 1].Tag = tablero[f, c].Tag;
                                        tablero[f, c].Tag = cambio;

                                    }
                                    else if (((Casilla)tablero[f, c - 1].Tag).Valor == casilla.Valor)
                                    {
                                        if (casilla.Valor == 2)
                                        {
                                            tablero[f, c - 1].Tag = new Casilla
                                            {
                                                Valor = 4,
                                                Imagen = Properties.Resources._1
                                            };
                                        }
                                        else if (casilla.Valor == 4)
                                        {
                                            tablero[f, c - 1].Tag = new Casilla
                                            {
                                                Valor = 8,
                                                Imagen = Properties.Resources._2
                                            };
                                        }
                                        else if (casilla.Valor == 8)
                                        {
                                            tablero[f, c - 1].Tag = new Casilla
                                            {
                                                Valor = 16,
                                                Imagen = Properties.Resources._3
                                            };
                                        }
                                        else if (casilla.Valor == 16)
                                        {
                                            tablero[f, c - 1].Tag = new Casilla
                                            {
                                                Valor = 32,
                                                Imagen = Properties.Resources._4
                                            };
                                        }
                                        else if (casilla.Valor == 32)
                                        {
                                            tablero[f, c - 1].Tag = new Casilla
                                            {
                                                Valor = 64,
                                                Imagen = Properties.Resources._5
                                            };
                                        }
                                        else if (casilla.Valor == 64)
                                        {
                                            tablero[f, c - 1].Tag = new Casilla
                                            {
                                                Valor = 128,
                                                Imagen = Properties.Resources._6
                                            };
                                        }
                                        else if (casilla.Valor == 128)
                                        {
                                            tablero[f, c - 1].Tag = new Casilla
                                            {
                                                Valor = 256,
                                                Imagen = Properties.Resources._7
                                            };
                                        }
                                        else if (casilla.Valor == 256)
                                        {
                                            tablero[f, c - 1].Tag = new Casilla
                                            {
                                                Valor = 512,
                                                Imagen = Properties.Resources._8
                                            };
                                        }
                                        else if (casilla.Valor == 512)
                                        {
                                            tablero[f, c - 1].Tag = new Casilla
                                            {
                                                Valor = 1024,
                                                Imagen = Properties.Resources._9
                                            };
                                        }
                                        else if (casilla.Valor == 1024)
                                        {
                                            tablero[f, c - 1].Tag = new Casilla
                                            {
                                                Valor = 2048,
                                                Imagen = Properties.Resources._10
                                            };
                                            Ganaste();
                                        }


                                        tablero[f, c].Tag = new Casilla
                                        {
                                            Valor = 0,
                                            Imagen = null
                                        };
                                    }
                                }
                            }
                        }
                    }
                }
                if (sinMovimiento != 0)
                {
                    AparecerRandom();
                }
                sinMovimiento = 0;
            }

        }

        private void Ganaste()
        {
            MessageBox.Show("Ganaste", "Ganador",
                                     MessageBoxButtons.OK);
            timer1.Stop();
        }
        int perdiste = 0;
        int o = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            perdiste = 0;
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    Casilla casilla = (Casilla)tablero[f, c].Tag;
                    tablero[f, c].Image = casilla.Imagen;

                }

            }
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    Casilla casilla = (Casilla)tablero[f, c].Tag;
                    if (casilla.Valor != 0)
                    {
                        perdiste++;
                    }

                }

            }
            if (perdiste == 16)
            {
                o++;
            }
            if (o == 2)
            {
                MessageBox.Show("Perdiste", "Perdiste",
                                      MessageBoxButtons.OK);
                timer1.Stop();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Start();
            CrearTablero();
            AparecerRandom();
        }
    }
}
