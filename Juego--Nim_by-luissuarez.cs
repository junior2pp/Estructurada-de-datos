using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using System.Timers;
namespace nim
{
    class Program
    {

        public void inicio()
        {
            Console.SetCursorPosition(10, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("BIENVENIDO AL JUEGO NIM SENCILLO");
        }
        public void mostrar(Stack pila1)
        {
            Console.SetCursorPosition(45, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PALILLOS RESTANTE");
            Console.SetCursorPosition(40, 6);
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in pila1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public void empezar()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Stack pila = new Stack();
            int n = 16;
            for (int i = 0; i < n; i++)
            {
                pila.Push("|");
            }

            Program gato = new Program();
            gato.inicio();
            Console.SetCursorPosition(10, 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("PRESIONA UNA TECLA PARA JUGAR");
            Console.ReadKey();
            Console.SetCursorPosition(10, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Nombre del Jugador 1: ");
            string juga1 = Console.ReadLine();
            Console.SetCursorPosition(10, 6);
            Console.Write("Nombre del Jugador 2: ");
            string juga2 = Console.ReadLine();
            string ganador = "";
            Console.WriteLine();

            // Console.Write("TIEMPO: " + total.ToString());
            Console.Clear();
            do
            {
                Console.SetCursorPosition(45, 5);
                gato.mostrar(pila);
                bool dato = true;
                string jugador1 = "";
                string jugador2 = "";

                int cont1 = 0;
                ganador = juga2;
                while (dato)
                {

                    Console.SetCursorPosition(40, 8);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("{0} Puedes sacar 1 o 2 Palillos: ", juga1);
                    jugador1 = Console.ReadLine();
                    if (jugador1 == "1" || jugador1 == "2")
                    {
                        dato = false;
                    }
                    else
                    {
                        cont1++;
                        Console.SetCursorPosition(40, 9);
                        Console.WriteLine("Por favor Ingrese 1 o 2");
                    }
                    if (cont1 > 3)
                    {
                        Console.SetCursorPosition(40, 9);
                        Console.WriteLine("Por favor No seas Estúpido/a mete  1 o 2");
                    }


                }

                if (pila.Count <= 2)
                {
                    if (jugador1 == "2")
                    {
                        ganador = juga1;
                        break;
                    }
                    if (pila.Count == 1 && jugador1 == "1")
                    {
                        ganador = juga1;
                        break;
                    }
                }
                int j = int.Parse(jugador1);
                for (int i = 0; i < j; i++)
                {
                    pila.Pop();
                }
                Console.Clear();
                gato.mostrar(pila);
                bool dato2 = true;
                int conta = 0;
                while (dato2)
                {
                    Console.SetCursorPosition(40, 8);
                    Console.Write("{0} Puedes sacar 1 o 2 Palillos: ", juga2);
                    jugador2 = Console.ReadLine();
                    if (jugador2 == "1" || jugador2 == "2")
                    {
                        dato2 = false;
                    }
                    else
                    {
                        conta++;
                        Console.SetCursorPosition(40, 11);
                        Console.WriteLine("Por favor Ingrese 1 o 2 ");
                    }
                    if (conta > 3)
                    {
                        Console.SetCursorPosition(40, 11);
                        Console.WriteLine("Por favor No seas Estúpido Mete  1 o 2 ");
                    }

                }

                if (pila.Count <= 2)
                {
                    if (jugador2 == "2")
                    {
                        ganador = juga2;
                        break;
                    }
                    if (pila.Count == 1 && jugador2 == "1")
                    {
                        ganador = juga2;
                        break;
                    }
                }
                int z = int.Parse(jugador2);
                for (int i = 0; i < z; i++)
                {
                    pila.Pop();
                }
                Console.Clear();

            } while (pila.Count != 0);
            Console.Clear();
            Console.SetCursorPosition(50, 5);
            Console.Write("SIN PALILLOS");
            Console.SetCursorPosition(45, 15);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("EL GANADOR ES " + ganador.ToUpper());
        }
        static void Main(string[] args)
        {

            Program luis = new Program();
            luis.empezar();
            bool estado = true;
            while (estado)
            {
                Console.SetCursorPosition(30, 18);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Desea Volver a Jugar SI/NO ===>>> ");
                string respuesta = Console.ReadLine();
                if (respuesta.ToUpper() == "SI")
                {
                    Console.Clear();
                    luis.empezar();
                }
                if (respuesta.ToUpper() == "NO")
                {
                    estado = false;
                }
            }
            Console.SetCursorPosition(30, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ESTE JUEGO SE CERRARA EN 5 SEGUNDOS");
            Thread.Sleep(5000);

        }
    }
}