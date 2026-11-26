namespace actividad_4_2;

public class Jugador2
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
    private string _apodo;
    public string Apodo
    {
        get
        {
            return _apodo;
        }
        set
        {
            _apodo = value;
        }
    }    
    private Equipo2 _equipoJuega; // referencia al objeto "Equipo" en el que juega
    public Equipo2 EquipoJuega
    {
        get
        {
            return _equipoJuega;
        }
        set
        {
            _equipoJuega = value;
        }
    }    
    private int _dorsal; //número de dorsal en el equipo
    public int Dorsal
    {
        get
        {
            return _dorsal;
        }
        set
        {
            _dorsal = value;
        }
    }

    public string GetNombreCorto()
    {
        string nombre_corto;
        if (Apodo!="")
        {
            nombre_corto = Apodo;
        }
        else
        {
            nombre_corto = Nombre;
        }
        return nombre_corto;
    }

    public string GetNombreEquipo()
    {
        if (EquipoJuega!=null)
        {
            return EquipoJuega.Nombre;
        }
        else
        {
            return "<<sin equipo>>";
        }
    }
    
}