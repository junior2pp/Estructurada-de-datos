using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ARCHIVOSSS
{
    class Program
    {
        //// SI VA A CONSERVAR LA RUTA DEBE CREAR UNA CARPETA LLAMADA ARCHIVOS EN EL DISCO LOCAL "C"
        static string ruta = "c:\\archivo\\autos.bin"; 
        static string nserie, nombrepiloto,cedulapiloto,nombrecopiloto,cedulacopiloto,numeroplaca,marcaauto, fabricante, color,tipocategoria;
        static bool encontrado;
        static string[] campos = new string[7];

        static void menu()
        {

            string opciones = "";
            do
            {
                try
                {
                    Console.WriteLine("MENÚ DE OPCIONES");
                    Console.WriteLine("1. REGISTRO DE AUTOS");
                    Console.WriteLine("2. REGISTRAR TIEMPOS");
                    Console.WriteLine("3. RESULTADOS");
                    Console.WriteLine("4. BASE DE AVANCES");
                    Console.WriteLine("5. MOSTRAR TODOS LOS REGISTROS ");
                    Console.WriteLine("6. SALIR ");
                    Console.Write("Ingrese Opción: ");
                    opciones = Console.ReadLine();
                    switch (opciones)
                    {
                        case "1":
                            crear1();
                            registroautos();
                            Console.ReadKey();
                            break;
                        case "2":
                            tramos();
                            Console.ReadKey();
                            break;
                        case "3":
                            resultados();
                            Console.ReadKey();
                            break;
                        case "4":
                            avances();
                            Console.ReadKey();
                            break;
                        case "5":
                            todos();
                            Console.ReadKey();
                            break;
                        case "6":
                            Environment.Exit(0);
                            break;

                        default:
                            Console.Write("OPCIÓN INCORRECTA");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("ERROR" + ex.Message);
                    throw;
                }
                catch(Exception e)
                {
                    Console.WriteLine("ERROR " + e.Message );
                }
                Console.Clear();
            } while (opciones != "6");

        }

       
        static void categoriaA()
        {
            
            tipocategoria = "A";
            altas();
        }
        static void categoriaB()
        {
            tipocategoria = "B";
            altas();
        }
        static void categoriaC()
        {
            tipocategoria = "C";
            altas();
        }
        static void llenarvector(int[] vector , List<string> lista)
        {
            int j = 0;

            foreach (var item in lista)
            {
                vector[j] = int.Parse(item);
                j++;
            }
        }

        static void ordenarvectores( int [] vector , int[] catg)
        {
            for (int k = 0; k < vector.Length; k++)
            {
                for (int h = 0; h < vector.Length - 1 - k; h++)
                {
                    if (vector[h] > vector[h + 1])
                    {
                        int aux = vector[h];
                        vector[h] = vector[h + 1];
                        vector[h + 1] = aux;
                        int aux1 = catg[h];
                        catg[h] = catg[h + 1];
                        catg[h + 1] = aux1;
                    }
                }
            }

        }
        static void mostrardatos(string catg , int[] vector1 , int[] vector2 )
        {
            Console.WriteLine("CATEGORIA CLASE ---> " + catg);
            for (int w = 0; w < vector1.Length; w++)
            {
                Console.WriteLine("Número de Auto  " + vector2[w] + " TIEMPO FINAL " + vector1[w]);
            }
        }
        static void resultados()
        {
            ///MOSTRAR LOS 5 PRIMEROS LUGARES POR CATEGORIA
            ///
            encontrado = false;
            try
            {
                //lectura = File.OpenText("tiempos.txt");
                Console.WriteLine("RESULTADOS");
                //cadena = lectura.ReadLine();
                int i = 15;
                int len = 0;
                int lenb = 0;
                int lenc = 0;
                string _string = "";
                List<string> milista = new List<string>();
                List<string> autocategA = new List<string>();

                List<string> tiempofinalB = new List<string>();
                List<string> autocategB = new List<string>();


                List<string> tiempofinalC = new List<string>();
                List<string> autocategC = new List<string>();

                FileStream fs1 = new FileStream(ruta, FileMode.Open);
                BinaryReader br = new BinaryReader(fs1);
                while (br.PeekChar() != -1)
                {
                    _string = br.ReadString();
                    campos = _string.Split(',');
                    if ("t" == campos[6].Trim() && "A" == campos[5].Trim())
                    {
                        autocategA.Add(campos[0]);
                        milista.Add(campos[4]);
                        len++;   
                    }
                    if ("t" == campos[6].Trim() && "B" == campos[5].Trim())
                    {
                        autocategB.Add(campos[0]);
                        tiempofinalB.Add(campos[4]);
                        lenb++;
                    }
                    if ("t" == campos[6].Trim() && "C" == campos[5].Trim())
                    {
                        autocategC.Add(campos[0]);
                        tiempofinalC.Add(campos[4]);
                        lenc++;
                    }
                    
                    
                }

                fs1.Close();
                br.Close();

                //CATEGORIA A
                int[] vector = new int[len];
                int[] catgA = new int[len];
                llenarvector(vector, milista);
                llenarvector(catgA, autocategA);
                //CATEGORIA B

                int[] vectorb = new int[lenb];
                int[] catgB = new int[lenb];
                llenarvector(vectorb,tiempofinalB);
                llenarvector(catgB, autocategB);
                //CATEGORIA C

                int[] vectorc = new int[lenc];
                int[] catgC = new int[lenc];
                llenarvector(vectorc,tiempofinalC);
                llenarvector(catgC,autocategC);


                ///ORDENAR
                ordenarvectores(vector,catgA);
                ordenarvectores(vectorb,catgB);
                ordenarvectores(vectorc,catgC);

                /// MOSTRAR DATOS 
                /// 
                mostrardatos("A",vector,catgA);
                mostrardatos("B" ,vectorb,catgB);
                mostrardatos("C", vectorc, catgC);

               
                



            }
            catch (FileNotFoundException e)
            {
                Console.Write("error " + e);
                throw;
            }
            catch (Exception ex)
            {
                Console.Write("error " + ex);
            }
         




        }

        static void avances()
        {

            encontrado = false;
            try
            {


                FileStream fs1 = new FileStream(ruta, FileMode.Open);
                BinaryReader br = new BinaryReader(fs1);
                string _string = "";
                while (br.PeekChar() != -1)
                {
                    _string = br.ReadString();
                    campos = _string.Split(',');

                    if ("t" == campos[6])
                    {
                        Console.WriteLine("++++++++++AUTO ENCONTRADO++++++++++++++++++++++++");
                        Console.WriteLine("Número de auto " + campos[0]);
                        Console.WriteLine("TRAMO 1---> " + campos[1]);
                        Console.WriteLine("TRAMO 2---> " + campos[2]);
                        Console.WriteLine("TRAMO 3---> " + campos[3]);
                        Console.WriteLine("TIEMPO FINAL---> " + campos[4]);
                        Console.WriteLine("CATEGORIA---> " + campos[5]);
                        encontrado = true;
                    }
                    
                    

                }

                fs1.Close();
                br.Close();         
                if (encontrado == false)
                {
                    Console.WriteLine("NO HAY AUTOS EN EL ARCHIVO ,POR FAVOR INGRESE UN AUTO");
                }
            }

            catch (FileNotFoundException e)
            {
                Console.Write("error " + e);
                
            }
            catch (Exception ex)
            {
                Console.Write("error " + ex);
            }

        }
        static void crear1()
        {
            FileStream fs = new FileStream(ruta, FileMode.Append);
            fs.Close();
        }
        static void tramos()
        {
            /// mostrar datos para llenar los tramos
            /// 
            encontrado = false;
            try
            {
                
                FileStream fs1 = new FileStream(ruta, FileMode.Open);
                BinaryReader br = new BinaryReader(fs1);
                Console.Write("Ingresa el Número del auto--->  ");
                nserie = Console.ReadLine();
                string _string = "";
                //buscar si existe el numero de serie
                while (br.PeekChar() != -1)
                  {
                       _string = br.ReadString();
                       campos = _string.Split(',');

                     if (nserie == campos[0])
                      {
                        encontrado = true;
                        Console.WriteLine("+++AUTO ENCONTRADO+++");
                        Console.WriteLine("Número del Auto--->  " + campos[0]);
                        Console.WriteLine("Nombre del piloto---> " + campos[1]);
                        Console.WriteLine("Cédula piloto---> " + campos[2]);
                        Console.WriteLine("Nombre Copiloto--->" + campos[3]);
                        Console.WriteLine("Cédula Copiloto---> " + campos[4]);
                        Console.WriteLine("Número de la Placa---> " + campos[5]);
                        Console.WriteLine("Marca del auto---> " + campos[6]);
                        Console.WriteLine("Categoria del auto ---> " + campos[7]);
                        Console.WriteLine("++++++++++++++++++++++++");
                        fs1.Close();
                        br.Close();
                        Console.WriteLine("\n");
                        Console.WriteLine("Ingrese Tramo 1: ");
                        string tramo1 = Console.ReadLine();
                        Console.WriteLine("Ingrese Tramo 2: ");
                        string tramo2 = Console.ReadLine();
                        Console.WriteLine("Ingrese Tramo 3: ");
                        string tramo3 = Console.ReadLine();
                        int totaltiempo = int.Parse(tramo1) + int.Parse(tramo2) + int.Parse(tramo3);
                        string idauto = campos[0];
                        string categoria = campos[7];

                        FileStream fs = new FileStream(ruta, FileMode.Append);
                        BinaryWriter bw = new BinaryWriter(fs);

                        bw.Write(idauto + "," + tramo1 + "," + tramo2 + "," + tramo3 + "," + totaltiempo + "," + categoria+","+"t");
                        bw.Close();
                        fs.Close();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("++++++TIEMPOS  AGREGADOS CORRECTAMENTE+++++");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                 }

                

                if (encontrado == false)
                {
                    Console.WriteLine("++++++++++++++");
                    Console.WriteLine("NO EXISTE ESTE NÚMERO DE AUTO: " + fabricante);

                }

            }
            catch (FileNotFoundException e)
            {
                Console.Write("error " + e);
               
            }
            catch (Exception ex)
            {
                Console.Write("error " + ex);
            }
    


        }
       
        static void registroautos()
        {

            
            string opciones = "";
            do
            {
                try
                {
                    Console.WriteLine("1. CATEGORIA A");
                    Console.WriteLine("2. CATEGORIA B");
                    Console.WriteLine("3  CATEGORIA C");
                    Console.Write("Ingrese Opción: ");
                    opciones = Console.ReadLine();
                    switch (opciones)
                    {
                        case "1":
                            categoriaA();
                            Console.ReadKey();
                            break;
                        case "2":
                            categoriaB();
                            Console.ReadKey();
                            break;
                        case "3":
                            categoriaC();
                            Console.ReadKey();
                            break;
                        default:
                            Console.Write("OPCIÓN INCORRECTA");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("ERROR" + ex.Message);
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR " + e.Message);
                }
                Console.Clear();
            } while (opciones != "6");
        }
        
        static void altas()
        {
           // crear();
            encontrado = false;
            ///SUBMENU DE CATEGORIAS
            ///
            // data a ser guardada
            FileStream fs1 = new FileStream(ruta, FileMode.Open);
            BinaryReader br = new BinaryReader(fs1);

            try
            {
                
                Console.WriteLine("Ingresa el Número del auto: ");
                nserie = Console.ReadLine();
                string _string = "";
                //buscar si existe el numero de serie
                while (br.PeekChar() != -1)
                {
                    _string = br.ReadString();
                    campos = _string.Split(',');

                    if (nserie == campos[0])
                    {
                        encontrado = true;
                        break;
                    }
                }

                fs1.Close();
                br.Close();
                if (encontrado == false)
                {
                    FileStream fs = new FileStream(ruta, FileMode.Append);
                    BinaryWriter bw = new BinaryWriter(fs);

                    
                    Console.Write("Nombre del Piloto: ");
                    nombrepiloto = Console.ReadLine();
                    nombrepiloto = nombrepiloto.ToUpper();
                    Console.Write("Cédula Piloto: ");
                    cedulapiloto = Console.ReadLine();
                    Console.Write("Nombre Copiloto: ");
                    nombrecopiloto = Console.ReadLine();
                    nombrecopiloto = nombrecopiloto.ToUpper();
                    Console.Write("Cédula Copiloto: ");
                    cedulacopiloto = Console.ReadLine();
                    Console.Write("Número de la Placa : ");
                    numeroplaca = Console.ReadLine();
                    Console.Write("Marca del Auto: ");
                    marcaauto = Console.ReadLine();
                    //escribiendo
                    bw.Write(nserie + "," + nombrepiloto + ","+cedulapiloto + ","+ nombrecopiloto + "," + cedulacopiloto + ","+numeroplaca + ","+marcaauto+ "," + tipocategoria);
                    bw.Close();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("++++++REGISTRO AGREGADO CORRECTAMENTE+++++");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    menu();
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ESTE NÚMERO DE AUTO YA EXISTE " + nserie);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            }
            catch (FileNotFoundException e)
            {
                Console.Write("error " + e);
                throw;
            }
            catch(Exception ex)
            {
                Console.Write("error " + ex);
            }
            finally {  }
            Console.ReadKey();

        }

        static void todos()
        {
            encontrado = false;
            try
            {


                FileStream fs1 = new FileStream(ruta, FileMode.Open);
                BinaryReader br = new BinaryReader(fs1);
                string _string = "";
                while (br.PeekChar() != -1)
                {
                    _string = br.ReadString();
                    campos = _string.Split(',');
                    encontrado = true;
                    if (campos[6] != "t")
                    {
                        Console.WriteLine("+++++++++++AUTO ENCONTRADO +++++++++++++");
                        Console.WriteLine("Número del Auto--->  " + campos[0]);
                        Console.WriteLine("Nombre del piloto---> " + campos[1]);
                        Console.WriteLine("Cédula piloto---> " + campos[2]);
                        Console.WriteLine("Nombre Copiloto--->" + campos[3]);
                        Console.WriteLine("Cédula Copiloto---> " + campos[4]);
                        Console.WriteLine("Número de la Placa---> " + campos[5]);
                        Console.WriteLine("Marca del auto---> " + campos[6]);
                        Console.WriteLine("Categoria del auto ---> " + campos[7]);
                        Console.WriteLine("++++++++++++++++++++++++");
                    }
                    
               
                }

                if (encontrado == false)
                {
                    Console.WriteLine("NO HAY AUTOS EN EL ARCHIVO DE TEXTO");
                }
                fs1.Close();
                br.Close();
            }

            catch (FileNotFoundException e)
            {
                Console.Write("error " + e);
                throw;
            }
            catch (Exception ex)
            {
                Console.Write("error " + ex);
            }
            

        }
        static void Main(string[] args)
        {
            menu();
            Console.ReadKey();
        }
    }
}
