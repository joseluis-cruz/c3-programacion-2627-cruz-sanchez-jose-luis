# UT03 - Actividad 6

En esta actividad trabajarás con un bucle `"for"` para calcular el **sumatorio y el factorial** de un número entero positivo.

Partirás de un proyecto proporcionado por el profesor que solicita un número entero entre **10 y 20**, almacenándolo en la variable `"limite_maximo"`. El programa también incluye las variables `"sumatorio"` y `"factorial"`, inicializadas a 0 y 1, respectivamente.

Completa el programa siguiendo los apartados en el orden indicado. Al finalizar cada uno, realiza el correspondiente commit utilizando exactamente la descripción indicada en la última columna.

| Apartado | Tarea a realizar | Descripción del commit |
|----------|------------------|------------------------|
| a | Copia el directorio `"src/cs/ut03/actividad_3_6"` proporcionado por el profesor en su repositorio, de manera que quede ubicado en **la misma ruta dentro de tu propio repositorio**. | `UT03A06a Copiado proyecto proporcionado por el profesor` |
| b | Plantea un bucle `"for"` que recorra los números enteros desde **1 hasta el valor de `"limite_maximo"` (incluido)**. En cada iteración, suma a la variable `"sumatorio"` el valor de la variable de control del bucle. | `UT03A06b Añadido cálculo del sumatorio mediante bucle for` |
| c | Completa el bloque del bucle `"for"` para que, en cada iteración, **multiplique la variable `"factorial"` por el valor de la variable de control**, acumulando así el producto de todos los números recorridos. | `UT03A06c Añadido cálculo del factorial mediante bucle for` |
| d | Añade las instrucciones necesarias para **mostrar por consola los valores finales de `"sumatorio"` y `"factorial"`**, una vez haya terminado la ejecución del bucle `"for"`. | `UT03A06d Añadida visualización de los resultados del sumatorio y factorial` |
| e | Modifica el programa para que los cálculos **no comiencen necesariamente en 1**, sino en otro número entero que deberá introducir el usuario antes de ejecutar el bucle. Solicita este valor mediante el mensaje `$"Introduce el entero base para el cálculo, entre 1 y {limite_maximo}"`, donde `"limite_maximo"` representa el número introducido inicialmente. Adapta el bucle `"for"` para que comience en el nuevo valor y termine en el límite máximo (incluido). | `UT03A06e Añadida selección del valor inicial para los cálculos` |

## TIPS

**TIP 1. Diferencia entre factorial, productoria y sumatorio**

Cuando multiplicamos todos los números naturales desde 1 hasta un número determinado, el resultado se denomina **factorial**.

Por ejemplo, el factorial de 5 es:

`5! = 1 × 2 × 3 × 4 × 5 = 120`

Sin embargo, cuando el cálculo comienza en un número distinto de 1, hablamos de una **productoria**, es decir, el producto de los números de un intervalo.

Por ejemplo, la productoria desde 3 hasta 5 es:

`3 × 4 × 5 = 60`

Por su parte, el término **sumatorio** sigue siendo válido independientemente del número en el que comience la suma:

- **Sumatorio de los 5 primeros números naturales positivos:** `1 + 2 + 3 + 4 + 5 = 15`.
- **Sumatorio del intervalo cerrado [3, 5]:** `3 + 4 + 5 = 12`.

**Recuerda:** un intervalo cerrado incluye tanto el valor inicial como el final. Por eso, en esta actividad, el bucle `"for"` deberá recorrer ambos extremos del intervalo.
