# UT02 · Programación en C# — Tanda 5

# Resolución razonada: implementación y uso de la clase `Producto`

> **Código fuente:** Esta guía reconstruye **paso a paso** la evolución desde un proyecto en blanco hasta la solución desarrollada en clase. Los fragmentos de cada etapa están pensados para comprenderlos y transcribirlos progresivamente.

## 1. ¿Qué queremos construir?

Vamos a representar un producto mediante una clase que recuerde su nombre, código de barras, existencias y precios. El programa principal solicitará los datos de una compra y una venta, utilizará los métodos del objeto y mostrará el importe de la venta y las existencias restantes.

Esta actividad es un refuerzo de la **UT02** y una preparación para la **UT04**: definición de clases, atributos, métodos, creación y uso de objetos.

## 2. Crear el proyecto de consola

Desde el directorio `src/ut02/actividad_2_5/` del repositorio ejecutamos:

```bash
dotnet new console -n actividad_2_5 --use-program-main
cd actividad_2_5
```

El parámetro `-n` establece el nombre del proyecto y, al no indicar otra ubicación, crea su directorio. `--use-program-main` hace que se genere una clase `Program` con un método `Main()` explícito, en lugar de instrucciones de nivel superior.

El comando crea una nueva carpeta `actividad_2_5` dentro de la carpeta del mismo nombre desde la que lo ejecutamos. Por tanto, la ubicación final del proyecto será `src/ut02/actividad_2_5/actividad_2_5/`, con la siguiente estructura:

```text
actividad_2_5/
└── actividad_2_5/
    ├── actividad_2_5.csproj
    └── Program.cs
```

El archivo `Program.cs` tendrá inicialmente una estructura semejante a esta:

```csharp
namespace actividad_2_5;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
```

**Comprobación:** ejecuta `dotnet run` desde el directorio del proyecto. Después elimina la instrucción que muestra `Hello, World!`, dejando vacío el cuerpo de `Main()`.

## 3. Definir la clase `Producto`

### 3.1. Crear un archivo independiente

Creamos `Producto.cs` junto a `Program.cs` y escribimos:

```csharp
namespace actividad_2_5;

public class Producto
{
    public string Nombre; // Descripción del producto
    public string CodigoBarras; //Código de barras del producto.
    public int Existencias; // Número de unidades disponibles.
    public double PrecioCoste; // Precio de coste por unidad.
    public double PrecioVenta; //Precio de venta por unidad.


    public void Comprar(int cantidad, double precio) // Incrementa Existencias en la cantidad indicada y establece PrecioCoste con el valor recibido en precio.
    {
        PrecioCoste = precio;
        Existencias += cantidad;
    }
    public double Vender(int cantidad) // Descuenta la cantidad indicada de Existencias y devuelve el importe total de la venta, calculado como cantidad * PrecioVenta.
    {
        Existencias -= cantidad;        
        return cantidad*PrecioVenta;
    }
    public void EstablecerMargen(double porcentaje) // Calcula y actualiza PrecioVenta aplicando el incremento porcentual indicado sobre el valor actual de PrecioCoste.
    {
        PrecioVenta = PrecioCoste * (1 + (porcentaje / 100));
    }
    
}
```

Ambos archivos pertenecen al mismo proyecto y al mismo espacio de nombres (`namespace`). Por ello podemos utilizar `Producto` desde `Program.cs` sin añadir una directiva `using` específica ni enlazar manualmente los archivos: el proyecto de .NET incluye los archivos `.cs` de forma predeterminada.

### 3.2. Declarar los atributos

Dentro de la clase incorporamos:

```csharp
public string Nombre;
public string CodigoBarras;
public int Existencias;
public double PrecioCoste;
public double PrecioVenta;
```

