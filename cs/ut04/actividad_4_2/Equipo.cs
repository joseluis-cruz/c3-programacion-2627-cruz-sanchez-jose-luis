namespace actividad_4_2;

public class Equipo
{
    public string Nombre;
    public int Jugadores;
    public void Fichar(Jugador jugador)
    {
        jugador.EquipoJuega = this;
        Jugadores++;
    }
}