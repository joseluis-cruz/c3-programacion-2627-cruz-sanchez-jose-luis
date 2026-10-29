namespace actividad_2_4;

class Jugador
{
    public string nombre;
    public string apodo;
    public Equipo equipo; // referencia al objeto "Equipo" en el que juega
    public int dorsal; //número de dorsal en el equipo

    public string GetNombreCorto()
    {
        string nombre_corto;
        if (apodo!="")
        {
            nombre_corto = apodo;
        }
        else
        {
            nombre_corto = nombre;
        }
        return nombre_corto;
    }

    public string GetNombreEquipo()
    {
        return equipo.nombre;
    }
    
}