using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace snackBlock
{
    class Program
    {

        //atributos
        static int[] bloques;
        static Random aleatorio = new Random();
        static List<int> verdes;
        static Stack valoresVerdes = new Stack();
        static Stack valoresRojos = new Stack();
        static int puntaje = 3;

        static void Main(string[] args)
        {
            crearBloques();
            valoresIrrepetibles();
            while (true)
            {
                mostrarVector();
                valoresIrrepetibles();
                nuevosValores();
                if (puntaje <= 0)
                {
                    break;
                }
                Console.Clear();
            }
            Console.Clear();
            Console.WriteLine("Usted perdido");
            Console.WriteLine("Su puntaje es: {0}",puntaje);
            Console.WriteLine("Valores Verdes");
            foreach (var item in valoresVerdes)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Valores Rojos");
            foreach (var item in valoresRojos)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();
        }

        //Este metodo inicializa los bloques
        static void crearBloques()
        {
            bloques = new int[5];
            verdes = new List<int>();
            nuevosValores();
        }

        //Cambiar los valores del vector
        static void nuevosValores()
        {
            for (int i = 0; i < bloques.Length; i++)
            {
                bloques[i] = aleatorio.Next(0,20);
            }
        }

        static void mostrarVector()
        {

            Console.WriteLine("\n El puntaje es: {0}",puntaje);
            for (int i = 0; i < bloques.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                foreach (int item in verdes)
                {
                    if (item == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }

                Console.SetCursorPosition((i*20)+5,5);
                Console.Write("\t {0} -> [{1}]",i+1,bloques[i]);
            }

            int res = getRespuesta();
            res -= 1;
            if (verdes.Contains(res))
            {
                puntaje += bloques[res];
                valoresVerdes.Push(bloques[res]);
            }
            else
            {
                puntaje -= bloques[res];
                valoresRojos.Push(bloques[res]);
            }
            Console.ResetColor();
            verdes.Clear();
        }

        static void valoresIrrepetibles()
        {
            int terminado = 0;
            while (terminado < 3)
            {
                int valor = aleatorio.Next(0,bloques.Length);
                if (!verdes.Contains(valor))
                {
                    verdes.Add(valor);
                    terminado++;
                }
            }
 
        }
        static int getRespuesta()
        {
            Console.WriteLine("\n Ingrese su respuesta entre 1 y 5");
            int respuesta = int.Parse(Console.ReadLine());
            return respuesta;
        }

    }
}
