# UT03 - Actividad 1

En esta actividad trabajarás a partir de un proyecto proporcionado por el profesor para practicar el uso de condiciones en C#. Copia primero el proyecto en tu repositorio y completa el programa siguiendo los apartados en orden. Al terminar cada apartado, realiza un commit utilizando exactamente la descripción indicada en la última columna.

| Apartado | Tarea a realizar | Descripción del commit |
|----------|------------------|------------------------|
| a | Copia el directorio `"src/cs/ut03/actividad_3_1"` proporcionado por el profesor en su repositorio, de manera que quede ubicado en **la misma ruta dentro de tu propio repositorio**. | `UT03A01a Copiado proyecto proporcionado por el profesor` |
| b | Completa el programa para que lea el segundo número. | `UT03A01b Añadida lectura del segundo número` |
| c | Utiliza un condicional para mostrar por consola el mensaje `"OK!"` **únicamente si el primer número es menor que el segundo**. | `UT03A01c Añadida comprobación mediante condicional` |
| d | Modifica el condicional para que muestre por consola el mensaje `"INCORRECTO!"` cuando no se cumpla la condición anterior. | `UT03A01d Añadido mensaje para condición no cumplida` |
| e | Modifica el condicional para que, además de mantener el comportamiento anterior, contemple el caso en que ambos números sean iguales, mostrando entonces el mensaje `"IGUALES!"`. | `UT03A01e Añadida comprobación de igualdad entre números` |
| f | Modifica el programa para que, cuando el resultado sea incorrecto, muestre el mensaje `"INCORRECTO: deberías haber indicado {?} y {?}"`, sustituyendo cada marcador `{?}` por el valor correspondiente, de manera que **los dos números aparezcan en el orden correcto, de menor a mayor**. | `UT03A01f Añadida indicación del orden correcto de los números` |

## TIPS

### TIP 1. Mostrar el valor de una variable por consola

En C# puedes mostrar el valor de una variable dentro de un mensaje utilizando una **cadena interpolada**.

Para ello, coloca el símbolo `$` delante de las comillas y escribe el nombre de la variable entre llaves `{}`.

Por ejemplo, si tienes una variable llamada `"num1"`:

```csharp
Console.WriteLine($"El valor de num1 es {num1}");
```

Si `"num1"` contiene el valor `15`, se mostrará por consola:

```text
El valor de num1 es 15
```

**Recuerda:** puedes incluir varias variables en un mismo mensaje, utilizando un par de llaves para cada una.
