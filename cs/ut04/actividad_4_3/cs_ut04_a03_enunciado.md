# UT04 – Actividad 3. Personalización de propiedades y propiedades automáticas

En esta actividad partiremos de las soluciones de las actividades 4_1 y 4_2. Por tanto, las clases de partida ya disponen de propiedades públicas de lectura y escritura, implementadas mediante atributos privados y accesores `get` y `set` explícitos.

El objetivo de esta actividad es modificar esas implementaciones para incorporar restricciones y simplificar el código mediante el uso de propiedades automáticas.

## Preparación de la actividad

Realiza esta actividad en el directorio `src/cs/ut04/actividad_4_3` de tu repositorio, donde encontrarás este enunciado y los archivos fuente de partida.

Duplica los archivos `Producto2.cs`, `CuentaBancaria2.cs`, `Equipo2.cs`, `Jugador2.cs` y `Libro2.cs`, sustituyendo el número `2` por el número `3` tanto en el nombre del archivo como en el de la clase pública que contiene. Adapta también las referencias entre las nuevas clases cuando sea necesario.

Conserva los archivos originales sin modificaciones.

## Transformación de las clases

Realiza las modificaciones en el orden indicado, partiendo de las propiedades y los métodos ya implementados. En función de las especificaciones de cada clase, deberás:

- Incorporar restricciones mediante código en los métodos ordinarios y/o en los accesores `set` de las propiedades.
- Convertir en automáticas las propiedades que no necesiten una implementación personalizada, eliminando los atributos privados correspondientes.
- Utilizar un `set` privado en aquellas propiedades cuya escritura deba quedar restringida a la propia clase.
- Sustituir los métodos indicados por propiedades calculadas de solo lectura.

Deberás deducir qué transformación corresponde a cada propiedad a partir de las especificaciones siguientes. Cuando se intente asignar un valor no permitido, lanza una excepción sin modificar el valor anterior.

Adapta los métodos existentes para que respeten las nuevas restricciones, utilizando las propiedades en lugar de acceder directamente a los atributos privados cuando sea necesario. Conserva su funcionalidad, salvo en los casos en los que se indique expresamente una modificación.

### Producto3

| Propiedad | Especificación |
|---|---|
| `Nombre` | Uso libre y público. |
| `CodigoBarras` | No puede contener más de 20 caracteres. |
| `Existencias` | No puede tomar valores negativos. |
| `PrecioCoste` | Solo se puede modificar desde la propia clase. |
| `PrecioVenta` | Solo se puede modificar desde la propia clase. |

### CuentaBancaria3

| Propiedad | Especificación |
|---|---|
| `Titular` | Uso libre y público. |
| `Saldo` | Solo se puede modificar desde la propia clase. |

### Equipo3

| Propiedad | Especificación |
|---|---|
| `Nombre` | Uso libre y público. |
| `Jugadores` | Solo se puede modificar desde la propia clase. |

### Jugador3

| Propiedad | Especificación |
|---|---|
| `Nombre` | Uso libre y público. |
| `Apodo` | Uso libre y público. |
| `Dorsal` | Uso libre y público. |
| `EquipoJuega` | Solo se puede modificar desde la propia clase. |
| `NombreCorto` | Propiedad de solo lectura que proporciona el mismo resultado que el método `GetNombreCorto()`, al que sustituye. |
| `NombreEquipo` | Propiedad de solo lectura que proporciona el mismo resultado que el método `GetNombreEquipo()`, al que sustituye. |

Crea un método público `FicharPor(Equipo3 equipo)` que actualice el valor de `EquipoJuega` con el equipo recibido como parámetro.

Elimina los métodos `GetNombreCorto()` y `GetNombreEquipo()` una vez sustituidos por las correspondientes propiedades.

### Volvemos a Equipo3

Como consecuencia de los cambios realizados en `Jugador3`, ya no es posible modificar directamente la propiedad `EquipoJuega` desde fuera de dicha clase.

Adapta la implementación del método `Fichar()` de `Equipo3` para que utilice el nuevo método público `FicharPor()` del jugador, en lugar de modificar directamente su propiedad `EquipoJuega`.

### Libro3

| Propiedad | Especificación |
|---|---|
| `Titulo` | Uso libre y público. |
| `Autor` | Uso libre y público. |
| `IdCliente` | Solo se puede modificar desde la propia clase. |
| `VecesPrestado` | No se puede modificar directamente desde fuera de la clase. Su valor seguirá controlándose mediante los métodos que gestionan los préstamos y las devoluciones. |
| `Estado` | Únicamente admite los valores `"N"`, `"D"` y `"P"`. Cualquier otro valor deberá provocar una excepción. |

Conserva el funcionamiento de los métodos originales: `Prestar()` incrementará el contador de préstamos y `Devolver()` no lo modificará, puesto que representa el número acumulado de préstamos del ejemplar.

## Entrega

Realiza un único commit que incluya todos los cambios de esta actividad, con la siguiente descripción:

`UT04A03 - Personalización de propiedades y uso de propiedades automáticas`

## TIP – Lanzamiento de excepciones

Recuerda que puedes utilizar la instrucción `throw` para lanzar una excepción cuando se detecte una situación no permitida. Por ejemplo:

```csharp
throw new Exception("Mensaje descriptivo del error");
```

El mensaje debe ser suficientemente claro para identificar el motivo por el que se ha producido la excepción.
