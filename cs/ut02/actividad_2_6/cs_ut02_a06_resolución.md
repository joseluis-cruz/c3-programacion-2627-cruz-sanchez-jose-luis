# UT02 · Programación en C# — Tanda 6

# Resolución razonada: implementación y uso de la clase `Libro`

> **Código fuente:** Esta guía reconstruye **paso a paso** la evolución desde un proyecto en blanco hasta la solución desarrollada en clase. Los fragmentos de cada etapa están pensados para comprenderlos y transcribirlos progresivamente.

## 1. ¿Qué queremos construir?

Vamos a representar ejemplares de una biblioteca mediante una clase `Libro`. Cada ejemplar recordará su título, autor, estado, número de préstamos y el identificador del último cliente que lo tomó prestado. Desde el programa principal crearemos dos objetos y realizaremos operaciones sobre ellos, mostrando cómo cambia su estado.

Esta actividad es un refuerzo de la **UT02** y una preparación para la **UT04**: definición de clases, atributos, métodos, creación y uso de objetos.

## 2. Crear el proyecto de consola

Desde el directorio `src/ut02/actividad_2_6/` del repositorio ejecutamos:

```bash
dotnet new console -n actividad_2_6 --use-program-main
cd actividad_2_6
```

El parámetro `-n` establece el nombre del proyecto y crea su directorio. `--use-program-main` genera una clase `Program` con un método `Main()` explícito, en lugar de instrucciones de nivel superior.

El comando crea otra carpeta `actividad_2_6` dentro de la carpeta del mismo nombre. La ubicación final será `src/ut02/actividad_2_6/actividad_2_6/`:

```text
actividad_2_6/
└── actividad_2_6/
    ├── actividad_2_6.csproj
    └── Program.cs
```

El archivo `Program.cs` tendrá inicialmente una estructura semejante a esta:

```csharp
namespace actividad_2_6;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
```

**Comprobación:** ejecuta `dotnet run` desde el directorio del proyecto. Después elimina la instrucción que muestra `Hello, World!`, dejando vacío el cuerpo de `Main()`.

## 3. Definir la clase `Libro`

### 3.1. Crear un archivo independiente

Creamos `Libro.cs` junto a `Program.cs` y escribimos:

```csharp
namespace actividad_2_6;

public class Libro
{
}
```

Los dos archivos pertenecen al mismo proyecto y al mismo espacio de nombres (`namespace`). El proyecto de .NET incluye los archivos `.cs` de forma predeterminada, por lo que no necesitamos enlazarlos manualmente ni añadir una directiva `using` específica para utilizar `Libro` desde `Program.cs`.

### 3.2. Declarar los atributos

Dentro de las llaves de la clase incorporamos:

```csharp
    public string Titulo;
    public string Autor;
    public int IdCliente;
    public int VecesPrestado;
    public string Estado;
```

| Atributo | Tipo | Información que recuerda |
|---|---|---|
| `Titulo` | `string` | Título del ejemplar |
| `Autor` | `string` | Autor |
| `IdCliente` | `int` | Identificador del último cliente; inicialmente 0 |
| `VecesPrestado` | `int` | Número de préstamos |
| `Estado` | `string` | `"P"`, `"D"` o `"N"` |

Los atributos son públicos (`public`) para poder acceder a ellos desde el programa principal. Sus nombres siguen la convención PascalCase utilizada en nuestras actividades.

> **DEBES SABER:** Una clase define qué información y operaciones tendrán sus objetos. Cada objeto tiene sus propios valores de los atributos, aunque todos compartan la misma definición de clase.

## 4. Implementar los métodos de la clase

Añadimos los siguientes métodos dentro de `Libro`, después de los atributos.

### 4.1. Comprar un ejemplar: `Comprar()`

Cuando incorporamos un ejemplar a la biblioteca, debe quedar disponible, sin préstamos anteriores ni cliente asociado.

```csharp
    public void Comprar()
    {
        Estado = "D";
        VecesPrestado = 0;
        IdCliente = 0;
    }
```

No necesita parámetros porque todos los valores iniciales son conocidos. `void` indica que no devuelve ningún valor. No modifica el título ni el autor: esos datos se asignarán desde `Main()`.

### 4.2. Prestar un ejemplar: `Prestar(int cliente)`

Para realizar un préstamo necesitamos conocer el identificador del cliente. El método recibe ese dato como parámetro:

```csharp
    public void Prestar(int cliente)
    {
        Estado = "P";
        IdCliente = cliente;
        VecesPrestado++;
    }
```

Primero marcamos el ejemplar como prestado, después recordamos quién lo tiene y finalmente incrementamos el contador. `VecesPrestado++` equivale a incrementar su valor en una unidad.

### 4.3. Devolver un ejemplar: `Devolver()`

Al devolverlo queremos que vuelva a estar disponible y conocer el identificador del cliente que lo tenía.

