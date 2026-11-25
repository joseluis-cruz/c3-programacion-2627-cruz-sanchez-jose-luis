# UT04 – Actividad 1. Pasar de atributos a propiedades

En esta actividad vamos a partir de la clase `Producto`, que ya hemos utilizado en la UT02, para introducir el uso de propiedades en C#.

## Preparación de la actividad

Realiza esta actividad en el directorio `src/cs/ut04/actividad_4_1` de tu repositorio, donde se encuentra este enunciado y el archivo `Producto.cs` proporcionado por el profesor.

Duplica el archivo `Producto.cs` con el nombre `Producto2.cs` y cambia el nombre de la clase de `Producto` a `Producto2`. Conserva el archivo original sin modificaciones.

## Transformación de la clase `Producto2`

Transforma todos los atributos públicos de la clase en **propiedades públicas que permitan tanto la lectura como la escritura** (`get` y `set`).

En esta actividad vamos a implementar propiedades públicas apoyándonos en **atributos privados**, que serán los encargados de almacenar los valores de cada objeto. Por tanto, no utilizaremos propiedades automáticas.

Para cada uno de los atributos originales de la clase, realiza los siguientes pasos:

1. **Convierte el atributo en privado**, sustituyendo el modificador de acceso `public` por `private`.
2. **Renombra el atributo** utilizando la tecla `F2` de Visual Studio Code, siguiendo la nomenclatura de C# que utilizaremos para los atributos privados: guion bajo inicial y primera letra en minúscula (`_camelCase`). Por ejemplo, pasa de `NombreAtributo` a `_nombreAtributo`.
3. **Crea una propiedad pública** con el mismo nombre y tipo de dato que tenía originalmente el atributo (`NombreAtributo`).
4. **Implementa los accesores `get` y `set`** de la propiedad:
   - `get`: devolverá mediante `return` el valor del atributo privado.
   - `set`: asignará al atributo privado el valor recibido mediante `value`.

Al finalizar la transformación, la clase deberá disponer de los siguientes atributos privados y propiedades públicas:

| Atributo privado | Propiedad pública | Tipo de dato |
|---|---|---|
| `_nombre` | `Nombre` | `string` |
| `_codigoBarras` | `CodigoBarras` | `string` |
| `_existencias` | `Existencias` | `int` |
| `_precioCoste` | `PrecioCoste` | `double` |
| `_precioVenta` | `PrecioVenta` | `double` |

Todas las propiedades permitirán tanto la lectura como la escritura. En esta primera actividad, los accesores `get` y `set` tendrán una implementación mínima, sin incorporar ninguna lógica adicional ni validación de valores.

Conserva el funcionamiento de los métodos originales de la clase: `Comprar()`, `Vender()` y `EstablecerMargen()`.

Al finalizar, deberán coexistir los archivos `Producto.cs` y `Producto2.cs` en el directorio de la actividad.

## Entrega

Realiza un único commit que incluya los cambios correspondientes a esta actividad, con la siguiente descripción:

`UT04A01 - Pasar de atributos a propiedades para la clase Producto`
