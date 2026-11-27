namespace actividad_4_3;

public class Jugador3
{
    public string Nombre {get; set;}
    public string Apodo {get; set;}
    public Equipo3 EquipoJuega {get; private set;}
    public int Dorsal {get; set;}

    public void FicharPor(Equipo3 equipo)
    {
        EquipoJuega = equipo;
    }

    public string NombreCorto
    {
        get
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
    }

    public string NombreEquipo
    {
        get
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
    
}