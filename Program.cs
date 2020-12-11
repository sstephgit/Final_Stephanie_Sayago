using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using Console = Colorful.Console;
using Colorful;

namespace Stephanie_final_Estructura_datos
{
    class Program
    {
          
        static Queue<int> pedidos;
        static void Main(string[] args)
        {

            int opcion = 0;

           
            while (opcion != 11)
            {
                Mensaje_Inicio();

                Console.WriteLine("~~~~~~~~~ MENU ~~~~~~~~~ ",Color.HotPink);
                Console.ResetColor();
                Console.WriteLine("\n(1) ~ Crear Cola" +
                        "\n(2) ~ Borrar  Cola " +
                        "\n(3) ~ Agregar Pedido " +
                        "\n(4) ~ Borrar Pedido" +
                        "\n(5) ~ Listar todos los pedidos" +
                        "\n(6) ~ Listar último Pedido" +
                        "\n(7) ~ Listar primer Pedido " +
                        "\n(8) ~ Cantidad de Pedido " +
                        "\n(9) ~ listar pares o impares" +
                        "\n(10) ~ Borrar ultimo Pedido " +                       
                        "\n(11) ~ Salir",Color.Pink);
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~", Color.HotPink);         
                       
            try
            {                            
                opcion = int.Parse(Console.ReadLine());
               
                    switch (opcion)
                    {
                        case 1:
                            Nueva_cola();
                            break;

                        case 2:
                            Borrar_Cola();
                            break;

                        case 3:
                            Agregar_Pedido();
                            break;

                        case 4:
                            Borrar_Pedido();
                            break;

                        case 5:
                            Listar_Pedidos();
                            break;

                        case 6:
                            listar_Ultimo_Pedido();
                            break;

                        case 7:
                            listar_Primer_Pedido();
                            break;

                        case 8:
                            Cantidad_pedidos();
                            break;

                        case 9:
                            Buscar_par_Impar();
                            break;

                        case 10:
                            borar_Ultimo_Pedido();
                            break;                       

                        case 11:
                            Console.Clear();
                            Figlet figlet = new Figlet();
                            Console.WriteLine(figlet.ToAscii("Adios!"), ColorTranslator.FromHtml("#F900FD"));
                            break;                      
                    }
                }
                 catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~", Color.Red);                  
                    Console.WriteLine("Ingrese una opcion valida", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("\n");
                }

            }
            void Mensaje_Inicio()
            {                 
                string mensaje = "PEDIDOS";
                if (pedidos != null && pedidos.Count > 0)
                {
                    mensaje = mensaje + ": ["+ pedidos.Count + "]";
                }
                
                Figlet figlet = new Figlet();              
                Console.WriteLine(figlet.ToAscii(mensaje), ColorTranslator.FromHtml("#F900FD"));              
            }

             void Nueva_cola()
             {         
                string reemplazar = "";
                if (pedidos != null && pedidos.Count > 0)
                {
                    while (reemplazar.ToUpper() != "SI" && reemplazar.ToUpper() != "NO")
                    {
                        Console.Clear();
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~ Alerta ~~~~~~~~~~~~~~~~~", Color.Yellow);
                        Console.WriteLine("Existen pedidos cargados, ¿desea remplazarlos? Si/No", Color.Yellow);
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Yellow);
                        reemplazar = Console.ReadLine();                      

                        if (reemplazar.ToUpper() == "SI")
                        {
                            Console.Clear();
                            pedidos = new Queue<int>();                         
                            Console.WriteLine("Cola Creada nuevamente ",Color.LawnGreen);
                        }
                        else if (reemplazar.ToUpper() != "NO")
                        {
                            Console.Clear();
                            Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~", Color.Red);
                            Console.WriteLine("Ingrese una opcion valida", Color.Red);
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                            Console.WriteLine("\n");
                        }
                    }
                }
                else
                {
                    pedidos = new Queue<int>();
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Ok ~~~~~~~~~~~", Color.Green);
                    Console.WriteLine("Se creo la Cola ", Color.Green);                 
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~", Color.Green);                    
                }
            }


             void Borrar_Cola()
            {
                if (pedidos == null)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existe la cola de pedidos", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else
                {
                    pedidos = null;
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Ok ~~~~~~~~~~~", Color.Green);
                    Console.WriteLine("La cola fue elimiada ", Color.Green);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~", Color.Green);
                }
            }

             void Agregar_Pedido()
             {
                if (pedidos == null)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existe la cola de pedidos", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);              
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~ Por favor ~~~~~~", Color.Pink);
                    Console.WriteLine("Ingrese su pedido ", Color.Pink);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~", Color.Pink);
                    int num_pedido = 0;
                    while (num_pedido == 0)
                    {
                        try
                        {
                            num_pedido = int.Parse(Console.ReadLine());
                            if (num_pedido < 0 || num_pedido > 999)
                            {
                                Console.Clear();
                                Console.WriteLine("~~~~~~~~~~~~~~~~~ Error ~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                                Console.WriteLine("El pedido tiene que ser mayor 0 y menor a 999", Color.Red);
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                            }
                            else
                            {
                                Console.Clear();
                                pedidos.Enqueue(num_pedido);
                            }
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                            Console.WriteLine("Los elementos deben ser un número entero", Color.Red);
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                        }                        
                    }   
                }
             }
            
             void Borrar_Pedido()
            {

                if (pedidos == null)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existe la cola de pedidos", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Cual pedido desea borrar? Ingrese el numero del pedido",Color.Yellow);
                    int Element_borrar = int.Parse(Console.ReadLine());                                        

                    List<int> lista_nueva = new List<int>();
                    bool borrado = false;

