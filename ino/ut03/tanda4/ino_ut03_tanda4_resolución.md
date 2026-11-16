# UT03 · Programación de microcontroladores — Tanda 4

## Resolución razonada: juego de reflejos

Esta guía explica **cómo construir progresivamente una posible solución** de las actividades 4.1, 4.2 y 4.3, partiendo del programa original y terminando con la implementación realizada en clase. El objetivo no es copiar una solución sin entenderla, sino comprender **qué se añade, dónde y por qué**.

> **Código fuente:** En el repositorio del profesor, junto a este documento de resolución, puedes consultar el código final de la tanda. Los fragmentos intermedios de esta guía representan pasos didácticos para alcanzar esa solución.

**Proyecto de partida:** [Wokwi — juego de reflejos](https://wokwi.com/projects/480296045717363713).

El circuito tiene un pulsador conectado al pin 2 y un LED conectado al pin 13. El jugador inicia una partida pulsando el botón, espera a que se encienda el LED y vuelve a pulsarlo lo más rápidamente posible. Si se adelanta o tarda demasiado, pierde.

---

## 1. Comprender el programa original

### 1.1. Pines y estados

El programa comienza con unas definiciones:

```cpp
#define BUTTON 2
#define LED 13

#define ESTADO_INICIAL 0
#define ESTADO_ESPERANDO_LUZ 1
#define ESTADO_LUZ_ENCENDIDA 2
```

Las constantes `ESTADO_...` identifican las **tres situaciones** por las que puede pasar el juego. En lugar de escribir números como `0`, `1` o `2` en las comparaciones, utilizamos nombres que explican su significado.

```cpp
byte estado = ESTADO_INICIAL;
bool boton_pulsado = false;
```

Son **variables globales**, declaradas fuera de las funciones. Necesitamos que mantengan su valor entre sucesivas ejecuciones de `loop()`:

- `estado` recuerda en qué fase del juego nos encontramos.
- `boton_pulsado` recuerda si una pulsación ya se ha atendido.

Una variable local declarada dentro de `loop()` no serviría directamente para conservar el estado entre una ejecución y la siguiente, porque deja de existir al salir de esa función.

### 1.2. Inicialización en `setup()`

```cpp
void setup()
{
  pinMode(BUTTON, INPUT_PULLUP);
  pinMode(LED, OUTPUT);
  digitalWrite(LED, LOW);
  Serial.begin(9600);
  Serial.println("Pulsa el botón para iniciar. Permanece atento y pulsa el botón tan rápido como veas que se enciende la luz.");
}
```

- `INPUT_PULLUP` activa la resistencia interna de *pull-up*: **sin pulsar** se lee `HIGH` y **pulsado** se lee `LOW`.
- `digitalWrite(LED, LOW)` apaga inicialmente la luz.
- `Serial.begin(9600)` inicializa la comunicación con la consola serie, donde mostraremos las instrucciones y los resultados.

### 1.3. Detección de una pulsación individual

El programa de partida ya contiene este bloque:

```cpp
if (!digitalRead(BUTTON))
{
  if (!boton_pulsado)
  {
    boton_pulsado = true;
    switch (estado)
    {
      // Casos correspondientes a cada estado
    }
  }
}
else if (boton_pulsado)
{
  boton_pulsado = false;
}
```

Aquí conviene distinguir **estar pulsando** de **haber realizado una nueva pulsación**:

1. `!digitalRead(BUTTON)` es verdadero cuando se presiona el botón.
2. `!boton_pulsado` comprueba que la pulsación aún no se ha procesado.
3. Al entrar, ponemos `boton_pulsado = true`, de modo que mantener el botón apretado no vuelve a ejecutar el `switch` en cada vuelta del bucle.
4. Cuando se suelta, el `else if` restablece el indicador a `false`. La siguiente pulsación volverá a atenderse.

**Importante:** el programa original tiene un `switch (estado)` con mensajes diferentes, pero **todavía no cambia el estado**. Por eso, inicialmente solo responde como `ESTADO_INICIAL`: las demás fases deben programarse.

---

## 2. Actividad 4.1 — Cambiar de estado y perder por adelantarse

### Paso 1. Iniciar una partida

Cuando pulsamos estando en `ESTADO_INICIAL`, debemos pasar a `ESTADO_ESPERANDO_LUZ`. Sustituimos las instrucciones de ese `case` por:

```cpp
case ESTADO_INICIAL:
  Serial.println("Vuelve a pulsar tan pronto como se encienda la luz...");
  estado = ESTADO_ESPERANDO_LUZ;
  break;
```

La asignación `estado = ESTADO_ESPERANDO_LUZ` es lo que hace avanzar el juego. El `break` finaliza ese caso del `switch`; no debe confundirse con salir de `loop()`.

### Paso 2. Atender una pulsación anticipada

Si se pulsa otra vez cuando aún esperamos la luz, el jugador pierde. En el segundo caso escribimos:

```cpp
case ESTADO_ESPERANDO_LUZ:
  Serial.println("Has perdido por adelantarte al encendido.");
  estado = ESTADO_INICIAL;
  break;
```

Después del aviso regresamos al estado inicial, por lo que una nueva pulsación puede iniciar otra partida. En la solución del profesor el mensaje termina con un punto; el sentido es el mismo que en el enunciado.

### Paso 3. Comprobar la actividad

Inicia la simulación, pulsa una vez y suelta el botón: aparecerá el aviso de espera. Pulsa de nuevo: debe aparecer el mensaje de pérdida. En esta primera actividad el LED **todavía no se enciende** porque aún no hemos implementado el contador.

---

## 3. Actividad 4.2 — Espera aleatoria y tiempo límite

Queremos que, al iniciar la partida, transcurran aproximadamente **entre 2 y 5 segundos** antes de que se encienda el LED. Una vez encendido, el jugador tendrá unos **2 segundos** para responder.

### Paso 1. Añadir un contador global

Junto a las variables globales originales añadimos:

```cpp
int contador_ticks = 0;
```

Este contador se debe recordar entre ejecuciones de `loop()`. En nuestro programa, cada vuelta comienza con:

```cpp
delay(10);
```

Como cada `delay(10)` espera diez milisegundos, tomaremos **aproximadamente 100 vueltas como un segundo**. Cada vuelta representa aproximadamente una centésima de segundo. Es una aproximación: también consumen tiempo las demás instrucciones.

### Paso 2. Elegir un tiempo aleatorio al iniciar

En la actividad 4.1 ya habíamos cambiado al estado de espera. Ahora completamos el primer `case`:

```cpp
case ESTADO_INICIAL:
  Serial.println("Vuelve a pulsar tan pronto como se encienda la luz...");
  contador_ticks = random(200, 501);
  estado = ESTADO_ESPERANDO_LUZ;
  break;
```

La función `random(min, max)` incluye el mínimo pero **excluye el máximo**. Por eso:

- `random(200, 501)` puede producir desde `200` hasta `500`.
- `200` ticks equivalen aproximadamente a 2 segundos.
- `500` ticks equivalen aproximadamente a 5 segundos.

El número se elige **una sola vez al empezar cada partida**, no en cada iteración: de lo contrario, el contador se reiniciaría constantemente y nunca realizaría bien la cuenta atrás.

### Paso 3. Descontar los ticks fuera del `switch`

El bloque del `switch` solamente se ejecuta cuando detectamos una pulsación nueva. Sin embargo, **el tiempo debe avanzar aunque nadie pulse**. Por eso, al final de `loop()`, después de toda la detección del botón, añadimos:

```cpp
if (estado != ESTADO_INICIAL)
{
  contador_ticks--;
}
```

Esta condición evita decrementar mientras el juego está inactivo. El operador `--` resta una unidad en cada vuelta. Más adelante añadiremos dentro de este mismo bloque las comprobaciones de los límites.

### Paso 4. Encender el LED cuando el contador llegue a cero

Completamos el bloque anterior:

```cpp
if (estado != ESTADO_INICIAL)
{
  contador_ticks--;

  if (contador_ticks == 0)
  {
    digitalWrite(LED, HIGH);
    estado = ESTADO_LUZ_ENCENDIDA;
  }
}
```

La transición ocurre exactamente cuando el contador llega a `0`: encendemos el LED y cambiamos al tercer estado. **No reiniciamos el contador**. Seguiremos decrementándolo, pero ahora pasará a valores negativos: `-1`, `-2`, `-3`… Esta decisión nos servirá también para medir el tiempo de reacción en la actividad 4.3.

### Paso 5. Detectar que el jugador tarda demasiado

Mientras el LED está encendido, el contador continúa bajando. Si llega a `-200` sin que se pulse el botón, habrán transcurrido aproximadamente dos segundos más. Añadimos el segundo control:

```cpp
if (estado != ESTADO_INICIAL)
{
  contador_ticks--;

  if (contador_ticks == 0)
  {
    digitalWrite(LED, HIGH);
    estado = ESTADO_LUZ_ENCENDIDA;
  }
  else if (contador_ticks <= -200)
  {
    Serial.println("Has perdido por no actuar sobre el botón durante demasiado tiempo.");
    digitalWrite(LED, LOW);
    estado = ESTADO_INICIAL;
  }
}
```

El `else if` evita comprobar la segunda condición como una acción separada después de alcanzar cero. La comparación `<= -200` también cubre el caso de que el contador llegara a estar por debajo del límite.

**¿Por qué está todo al final de `loop()`?** Porque necesitamos atender dos procesos diferentes: primero, las pulsaciones; segundo, el paso del tiempo. El tiempo debe seguir avanzando tanto durante la espera como después de encenderse el LED.

### Paso 6. Comprobar la actividad

- Pulsa para iniciar y no pulses de nuevo: el LED se encenderá tras una espera aleatoria y, si sigues sin pulsar, se apagará tras unos dos segundos mostrando el mensaje de pérdida.
- Inicia otra partida y pulsa **antes** del encendido: aparecerá el aviso de pulsación anticipada y el juego volverá al inicio.
- Tras perder, el sistema debe estar preparado para volver a empezar.

---

## 4. Actividad 4.3 — Medir el tiempo de reacción

Solo nos falta resolver el caso en el que el jugador sí pulsa mientras el LED está encendido.

### Paso 1. Interpretar los valores negativos

Al encender el LED, el contador llega a `0`. En cada vuelta posterior desciende: `-1`, `-2`, `-3`… Esos valores indican **cuántos ticks han transcurrido desde el encendido**, pero con signo negativo.

Por ejemplo, si al pulsar tenemos `contador_ticks == -37`, estimamos que el jugador ha tardado **37 centésimas** de segundo, aproximadamente 0,37 segundos. Para mostrarlo en positivo basta multiplicar por `-1`.

### Paso 2. Completar el tercer caso del `switch`

El bloque definitivo es:

```cpp
case ESTADO_LUZ_ENCENDIDA:
  Serial.print("Has tardado ");
  Serial.print(contador_ticks * -1);
  Serial.println(" centésimas");
  estado = ESTADO_INICIAL;
  digitalWrite(LED, LOW);
  break;
```

Aquí intervienen tres ideas:

1. `Serial.print()` escribe sin saltar de línea, lo que permite construir un mensaje con texto y un número.
2. `contador_ticks * -1` convierte a positivo el tiempo acumulado después del encendido.
3. Al terminar **apagamos el LED y volvemos al estado inicial**, para permitir una partida nueva.

No necesitamos una variable adicional para el tiempo de reacción: reutilizamos el propio contador que ya hemos empleado en la cuenta atrás.

### Paso 3. Comprobar los tres resultados posibles

1. **Pulsación anticipada:** iniciar, soltar y volver a pulsar antes del encendido → se muestra que has perdido por adelantarte.
2. **Demasiado lento:** iniciar y no pulsar tras el encendido → se muestra que has perdido por esperar demasiado; se apaga el LED.
3. **Reacción correcta:** iniciar, esperar el encendido, pulsar antes de dos segundos → se muestran las centésimas aproximadas, se apaga el LED y se vuelve al inicio.

Recuerda **soltar el botón entre pulsaciones**: `boton_pulsado` impide procesar varias veces la misma pulsación mantenida.

---

## 5. Código completo de la solución final

Este es el código de referencia proporcionado por el profesor. Los fragmentos anteriores muestran cómo se ha llegado a él. Se mantiene su estructura y comportamiento, incluidos los comentarios originales.

```cpp
#define BUTTON 2
#define LED 13

#define ESTADO_INICIAL 0
#define ESTADO_ESPERANDO_LUZ 1
#define ESTADO_LUZ_ENCENDIDA 2

byte estado = ESTADO_INICIAL; // nos ayuda a saber en qué momento pulsamos el botón, para actuar según dicho estado
bool boton_pulsado = false; // nos ayuda a detectar que el botón no estaba pulsado, de forma que sólo atendamos su pulsación una vez, hasta que se vuelva a liberar

int contador_ticks = 0;

void setup()
{
  pinMode(BUTTON, INPUT_PULLUP);
  pinMode(LED, OUTPUT);
  digitalWrite(LED,LOW);
  Serial.begin(9600);
  Serial.println("Pulsa el botón para iniciar. Permanece atento y pulsa el botón tan rápido como veas que se enciende la luz.");
}

void loop()
{
  //evitamos que se sobrecarge el emulador
  delay(10);
  // si se pulsa el botón
  if (!digitalRead(BUTTON))
  {
    if (!boton_pulsado) // si previamente no estaba pulsado
    {
      boton_pulsado = true; // recordamos que se ha pulsado, para evitar que el switch se ejecute repetidamente
      switch (estado)
      {
        case ESTADO_INICIAL:
          Serial.println("Vuelve a pulsar tan pronto como se encienda la luz...");
          contador_ticks = random(200, 501);
          estado = ESTADO_ESPERANDO_LUZ;
          break;
        case ESTADO_ESPERANDO_LUZ:
          Serial.println("Has perdido por adelantarte al encendido.");
          estado = ESTADO_INICIAL;
          break;
        case ESTADO_LUZ_ENCENDIDA:
          Serial.print("Has tardado ");
          Serial.print(contador_ticks*-1);
          Serial.println(" centésimas");
          estado = ESTADO_INICIAL;
          digitalWrite(LED,LOW);
          break;
      }
    }
  }
  else if (boton_pulsado) // borramos el flag de botón pulsado
  {
    boton_pulsado = false;
  }
  // decrementamos el contador de ticks si no estamos en estado inicial
  if (estado!=ESTADO_INICIAL)
  {
    contador_ticks--;
    //Serial.println(contador_ticks);
    // compruebo si llega a cero
    if (contador_ticks==0)
    {
      digitalWrite(LED,HIGH);
      estado = ESTADO_LUZ_ENCENDIDA;
    }
    else if (contador_ticks<=-200)
    {
      Serial.println("Has perdido por no actuar sobre el botón durante demasiado tiempo.");
      digitalWrite(LED,LOW);
      estado = ESTADO_INICIAL;
    }
  }
}
```

---

## 6. ¿Qué hemos aprendido?

- **Máquina de estados:** una variable `estado` permite decidir qué debe hacer la misma pulsación según la fase del juego.
- **Variables globales:** `estado`, `boton_pulsado` y `contador_ticks` conservan información entre llamadas sucesivas a `loop()`.
- **Pulsaciones individuales:** combinamos la lectura del pulsador con un indicador booleano para no repetir una acción mientras permanece pulsado.
- **Condiciones y selección:** `if`, `else if` y `switch` permiten organizar las decisiones del programa.
- **Repetición continua:** `loop()` hace posible revisar el botón y actualizar el contador sin escribir un bucle adicional.
- **Números aleatorios:** `random(200, 501)` selecciona un tiempo de espera entero entre 200 y 500 ticks.
- **Medición aproximada de tiempos:** el contador positivo sirve para esperar y, después de pasar por cero, el negativo sirve para estimar el tiempo de reacción.
- **Consola serie:** `Serial.print()` y `Serial.println()` permiten comunicar resultados sin utilizar una pantalla externa.

**Limitación de esta solución:** los ticks no son un reloj exacto. `delay(10)` garantiza una espera nominal de 10 ms, pero el resto de las instrucciones también consume tiempo; por eso se habla de centésimas **aproximadas**. En esta tanda hemos priorizado el refuerzo de variables, condiciones y repetición frente a una medición de precisión.
