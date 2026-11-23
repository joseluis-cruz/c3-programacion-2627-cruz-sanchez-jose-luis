namespace actividad_2_5;

class Program
{
    static void Main(string[] args)
    {
        // primero recabo los datos del usuario en variables locales
        Console.WriteLine("Indique el nombre del producto:");
        string nombre = Console.ReadLine();
        Console.WriteLine("Indique el precio de coste por unidad:");
        double precio_coste = double.Parse(Console.ReadLine());
        Console.WriteLine("Indique la cantidad comprada:");
        int cantidad_comprada = int.Parse(Console.ReadLine());
        Console.WriteLine("Indique el margen de venta, expresado como porcentaje:");
        double margen_venta = double.Parse(Console.ReadLine());
        Console.WriteLine("Indique la cantidad vendida:");
        int cantidad_vendida = int.Parse(Console.ReadLine());
        
        //ahora creo el objeto y asigno su nombre, dejando los datos numéricos a cero
        Producto p1 = new Producto();
        p1.Nombre = nombre;
        p1.CodigoBarras = "";
        p1.Existencias = 0;
        p1.PrecioCoste = 0.0;
        p1.PrecioVenta = 0.0;

        //utilizo los métodos que dice el enunciado para darle los valores a los atributos
        p1.Comprar(cantidad_comprada,precio_coste);
        p1.EstablecerMargen(margen_venta);
        double importe_venta = p1.Vender(cantidad_vendida);

        Console.WriteLine($"El importe total de la venta es: {importe_venta}");
        Console.WriteLine($"Las existencias que quedan en stock son: {p1.Existencias}");


    }
}
