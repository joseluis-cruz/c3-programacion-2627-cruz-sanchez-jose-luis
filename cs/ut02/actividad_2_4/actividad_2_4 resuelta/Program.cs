namespace actividad_2_4;

class Program
{
    static void Main(string[] args)
    {
        Jugador j1 = new Jugador();
        j1.nombre = "Marcelo";
        j1.dorsal = 12;
        j1.apodo = "";
        Console.WriteLine(j1.GetNombreCorto());
    }
}
