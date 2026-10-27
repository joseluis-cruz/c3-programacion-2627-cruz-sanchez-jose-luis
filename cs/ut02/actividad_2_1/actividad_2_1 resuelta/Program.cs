namespace actividad_2_1;
/* La línea using sirve para incluir esa librería en este programa y que,
   si aparece alguna referencia a una clase de esta librería, el programa
   la reconozca y no de error */
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

    cronometro.Start(); //método Start de la clase Stopwatch

    Console.WriteLine("Pulsa INTRO lo más rápido posible...");
    Console.ReadLine(); 

    cronometro.Stop(); //método Stop de la clase Stopwatch
    // Elapsed es un atributo, porque carece de paréntesis
    TimeSpan ts = cronometro.Elapsed;
    int segundos = ts.Seconds;
    int milisec = ts.Milliseconds;    

    Console.WriteLine($"Has tardado {segundos} s. y {milisec} ms.");
  }
}
