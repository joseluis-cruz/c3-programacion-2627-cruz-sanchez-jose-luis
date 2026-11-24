namespace actividad_2_6;

class Program
{
    static void Main(string[] args)
    {
        //Solicita al usuario el título y el autor de cada uno de los dos ejemplares, almacenando los datos introducidos en variables locales.
        Console.WriteLine("LIBRO 1 - Introduzca el título");
        string libro1Titulo = Console.ReadLine();
        Console.WriteLine("LIBRO 1 - Introduzca el autor");
        string libro1Autor = Console.ReadLine();
        Console.WriteLine("LIBRO 2 - Introduzca el título");
        string libro2Titulo = Console.ReadLine();
        Console.WriteLine("LIBRO 2 - Introduzca el autor");
        string libro2Autor = Console.ReadLine();

        //Declara y crea los dos objetos (l1 y l2) de la clase Libro, asignando valores iniciales coherentes a sus atributos y haciendo uso del método Comprar().
        Libro l1 = new Libro();
        l1.Titulo = libro1Titulo;
        l1.Autor = libro1Autor;
        l1.Comprar();
        Console.WriteLine(l1.DescribeEstado()); // nos pide el enunciado que lo hagamos tras usar cualquier método de la clase libro
        Libro l2 = new Libro();
        l2.Titulo = libro2Titulo;
        l2.Autor = libro2Autor;
        l2.Comprar();
        Console.WriteLine(l2.DescribeEstado()); // nos pide el enunciado que lo hagamos tras usar cualquier método de la clase libro

        //Marca el primer ejemplar como no disponible, mediante una invocación al método Retirar().
        l1.Retirar();
        Console.WriteLine(l1.DescribeEstado()); // nos pide el enunciado que lo hagamos tras usar cualquier método de la clase libro

        //Solicita al usuario el identificador numérico de un cliente...
        Console.WriteLine("Indique el cliente a prestar");
        int idCliente = int.Parse(Console.ReadLine());
        //... y préstale el segundo ejemplar mediante el método Prestar().
        l2.Prestar(idCliente);
        Console.WriteLine(l2.DescribeEstado()); // nos pide el enunciado que lo hagamos tras usar cualquier método de la clase libro
        
        //Devuelve el segundo ejemplar mediante una invocación al método Devolver().        
        l2.Devolver();
        Console.WriteLine(l2.DescribeEstado()); // nos pide el enunciado que lo hagamos tras usar cualquier método de la clase libro
    }
}
