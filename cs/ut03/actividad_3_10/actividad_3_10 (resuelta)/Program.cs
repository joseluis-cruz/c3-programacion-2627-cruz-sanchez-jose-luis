namespace actividad_3_10;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Escribe una palabra y yo me encargaré de acortarla hasta que quede en nada:");
        string palabra = Console.ReadLine();
        //PROFESOR::usa un bucle do-while para cumplir con el enunciado
        do
        {
            Console.WriteLine(palabra);
            // quito el último carácter copiando desde el primer (0) hasta su longitud menos uno
            palabra = palabra.Substring(0, palabra.Length - 1);            
        }
        while (palabra != "");
    }
}
