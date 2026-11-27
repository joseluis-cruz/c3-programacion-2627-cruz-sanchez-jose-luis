namespace actividad_4_3;

public class Equipo2
{
    private string _nombre;
    public string Nombre
    {
        get
        {
            return _nombre;
        }
        set
        {
            _nombre = value;
        }        
    }
    private int _jugadores;
    public int Jugadores
    {
        get
        {
            return _jugadores;
        }
        set
        {
            _jugadores = value;
        }        
    }
    public void Fichar(Jugador2 jugador)
    {
        jugador.EquipoJuega = this;
        _jugadores++;
    }
}