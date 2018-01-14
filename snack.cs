using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace snackBlock
{
    class Program
    {

        //atributos
        static int[] bloques;
        static Random aleatorio = new Random();
        static List<int> verdes;

        static void Main(string[] args)
        {
            crearBloques();
            valoresIrrepetibles();
            while (true)
            {
                mostrarVector();
                Thread.Sleep(2000);
                valoresIrrepetibles();
                nuevosValores();
                Console.Clear();
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

                Console.Write("\t [{0}]",bloques[i]);
            }

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

    }
}
