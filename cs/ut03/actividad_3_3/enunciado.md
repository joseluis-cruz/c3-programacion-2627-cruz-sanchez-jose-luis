# UT03 - Actividad 3

En esta actividad trabajarás a partir de un proyecto proporcionado por el profesor para comprobar si una contraseña cumple determinados requisitos y confirmar su cambio.

Realiza los apartados en el orden indicado. Al finalizar cada uno, registra los cambios mediante un commit utilizando exactamente la descripción de la última columna.

| Apartado | Tarea a realizar | Descripción del commit |
|----------|------------------|------------------------|
| a | Copia el directorio `"src/cs/ut03/actividad_3_3"` proporcionado por el profesor en su repositorio, de manera que quede ubicado en **la misma ruta dentro de tu propio repositorio**. | `UT03A03a Copiado proyecto proporcionado por el profesor` |
| b | Comprueba que la contraseña introducida contiene **al menos 8 caracteres**. Si no cumple este requisito, muestra por consola el mensaje `"Demasiado corta, debe contener al menos 8 caracteres"`. | `UT03A03b Añadida comprobación de longitud mínima de la contraseña` |
| c | Si la contraseña supera la primera comprobación, comprueba que contiene **tanto letras mayúsculas como minúsculas**. | `UT03A03c Añadida comprobación de mayúsculas y minúsculas` |
| d | Si la contraseña supera todas las comprobaciones anteriores, pide al usuario que **repita la contraseña** y comprueba que coincide con la introducida inicialmente. Si coincide, muestra por consola `"Contraseña cambiada correctamente"`. En caso contrario, muestra `"Las contraseñas no coinciden"`. El programa terminará en ambos casos. | `UT03A03d Añadida confirmación de contraseña` |

## TIPS

### TIP 1. Medir la longitud de una cadena

En C#, la propiedad `"Length"` permite conocer el número de caracteres de una cadena, incluidos los espacios.

```csharp
string texto = "Hola Mundo";
Console.WriteLine(texto.Length);
```

El resultado será `10`.

### TIP 2. Detectar mayúsculas y minúsculas mediante comparaciones

Puedes averiguar si una cadena contiene letras de ambos tipos comparándola con dos versiones de sí misma:

- Si es diferente de su versión completamente en mayúsculas, contiene alguna letra minúscula.
- Si es diferente de su versión completamente en minúsculas, contiene alguna letra mayúscula.

Si se cumplen ambas condiciones, contiene mayúsculas y minúsculas.

### TIP 3. Obtener versiones en mayúsculas y minúsculas

En C# puedes utilizar los métodos `"ToUpper()"` y `"ToLower()"` de una cadena para obtener versiones con sus letras convertidas a mayúsculas o minúsculas, respectivamente.

```csharp
string texto = "Hola Mundo";
Console.WriteLine(texto.ToUpper());
Console.WriteLine(texto.ToLower());
```

Se mostrará:

```text
HOLA MUNDO
hola mundo
```

**Recuerda:** estos métodos devuelven nuevas cadenas; no modifican la original.

### TIP 4. Comparar cadenas para saber si son iguales

En C# puedes utilizar `"=="` para comprobar si dos cadenas son iguales y `"!="` para comprobar si son diferentes. Estas comparaciones distinguen entre mayúsculas y minúsculas.

```csharp
string palabra1 = "Hola";
string palabra2 = "hola";

Console.WriteLine(palabra1 == palabra2); // False
Console.WriteLine(palabra1 != palabra2); // True
```

Una comparación produce un valor lógico: `"true"` o `"false"`, que puedes utilizar como condición en un `"if"`.
