using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace finalestructura
{
    class Program
    {
        public static Queue AgregarPedido(ref Queue cola, int control)
        {
            int pedido = 1;
            if (control == 1)
            {
                do
                {
                    Console.WriteLine("Ingrese el n° de pedido a agregar");
                    pedido = Convert.ToInt32(Console.ReadLine());
                    if (pedido < 999 && pedido > 0)
                    {
                        cola.Enqueue(pedido);
                    }
                    else
                    {
                        Console.WriteLine("El n° de pedido debe ser mayor a 0 y menor a 999");
                    }
                } while (pedido < 0 || pedido > 999);
            }
            else
            {
                Console.WriteLine("No existe una cola de pedidos. Genere una nueva cola para poder agregar pedidos.");
            }

            return cola;

        }

        public static void VerPedidos(Queue cola, int control)
        {
            if (control == 1)
            {
                int pedido;
                int cantidad = cola.Count;
                Console.WriteLine("Los pedidos que se encuentran en cola son:");
                for (byte i = 0; i < cantidad; i++)
                {
                    pedido = (int)cola.Dequeue();
                    Console.WriteLine(pedido);
                    cola.Enqueue(pedido);
                }
            }
            else
            {
                Console.WriteLine("No existe una cola de pedidos.");
            }
        }

        public static void VerUltimoPedido(Queue cola, int control)
        {
            if (control == 1)
            {
                int pedido;
                int cantidad = cola.Count;
                for (byte i = 0; i < cantidad; i++)
                {
                    pedido = (int)cola.Dequeue();
                    if (i == cantidad - 1)
                    {
                        Console.WriteLine("El último pedido es {0}", pedido);
                    }
                    cola.Enqueue(pedido);
                }
            }
            else
            {
                Console.WriteLine("No existe una cola de pedidos.");
            }
        }

        public static void ExtraerPedidos(ref Queue cola, int cantidad)
        {
            Console.WriteLine("Se extrajeron los próximos pedidos");
            for (byte i = 0; i < cantidad; i++)
            {
                int pedido = Convert.ToInt32(cola.Dequeue());
                Console.WriteLine(pedido);
            }
        }

        public static Queue ModificarPedido(ref Queue cola, int pedido_modificar)
        {

            int cantidad = cola.Count;

            for (byte i = 0; i < cantidad; i++)
            {
                int pedido = Convert.ToInt32(cola.Dequeue());
                if (pedido == pedido_modificar)
                {
                    Console.WriteLine("Indique A si desea modificar el pedido o B si desea eliminar el pedido");
                    string opcion = Console.ReadLine();
                    string opcion_mayuscula = opcion.ToUpper();
                    if (opcion_mayuscula == "A")
                    {
                        Console.WriteLine("Ingrese el nuevo número de pedido:");
                        pedido = Convert.ToInt32(Console.ReadLine());
                        cola.Enqueue(pedido);
                    }
                    if (opcion_mayuscula == "B")
                    {
                        Console.WriteLine("El pedido fue eliminado de la cola");
                    }
                    if (opcion_mayuscula != "A" && opcion_mayuscula != "B")
                    {
                        Console.WriteLine("Opción Inválida");
                    }
                }
                else
                {
                    cola.Enqueue(pedido);
                }

            }

            return cola;
        }
        static void Main(string[] args)
        {
            int controlador = 0;
            string flag = "0";
            Queue colaPedidos = new Queue();

            do
            {
                Console.WriteLine("Bienvenido al menú de pedidos. Por favor ingrese la opción que desea realizar:");
                Console.WriteLine("Crer cola de pedidos: 1");
                Console.WriteLine("Borrar cola de pedidos: 2");
                Console.WriteLine("Agregar pedido a la cola: 3");
                Console.WriteLine("Ver lista completa de pedidos: 4");
                Console.WriteLine("Ver el último pedido: 5");
                Console.WriteLine("Ver el primer pedido: 6");
                Console.WriteLine("Ver la cantidad de pedidos: 7");
                Console.WriteLine("Extraer los próximos pedidos: 8");
                Console.WriteLine("Modificar o Eliminar un pedido: 9");
                Console.WriteLine("Salir: 10");
                flag = Console.ReadLine();



                switch (flag)
                {
                    case "1":
                        {
                            if (controlador == 0)
                            {
                                controlador = 1;
                                Console.WriteLine("Se creó la cola de pedidos correctamente");
                                break;
                            }
                            if (controlador == 1)
                            {
                                Console.WriteLine("Ya existe una cola de pedidos creada");
                            }
                            break;
                        }
                    case "2":
                        {
                            if (controlador == 1)
                            {
                                colaPedidos.Clear();
                                controlador = 0;
                                Console.WriteLine("Se borró la cola de pedidos");

                            }
                            else
                            {
                                Console.WriteLine("No existe ninguna cola de pedidos para borrar.");
                            }
                            break;

                        }
                    case "3":
                        {
                            AgregarPedido(ref colaPedidos, controlador);
                            break;
                        }
                    case "4":
                        {
                            VerPedidos(colaPedidos, controlador);
                            break;
                        }
                    case "5":
                        {
                            VerUltimoPedido(colaPedidos, controlador);
                            break;
                        }
                    case "6":
                        {
                            if (controlador == 1)
                            {
                                Console.WriteLine("El primer pedido es el {0}", colaPedidos.Peek());
                            }
                            else
                            {
                                Console.WriteLine("No existe una cola de pedidos.");
                            }
                            break;
                        }
                    case "7":
                        {
                            if (controlador == 1)
                            {
                                int cantidad = colaPedidos.Count;
                                Console.WriteLine("Hay {0} pedidos", cantidad);
                            }
                            else
                            {
                                Console.WriteLine("No existe una cola de pedidos.");
                            }
                            break;
                        }
                    case "8":
                        {
                            if (controlador == 1)
                            {
                                int cantidad_extractor = 0;
                                int cantidad_pedidos = 0;
                                do
                                {
                                    Console.WriteLine("Indique cuántos pedidos desea extraer:");
                                    cantidad_extractor = Convert.ToInt32(Console.ReadLine());
                                    cantidad_pedidos = colaPedidos.Count;
                                    if (cantidad_extractor > cantidad_pedidos)
                                    {
                                        Console.WriteLine("El número indicado excede la cantidad de pedidos en la cola, el cuál es de {0} pedidos", cantidad_pedidos);
                                    }
                                    if (cantidad_extractor <= 0)
                                    {
                                        Console.WriteLine("El número indicado es menor o igual a 0");
                                    }
                                    else
                                    {
                                        ExtraerPedidos(ref colaPedidos, cantidad_extractor);
                                    }
                                } while (cantidad_extractor <= 0 || cantidad_extractor > cantidad_pedidos);
                            }
                            else
                            {
                                Console.WriteLine("No existe una cola de pedidos generada.");
                            }
                            break;
                        }
                    case "9":
                        {
                            if (controlador == 1)
                            {
                                Console.WriteLine("Ingrese el número de pedido que desea modificar o eliminar:");
                                int pedido_buscado = Convert.ToInt32(Console.ReadLine());
                                if (colaPedidos.Contains(pedido_buscado) == false)
                                {
                                    Console.WriteLine("No existe el pedido indicado");
                                }
                                else
                                {
                                    ModificarPedido(ref colaPedidos, pedido_buscado);
                                }

                            }
                            else
                            {
                                Console.WriteLine("No existe una cola de pedidos generada");
                            }
                            break;
                        }
                    case "10":
                        {
                            Console.WriteLine("Adios");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Ingresó una opción inválida");
                            break;
                        }
                }
            } while (flag != "10");
        }
    }
}

