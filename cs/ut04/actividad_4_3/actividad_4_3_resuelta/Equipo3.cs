namespace actividad_4_3;

public class Equipo3
{
    public string Nombre {get; set;}
    public int Jugadores {get; private set;}
    public void Fichar(Jugador3 jugador)
    {
        jugador.FicharPor(this);
        Jugadores++;
    }
}