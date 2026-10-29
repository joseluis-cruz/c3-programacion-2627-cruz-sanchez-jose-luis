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

        Jugador j2 = new Jugador();
        j2.nombre = "Macario";
        j2.dorsal = 13;
        j2.apodo = "Maca";

        e1.Fichar(j1);
        e1.Fichar(j2);

        Console.WriteLine($"{j1.GetNombreCorto()} juega en el equipo {j1.GetNombreEquipo()}");
        Console.WriteLine($"{j2.GetNombreCorto()} juega en el equipo {j2.GetNombreEquipo()}");
        Console.WriteLine($"El equipo {e1.nombre} tiene fichados {e1.jugadores} jugadores.");
    }
}
