# UT04 – Actividad 2. Pasar de atributos a propiedades

En esta actividad vamos a repetir el procedimiento de la actividad 4_1, aplicándolo a las clases `Libro`, `Vector2D`, `CuentaBancaria`, `Equipo` y `Jugador`.

## Preparación de la actividad

Realiza esta actividad en el directorio `src/cs/ut04/actividad_4_2` de tu repositorio, donde se encuentra este enunciado y los archivos fuente proporcionados por el profesor.

Duplica cada uno de los archivos `.cs` originales añadiendo un `2` al nombre del archivo y al nombre de la clase pública que contiene. Por ejemplo, a partir de `Libro.cs`, crea `Libro2.cs`, que contendrá la clase `public class Libro2`.

Conserva los archivos originales sin modificaciones.

## Transformación de las clases

Identifica, consultando directamente el código fuente de cada clase, todos sus atributos públicos y transfórmalos en propiedades públicas que permitan tanto la lectura como la escritura.

Sigue el mismo procedimiento que en la actividad 4_1: convierte los atributos en privados, renómbralos siguiendo la nomenclatura `_camelCase` y crea las propiedades públicas con los nombres y tipos originales, implementando explícitamente los accesores `get` y `set` sobre los atributos privados.

No utilices propiedades automáticas ni incorpores lógica adicional o validaciones en los accesores. Conserva el funcionamiento de los métodos originales de cada clase.

Si necesitas más información sobre el procedimiento, consulta el [enunciado de la actividad 4_1](../actividad_4_1/cs_ut04_a01_enunciado.md).

## Entrega

Realiza un único commit que incluya los cambios correspondientes a las cinco clases, con la siguiente descripción:

`UT04A02 - Pasar de atributos a propiedades para las clases Libro, Verctor2D, CuentaBancaria, Equipo y Jugador`
