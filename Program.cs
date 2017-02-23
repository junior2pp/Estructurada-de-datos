using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Matriz7
{
    class Matriz7
    {
        private int[,] mat;

        public void Cargar()
        {
            Console.Write("Cuantas fila tiene la matriz:");
            string linea;
            linea = Console.ReadLine();
            int filas = int.Parse(linea);
            Console.Write("Cuantas columnas tiene la matriz:");
            linea = Console.ReadLine();

            int columnas = int.Parse(linea);
            mat = new int[filas, columnas];
            Random r = new Random();
            for (int f = 0; f < mat.GetLength(0); f++)
            {
                for (int c = 0; c < mat.GetLength(1); c++)
                {
                   
                    mat[f, c] = r.Next(1,10);
                }
            }
        }

        public void Intercambiar()
        {
            ////ESTE SIRVE PARA INTERCAMBIAR LAS COLUMNAS
            Console.SetCursorPosition(15, 10);
            Console.Write("Que Columna desea intercambiar # 1 : ");
            int colu1 = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(15, 11);
            Console.Write("Que Columna desea intercambiar # 2 : ");
            int colu2 = int.Parse(Console.ReadLine());
            for (int c = 0; c < mat.GetLength(0); c++)
            {
                int aux = mat[colu1, c];
                mat[colu1, c] = mat[colu2, c];
                mat[colu2, c] = aux;
            }
            for (int f = 0; f < mat.GetLength(0); f++)
            {
                for (int c = 0; c < mat.GetLength(1); c++)
                {
                    Console.SetCursorPosition((5 * f) + 25, (2 * c) + 5);
                    Console.Write(mat[f, c] + " ");
                }
            }
        }


        public void intercambiarfilas()
        {
            Console.SetCursorPosition(15, 14);
            Console.Write("Que fila desea intercambiar # 1 : ");
            int colu1 = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(15, 15);
            Console.Write("Que fila desea intercambiar # 2 : ");
            int colu2 = int.Parse(Console.ReadLine());
            for (int c = 0; c < mat.GetLength(1); c++)
            {
                int aux = mat[c, colu1];
                mat[c, colu1] = mat[c, colu2];
                mat[c, colu2] = aux;
            }
            for (int f = 0; f < mat.GetLength(1); f++)
            {
                for (int c = 0; c < mat.GetLength(1); c++)
                {
                    Console.SetCursorPosition((5 * f) + 45, (2 * c) + 5);
                    Console.Write(mat[f, c]);
                }
            }
        }
        public void Imprimir()
        {
            for (int f = 0; f < mat.GetLength(0); f++)
            {
                for (int c = 0; c < mat.GetLength(1); c++)
                {
                    Console.SetCursorPosition((5*f)+10,(2*c)+5);
                    Console.Write(mat[f, c] + " ");
                }
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Matriz7 ma = new Matriz7();
            ma.Cargar();
            ma.Imprimir();
            ma.Intercambiar();
            ma.intercambiarfilas();
            Console.ReadKey();
            //ma.Imprimir();
        }
    }
}




