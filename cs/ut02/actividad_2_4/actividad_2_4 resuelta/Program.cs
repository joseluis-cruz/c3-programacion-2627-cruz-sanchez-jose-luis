namespace actividad_2_4;

class Program
{
    static void Main(string[] args)
    {
        Equipo e1 = new Equipo();
        e1.nombre ="Futbooleanos";

        Jugador j1 = new Jugador();
        j1.nombre = "Marcelo";
        j1.dorsal = 12;
        j1.apodo = "";
        //j1.equipo = e1;
        Console.WriteLine($"{j1.GetNombreCorto()} juega en el equipo {j1.GetNombreEquipo()}");
    }
}
