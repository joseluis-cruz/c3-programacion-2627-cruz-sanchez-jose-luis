namespace actividad_2_3;

class Program
{
    static void Main(string[] args)
    {
        NombresPersona n1 = new NombresPersona();
        n1.tratamiento = "Sr.";
        n1.apellido1 = "Pérez";
        n1.apellido2 = "Sánchez";
        n1.nombre = "Manuel";
        Console.WriteLine(n1.NombreCompleto());
    }
}

class NombresPersona
{
    public string tratamiento;
    public string nombre;
    public string apellido1;
    public string apellido2;

    public string NombreCompleto()
    {
        return nombre + " " + apellido1 + " "+ apellido2;
    }
}
