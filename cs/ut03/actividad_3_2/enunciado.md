# UT03 - Actividad 2

En esta actividad trabajarás a partir de un proyecto proporcionado por el profesor para practicar distintas comprobaciones sobre un número mediante condicionales.

Realiza los apartados en el orden indicado. Al finalizar cada uno, haz el correspondiente commit utilizando exactamente la descripción de la última columna.

| Apartado | Tarea a realizar | Descripción del commit |
|----------|------------------|------------------------|
| a | Copia el directorio `"src/cs/ut03/actividad_3_2"` proporcionado por el profesor en su repositorio, de manera que quede ubicado en **la misma ruta dentro de tu propio repositorio**. | `UT03A02a Copiado proyecto proporcionado por el profesor` |
| b | Completa el programa para que compruebe si el número introducido es **negativo, cero o positivo**, mostrando por consola el mensaje correspondiente en cada caso. | `UT03A02b Añadida comprobación del signo del número` |
| c | Con independencia de la comprobación anterior, haz que el programa muestre también si el número introducido es **par o impar**. | `UT03A02c Añadida comprobación de paridad del número` |
| d | Mejora la comprobación de los números negativos para que, además de indicar que el número es negativo, muestre también **su valor en positivo**. | `UT03A02d Añadido valor positivo de los números negativos` |
| e | Modifica el programa para que, **si el número es par**, compruebe si es múltiplo de diez y muestre por consola el resultado. En este caso, ya no deberá mostrar el mensaje que indica que el número es par. Si es impar, mantendrá el comportamiento anterior. | `UT03A02e Añadida comprobación de múltiplos de diez para números pares` |

## TIPS

**TIP 1. Comprobar si un número es múltiplo de otro**

En C# puedes utilizar el operador **módulo (`%`)** para obtener el resto de una división entera.

Si el resto es cero, significa que el primer número es múltiplo del segundo.

Por ejemplo, para comprobar si `"num"` es múltiplo de 5:

```csharp
if (num % 5 == 0)
{
    Console.WriteLine("Es múltiplo de 5");
}
```

**Recuerda:** el operador `%` devuelve el resto de la división, mientras que `==` permite comprobar si ese resto es igual a cero.

**TIP 2. Comprobar si un número es par**

Un número entero es **par si es múltiplo de 2**, es decir, si el resto de dividirlo entre 2 es cero.

Por tanto, para saber si un número es par, basta con comprobar que:

```csharp
num % 2 == 0
```

Si esta condición es verdadera, el número es par; en caso contrario, es impar.
