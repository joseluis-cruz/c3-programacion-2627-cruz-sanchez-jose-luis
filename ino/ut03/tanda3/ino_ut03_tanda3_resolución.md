# UT03 · Programación de microcontroladores — Tanda 3

## Resolución razonada: sistema de intermitentes

En esta guía reconstruiremos **una posible solución** de las actividades 3.1 a 3.4. Partiremos de un circuito con **dos LED (izquierdo y derecho) y dos pulsadores**, y avanzaremos desde un parpadeo sencillo hasta un sistema que recuerda su **estado** y permite activar la emergencia.

> **Código fuente:** En el repositorio del profesor, junto a este documento, se encuentra el código de la solución final. Los fragmentos siguientes se presentan de manera progresiva para que puedas reproducir los cambios y entender por qué se realizan.

**Proyecto de partida:** [Wokwi — Tanda 3: intermitentes](https://wokwi.com/projects/479932135432769537).

**Cómo usar esta guía.** Cada actividad parte de la anterior. Los fragmentos muestran las instrucciones que debemos incorporar o sustituir; al final encontrarás el programa completo de referencia, correspondiente a la actividad 3.4. Los ejemplos intermedios son pasos didácticos de construcción, no transcripciones verificadas de los archivos originales de cada etapa.

---

## 1. Preparar el circuito desde el código

Los nombres que utilizaremos para los pines son:

```cpp
#define LEDIZQ 4
#define LEDDER 7
#define BTNIZQ 5
#define BTNDER 6
```

Las directivas `#define` permiten utilizar nombres comprensibles en lugar de repetir números de pin por todo el programa.

En `setup()` configuramos los LED como salidas y los botones como entradas con resistencia interna de *pull-up*:

```cpp
void setup()
{
  pinMode(LEDIZQ, OUTPUT);
  pinMode(LEDDER, OUTPUT);
  pinMode(BTNIZQ, INPUT_PULLUP);
  pinMode(BTNDER, INPUT_PULLUP);

  digitalWrite(LEDIZQ, LOW);
  digitalWrite(LEDDER, LOW);
}
```

**Importante:** Con `INPUT_PULLUP`, un botón sin pulsar se lee como `HIGH` y uno pulsado como `LOW`. Por eso, más adelante utilizaremos expresiones como `!digitalRead(BTNIZQ)` para detectar la pulsación.

## 2. Actividad 3.1 — Conseguir que parpadee el LED izquierdo

### Paso 1. Dar nombre al tiempo de espera

Declaramos una constante para poder cambiar la velocidad sin modificar varias instrucciones:

```cpp
#define BLINK_MS 500 //3.1
```

### Paso 2. Alternar los estados del LED

Un parpadeo requiere dos fases: LED encendido y LED apagado, ambas con la misma duración.

```cpp
void loop()
{
  digitalWrite(LEDIZQ, HIGH); // Encender
  delay(BLINK_MS);            // Esperar 500 ms
  digitalWrite(LEDIZQ, LOW);  // Apagar
  delay(BLINK_MS);            // Esperar otros 500 ms
}
```

**¿Por qué no necesitamos escribir un `while`?** Porque Arduino ejecuta `loop()` una y otra vez mientras está funcionando. Así, la secuencia se repite indefinidamente.

**Comprueba en Wokwi:** el LED izquierdo se enciende 500 ms, se apaga 500 ms y vuelve a empezar. Si cambias `BLINK_MS`, cambia el ritmo.

---

## 3. Actividad 3.2 — Preparar el intermitente derecho

Ahora queremos que el programa pueda activar **uno u otro LED**. La idea inicial consiste en usar condiciones para decidir qué LED debe parpadear, sin duplicar la constante `BLINK_MS`.

Podemos ensayar una versión sencilla en la que dos variables indican qué intermitente debe funcionar:

```cpp
bool izquierdaActiva = true;
bool derechaActiva = false;
```

Estas variables solo nos sirven como **etapa de aprendizaje**; en la actividad 3.3 las sustituiremos por una sola variable `estado`, que expresa de forma más clara en qué situación se encuentra el sistema.

### Paso 1. Encender únicamente los LED seleccionados

```cpp
if (izquierdaActiva)
{
  digitalWrite(LEDIZQ, HIGH);
}
if (derechaActiva)
{
  digitalWrite(LEDDER, HIGH);
}
```

### Paso 2. Compartir los tiempos de encendido y apagado

Después de encender los LED que corresponda, hacemos una espera común, apagamos ambos y volvemos a esperar:

```cpp
delay(BLINK_MS);
digitalWrite(LEDIZQ, LOW);
digitalWrite(LEDDER, LOW);
delay(BLINK_MS);
```

Así evitamos encadenar dos secuencias completas con esperas independientes: el esquema también nos servirá cuando ambos LED deban parpadear **a la vez**.

**Comprueba en Wokwi:** cambia los valores de `izquierdaActiva` y `derechaActiva` para probar primero un intermitente y después el otro. No estamos controlando todavía la selección con los botones: eso llegará en la siguiente actividad.

---

## 4. Actividad 3.3 — Recordar el estado y seleccionar mediante pulsadores

### Paso 1. Por qué necesitamos una variable `estado`

Ahora el botón no debe activar un LED únicamente **mientras está pulsado**. Queremos que una pulsación seleccione un intermitente y que este continúe funcionando al soltar el botón.

Por tanto, el programa debe **recordar qué está haciendo** entre una ejecución de `loop()` y la siguiente.

Definimos tres valores con nombres expresivos y una **variable global**:

```cpp
#define ESTADO_TODO_APAGADO 0
#define ESTADO_PARPADEA_IZQUIERDA 1
#define ESTADO_PARPADEA_DERECHA 2

byte estado;
```

La variable es global porque se declara fuera de `setup()` y `loop()`. De ese modo **conserva su valor** entre ejecuciones sucesivas de `loop()`. Una variable local declarada dentro de `loop()` no sirve directamente para conservar ese valor cuando termina cada llamada.

La inicializamos una única vez en `setup()`:

```cpp
estado = ESTADO_TODO_APAGADO;
```

**No debemos volver a asignarle ese valor al comienzo de `loop()`**, porque borraríamos el estado recordado en cada iteración.

### Paso 2. Separar dos responsabilidades

Organizaremos `loop()` en dos fases:

- **Fase 1:** leer los botones y, si corresponde, modificar `estado`.
- **Fase 2:** encender y apagar los LED dependiendo de `estado`.

Esta separación es importante: **el estado expresa la decisión**, mientras que las instrucciones `digitalWrite()` realizan la acción física.

### Paso 3. Programar el comportamiento del botón izquierdo

```cpp
if (!digitalRead(BTNIZQ))
{
  if (estado == ESTADO_PARPADEA_IZQUIERDA)
  {
    estado = ESTADO_TODO_APAGADO;
  }
  else
  {
    estado = ESTADO_PARPADEA_IZQUIERDA;
  }
}
```

Razonemos las dos posibilidades:

- Si el intermitente izquierdo **ya** está seleccionado, pulsarlo de nuevo lo desactiva.
- Si estaba apagado o parpadeando el derecho, la pulsación selecciona el izquierdo.

**La misma pulsación puede hacer cosas distintas según el estado anterior.** Este es el fundamento del ejercicio.

### Paso 4. Incorporar el botón derecho

```cpp
else if (!digitalRead(BTNDER))
{
  if (estado == ESTADO_PARPADEA_DERECHA)
  {
    estado = ESTADO_TODO_APAGADO;
  }
  else
  {
    estado = ESTADO_PARPADEA_DERECHA;
  }
}
```

Usamos `else if` para que, en esta etapa, el segundo bloque solo se evalúe si no se ha ejecutado el primero. En la actividad 3.4 mejoraremos el orden para atender expresamente las pulsaciones simultáneas.

### Paso 5. Hacer depender las luces del estado

Ya no necesitamos `izquierdaActiva` ni `derechaActiva`. Utilizamos directamente la variable global:

```cpp
if (estado == ESTADO_PARPADEA_IZQUIERDA)
{
  digitalWrite(LEDIZQ, HIGH);
}
if (estado == ESTADO_PARPADEA_DERECHA)
{
  digitalWrite(LEDDER, HIGH);
}

delay(BLINK_MS);
digitalWrite(LEDIZQ, LOW);
digitalWrite(LEDDER, LOW);
delay(BLINK_MS);
```

Si `estado` vale `ESTADO_TODO_APAGADO`, ninguna condición de encendido se cumple, de modo que los dos LED permanecen apagados.

**Comprueba en Wokwi:** pulsa el botón izquierdo, suéltalo, prueba el derecho y vuelve a pulsar el que esté activo. Comprueba que cambia la selección o se apaga.

---

## 5. Actividad 3.4 — Añadir el estado de emergencia

### Paso 1. Crear una constante más

El sistema pasa de tres estados a cuatro:

```cpp
#define ESTADO_EMERGENCIA 3
```

Ahora tendremos un estado para ambos LED apagados, dos estados para el parpadeo individual y otro para el parpadeo simultáneo.

### Paso 2. Comprobar primero la pulsación de ambos botones

Si comprobásemos primero el botón izquierdo, una pulsación de ambos podría quedar interpretada como pulsación izquierda. Por eso debemos colocar al principio la **condición compuesta**:

```cpp
if ((!digitalRead(BTNIZQ)) && (!digitalRead(BTNDER)))
{
  if (estado == ESTADO_EMERGENCIA)
  {
    estado = ESTADO_TODO_APAGADO;
  }
  else
  {
    estado = ESTADO_EMERGENCIA;
  }
}
```

El operador `&&` exige que **ambas condiciones sean verdaderas**: botón izquierdo pulsado **y** botón derecho pulsado.

El `if` interior permite alternar el estado de emergencia: si ya estaba activo, lo apaga; si no, lo activa.

### Paso 3. Conservar el comportamiento individual usando `else if`

A continuación colocamos las comprobaciones individuales:

```cpp
else if (!digitalRead(BTNIZQ))
{
  if (estado == ESTADO_PARPADEA_IZQUIERDA)
    estado = ESTADO_TODO_APAGADO;
  else
    estado = ESTADO_PARPADEA_IZQUIERDA;
}
else if (!digitalRead(BTNDER))
{
  if (estado == ESTADO_PARPADEA_DERECHA)
    estado = ESTADO_TODO_APAGADO;
  else
    estado = ESTADO_PARPADEA_DERECHA;
}
```

El encadenamiento `if` / `else if` permite seleccionar **una sola decisión** en cada comprobación: ambos pulsados, solo izquierda o solo derecha.

### Paso 4. Adaptar el encendido de los LED

El LED izquierdo tiene que encenderse en **dos estados**: izquierda y emergencia. Lo mismo sucede con el derecho:

```cpp
if ((estado == ESTADO_PARPADEA_IZQUIERDA) ||
    (estado == ESTADO_EMERGENCIA))
{
  digitalWrite(LEDIZQ, HIGH);
}

if ((estado == ESTADO_PARPADEA_DERECHA) ||
    (estado == ESTADO_EMERGENCIA))
{
  digitalWrite(LEDDER, HIGH);
}
```

El operador `||` significa **O lógico**: basta con que se cumpla una de las condiciones de cada `if`.

La fase de apagado **no cambia**:

```cpp
delay(BLINK_MS);
digitalWrite(LEDIZQ, LOW);
digitalWrite(LEDDER, LOW);
delay(BLINK_MS);
```

Cuando `estado == ESTADO_EMERGENCIA`, los dos LED se encienden antes de la primera espera y se apagan antes de la segunda: **parpadean sincronizados**.

---

## 6. Programa completo de referencia (actividad 3.4)

El siguiente programa reproduce la **estructura y el comportamiento de la solución final facilitada por el profesor**, usando el identificador corregido `ESTADO_PARPADEA_DERECHA`.

```cpp
#define LEDIZQ 4
#define LEDDER 7
#define BTNIZQ 5
#define BTNDER 6

#define BLINK_MS 500

#define ESTADO_TODO_APAGADO 0
#define ESTADO_PARPADEA_IZQUIERDA 1
#define ESTADO_PARPADEA_DERECHA 2
#define ESTADO_EMERGENCIA 3

byte estado;

void setup()
{
  pinMode(LEDIZQ, OUTPUT);
  pinMode(LEDDER, OUTPUT);
  pinMode(BTNIZQ, INPUT_PULLUP);
  pinMode(BTNDER, INPUT_PULLUP);

  digitalWrite(LEDIZQ, LOW);
  digitalWrite(LEDDER, LOW);
  estado = ESTADO_TODO_APAGADO;
}

void loop()
{
  // FASE 1: detectar pulsaciones y actualizar el estado
  if ((!digitalRead(BTNIZQ)) && (!digitalRead(BTNDER)))
  {
    if (estado == ESTADO_EMERGENCIA)
      estado = ESTADO_TODO_APAGADO;
    else
      estado = ESTADO_EMERGENCIA;
  }
  else if (!digitalRead(BTNIZQ))
  {
    if (estado == ESTADO_PARPADEA_IZQUIERDA)
      estado = ESTADO_TODO_APAGADO;
    else
      estado = ESTADO_PARPADEA_IZQUIERDA;
  }
  else if (!digitalRead(BTNDER))
  {
    if (estado == ESTADO_PARPADEA_DERECHA)
      estado = ESTADO_TODO_APAGADO;
    else
      estado = ESTADO_PARPADEA_DERECHA;
  }

  // FASE 2: encender y apagar LED según el estado
  if ((estado == ESTADO_PARPADEA_IZQUIERDA) ||
      (estado == ESTADO_EMERGENCIA))
  {
    digitalWrite(LEDIZQ, HIGH);
  }

  if ((estado == ESTADO_PARPADEA_DERECHA) ||
      (estado == ESTADO_EMERGENCIA))
  {
    digitalWrite(LEDDER, HIGH);
  }

  delay(BLINK_MS);
  digitalWrite(LEDIZQ, LOW);
  digitalWrite(LEDDER, LOW);
  delay(BLINK_MS);
}
```

### Una limitación que conviene conocer

Esta solución es suficiente para trabajar **variables globales, estados, condiciones y secuencias**. No obstante, no implementa una detección estricta de pulsaciones individuales: si mantenemos un botón pulsado durante varios ciclos de `loop()`, el estado puede alternarse repetidamente. Además, durante los `delay()` no se leen los botones. Por tanto, para comprobar las transiciones conviene realizar pulsaciones breves y bien separadas; incluso así, no están garantizadas todas las detecciones.

No añadiremos aquí mecanismos adicionales de control de pulsaciones ni temporizadores distintos, porque el objetivo de esta tanda es **comprender las estructuras de control y la gestión del estado**.

---

## 7. Qué hemos aprendido

- Un parpadeo combina **secuencia de instrucciones** y **repetición continua de `loop()`**.
- Las constantes, como `BLINK_MS`, permiten modificar el comportamiento desde un solo lugar.
- Una **variable global** permite recordar el estado del sistema entre llamadas a `loop()`.
- Una pulsación puede provocar una **transición de estado** distinta según la situación previa.
- `&&` exige que se cumplan varias condiciones; `||` permite que se cumpla cualquiera de ellas.
- Separar el programa en **lectura de pulsadores** y **control de LED** facilita su comprensión y ampliación.

**Idea principal:** no necesitamos crear un programa diferente para cada situación. Podemos describir un único sistema mediante una variable `estado` y decidir, en cada ejecución de `loop()`, cómo deben comportarse sus componentes.
