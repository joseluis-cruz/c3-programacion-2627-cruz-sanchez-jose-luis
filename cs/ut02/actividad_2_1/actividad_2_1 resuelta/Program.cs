namespace actividad_2_1;
using System.Diagnostics;

class Program
{
  static void Main(string[] args)
  {
    /* Aquí aparece la clase "Stopwatch", de la cual se
    está declarando un objeto "cronometro" y, al mismo tiempo,
    se le está asignando un objeto de esa misma clase para
    poder utilizarlo*/
    Stopwatch cronometro = new Stopwatch();

    cronometro.Start(); 

    Console.WriteLine("Pulsa INTRO lo más rápido posible...");
    Console.ReadLine();

    Console.WriteLine($"Has tardado {cronometro.ElapsedMilliseconds} ms");
  }
}
