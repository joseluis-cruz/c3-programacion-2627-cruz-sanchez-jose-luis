namespace PersonasYMascotas;

class Program
{
    static void Main(string[] args)
    {
        Persona persona = new Persona();
        persona.nombre = "Ana";
        persona.telefono = "600123456";

        Mascota mascota = new Mascota();
        mascota.nombre = "Luna";
        mascota.raza = "Labrador";
        mascota.propietario = persona;

        Console.WriteLine($"{mascota.nombre} pertenece a {mascota.propietario.nombre}");
        Console.WriteLine($"Teléfono: {mascota.propietario.telefono}");        
    }
}
