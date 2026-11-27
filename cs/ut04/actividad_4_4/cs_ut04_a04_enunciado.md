# UT04 – Actividad 4. Implementación de constructores

En esta actividad partiremos de las clases resultantes de la actividad 4_3 e incorporaremos constructores que permitan inicializar los objetos en el momento de su creación. Trabajaremos también la sobrecarga de constructores.

## Preparación de la actividad

Trabaja en el directorio `src/cs/ut04/actividad_4_4` de tu repositorio, donde encontrarás los archivos de partida.

Duplica los archivos y renombra las clases según la siguiente tabla, conservando los archivos originales:

| Clase de partida | Nueva clase | Archivo de entrega |
|---|---|---|
| `Vector2D3` | `Vector2D4` | `Vector2D4.cs` |
| `CuentaBancaria3` | `CuentaBancaria4` | `CuentaBancaria4.cs` |
| `Equipo3` | `Equipo4` | `Equipo4.cs` |
| `Producto3` | `Producto4` | `Producto4.cs` |
| `Libro3` | `Libro4` | `Libro4.cs` |
| `Jugador3` | `Jugador4` | `Jugador4.cs` |

Actualiza las referencias entre las clases para utilizar las nuevas versiones. Conserva la funcionalidad de los métodos y las restricciones de acceso y asignación de las propiedades establecidas anteriormente. Inicializa las propiedades desde los constructores, respetando sus restricciones.

## 1. Clase `Vector2D4`

Implementa dos constructores:

- Uno sin parámetros, que inicialice las propiedades `X` e `Y` a cero.
- Otro que reciba las dos coordenadas e inicialice `X` e `Y` con los valores recibidos.

## 2. Clase `CuentaBancaria4`

Implementa un único constructor que reciba el nombre del titular, inicialice la propiedad `Titular` con el valor recibido y establezca `Saldo` a cero.

## 3. Clase `Equipo4`

Implementa un único constructor que reciba el nombre del equipo, inicialice la propiedad `Nombre` con el valor recibido y establezca `Jugadores` a cero.

## 4. Clase `Producto4`

Implementa tres constructores sobrecargados:

| Constructor | Parámetros recibidos |
|---|---|
| 1 | Nombre. |
| 2 | Nombre y código de barras. |
| 3 | Nombre, código de barras, stock inicial y precio de coste. |

Inicializa las propiedades correspondientes con los valores recibidos. Cuando no se proporcionen como parámetros, establece los siguientes valores iniciales:

- `CodigoBarras`: cadena vacía (`""`).
- `Existencias`: `0`.
- `PrecioCoste`: `0`.

Inicializa `PrecioVenta` a cero en los tres constructores. Su valor podrá establecerse posteriormente mediante el método `EstablecerMargen()`.

Respeta las restricciones de longitud del código de barras y de existencias no negativas establecidas en la actividad 4_3.

## 5. Clase `Libro4`

Implementa dos constructores sobrecargados:

| Constructor | Parámetros recibidos | Estado inicial |
|---|---|---|
| 1 | Título y autor. | Disponible (`"D"`). |
| 2 | Título, autor y estado inicial. | El recibido, que solo podrá ser `"D"` o `"N"`. |

Inicializa `Titulo` y `Autor` con los valores recibidos y establece `IdCliente` y `VecesPrestado` a cero en ambos constructores.

Si el segundo constructor recibe un estado distinto de `"D"` o `"N"`, deberá lanzar una excepción. No se permite crear un ejemplar inicialmente prestado.

**Importante:** esta restricción afecta únicamente a la creación del objeto. La propiedad `Estado` seguirá admitiendo los valores `"D"`, `"N"` y `"P"` durante la vida del objeto.

## 6. Clase `Jugador4`

Implementa cuatro constructores sobrecargados:

| Constructor | Parámetros recibidos | Inicialización |
|---|---|---|
| 1 | Nombre. | Establece el mismo valor para `Nombre` y `Apodo`. |
| 2 | Nombre y apodo. | Inicializa `Nombre` y `Apodo` con los valores recibidos. |
| 3 | Nombre, apodo y equipo. | Además de inicializar `Nombre` y `Apodo`, ficha al jugador por el equipo indicado. |
| 4 | Nombre, apodo, equipo y dorsal. | Además de realizar las operaciones del constructor anterior, establece `Dorsal` con el valor recibido. |

Cuando no se reciba un equipo, inicializa `EquipoJuega` a `null`. Cuando no se reciba un dorsal, inicializa `Dorsal` a cero.

Cuando se proporcione un equipo, utiliza el método `Fichar()` de dicho equipo para que se actualice también su número de jugadores. Conserva la comunicación entre las clases establecida en la actividad 4_3.

No es necesario utilizar el encadenamiento de constructores mediante `this()`.

## Entrega

Realiza un único commit que incluya todas las modificaciones, con la siguiente descripción:

`UT04A04 - Implementación de constructores`
