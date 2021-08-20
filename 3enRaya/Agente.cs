using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3enRaya
{
    public class Agente
    {
        public Agente(string[,] tablero)
        {
            this.tablero = tablero;
        }
        string turno = "X";
        public string[,] tablero { get; set; }

        internal int[] mover()
        {
            int puntajeM = -10;
            int[] movimiento = new int[2];
            Console.WriteLine("********OPCIONES Principales**********");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tablero[i, j] == "-")
                    {
                        tablero[i, j] = turno;
                        imprimirTablero();
                        int puntos = min();
                     Console.WriteLine($"puntos: {puntos}");
                        tablero[i, j] ="-";
                        if (puntos > puntajeM)
                        {
                            puntajeM = puntos;
                            movimiento[0] = i;
                            movimiento[1] = j;
                          Console.WriteLine("elegido");
                        }
                    }
                }
                Console.WriteLine("");
            }
            return movimiento;
        }

        private void imprimirTablero()
        {
            Console.WriteLine("------------------");
            for (int i = 0; i < 3; i++)
            {
                
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"|{tablero[i, j]}");
                }
                Console.WriteLine("");
            }
        }

        private int min()
        {
            int resultado = buscarGanador();
            if (resultado != -2)
            {
                return resultado;
            }
            int puntajeM = 10;
           // Console.WriteLine("********OPCIONES **********");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tablero[i, j] == "-")
                    {
                        tablero[i, j] = "O";
                       // imprimirTablero();
                        int puntaje = max();
                        tablero[i, j] = "-";
                        if (puntaje < puntajeM)
                        {
                            puntajeM = puntaje;
                          //  Console.WriteLine("elegido");
                        }
                    }
                }
            }
            return puntajeM;
        }

        private int max()
        {
            int resultado = buscarGanador();
            if (resultado != -2)
            {
                return resultado;
            }
            int puntajeM = -10;
          //  Console.WriteLine("********OPCIONES **********");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tablero[i, j] == "-")
                    {
                        tablero[i, j] = turno;
                        //imprimirTablero();
                        int puntaje = min();
                        tablero[i, j] = "-";
                        if (puntaje > puntajeM)
                        {
                            puntajeM = puntaje;
                           // Console.WriteLine("elegido");
                        }
                    }
                }
            }
            return puntajeM;

        }

        private int buscarGanador()
        {
            string texG = "";
           
            //filas
            for (int i = 0; i < 3; i++)
            {
                if(tablero[i,0]==tablero[i,1] && tablero[i, 1] == tablero[i, 2])
                {
                    texG = tablero[i, 0];
                }
            }
            //columnas
            for (int i = 0; i < 3; i++)
            {
                if(tablero[0,i]==tablero[1,i] && tablero[1, i] == tablero[2, i])
                {
                    texG = tablero[0, i];
                }
            }
            //diagonales
            if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2])
            {
                texG = tablero[1, 1];
            }else if(tablero[0,2]==tablero[1,1] && tablero[1, 1] == tablero[2,0])
            {
                texG = tablero[1, 1];
            }
            //empate 
            int contE = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tablero[i, j] != "-")
                    {
                        contE++;
                    }
                }
            }
            if (texG == turno)
            {
                return 1;
            }
            else if(texG=="O")
            {
                return -1;
            }else if (contE == 9)
            {
                return 0;
            }
            else
            {
                return -2;
            }
            
        }
    }
}
