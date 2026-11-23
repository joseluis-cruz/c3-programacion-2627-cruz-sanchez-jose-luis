# UT02 – Tanda 5. Actividad de refuerzo

## Diseño e implementación de la clase `Producto`

Esta actividad tiene como objetivo **reforzar los conocimientos adquiridos en la UT02 y preparar el trabajo de la UT04**, en la que profundizaremos en la programación orientada a objetos.

Deberás realizar el **diseño completo de una clase `Producto` en C#** y utilizarla desde una aplicación de consola. La actividad no está dividida en apartados: debes cumplir todas las especificaciones y realizar **un único commit** al finalizar.

### Preparación del proyecto

Crea un proyecto de consola en C# denominado **`actividad_2_5`**, ubicado en el mismo directorio que los proyectos de las actividades 2.1, 2.2, 2.3 y 2.4.

El proyecto deberá contener, al menos, los siguientes archivos:

- **`Program.cs`**: contendrá la clase `Program` y el método `Main()`, desde el que se creará y utilizará un objeto de la clase `Producto`.
- **`Producto.cs`**: contendrá la definición e implementación de la clase `Producto`, en un archivo independiente.

Ambos archivos deberán formar parte del mismo proyecto.

### Atributos de la clase `Producto`

La clase deberá disponer de los siguientes atributos:

| Atributo | Tipo de dato | Descripción |
|---|---|---|
| `Nombre` | `string` | Nombre del producto. |
| `CodigoBarras` | `string` | Código de barras del producto. |
| `Existencias` | `int` | Número de unidades disponibles. |
| `PrecioCoste` | `double` | Precio de coste por unidad. |
| `PrecioVenta` | `double` | Precio de venta por unidad. |

Respeta los nombres indicados, comenzando con mayúscula.

### Métodos de la clase `Producto`

Implementa los siguientes métodos:

| Método | Tipo de retorno | Funcionamiento |
|---|---|---|
| `Comprar(int cantidad, double precio)` | `void` | Incrementa `Existencias` en la cantidad indicada y establece `PrecioCoste` con el valor recibido en `precio`. |
| `Vender(int cantidad)` | `double` | Descuenta la cantidad indicada de `Existencias` y devuelve el **importe total de la venta**, calculado como `cantidad * PrecioVenta`. |
| `EstablecerMargen(double porcentaje)` | `void` | Calcula y actualiza `PrecioVenta` aplicando el incremento porcentual indicado sobre el valor actual de `PrecioCoste`. |

Por ejemplo, si el precio de coste es de 80 € y se establece un margen del 25 %, el precio de venta será de 100 €.

### Programa principal (`Program.cs`)

Desde el método `Main()`, crea un objeto de la clase `Producto` y solicita al usuario, en este orden:

1. El **nombre del producto**.
2. El **precio de coste** por unidad.
3. La **cantidad comprada**.
4. El **margen de venta**, expresado como porcentaje.
5. La **cantidad vendida**.

Utiliza el objeto creado y sus métodos `Comprar()`, `EstablecerMargen()` y `Vender()` para realizar las operaciones correspondientes.

Al finalizar, muestra por consola:

- El **importe total de la venta**, utilizando el valor devuelto por `Vender()`.
- Las **unidades restantes en existencias**, consultando el atributo `Existencias` del objeto.

Las operaciones de compra, venta y cálculo del precio deben realizarse mediante los métodos de `Producto`, **sin repetir sus cálculos en `Main()`**.

### Entrega

Una vez completada la actividad, realiza un **único commit** que incluya toda la implementación:

`UT02A05 - Implementación y uso de la clase 'Producto'`