```csharp
    public int Devolver()
    {
        Estado = "D";
        return IdCliente;
    }
```

No necesitamos recibir parámetros: el objeto ya recuerda el identificador. El tipo de retorno `int` indica que el método devuelve un entero mediante `return`.

**Importante:** no ponemos `IdCliente` a cero ni decrementamos `VecesPrestado`. El ejemplar debe conservar el historial del último cliente y el número de préstamos realizados.

### 4.4. Retirar un ejemplar: `Retirar()`

Un ejemplar puede marcarse como no disponible, pero no mientras esté prestado. Utilizamos una condición para distinguir ambos casos:

```csharp
    public void Retirar()
    {
        if (Estado=="P")
        {
            throw new Exception ("El libro está prestado y no puede marcarse como no disponible mientras no se devuelva");
        }
        else
        {
            Estado = "N";
        }
    }
```

`==` compara el estado actual con `"P"`. Si está prestado, `throw` lanza una excepción y el estado permanece intacto. En caso contrario, se asigna `"N"`.

> **DEBES SABER:** Lanzar una excepción no es lo mismo que mostrar un mensaje por consola. La excepción interrumpe la ejecución normal del método y puede ser capturada mediante `try-catch`, como vimos en la UT03. En esta solución no añadimos una captura porque el recorrido previsto no intenta retirar un ejemplar prestado.

### 4.5. Describir el estado: `DescribeEstado()`

Queremos obtener un texto que reúna la información del ejemplar sin tener que construirlo cada vez desde el programa principal:

```csharp
    public string DescribeEstado()
    {
        return $"El ejemplar titulado {Titulo} se encuentra en estado {Estado} y vinculado al cliente con id {IdCliente}";
    }
```

El prefijo `$` permite interpolar los valores de los atributos dentro de la cadena, mediante las llaves. El método devuelve un `string`, no lo imprime. Así podemos utilizarlo desde `Console.WriteLine()`.

## 5. Desarrollar el programa principal

A partir de aquí escribimos las instrucciones dentro de `Main()` en `Program.cs`, en el orden indicado.

### 5.1. Recabar los datos de los dos ejemplares

```csharp
Console.WriteLine("LIBRO 1 - Introduzca el título");
string libro1Titulo = Console.ReadLine();
Console.WriteLine("LIBRO 1 - Introduzca el autor");
string libro1Autor = Console.ReadLine();
Console.WriteLine("LIBRO 2 - Introduzca el título");
string libro2Titulo = Console.ReadLine();
Console.WriteLine("LIBRO 2 - Introduzca el autor");
string libro2Autor = Console.ReadLine();
```

`Console.ReadLine()` obtiene el texto introducido. Las cuatro variables son locales a `Main()` y todavía no hemos creado ningún objeto.

### 5.2. Crear e inicializar los objetos

```csharp
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
```

`Libro l1` declara una variable de tipo `Libro`; `new Libro()` crea el objeto. Con el operador punto accedemos a sus atributos y métodos. Repetimos el proceso con `l2`, que representa otro ejemplar independiente.

Asignamos título y autor y utilizamos `Comprar()` para inicializar los demás atributos. Después de cada compra mostramos el estado devuelto por `DescribeEstado()`.

**Comprobación:** ejecuta el programa. Los dos ejemplares deben aparecer disponibles (`D`) y vinculados al cliente `0`.

### 5.3. Retirar el primer ejemplar

```csharp
l1.Retirar();
Console.WriteLine(l1.DescribeEstado()); // nos pide el enunciado que lo hagamos tras usar cualquier método de la clase libro
```

Como `l1` está disponible, `Retirar()` cambia su estado a `N`. El segundo ejemplar no se modifica.

### 5.4. Prestar el segundo ejemplar

```csharp
Console.WriteLine("Indique el cliente a prestar");
int idCliente = int.Parse(Console.ReadLine());
//... y préstale el segundo ejemplar mediante el método Prestar().
l2.Prestar(idCliente);
Console.WriteLine(l2.DescribeEstado()); // nos pide el enunciado que lo hagamos tras usar cualquier método de la clase libro
```

Convertimos la cadena introducida a entero mediante `int.Parse()` y pasamos ese valor al método `Prestar()`. El objeto `l2` queda prestado, recuerda el cliente y su contador aumenta a uno.

### 5.5. Devolver el segundo ejemplar

```csharp
l2.Devolver();
Console.WriteLine(l2.DescribeEstado()); // nos pide el enunciado que lo hagamos tras usar cualquier método de la clase libro
```

El método `Devolver()` cambia el estado a `D` y devuelve el identificador. En el programa de referencia no necesitamos guardar ese valor de retorno, pero el método permite hacerlo si queremos comprobar quién tenía el ejemplar. El identificador sigue almacenado en el objeto.

> **DEBES SABER:** En `Console.WriteLine(l2.DescribeEstado());` se ejecuta primero `DescribeEstado()` y el texto que devuelve se utiliza como argumento de `Console.WriteLine()`.

