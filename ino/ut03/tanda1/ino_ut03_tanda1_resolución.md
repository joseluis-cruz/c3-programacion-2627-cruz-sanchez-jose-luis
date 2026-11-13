# UT03 · Programación de microcontroladores — Tanda 1

## Resolución razonada

Esta guía explica **una posible resolución** de las seis actividades de refuerzo de la UT03, utilizando el circuito de tres LED y un pulsador del [proyecto del profesor en Wokwi](https://wokwi.com/projects/479588049590466561). El objetivo no es memorizar un programa terminado, sino comprender **qué se modifica, dónde y por qué**.

> **Código fuente de las soluciones:** En el repositorio del profesor, junto a este documento, encontrarás los archivos `.ino` con las soluciones finales de todas las actividades. Puedes consultarlos para comprobar cómo se han aplicado las explicaciones desarrolladas en esta guía.

Trabajamos con los pines `LEDR` (4), `LEDA` (3), `LEDV` (2) y `BTN1` (7). Los fragmentos de cada actividad se incorporan al código correspondiente, sin necesidad de volver a copiar todas las instrucciones que permanecen iguales.

> **Cómo seguir la guía:** abre el código de la actividad que estés resolviendo y lee cada explicación antes de transcribir su fragmento. Comprueba después el resultado en Wokwi.

## Actividad 1.1 · Comprender el código original

En esta primera actividad **no tenemos que cambiar el funcionamiento**: se trata de entender las instrucciones y explicar qué hacen. La solución comentada que se trabajó en clase es la siguiente:

```cpp
/* Actividad 1.1
  Estas instrucciones define son la forma en la que se definen
  constantes en el lenguaje C. Con ellas, podemos asignar un identificador
  a un valor y modificar rápidamente ese valor para, por ejemplo,
  cambiar el puerto en el que tenemos conectado un dispositivo.
  En este ejemplo, hemos definido como constantes los puertos
  por los que conectamos los 3 leds y el botón.
*/
#define LEDR 4 // led rojo
#define LEDA 3 // led amarillo
#define LEDV 2 // led verde
#define BTN1 7 // botón de pulsación

void setup() // Método que se ejecuta al inicio, sólo una vez
{
  // Configurar cada puerto como entrada o salida mediante pinMode
  pinMode(LEDR, OUTPUT);
  pinMode(LEDA, OUTPUT);
  pinMode(LEDV, OUTPUT);
  pinMode(BTN1, INPUT);

  // Apagar inicialmente los tres leds
  // digitalWrite establece HIGH (alto) o LOW (bajo) en una salida
  digitalWrite(LEDR, LOW);
  digitalWrite(LEDA, LOW);
  digitalWrite(LEDV, LOW);
}

void loop() // Se ejecuta repetidamente mientras la placa funciona
{
  // digitalRead lee el valor digital del pin conectado al botón
  if (digitalRead(BTN1))
  {
    // Al pulsar, el LED rojo parpadea tres veces
    for (int i = 0; i < 3; i++)
    {
      digitalWrite(LEDR, HIGH);
      delay(500);
      digitalWrite(LEDR, LOW);
      delay(500);
    }
  }
}
```

### ¿Qué conceptos estamos utilizando?

- **`#define`:** asocia un nombre a un valor mediante una directiva del *preprocesador*. Aunque en clase podemos hablar de «constantes» para simplificar, **no crea una variable ni una constante tipada**: el identificador se sustituye por su valor antes de compilar. Si cambiamos un pin, basta con modificar su definición.
- **`setup()`:** se ejecuta una vez al iniciar o reiniciar el programa; configura los pines y establece el estado inicial de los LED.
- **`pinMode(pin, OUTPUT/INPUT)`:** indica si utilizamos un pin como salida o entrada. En este circuito se mantiene `INPUT` para el botón, tal como aparece en el programa original.
- **`digitalWrite(pin, HIGH/LOW)`:** establece el nivel lógico alto o bajo en una salida. En el montaje permite encender y apagar los LED.
- **`loop()`:** se ejecuta una y otra vez. Por eso no hace falta programar un bucle adicional para que el dispositivo siga comprobando el botón.
- **`digitalRead(BTN1)`:** obtiene el nivel lógico del pulsador. En el circuito compartido, la condición del `if` se cumple al pulsarlo.
- **`if`:** ejecuta las instrucciones interiores solamente cuando se cumple una condición.
- **`for`:** repite las instrucciones interiores tres veces, con `i = 0, 1, 2`.
- **`delay(500)`:** detiene la ejecución durante 500 milisegundos (medio segundo).

**Comprobación:** al pulsar el botón, el LED rojo se enciende y se apaga tres veces. Cada encendido y cada apagado dura 500 ms. Si se mantiene el botón presionado, una vez terminado el `for` pueden comenzar otras tres repeticiones, ya que `loop()` sigue ejecutándose.


## Actividad 1.2 · Modificar los parpadeos

**Objetivo:** que el LED rojo parpadee **cinco veces**, permaneciendo **300 ms encendido** y **300 ms apagado**.

Partimos del `for` de la actividad anterior. Solo hay que modificar dos cosas:

1. La condición `i < 3` pasa a `i < 5`, porque queremos cinco repeticiones.
2. Las dos esperas pasan de `500` a `300` milisegundos. Es importante modificar **las dos**, para que el encendido y el apagado duren lo mismo.

Sustituimos el bucle original por este:

```cpp
for (int i = 0; i < 5; i++)
{
  digitalWrite(LEDR, HIGH);
  delay(300);
  digitalWrite(LEDR, LOW);
  delay(300);
}
```

El `if (digitalRead(BTN1))`, `setup()` y las definiciones de los pines no necesitan cambios.

**Comprobación:** al pulsar el botón deben verse cinco destellos del rojo, separados por pausas de 300 ms.

## Actividad 1.3 · Alternar los LED rojo y verde

**Objetivo:** alternar rojo y verde durante **cinco ciclos completos**. Nunca deben estar encendidos simultáneamente.

Aprovechamos el `for` de cinco repeticiones. En lugar de encender y apagar únicamente el rojo, necesitamos **dos fases en cada ciclo**:

1. Encender rojo y apagar verde.
2. Apagar rojo y encender verde.

Antes, definimos una constante para el tiempo de conmutación, junto a los demás `#define`:

```cpp
#define TIEMPO_CONMUTACION 250
```

Después, dentro del `if` del pulsador, escribimos:

```cpp
for (int i = 0; i < 5; i++)
{
  digitalWrite(LEDR, HIGH);
  digitalWrite(LEDV, LOW);
  delay(TIEMPO_CONMUTACION);

  digitalWrite(LEDR, LOW);
  digitalWrite(LEDV, HIGH);
  delay(TIEMPO_CONMUTACION);
}

digitalWrite(LEDR, LOW);
digitalWrite(LEDV, LOW);
```

El apagado final es importante: cuando concluye la última repetición, el LED verde todavía está encendido y debemos dejar **ambos apagados**.

**Comprobación:** cada ciclo tiene una fase roja de 250 ms y otra verde de 250 ms. Al terminar el quinto ciclo, ambos quedan apagados.

**Ajuste respecto al archivo utilizado en clase:** en `actividad_1_3.ino` aparecen esperas de **300 ms** y no se declara la constante. Para cumplir literalmente el enunciado, utilizamos aquí `TIEMPO_CONMUTACION = 250`. La alternancia de LED de aquella solución sí refleja el razonamiento que necesitamos.

## Actividad 1.4 · Secuencia de tres LED

**Objetivo:** recorrer la secuencia **rojo → amarillo → verde**, cuatro veces, manteniendo cada LED encendido **250 ms** y sin solapamientos.

Partimos de la idea anterior, pero ahora cada repetición consta de **tres fases**. La condición del `for` pasa a `i < 4`.

Definimos la duración de cada fase al comienzo del programa:

```cpp
#define TIEMPO_CONMUTACION 250
```

Y sustituimos el contenido del `if` por:

```cpp
for (int i = 0; i < 4; i++)
{
  digitalWrite(LEDR, HIGH);
  delay(TIEMPO_CONMUTACION);
  digitalWrite(LEDR, LOW);

  digitalWrite(LEDA, HIGH);
  delay(TIEMPO_CONMUTACION);
  digitalWrite(LEDA, LOW);

  digitalWrite(LEDV, HIGH);
  delay(TIEMPO_CONMUTACION);
  digitalWrite(LEDV, LOW);
}
```

La clave está en **apagar el LED actual antes de encender el siguiente**. Al finalizar cada repetición apagamos también el verde, de modo que la próxima pueda empezar con rojo sin dejar dos LED encendidos a la vez.

**Comprobación:** se ven cuatro secuencias completas y los tres LED quedan apagados.


## Actividad 1.5 · Semáforo controlado por el botón

**Objetivo:** el semáforo está normalmente en **verde**. Al pulsar, pasa a **amarillo durante 1 segundo**, después a **rojo durante 3 segundos** y finalmente vuelve al verde.

Aquí ya no interesa repetir una secuencia un número fijo de veces. Necesitamos **un estado inicial y una secuencia que solo se ejecute al pulsar**.

### Paso 1. Definir los tiempos

```cpp
#define TIEMPO_ESPERA_AMARILLO 1000
#define TIEMPO_ESPERA_ROJO 3000
```

### Paso 2. Encender el verde desde el principio

En `setup()`, después de configurar los pines, dejamos rojo y amarillo apagados y verde encendido:

```cpp
digitalWrite(LEDR, LOW);
digitalWrite(LEDA, LOW);
digitalWrite(LEDV, HIGH);
```

### Paso 3. Ejecutar la secuencia al pulsar

En `loop()` mantenemos la condición del pulsador. En su interior escribimos las fases, una detrás de otra:

```cpp
if (digitalRead(BTN1))
{
  // Verde -> amarillo
  digitalWrite(LEDV, LOW);
  digitalWrite(LEDA, HIGH);
  delay(TIEMPO_ESPERA_AMARILLO);

  // Amarillo -> rojo
  digitalWrite(LEDA, LOW);
  digitalWrite(LEDR, HIGH);
  delay(TIEMPO_ESPERA_ROJO);

  // Rojo -> verde
  digitalWrite(LEDR, LOW);
  digitalWrite(LEDV, HIGH);
}
```

Los cambios de color se hacen **apagando el anterior y encendiendo el siguiente**. Al salir del `if`, el verde permanece encendido hasta que vuelva a detectarse el botón.

**Comprobación:** el programa arranca en verde y, después de cada pulsación, sigue la secuencia amarillo (1 s) → rojo (3 s) → verde.


## Actividad 1.6 · Semáforo con amarillo intermitente

**Objetivo:** normalmente el amarillo debe parpadear, alternando cada **500 ms**. Cuando se pulsa el botón, queda **amarillo fijo durante 1 segundo**, después **rojo durante 3 segundos** y finalmente vuelve a parpadear.

La diferencia principal respecto a la actividad anterior es que **el comportamiento normal ya no es dejar el verde encendido**, sino alternar el amarillo. Para conseguirlo, aprovecharemos que `loop()` se repite automáticamente.

### Paso 1. Definir los tres tiempos

```cpp
#define TIEMPO_ESPERA_PARPADEO_AMARILLO 500
#define TIEMPO_ESPERA_AMARILLO 1000
#define TIEMPO_ESPERA_ROJO 3000
```

### Paso 2. Empezar con todos los LED apagados

En `setup()`:

```cpp
digitalWrite(LEDR, LOW);
digitalWrite(LEDA, LOW);
digitalWrite(LEDV, LOW);
```

### Paso 3. Generar el parpadeo normal al comienzo de `loop()`

```cpp
digitalWrite(LEDA, HIGH);
delay(TIEMPO_ESPERA_PARPADEO_AMARILLO);
digitalWrite(LEDA, LOW);
delay(TIEMPO_ESPERA_PARPADEO_AMARILLO);
```

Estas instrucciones se ejecutarán una y otra vez, porque forman parte de `loop()`. **No necesitamos un `while` adicional.**

### Paso 4. Añadir la secuencia especial tras detectar el botón

Justo después del parpadeo, dentro del mismo `loop()`:

```cpp
if (digitalRead(BTN1))
{
  digitalWrite(LEDA, HIGH);
  delay(TIEMPO_ESPERA_AMARILLO);

  digitalWrite(LEDA, LOW);
  digitalWrite(LEDR, HIGH);
  delay(TIEMPO_ESPERA_ROJO);

  digitalWrite(LEDR, LOW);
}
```

Al concluir este `if`, `loop()` comienza otra vez y se recupera automáticamente el parpadeo amarillo. El verde permanece siempre apagado.

**Comprobación:** sin pulsaciones, el LED amarillo alterna 500 ms encendido y 500 ms apagado. Tras detectarse el botón, permanece fijo 1 segundo, pasa a rojo 3 segundos y recupera la intermitencia.

**Límite de esta solución sencilla:** el botón se comprueba **después de las dos pausas de 500 ms**, por lo que una pulsación muy breve realizada mientras se espera puede no detectarse. Es un comportamiento esperable al usar `delay()`; para estos ejercicios basta con mantener el botón hasta que se atienda la pulsación. Más adelante se puede mejorar la respuesta del programa sin bloquear la ejecución.


### Mejora: encapsular la atención al botón en una función

En la solución anterior, comprobamos el pulsador una sola vez por cada vuelta completa de `loop()`, **después de las dos esperas** de 500 ms. Si una pulsación se produce y termina durante esas esperas, el programa puede no detectarla.

Vamos a **encapsular** el código que atiende al botón en una función: así podremos llamarla en distintos puntos del programa sin repetir todas sus instrucciones. Esta mejora está implementada en el archivo `actividad_1_6_mejorada.ino`.

**Paso 1. Localizar el bloque que atiende a la pulsación.** Es el `if (digitalRead(BTN1))` que enciende el amarillo fijo, espera un segundo, enciende el rojo, espera tres segundos y finalmente lo apaga. Lo trasladamos fuera de `loop()` a una función llamada `checkBoton()`.

```cpp
void checkBoton()
{
  if (digitalRead(BTN1))
  {
    digitalWrite(LEDA, HIGH);
    delay(TIEMPO_ESPERA_AMARILLO);

    digitalWrite(LEDA, LOW);
    digitalWrite(LEDR, HIGH);
    delay(TIEMPO_ESPERA_ROJO);

    digitalWrite(LEDR, LOW);
  }
}
```

La función es de tipo `void` porque **no devuelve ningún resultado**. Tampoco necesita parámetros: utiliza las constantes de los pines y de los tiempos definidas al comienzo del programa.

**Paso 2. Invocar la función después de cada espera.** Ahora `loop()` se ocupa del parpadeo habitual y llama a `checkBoton()` en dos momentos:

```cpp
void loop()
{
  digitalWrite(LEDA, HIGH);
  delay(TIEMPO_ESPERA_PARPADEO_AMARILLO);
  checkBoton();

  digitalWrite(LEDA, LOW);
  delay(TIEMPO_ESPERA_PARPADEO_AMARILLO);
  checkBoton();
}
```

**Paso 3. Comprobar el funcionamiento.** El LED amarillo continúa parpadeando de forma habitual. Cuando se detecta una pulsación en cualquiera de esas dos comprobaciones, se ejecuta la secuencia amarillo fijo (1 s) → rojo (3 s) y, al regresar de la función, continúa el parpadeo.

**¿Qué mejora y qué limitación queda?** Hemos eliminado la repetición del código de atención al botón y duplicado los puntos de comprobación por ciclo. No obstante, `delay()` sigue bloqueando la ejecución: una pulsación breve durante una espera puede pasar inadvertida, y durante la secuencia especial no se atienden otras pulsaciones. Para responder sin bloqueos necesitaríamos otra técnica de temporización.

**¿Qué hemos aprendido?** Una función nos permite organizar, reutilizar y mantener un bloque de instrucciones con un nombre significativo. Podemos invocarla desde diferentes lugares sin duplicar su código.

## Ideas que hemos reforzado

| Recurso | Para qué lo hemos usado |
| --- | --- |
| `#define` | Asignar nombres a pines y tiempos de espera. |
| `setup()` | Configurar entradas/salidas y establecer el estado inicial. |
| `loop()` | Repetir continuamente el comportamiento del dispositivo. |
| `digitalRead()` y `if` | Ejecutar una secuencia cuando detectamos el botón. |
| `for` | Repetir un número concreto de ciclos. |
| `digitalWrite()` | Cambiar el estado de los LED sin solapamientos. |
| `delay()` | Controlar la duración de cada fase. |
| `void checkBoton()` | Encapsular la atención al pulsador y reutilizarla desde distintos puntos de `loop()`. |

**Recuerda:** las soluciones de las actividades son **independientes**. Cada una se guarda en su propio archivo (`actividad_1_1.ino` a `actividad_1_6.ino`), aunque reutilicemos las mismas definiciones y estructuras de los ejercicios anteriores.
