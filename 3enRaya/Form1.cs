using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3enRaya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool turno = true;
        Button[,] matriz = new Button[3,3];
        private void Form1_Load(object sender, EventArgs e)
        {
           
           
            matriz[0, 0] = button1;
            matriz[0, 1] = button2;
            matriz[0, 2] = button3;
            matriz[1, 0] = button4;
            matriz[1, 1] = button5;
            matriz[1, 2] = button6;
            matriz[2, 0] = button7;
            matriz[2, 1] = button8;
            matriz[2, 2] = button9;

            
           
            Random ram = new Random();
            int fila = ram.Next(0, 3);
            int colu = ram.Next(0, 3);
            matriz[fila, colu].Text = "X";
            matriz[fila, colu].Enabled = false;
            turno = !turno;
        }

        private string[,] obtenerMatriz()
        {
            string[,] tab = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tab[i, j] = matriz[i, j].Text;
                }

            }
            return tab;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            marcar(0,0);
            validarEstado();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            marcar(0,1);
            validarEstado();
        }

      
        private void button3_Click(object sender, EventArgs e)
        {
            marcar(0,2);
            validarEstado();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            marcar(1,0);
            validarEstado();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            marcar(1,1);
            validarEstado();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            marcar(1,2);
            validarEstado();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            marcar(2,0);
            validarEstado();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            marcar(2,1);
            validarEstado();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            marcar(2,2);
            validarEstado();
        }
        private void marcar(int fil, int col)
        {
            if (turno)
            {
                matriz[fil, col].Text = "X";
            }
            else
            {
                matriz[fil, col].Text = "O";
            }

            matriz[fil, col].Enabled = false;
            turno = !turno;

            string[,] tabAux = new string[3, 3];
            tabAux = obtenerMatriz();
            Agente agente = new Agente(tabAux);
            int[] coordenadas = agente.mover();
            matriz[coordenadas[0], coordenadas[1]].Text = "X";
            matriz[coordenadas[0], coordenadas[1]].Enabled = false;
            turno = !turno;

        }
        private void validarEstado()
        {
            string ga = ganadorT();
            if(ga != "")
            {
                label1.Text = "ganador: " + ga;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        matriz[i, j].Enabled = false;
                    }
                }
            }
            


        }

        private string  ganadorT()
        {
            string texto = "";
            //filas
            for (int i = 0; i < 3; i++)
            {
                if (matriz[i, 0].Text == matriz[i, 1].Text && matriz[i, 1].Text == matriz[i, 2].Text)
                {
                    texto = matriz[i, 0].Text;
                
                }
            }
            //columnas
            for (int i = 0; i < 3; i++)
            {
                if (matriz[0, i].Text == matriz[1, i].Text && matriz[1, i].Text == matriz[2, i].Text)
                {
                    texto = matriz[0, i].Text;
                   
                }
            }
            //diagonales
            if (matriz[0, 0].Text == matriz[1, 1].Text && matriz[1, 1].Text == matriz[2, 2].Text)
            {
                texto = matriz[1, 1].Text;
                
            }
            else if (matriz[0, 2].Text == matriz[1, 1].Text && matriz[1, 1].Text == matriz[2,0].Text)
            {
                texto = matriz[1, 1].Text;
                
            }
            //empate 
            int contE = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matriz[i, j].Text != "-")
                    {
                        contE++;
                    }
                }
            }
            if (texto == "X")
            {
                return texto;
            }
            else if (texto == "O")
            {
                return texto;
            }
            else if (contE == 9)
            {
                return "empate";
            }
            else
            {
                return "";
            }
        }
    }
}