                    foreach (int num in pedidos)
                    {
                        if (num != Element_borrar)
                        {
                            lista_nueva.Add(num);
                        }
                        else
                        {
                            borrado = true; /// si el numero de pedido coincide con el numero ingresado no lo agrega en lista_nueva
                        }
                    }
                    if (borrado)
                    {
                        Console.Clear();
                        Console.WriteLine("~~~~~~~~~ Ok ~~~~~~~~~~~", Color.Green);
                        Console.WriteLine("Borrada con exito", Color.Green);
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~", Color.Green);
                        pedidos = new Queue<int>(lista_nueva);                        
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                        Console.WriteLine("el pedido no existe", Color.Red);
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                    }
                }
            }

             void Listar_Pedidos()
             {
                if (pedidos == null)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No hay cola de pedidos", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else if (pedidos.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No hay pedidos cargados", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else
                {
                    Console.Clear();
                    int contador = 1;
                    Console.WriteLine("~~ lista de Pedidos ~~", Color.HotPink);
                    foreach (int numero in pedidos)
                    {                             
                        string dream = "{0} - {1} ";
                        Formatter[] fruits = new Formatter[]
                        {
                            new Formatter(""+(contador ++)+"", Color.Pink),                            
                            new Formatter(""+ numero +"", Color.Pink),                            
                        };

                        Console.WriteLineFormatted(dream, Color.HotPink, fruits);
                    }
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~", Color.HotPink);
                }
             }

             void listar_Ultimo_Pedido()
             {
                if (pedidos == null) 
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existe la cola de pedidos", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else if ( pedidos.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existen pedidos cargados", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else
                {
                    int[] lista_pedidos = pedidos.ToArray();
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Ultimo ~~~~~~~~~~~", Color.HotPink);
                    Console.WriteLine("el Ultimo Pedido es " + (lista_pedidos[lista_pedidos.Length -1]) + "", Color.HotPink);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.HotPink);
                }
             }

            void listar_Primer_Pedido()

            {
                if (pedidos == null)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existe la cola de pedidos", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else if (pedidos.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existen pedidos cargados", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else
                {
                    
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Primero ~~~~~~~~~~~", Color.HotPink);
                    Console.WriteLine("el Primer Pedido es " + (pedidos.Peek()) + "", Color.HotPink);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.HotPink);
                }                
            }

            void borar_Ultimo_Pedido()
            {
                if (pedidos == null)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existe la cola de pedidos", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else if (pedidos.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existen pedidos cargados", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else
                {
                    
                    List<int> lista_nueva = new List<int>();
                    int[] lista_pedidos = pedidos.ToArray();
                    int contador = 1;
                    /// el for inicia recorriendo desde el final
                    foreach (int num in pedidos)
                    {                        
                        if (contador++ < pedidos.Count)
                        {
                            lista_nueva.Add(num);
                        }
                    }                                       

                    pedidos = new Queue<int>(lista_nueva);

                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Ok ~~~~~~~~~~~", Color.Green);
                    Console.WriteLine("Ultimo pedido borrado", Color.Green);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~", Color.Green);
                }

            }



            void Cantidad_pedidos()
            {
                if (pedidos == null)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existe la cola de pedidos", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else if (pedidos.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existen pedidos cargados", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Ok ~~~~~~~~~~~", Color.Green);              
                    Console.WriteLine("El total de pedidos es de "+(pedidos.Count()) +"", Color.Green);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~", Color.Green);                   
                }
            }

            void Buscar_par_Impar()
            {
                if (pedidos == null)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existe la cola de pedidos", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else if (pedidos.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~ Error ~~~~~~~~~~~", Color.Red);
                    Console.WriteLine("No existen pedidos cargados", Color.Red);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~", Color.Red);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("listar pares o impares? p/i ",Color.Yellow);
                    string respuesta = "";
                    while (respuesta.ToUpper() != "P" && respuesta.ToUpper() != "I")
                    {
                        respuesta = Console.ReadLine();

                        if (respuesta.ToUpper() == "P")
                        {
                            List<int> lista_nueva = new List<int>();
                            foreach (int numero in pedidos)
                            {
                                if ((numero % 2) == 0)
                                {
                                    lista_nueva.Add(numero);  
                                }
                              
                            }

                            Console.Clear();
                            int counter = 1;
                            Console.WriteLine("~~ lista de Pedidos Pares ~~", Color.HotPink);
                            foreach (int numero in lista_nueva)
                            {
                                string dream = "{0} - {1} ";
                                Formatter[] fruits = new Formatter[]
                                {
                                     new Formatter(""+(counter ++)+"", Color.Pink),
                                     new Formatter(""+ numero +"", Color.Pink),
                                };

                                Console.WriteLineFormatted(dream, Color.HotPink, fruits);
                            }
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~", Color.HotPink);
                        }
                        else if (respuesta.ToUpper() == "I")
                        {
                            List<int> lista_nueva = new List<int>();
                            foreach (int numero in pedidos)
                            {
                                if ((numero % 2) != 0)
                                {
                                    lista_nueva.Add(numero);
                                }

                            }

                            Console.Clear();
                            int counter = 1;
                            Console.WriteLine("~~ lista de Pedidos impares ~~", Color.HotPink);
                            foreach (int numero in lista_nueva)
                            {
                                string dream = "{0} - {1} ";
                                Formatter[] fruits = new Formatter[]
                                {
                                     new Formatter(""+(counter ++)+"", Color.Pink),
                                     new Formatter(""+ numero +"", Color.Pink),
                                };

                                Console.WriteLineFormatted(dream, Color.HotPink, fruits);
                            }
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~", Color.HotPink);
                        }
                    }                  

                }
            }             
        }
    }
}