| Atributo | Tipo | Información que recuerda |
|---|---|---|
| `Nombre` | `string` | Nombre del producto |
| `CodigoBarras` | `string` | Código de barras, que puede contener ceros iniciales |
| `Existencias` | `int` | Número de unidades disponibles |
| `PrecioCoste` | `double` | Coste por unidad |
| `PrecioVenta` | `double` | Precio de venta por unidad |

Utilizamos `public` para poder acceder a los atributos desde el programa principal. Sus nombres siguen la convención **PascalCase** utilizada en nuestras actividades de C#.

> **DEBES SABER:** Cada objeto de la clase tendrá sus propios valores para estos atributos. La clase describe qué información tendrá un producto, pero todavía no hemos creado ningún objeto.

## 4. Implementar los métodos

Añadimos los siguientes métodos dentro de `Producto`, después de los atributos.

### 4.1. Comprar unidades

```csharp
public void Comprar(int cantidad, double precio)
{
    PrecioCoste = precio;
    Existencias += cantidad;
}
```

Recibimos dos parámetros: la cantidad comprada y el coste por unidad. El primero se suma a las existencias actuales; el segundo sustituye al precio de coste anterior. `+=` equivale aquí a `Existencias = Existencias + cantidad`.

El método es `void` porque modifica el objeto pero no necesita devolver ningún valor.

**Comprobación razonada:** si hay 3 unidades y compramos 10 a 8 euros, quedan 13 unidades y el coste unitario pasa a ser 8 euros.

### 4.2. Vender unidades

```csharp
public double Vender(int cantidad)
{
    Existencias -= cantidad;
    return cantidad * PrecioVenta;
}
```

La primera instrucción descuenta las unidades vendidas. La segunda calcula el importe total y lo devuelve al código que invocó el método. Por eso el tipo de retorno es `double`, no `void`.

**Comprobación razonada:** si hay 13 unidades y vendemos 4 a 10 euros cada una, quedan 9 unidades y el método devuelve 40.

### 4.3. Establecer el margen de venta

El porcentaje representa un incremento sobre el coste actual. Por ejemplo, con un coste de 80 euros y un margen del 25 %, el incremento es 20 euros y el precio de venta es 100 euros.

Podemos expresar el cálculo como `PrecioCoste + PrecioCoste * porcentaje / 100`, o agrupar el factor multiplicador:

```csharp
public void EstablecerMargen(double porcentaje)
{
    PrecioVenta = PrecioCoste * (1 + (porcentaje / 100));
}
```

| Coste | Margen | Precio de venta |
|---:|---:|---:|
| 80 | 25 % | 100 |
| 10 | 50 % | 15 |
| 10 | 0 % | 10 |

Los paréntesis permiten multiplicar el coste por todo el factor `1 + porcentaje / 100`.

## 5. Utilizar la clase desde el programa principal

### 5.1. Recabar los datos del usuario

Dentro de `Main()` incorporamos:

```csharp
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
```

`Console.ReadLine()` lee texto. Para convertirlo a un número utilizamos `int.Parse()` o `double.Parse()` según el tipo que necesitamos. Guardamos los datos en variables locales de `Main()` antes de crear el objeto.

### 5.2. Crear e inicializar el objeto

A continuación escribimos:

```csharp
Producto p1 = new Producto();
p1.Nombre = nombre;
p1.CodigoBarras = "";
p1.Existencias = 0;
p1.PrecioCoste = 0.0;
p1.PrecioVenta = 0.0;
```

`Producto` es el tipo de la variable `p1`; `new Producto()` crea el objeto. Mediante el operador punto accedemos a sus atributos. Dejamos el código de barras vacío porque el enunciado no solicita ese dato, y los valores numéricos a cero porque todavía no hemos realizado ninguna operación.

> **DEBES SABER:** La variable local `nombre` y el atributo `p1.Nombre` no son lo mismo. La asignación copia el valor recogido por consola al atributo del objeto.

### 5.3. Comprar, establecer el margen y vender

```csharp
p1.Comprar(cantidad_comprada, precio_coste);
p1.EstablecerMargen(margen_venta);
double importe_venta = p1.Vender(cantidad_vendida);
```

