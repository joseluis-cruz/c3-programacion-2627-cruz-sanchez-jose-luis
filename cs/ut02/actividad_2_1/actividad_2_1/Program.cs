namespace actividad_2_1;
using System.Diagnostics;

class Program
{
  static void Main(string[] args)
  {

    Stopwatch cronometro = new Stopwatch();

    cronometro.Start();

    Console.WriteLine("Pulsa INTRO lo más rápido posible...");
    Console.ReadLine();

    cronometro.Stop();

    Console.WriteLine($"Has tardado {cronometro.ElapsedMilliseconds} ms");
  }
}
