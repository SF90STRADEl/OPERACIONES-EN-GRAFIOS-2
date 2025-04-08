using System.Collections.Generic;

public class Grafo
{
    private Dictionary<int, Nodo> nodos;
    private bool esDirigido;

    public Grafo(bool dirigido)
    {
        nodos = new Dictionary<int, Nodo>();
        esDirigido = dirigido;
    }

    public void AgregarNodo(int valor)
    {
        if (!nodos.ContainsKey(valor))
            nodos[valor] = new Nodo(valor);
    }

    public void AgregarArista(int origen, int destino)
    {
        if (!nodos.ContainsKey(origen)) AgregarNodo(origen);
        if (!nodos.ContainsKey(destino)) AgregarNodo(destino);

        nodos[origen].Vecinos.Add(nodos[destino]);
        if (!esDirigido) nodos[destino].Vecinos.Add(nodos[origen]);
    }

    public List<int> BFS(int inicio)
    {
        var recorrido = new List<int>();
        if (!nodos.ContainsKey(inicio)) return recorrido;

        var cola = new Queue<Nodo>();
        var visitados = new HashSet<int>();
        cola.Enqueue(nodos[inicio]);
        visitados.Add(inicio);

        while (cola.Count > 0)
        {
            Nodo actual = cola.Dequeue();
            recorrido.Add(actual.Valor);

            foreach (Nodo vecino in actual.Vecinos)
                if (visitados.Add(vecino.Valor))
                    cola.Enqueue(vecino);
        }
        return recorrido;
    }

    public List<int> DFS(int inicio)
    {
        var recorrido = new List<int>();
        if (!nodos.ContainsKey(inicio)) return recorrido;

        var pila = new Stack<Nodo>();
        var visitados = new HashSet<int>();
        pila.Push(nodos[inicio]);
        visitados.Add(inicio);

        while (pila.Count > 0)
        {
            Nodo actual = pila.Pop();
            recorrido.Add(actual.Valor);

            foreach (Nodo vecino in actual.Vecinos)
                if (visitados.Add(vecino.Valor))
                    pila.Push(vecino);
        }
        return recorrido;
    }

    public void MostrarGrafo()
    {
        foreach (var par in nodos)
            Console.WriteLine($"{par.Key} -> {string.Join(", ", par.Value.Vecinos.Select(v => v.Valor))}");
    }
}