## 6. Comprobar el funcionamiento

Ejecutamos `dotnet run` e introducimos, por ejemplo, `Don Quijote`, `Miguel de Cervantes`, `La isla del tesoro`, `Robert Louis Stevenson` y, cuando se solicite, el identificador `123`.

La evolución esperada es:

| Operación | Objeto | Estado | IdCliente | VecesPrestado |
|---|---|---|---:|---:|
| Comprar | `l1` | D | 0 | 0 |
| Comprar | `l2` | D | 0 | 0 |
| Retirar | `l1` | N | 0 | 0 |
| Prestar | `l2` | P | 123 | 1 |
| Devolver | `l2` | D | 123 | 1 |

Los mensajes de estado que esperamos obtener (sin incluir las preguntas del programa) son:

```text
El ejemplar titulado Don Quijote se encuentra en estado D y vinculado al cliente con id 0
El ejemplar titulado La isla del tesoro se encuentra en estado D y vinculado al cliente con id 0
El ejemplar titulado Don Quijote se encuentra en estado N y vinculado al cliente con id 0
El ejemplar titulado La isla del tesoro se encuentra en estado P y vinculado al cliente con id 123
El ejemplar titulado La isla del tesoro se encuentra en estado D y vinculado al cliente con id 123
```

**Comprobación adicional:** si quieres comprobar la excepción, introduce temporalmente `l2.Retirar();` justo después de mostrar el estado del segundo ejemplar prestado y antes de devolverlo. Debe lanzarse la excepción indicada en el enunciado. Elimina esa instrucción después de la prueba para recuperar el programa final.

## 7. Código final de referencia

### `Libro.cs`

```csharp
namespace actividad_2_6;

public class Libro
{
    public string Titulo; // Título del libro.
    public string Autor; // Nombre del autor.
    public int IdCliente; // Identificador del último cliente que ha tomado prestado el ejemplar. Inicialmente será 0.
    public int VecesPrestado; // Número de veces que se ha prestado el ejemplar.
    public string Estado; // Estado del ejemplar: "P" (prestado), "D" (disponible) o "N" (no disponible).    

    // Inicializa el estado del ejemplar a "D" (disponible) y los atributos VecesPrestado e IdCliente a cero.
    public void Comprar() 
    {
        Estado = "D";
        VecesPrestado = 0;
        IdCliente = 0;
    }

    // Cambia el estado del ejemplar a "P" (prestado), almacena en el atributo IdCliente el identificador del cliente...
    // ... recibido e incrementa en una unidad el contador VecesPrestado.
    public void Prestar(int cliente) 
    {
        Estado = "P";
        IdCliente = cliente;
        VecesPrestado++;                        
    }

    // Cambia el estado del ejemplar a "D" (disponible) y devuelve el identificador del cliente....
    //  ...que lo tenía prestado, para permitir comprobar que realmente lo tenía ese cliente, sin modificar el atributo IdCliente.
    public int Devolver()     
    {
        Estado = "D";
        return IdCliente;
    }

    // Cambia el estado del ejemplar a "N" (no disponible), salvo que actualmente esté prestado ("P"). En ese caso, deberá lanzar...
    // ... una excepción con el mensaje indicado a continuación, sin modificar su estado.
    public void Retirar() 
    {
        if (Estado=="P")
        {
            throw new Exception ("El libro está prestado y no puede marcarse como no disponible mientras no se devuelva");
        }
        else
        {
            Estado = "N";            
        }
    }
    
    // Devuelve una cadena de caracteres que describe el estado actual del ejemplar, incluyendo su título, su estado y...
    // ... el identificador del cliente, siguiendo el formato indicado a continuación.
    public string DescribeEstado() 
    {
        return $"El ejemplar titulado {Titulo} se encuentra en estado {Estado} y vinculado al cliente con id {IdCliente}";
    }

}
```

### `Program.cs`

```csharp
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
```

## 8. Qué hemos aprendido

- **Clases y objetos:** una misma clase permite crear ejemplares independientes.
- **Atributos:** cada objeto conserva su propia información.
- **Métodos y parámetros:** podemos modificar los atributos mediante operaciones que reciben datos externos.
- **Valores de retorno:** `Devolver()` devuelve un entero y `DescribeEstado()` devuelve una cadena.
- **Condiciones y excepciones:** `Retirar()` evita un cambio de estado no permitido.
- **Separación de responsabilidades:** `Libro` gestiona sus datos y `Main()` se ocupa de interactuar con el usuario y utilizar los objetos.

**Limitación consciente:** la solución no incorpora validaciones adicionales para los préstamos, las devoluciones o la entrada de datos, pues no forman parte de las especificaciones de esta actividad.

## 9. Entrega

Una vez comprobado el funcionamiento, realiza un único commit con la descripción:

```text
UT02A06 - Implementación y uso de la clase 'Libro'
```