El orden es importante:

1. Compramos para actualizar el coste y las existencias.
2. Establecemos el margen sobre ese coste para calcular el precio de venta.
3. Vendemos las unidades y guardamos el importe devuelto en una variable local.

No repetimos los cálculos en `Main()`: los métodos de `Producto` son los responsables de modificar sus atributos y calcular el importe.

### 5.4. Mostrar el resultado

```csharp
Console.WriteLine($"El importe total de la venta es: {importe_venta}");
Console.WriteLine($"Las existencias que quedan en stock son: {p1.Existencias}");
```

La interpolación de cadenas (`$` y llaves) permite incorporar los valores al mensaje. El importe procede del retorno de `Vender()` y las existencias se consultan directamente en el objeto.

## 6. Comprobar el funcionamiento

Ejecuta `dotnet run` e introduce estos datos:

| Dato | Valor |
|---|---|
| Nombre | Cuaderno |
| Precio de coste | 8 |
| Cantidad comprada | 20 |
| Margen de venta | 25 |
| Cantidad vendida | 6 |

Podemos seguir la evolución del objeto:

| Operación | Existencias | PrecioCoste | PrecioVenta |
|---|---:|---:|---:|
| Inicialización | 0 | 0 | 0 |
| Comprar | 20 | 8 | 0 |
| EstablecerMargen | 20 | 8 | 10 |
| Vender | 14 | 8 | 10 |

La salida esperada es:

```text
El importe total de la venta es: 60
Las existencias que quedan en stock son: 14
```

## 7. Código final de referencia

### `Producto.cs`

Estos son los dos archivos completos de la solución.

```csharp
namespace actividad_2_5;

public class Producto
{
    public string Nombre; // Descripción del producto
    public string CodigoBarras; //Código de barras del producto.
    public int Existencias; // Número de unidades disponibles.
    public double PrecioCoste; // Precio de coste por unidad.
    public double PrecioVenta; //Precio de venta por unidad.


    public void Comprar(int cantidad, double precio) // Incrementa Existencias en la cantidad indicada y establece PrecioCoste con el valor recibido en precio.
    {
        PrecioCoste = precio;
        Existencias += cantidad;
    }
    public double Vender(int cantidad) // Descuenta la cantidad indicada de Existencias y devuelve el importe total de la venta, calculado como cantidad * PrecioVenta.
    {
        Existencias -= cantidad;        
        return cantidad*PrecioVenta;
    }
    public void EstablecerMargen(double porcentaje) // Calcula y actualiza PrecioVenta aplicando el incremento porcentual indicado sobre el valor actual de PrecioCoste.
    {
        PrecioVenta = PrecioCoste * (1 + (porcentaje / 100));
    }
    
}
```

### `Program.cs`

```csharp
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
```

## 8. Qué hemos aprendido

- **Clases y archivos:** organizamos `Producto` y `Program` en archivos independientes del mismo proyecto.
- **Atributos:** almacenan la información propia de cada objeto.
- **Métodos y parámetros:** permiten operar sobre el objeto utilizando datos externos.
- **Valores de retorno:** `Vender()` devuelve un resultado que podemos guardar y utilizar desde `Main()`.
- **Instanciación:** `new Producto()` crea un objeto de la clase.
- **Separación de responsabilidades:** el programa principal recoge y muestra datos; la clase realiza las operaciones del producto.

**Limitaciones conscientes:** esta solución no valida entradas incorrectas, cantidades negativas ni ventas superiores a las existencias. Los atributos de texto y las lecturas de consola pueden generar advertencias de nulabilidad en proyectos recientes de .NET. Conservamos el enfoque de clase sin introducir técnicas adicionales que no exige esta actividad.

## 9. Entrega

Una vez comprobado el funcionamiento, realiza un único commit que incluya toda la implementación:

```text
UT02A05 - Implementación y uso de la clase 'Producto'
```
