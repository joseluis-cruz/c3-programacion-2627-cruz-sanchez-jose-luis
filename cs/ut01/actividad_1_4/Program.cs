/*
Autor: José Luis Cruz Sánchez
Correo: joseluis.cruz@murciaeduca.es
Proyecto: HolaCS_10_4 para actividad 1.4

*/

// declaración de variables que son los valores de entrada
int a = 2;
int b = 3;

// declaro variable suma, con el valor de a+b
int suma = Sumar(a, b);

// Escribo el resultado
// El "$" antes del literal permite que {suma}...
// ...se reemplace por su valor real cuando se va a imprimir

// Console.WriteLine($"Resultado: {suma}"); Comentada temporalmente

/*
  Este es un ejemplo de función que toma dos valores enteros
  y devuelve la suma de ambos. Realmente no necesitamos esta función,
  pero nos sirve como ejemplo de cómo saltar de un punto a otro del programa.
*/
static int Sumar(int x, int y)
{
    int resultado = x + y;
    return resultado;
}