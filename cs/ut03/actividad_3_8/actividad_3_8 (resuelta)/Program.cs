namespace actividad_3_8;

class Program
{
    static void Main(string[] args)
    {
        const int NUMERO_MIN = 2;
        const int NUMERO_MAX = 10000;

        Console.WriteLine("Selecciona un número positivo (no mayor de 10000) y yo te diré sus divisores:");
        int numero = int.Parse(Console.ReadLine());
        Console.WriteLine($"Los divisores de {numero} son:");
        int test_divisor = numero-1; // corrijo esto para no detectar al propio número como divisor de sí mismo
        /* PROFESOR::usando un bucle while, completa el programa para que en cada paso reste 1 a test_divisor
           y compruebe si test_divisor es divisor del número introducido. Si lo es, muéstralo por pantalla.
           El bucle debe terminar cuando test_divisor sea igual a 2, ya que el 1 divide a cualquiera y no se considera un divisor propio.
        */
        if (numero<NUMERO_MIN || numero>NUMERO_MAX)
        {
            Console.WriteLine($"El número debe estar entre {NUMERO_MIN} y {NUMERO_MAX}");            
        }
        else // ahora sí, me he garantizado que el número está entre 2 y 10000
        {
            int contador_divisores = 0;
            while (test_divisor>=NUMERO_MIN)
            {
                //Compruebo si "test_divisor" divide o no a "numero"
                if (numero % test_divisor == 0) // si el resto de la división es cero, es divisble
                {
                    contador_divisores++;
                    Console.WriteLine($"El número {test_divisor} es divisor de {numero}");
                }
                //Finalizo restando 1 a test_divisor
                test_divisor--;
            }   
            Console.WriteLine($"Se han encontrado {contador_divisores} divisores");         
        }
    }
}
