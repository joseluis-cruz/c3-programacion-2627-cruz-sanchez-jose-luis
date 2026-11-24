# UT02 – Tanda 6. Diseño e implementación de la clase `Libro`

Esta actividad tiene como objetivo reforzar los conocimientos adquiridos en la UT02 y preparar el trabajo que desarrollaremos en la UT04, donde profundizaremos en la programación orientada a objetos.

Deberás diseñar e implementar una clase denominada `Libro` en C#, en la que cada objeto represente un ejemplar de una biblioteca. Deberás cumplir todas las especificaciones y realizar un único commit al finalizar la actividad.

## Preparación del proyecto

Crea un proyecto de consola en C# denominado `actividad_2_6`, ubicado en el mismo directorio que los proyectos de las actividades anteriores.

El proyecto deberá contener, al menos, los siguientes archivos:

- `Program.cs`: contendrá la clase `Program` con el método `Main()`, desde el que se crearán y utilizarán objetos de la clase `Libro`.
- `Libro.cs`: contendrá la definición e implementación de la clase `Libro`, en un archivo independiente.

Ambos archivos deberán formar parte del mismo proyecto.

## Atributos de la clase `Libro`

| Atributo | Tipo de dato | Descripción |
|---|---|---|
| `Titulo` | `string` | Título del libro. |
| `Autor` | `string` | Nombre del autor. |
| `IdCliente` | `int` | Identificador del último cliente que ha tomado prestado el ejemplar. Inicialmente será `0`. |
| `VecesPrestado` | `int` | Número de veces que se ha prestado el ejemplar. |
| `Estado` | `string` | Estado del ejemplar: `"P"` (prestado), `"D"` (disponible) o `"N"` (no disponible). |

**Importante:** el atributo `IdCliente` tendrá inicialmente el valor `0`, indicando que el ejemplar nunca ha sido prestado. A partir del primer préstamo, conservará siempre el identificador del último cliente que lo tomó prestado, incluso después de su devolución o retirada.

## Métodos de la clase `Libro`

| Método | Tipo de retorno | Descripción |
|---|---|---|
| `Comprar()` | `void` | Inicializa el estado del ejemplar a `"D"` (disponible) y los atributos `VecesPrestado` e `IdCliente` a cero. |
| `Prestar(int cliente)` | `void` | Cambia el estado del ejemplar a `"P"` (prestado), almacena en el atributo `IdCliente` el identificador del cliente recibido e incrementa en una unidad el contador `VecesPrestado`. |
| `Devolver()` | `int` | Cambia el estado del ejemplar a `"D"` (disponible) y devuelve el identificador del cliente que lo tenía prestado, para permitir comprobar que realmente lo tenía ese cliente, sin modificar el atributo `IdCliente`. |
| `Retirar()` | `void` | Cambia el estado del ejemplar a `"N"` (no disponible), salvo que actualmente esté prestado (`"P"`). En ese caso, deberá lanzar una excepción con el mensaje indicado a continuación, sin modificar su estado. |
| `DescribeEstado()` | `string` | Devuelve una cadena de caracteres que describe el estado actual del ejemplar, incluyendo su título, su estado y el identificador del cliente, siguiendo el formato indicado a continuación. |

**Mensaje de excepción del método `Retirar()`:**

```text
El libro está prestado y no puede marcarse como no disponible mientras no se devuelva
```

**Formato de la cadena devuelta por `DescribeEstado()`:**

```text
El ejemplar titulado "<titulo>" se encuentra en estado "<estado>" y vinculado al cliente con id "<cliente>"
```

Por ejemplo:

```text
El ejemplar titulado "Don Quijote" se encuentra en estado "P" y vinculado al cliente con id "123"
```

El método `DescribeEstado()` deberá devolver la cadena, no mostrarla directamente por consola.

## Programa principal (`Program.cs`)

Una vez implementada la clase `Libro`, deberás completar el método `Main()` de la aplicación de consola para crear y utilizar dos objetos de esta clase, que representarán dos ejemplares de una biblioteca.

El programa deberá realizar las siguientes operaciones:

1. Solicita al usuario el título y el autor de cada uno de los dos ejemplares, almacenando los datos introducidos en variables locales.
2. Declara y crea los dos objetos de la clase `Libro`, asignando valores iniciales coherentes a sus atributos y haciendo uso del método `Comprar()`.
3. Marca el primer ejemplar como no disponible, mediante una invocación al método `Retirar()`.
4. Solicita al usuario el identificador numérico de un cliente y préstale el segundo ejemplar mediante el método `Prestar()`.
5. Devuelve el segundo ejemplar mediante una invocación al método `Devolver()`.

**Después de cada invocación a los métodos `Comprar()`, `Retirar()`, `Prestar()` y `Devolver()`, deberás ejecutar una instrucción como la siguiente, utilizando el objeto correspondiente:**

```csharp
Console.WriteLine(objeto_libro.DescribeEstado());
```

De esta forma, se mostrarán por consola los cambios que experimenta cada uno de los ejemplares a lo largo de la ejecución del programa.

Todas las operaciones relacionadas con los cambios de estado, los préstamos y las devoluciones deberán realizarse mediante los métodos de la clase `Libro`, sin reproducir su lógica en `Main()`.

## Entrega

Realiza un único commit que incluya toda la implementación y el uso de la clase `Libro`, con la siguiente descripción:

`UT02A06 - Implementación y uso de la clase 'Libro'`
