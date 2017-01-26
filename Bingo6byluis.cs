using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections;
namespace bingo
{
    class Program
    {
        
        
        static void mostrar ( int [,] matriz1,Stack pila1)
            {
            
            for (int i = 0; i < 9; i++)
            {
               
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition((i * 4) + 40, (j * 1) + 5);
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (int item in pila1)
                    {
                        if (matriz1[i, j] == item)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }
                    Console.Write(matriz1[i, j]);
                    


                }
            }
            


        }
        static List<int> lista1 = new List<int>();
        static List<int> lista2 = new List<int>();
        static List<int> lista3 = new List<int>();
        static List<int> lista4 = new List<int>();
        static List<int> lista5 = new List<int>();
        static List<int> lista6 = new List<int>();

        static void limpiar()
        {
            lista1.Clear();
            lista2.Clear();
            lista3.Clear();
            lista4.Clear();
            lista5.Clear();
            lista6.Clear();

        }

        static void marcarjugadores(Stack pila2)
        {

            foreach (int item in pila2)
            {

                lista1.Remove(item);
                lista2.Remove(item);
                lista3.Remove(item);
                lista4.Remove(item);
                lista5.Remove(item);
                lista6.Remove(item);
                

            }
            Console.SetCursorPosition(2, 16);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("JUGADOR 1");
            Console.SetCursorPosition(2, 17);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in lista1)
            {    
                Console.Write(item + " ");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(2, 18);
            Console.Write("JUGADOR 2");
            Console.SetCursorPosition(2, 19);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in lista2)
            {
                Console.Write(item + " ");
            }
            Console.SetCursorPosition(2, 20);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("JUGADOR 3");
            Console.SetCursorPosition(2, 21);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in lista3)
            {
                Console.Write(item + " ");
            }
            Console.SetCursorPosition(2, 22);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("JUGADOR 4");
            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in lista4)
            {
                Console.Write(item + " ");
            }
            Console.SetCursorPosition(2, 24);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("JUGADOR 5");
            Console.SetCursorPosition(2, 25);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in lista5)
            {
                Console.Write(item + " ");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(2, 26);
            Console.Write("JUGADOR 6");
            Console.SetCursorPosition(2, 27);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in lista6)
            {
                Console.Write(item + " ");
            }

        }
        static void jugadores()
        {
            lista1.Add(10);
            lista1.Add(22);
            lista1.Add(54);
            lista1.Add(61);
            lista1.Add(84);
            lista1.Add(27);
            lista1.Add(47);
            lista1.Add(58);
            lista1.Add(74);
            lista1.Add(86);
            lista1.Add(4);
            lista1.Add(39);
            lista1.Add(48);
            lista1.Add(65);
            lista1.Add(77);
            Console.SetCursorPosition(2, 17);
            foreach (var item in lista1)
            {
                Console.Write(item + " ");
            }

            lista2.Add(15);
            lista2.Add(36);
            lista2.Add(40);
            lista2.Add(68);
            lista2.Add(80);
            lista2.Add(29);
            lista2.Add(38);
            lista2.Add(50);
            lista2.Add(76);
            lista2.Add(82);
            lista2.Add(1);
            lista2.Add(17);
            lista2.Add(43);
            lista2.Add(55);
            lista2.Add(79);

            Console.SetCursorPosition(2, 19);
            foreach (var item in lista2)
            {
                Console.Write(item + " ");
            }

            lista3.Add(2);
            lista3.Add(12);
            lista3.Add(41);
            lista3.Add(73);
            lista3.Add(81);
            lista3.Add(14);
            lista3.Add(34);
            lista3.Add(44);
            lista3.Add(66);
            lista3.Add(75);
            lista3.Add(5);
            lista3.Add(25);
            lista3.Add(51);
            lista3.Add(67);
            lista3.Add(89);

            Console.SetCursorPosition(2,21);
            foreach (int item in lista3)
            {
                Console.Write(item + " ");
            }

            lista4.Add(3);
            lista4.Add(20);
            lista4.Add(42);
            lista4.Add(72);
            lista4.Add(83);
            lista4.Add(21);
            lista4.Add(32);
            lista4.Add(59);
            lista4.Add(63);
            lista4.Add(87);
            lista4.Add(8);
            lista4.Add(16);
            lista4.Add(37);
            lista4.Add(46);
            lista4.Add(69);
            Console.SetCursorPosition(2,23);
            foreach (var item in lista4)
            {
                Console.Write(item + " ");
            }

            lista5.Add(13);
            lista5.Add(23);
            lista5.Add(52);
            lista5.Add(70);
            lista5.Add(85);
            lista5.Add(7);
            lista5.Add(24);
            lista5.Add(30);
            lista5.Add(53);
            lista5.Add(71);
            lista5.Add(19);
            lista5.Add(33);
            lista5.Add(49);
            lista5.Add(62);
            lista5.Add(88);
            Console.SetCursorPosition(2,25);
            foreach (int item in lista5)
            {
                Console.Write(item + " ");
            }

            lista6.Add(6);
            lista6.Add(11);
            lista6.Add(31);
            lista6.Add(56);
            lista6.Add(60);
            lista6.Add(9);
            lista6.Add(26);
            lista6.Add(35);
            lista6.Add(64);
            lista6.Add(90);
            lista6.Add(18);
            lista6.Add(28);
            lista6.Add(45);
            lista6.Add(57);
            lista6.Add(78);

            Console.SetCursorPosition(2,27);
            foreach (int item in lista6)
            {
                Console.Write(item + " ");
            }





        }

        static void menu()
        {
            jugadores();
            int[,] matriz;
            Random r = new Random();

            matriz = new int[9, 10];

            int h = 1;
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    matriz[i, k] = h;
                    h++;
                }
            }

            Stack pila = new Stack();

            int f = 90;
            int cont = 0;
            int aleatorio = 51;
            bool estado = true;
            while (f != cont && estado)
            {
                aleatorio = r.Next(1, 90);
                if (pila.Contains(aleatorio) == false)
                {

                    pila.Push(aleatorio);
                    mostrar(matriz, pila);
                    cont++;
                    Console.SetCursorPosition(5, 5);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NÚMERO GENERADO");
                    Console.SetCursorPosition(11, 7);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(aleatorio);
                    Console.Beep();
                    marcarjugadores(pila);
                    if (lista1.Count == 0)
                    {
                        
                        
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(15, 16);
                        Console.WriteLine("BINGOOOOOOOOOO EL GANADOR ES JUGADOR 1");
                        Console.ReadKey();
                        Console.Clear();
                        estado = false;
                        break;
                    }
                    if (lista2.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(15, 18);
                        Console.WriteLine("BINGOOOOOOOOOO EL GANADOR ES JUGADOR 2");
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                        Console.ReadKey();
                        Console.Clear();
                        estado = false;
                        break;
                    }
                    if (lista3.Count == 0)
                    {
                        
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(15, 20);
                        Console.WriteLine("BINGOOOOOOOOOO EL GANADOR ES JUGADOR 3");
                        Console.ReadKey();
                        Console.Clear();
                        estado = false;
                        break;
                    }
                    if (lista4.Count == 0)
                    {
                        
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(15, 22);
                        Console.WriteLine("BINGOOOOOOOOO EL GANADOR ES JUGADOR 4");
                        Console.ReadKey();
                        Console.Clear();
                        estado = false;
                        break;
                    }
                    if (lista5.Count == 0)
                    {
                        
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(15, 24);
                        Console.WriteLine("BINGOOOOOOOOO EL GANADOR ES JUGADOR 5");
                        Console.ReadKey();
                        Console.Clear();
                        estado = false;
                        break;
                    }
                    if (lista6.Count == 0)
                    {
                        
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(15, 26);
                        Console.WriteLine("BINGOOOOOOOOO EL GANADOR ES JUGADOR 6");
                        Console.ReadKey();
                        Console.Clear();
                        estado = false;
                        break;
                    }
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }
        static void Main(string[] args)
        {
            Console.SetCursorPosition(50,3);
            Console.Write("PRESIONA ENTER PARA EMPEZAR......");
            Console.ReadKey();
            menu();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(8, 23);
            Console.Write("DESEA VOLVER A JUGAR SI/NO ===>  ");
            
            string respuesta = Console.ReadLine();
            if (respuesta.ToUpper() == "SI")
            {
                limpiar();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                menu();
                
            }
            if (respuesta.ToUpper() == "NO")
            {
                Environment.Exit(0);
            }
            
        }
    }
}
