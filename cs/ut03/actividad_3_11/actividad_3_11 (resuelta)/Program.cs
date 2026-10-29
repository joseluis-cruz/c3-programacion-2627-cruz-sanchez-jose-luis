namespace actividad_3_11;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Voy a mostrarte la tabla de multiplicar del número que me digas!");
        try
        {
            int numero = int.Parse(Console.ReadLine());
            //::PROFESOR:: Agregar un ciclo for para mostrar la tabla de multiplicar del número introducido
            //::PROFESOR:: El resultado será, para cada línea "{numero} x {i} = {numero * i}"
            //::PROFESOR:: Ejemplo: "5 x 1 = 5" ; "5 x 2 = 10" ; "5 x 3 = 15" ; ... ; "5 x 10 = 50")
            if (numero>=1 && numero<=10)
            {
                for (int i=1;i<=10;i++)
                {
                    int resultado = numero*i;
                    Console.WriteLine($"{numero} x {i} = {resultado}");
                }
            }
            else
            {
                Console.WriteLine("El número indicado debe estar entre 1 y 10");
            }
        }
        catch
        {
            Console.WriteLine("Debes introducir un número válido");
        }
    }
}
