public class Nodo
{
    public int Valor { get; set; }
    public List<Nodo> Vecinos { get; set; }

    public Nodo(int valor)
    {
        Valor = valor;
        Vecinos = new List<Nodo>();
    }
}