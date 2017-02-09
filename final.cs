using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace final
{
    class Program
    {

        static int[,] matriz;
        
        static void llenar(int [,]mat,int n)
        {

            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int g = 0; g < n; g++)
                {
                    mat[i, g] = r.Next(1,100);
                    Console.SetCursorPosition((5*i)+10,(2*g)+15);
                    Console.WriteLine(mat[i,g]);
                }

            }
        }

        static void maximo(int[,] mat,int n)
        {
            int mayor = mat[0,0];
            for (int i = 0; i < n; i++)
            {
                for (int f = 0; f < n; f++)
                {
                    if (mayor<mat[i,f])
                    {
                        mayor = mat[i, f];
                    }
                }
            }
            Console.WriteLine("El número mayor es: " + mayor);
        }

        static void minimo(int[,] mat, int n)
        {
            int minimo = mat[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int f = 0; f < n; f++)
                {
                    if (minimo > mat[i, f])
                    {
                        minimo = mat[i, f];
                    }
                }
            }
            Console.WriteLine("El número menor es: " + minimo);
        }


        static void sumadiagonal(int [,] mat,int n)
        {
            int suma = 0;
            for (int i = 0; i < n; i++)
            {
                suma = suma + mat[i, i];
            }
            Console.WriteLine("La suma de la digonal es: " + suma);
        }

        static void reporte(int [,] mat,int n)
        {
            StreamWriter escribir;
            escribir = File.AppendText("multiplos.txt");
            for (int i = 0; i < n; i++)
            {
                for (int f = 0; f < n; f++)
                {
                    if (mat[i,f]%3 == 0)
                    {
                        escribir.WriteLine(matriz[i,f] + "; " + i + "," + f);
                    }
                }
            }
            escribir.Close();
        }
        static int valor = 0;
        static void menu()
        {
            string opcion = "";
            do
            {
                Console.WriteLine("MENÚ ");
                Console.WriteLine("1.LLENAR MATRIZ ");
                Console.WriteLine("2.MÁXIMO");
                Console.WriteLine("3.MINÍMO");
                Console.WriteLine("4.DIAGONAL");
                Console.WriteLine("5.REPORTE");
                Console.WriteLine("6.SALIR");
                Console.Write("Ingrese Opción: ");
                opcion = Console.ReadLine();
                if (opcion == "1")
                {
                    Console.WriteLine("Ingrese Tamaño de la Matriz NXN: ");
                    valor = int.Parse(Console.ReadLine());
                    matriz = new int[valor,valor];
                    llenar(matriz,valor);
                    Console.ReadKey();
                }
                if (opcion == "2")
                {
                    maximo(matriz,valor);
                }
                if (opcion == "3")
                {
                    minimo(matriz, valor);
                }
                if (opcion == "4")
                {
                    sumadiagonal(matriz,valor);
                }
                if (opcion == "5")
                {
                    reporte(matriz,valor);
                }




            } while (opcion != "6");
        }
        static void Main(string[] args)
        {
            menu();
        }
    }
}

