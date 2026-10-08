# UT03 - Actividad 4

En esta actividad trabajarás a partir de un proyecto proporcionado por el profesor para mostrar una valoración del curso según la calificación introducida por el usuario. Realiza los apartados en orden y, al finalizar cada uno, registra los cambios mediante un commit con la descripción indicada.

| Apartado | Tarea a realizar | Descripción del commit |
|----------|------------------|------------------------|
| a | Copia el directorio `"src/cs/ut03/actividad_3_4"` proporcionado por el profesor en su repositorio, de manera que quede ubicado en **la misma ruta dentro de tu propio repositorio**. | `UT03A04a Copiado proyecto proporcionado por el profesor` |
| b | Utiliza el condicional `"switch"` para mostrar por consola el mensaje `"El curso te parece {valoracion_como_texto}"`, sustituyendo `{valoracion_como_texto}` por **"horroroso", "malo", "regulero", "interesante" o "maravilloso"**, según la calificación introducida sea 1, 2, 3, 4 o 5, respectivamente. | `UT03A04b Añadida valoración del curso mediante switch` |
| c | Mejora el programa declarando cinco constantes de tipo `"string"`, llamadas `"RATING_1"`, `"RATING_2"`, `"RATING_3"`, `"RATING_4"` y `"RATING_5"`, con los textos correspondientes del apartado anterior. Modifica los casos del `"switch"` para que asignen la constante correspondiente a una variable de tipo `"string"`. Finalmente, utiliza **un único `"Console.WriteLine()"`**, situado después del `"switch"`, para mostrar el mensaje con la valoración obtenida. Puedes declarar también una constante `"RATING_TEXT"` para la parte inicial del mensaje, `"El curso te parece "` (**observa el espacio al final**). | `UT03A04c Incorporadas constantes y unificada la salida por consola` |
| d | Contempla también el caso de que el usuario introduzca una calificación **inferior a 1 o superior a 5**. En tal caso, el programa deberá mostrar únicamente el mensaje `"Debes indicar un valor entre 1 y 5 (incluidos)"`. Puedes almacenar este mensaje en una constante llamada `"RATING_ERROR"`. | `UT03A04d Añadido control de calificaciones fuera de rango` |

## TIPS

### TIP 1. Componer mensajes concatenando cadenas

En C# puedes utilizar el operador `+` para **concatenar cadenas de texto**, es decir, unir varias cadenas para formar una sola.

Esto resulta especialmente útil cuando un mensaje tiene una parte fija y otra que depende de una condición.

Por ejemplo, podemos declarar las siguientes constantes:

```csharp
const string RATING_TEXT = "El curso te parece ";
const string RATING_1 = "horroroso";
const string RATING_5 = "maravilloso";
```

Después, podemos combinar la parte fija con una de las valoraciones y **almacenar el resultado en una variable**:

```csharp
string mensaje = RATING_TEXT + RATING_1;
```

La variable `"mensaje"` contendrá:

```text
El curso te parece horroroso
```

Si asignamos otra combinación:

```csharp
mensaje = RATING_TEXT + RATING_5;
```

Su contenido pasará a ser:

```text
El curso te parece maravilloso
```

**Recuerda:** el operador `+` une las cadenas exactamente como están escritas. Por eso es importante que `"RATING_TEXT"` incluya un espacio al final.

De esta manera, puedes construir el mensaje completo en una variable y mostrarlo posteriormente con un único `"Console.WriteLine()"`.
