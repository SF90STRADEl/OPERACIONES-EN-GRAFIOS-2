using System;

class Program
{
    static Grafo grafo;

    static void Main()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\nMENÚ GRAFO");
            Console.WriteLine("1. Crear grafo");
            Console.WriteLine("2. Agregar nodo");
            Console.WriteLine("3. Agregar arista");
            Console.WriteLine("4. Mostrar estructura");
            Console.WriteLine("5. Recorrido BFS");
            Console.WriteLine("6. Recorrido DFS");
            Console.WriteLine("7. Salir");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("¿Grafo dirigido? (s/n): ");
                    grafo = new Grafo(Console.ReadLine().ToLower() == "s");
                    Console.WriteLine("Grafo creado!");
                    break;

                case "2":
                    Console.Write("Valor del nodo: ");
                    if (int.TryParse(Console.ReadLine(), out int nodo))
                    {
                        grafo?.AgregarNodo(nodo);
                        Console.WriteLine("Nodo agregado");
                    }
                    else Console.WriteLine("Valor inválido");
                    break;

                case "3":
                    if (grafo == null) break;
                    Console.Write("Origen: ");
                    int origen = LeerEntero();
                    Console.Write("Destino: ");
                    int destino = LeerEntero();
                    if (origen != -1 && destino != -1)
                    {
                        grafo.AgregarArista(origen, destino);
                        Console.WriteLine("Arista agregada");
                    }
                    break;

                case "4":
                    grafo?.MostrarGrafo();
                    break;

                case "5":
                    if (grafo != null)
                    {
                        Console.Write("Nodo inicial: ");
                        int inicioBfs = LeerEntero();
                        if (inicioBfs != -1)
                            Console.WriteLine("BFS: " + string.Join(" -> ", grafo.BFS(inicioBfs)));
                    }
                    break;

                case "6":
                    if (grafo != null)
                    {
                        Console.Write("Nodo inicial: ");
                        int inicioDfs = LeerEntero();
                        if (inicioDfs != -1)
                            Console.WriteLine("DFS: " + string.Join(" -> ", grafo.DFS(inicioDfs)));
                    }
                    break;

                case "7":
                    salir = true;
                    break;
            }
        }
    }

    static int LeerEntero()
    {
        return int.TryParse(Console.ReadLine(), out int valor) ? valor : -1;
    }
}