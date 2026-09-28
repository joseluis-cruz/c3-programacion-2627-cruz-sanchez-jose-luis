int a = 2;
int b = 3;

int suma = Sumar(a, b);

Console.WriteLine($"Resultado: {suma}");

static int Sumar(int x, int y)
{
    int resultado = x + y;
    return resultado;
}