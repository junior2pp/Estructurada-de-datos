using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace administrar_colas_by_luisS
{
	class colas
	
  /*ADMINISTRADOR DE COLAS PARA LA MATERIA DE ÁRBOLES Y TEORIA DE JUEGOS 
    IMPARTIDA POR EL PROFESOR ING.MARCILLO VERA */
    
		public static Queue cola = new Queue();

		public void menu()
		{
			Console.WriteLine("              BIENVENIDO AL ADMINISTRADOR DE COLA BY LUIS SUÁREZ ING.TELEMÁTICA MÓDULO 3");
			Console.WriteLine("===>ELIJA SU OPCIÓN");
			Console.WriteLine("1<->Insertar");
			Console.WriteLine("2<->Quitar");
			Console.WriteLine("3<->Ver cola");
			Console.WriteLine("4<->Vaciar cola");
			Console.WriteLine("5<->Llenar Cola aleatoriamente");
			Console.WriteLine("6<->Salir");
		}
		public void pausa()
		{
			Console.WriteLine(">>>>>>>>Presione una tecla para continuar<<<<<<<<");
			Console.ReadKey();
		}
		public void exito()
		{

			Console.WriteLine(">>>>>>>>EXITO AL GUARDAR DATO<<<<<<<<<<");
		}
		static void Main(string[] args)
		{

			colas c = new colas();
			Random r = new Random();
			int opciones;
			do
			{
				c.menu();
				Console.Write("Opción: ");
				opciones = int.Parse(Console.ReadLine());
				switch (opciones)
				{
					case 1:
						Console.Write("VALOR PARA INSERTAR A LA COLA ====> ");
						string valor = Console.ReadLine();
						cola.Enqueue(valor);
						c.exito();
						c.pausa();
						break;
					case 2:
						cola.Dequeue();
						Console.WriteLine("Valor quitado con exito");
						c.pausa();
						break;

					case 3:
						Console.WriteLine("          DATOS EN LA COLA        ");
						foreach (var item in cola)
						{
							Console.WriteLine("-->" + item);
						}
						c.pausa();
						break;

					case 4:

						cola.Clear();
						Console.WriteLine("La cola se a vaciado con exito");
						c.pausa();
						break;

					case 5:

						Console.Write("Ingrese N número para llenar cola ====> ");
						int n = int.Parse(Console.ReadLine());
						for (int i = 0; i < n; i++)
						{
							cola.Enqueue(r.Next(1000));
						}
						Console.WriteLine("Cola llenada exitosamente");
						c.pausa();
						break;

					case 6:

						Environment.Exit(0);
						break;

					default:
						Console.WriteLine("Ingrese un valor entre 1 y 6");
						c.pausa();
						Console.ReadKey();
						break;

				}
				Console.Clear();
			} while (opciones != 6);


		}
	}
}
