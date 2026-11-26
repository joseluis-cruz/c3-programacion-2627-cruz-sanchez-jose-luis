namespace actividad_4_2;

public class Jugador
{
    public string Nombre;
    public string Apodo;
    public Equipo EquipoJuega; // referencia al objeto "Equipo" en el que juega
    public int Dorsal; //número de dorsal en el equipo

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