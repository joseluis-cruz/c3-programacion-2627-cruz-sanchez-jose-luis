using System.Numerics;

namespace test_Vectores;

class Program
{
    static void Main(string[] args)
    {
        Vector2D v1, v2; // una forma abreviada de declarar dos referencias a objetos de la misma clase

        v1 = new Vector2D();
        v2 = new Vector2D();

        v1.x = 4;
        v1.y = 3;

        v2.x = -4;
        v2.y = -3;

        Console.WriteLine($"Tenemos dos vectores v1({v1.x},{v1.y}) y v2({v2.x},{v2.y})");

        double mod_v1 = v1.Modulo();
        Console.WriteLine($"El módulo de v1 es {mod_v1}"); // podría haber puesto {v1.Modulo()} directamente aquí, sin declarar mod_v1

        v2.Invertir();
        Console.WriteLine($"El vector v2 tras invertirlo es ({v2.x},{v2.y})");

        if (v1.EsIgualA(v2))
        {
            Console.WriteLine("Los dos vectores son iguales");
        }
        else
        {
            Console.WriteLine("Los dos vectores son diferentes");
        }


    }
}
