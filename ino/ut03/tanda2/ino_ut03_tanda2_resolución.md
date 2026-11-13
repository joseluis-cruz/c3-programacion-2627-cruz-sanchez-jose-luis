# UT03 · Programación de microcontroladores — Tanda 2

## Resolución razonada: control de un servomotor

Esta guía explica **una posible resolución**, basada en la solución desarrollada en clase. Seguiremos la transformación del programa original hasta el resultado de la actividad 2.4: primero introduciremos constantes, después añadiremos el segundo pulsador y, por último, **refactorizaremos** el código común en un método.

> **Código fuente:** Los archivos con las soluciones finales están disponibles en el repositorio del profesor, junto a este documento. Los fragmentos de esta guía se pueden ir incorporando y comprobando en el simulador, pero no sustituyen por sí solos al programa completo.

**Proyecto de partida:** [Wokwi — Servo, buttons and leds](https://wokwi.com/projects/479671974184741889).

## 1. El programa original: nuestro punto de partida

El circuito dispone de un servomotor, dos botones y dos LED, aunque el programa inicial **solo controla un botón y el LED rojo**. El botón de incremento (pin 6) mueve el servomotor en pasos de 2°; cuando ya está en 180°, se enciende el LED rojo.

Este es el código original compartido:

```cpp
// Used pins
#define SERVO1 3  // Servo motor on pin 3 (orange wire)
#define LEDRED 7  // Red led (brown wire)
#define BTNINC 6  // INCrease BuTtoN on pin 6 (light green wire)

// Include the library for controlling servo motors
#include <Servo.h>

// Create a Servo object to control the servo motor
Servo servoMotor1;

// Variable to store the current servo position
int servo1Position;

void setup() // Runs only once, at startup
{
  // Configure the digital pins:
  pinMode(LEDRED, OUTPUT);
  pinMode(BTNINC, INPUT_PULLUP); // HIGH = not pressed, LOW = pressed

  // Attach the servo motor to its pin
  servoMotor1.attach(SERVO1);

  // Set the initial servo position to 0 degrees
  servo1Position = 0;

  // Move the servo to the initial position
  servoMotor1.write(servo1Position);

  // Set the initial status of leds (turned off)
  digitalWrite(LEDRED,LOW);
}

void loop() // Runs continuously after setup()
{
  delay(10); // Prevents the simulator from being overloaded

  if (!digitalRead(BTNINC)) // If BTNINC is pressed
  {
    // Increase the servo position by 2 degrees
    if (servo1Position<180)
    {
      servo1Position += 2;
    }
    else
    {
      digitalWrite(LEDRED,HIGH);
    }

    // Send the new position to the servo motor
    servoMotor1.write(servo1Position);

    // Wait 20 ms to slow down the movement
    delay(10);
  }
}
```

### Antes de modificarlo, comprendamos sus piezas

- `#include <Servo.h>` incorpora la biblioteca que permite controlar el servomotor. `Servo servoMotor1;` crea el objeto que utilizaremos para manejarlo.
- `servoMotor1.attach(SERVO1)` indica al objeto `servoMotor1` que el servomotor estará conectado al microcontrolador por el pin indicado en la constante `SERVO1` (actualmente, el pin 3). Por su parte, `servoMotor1.write(servo1Position)` ordena al servomotor adoptar la posición indicada.
- `servo1Position` es una **variable global**, porque está declarada al principio del programa, fuera de cualquier función. Esto es importante: `loop()` se ejecuta continuamente y necesitamos recordar la última posición del servomotor entre una ejecución y la siguiente. Las variables globales conservan su valor durante toda la ejecución del programa y pueden utilizarse desde distintas funciones.

  En cambio, una **variable local**, declarada dentro de una función como `loop()`, deja de existir cuando termina esa ejecución de la función. Si se vuelve a ejecutar `loop()`, la variable local se crea de nuevo: no podemos utilizarla directamente para recordar el valor que tenía en la iteración anterior. Por eso declaramos `servo1Position` como global.

  **DEBES SABER:** Cuando necesitemos conservar información entre sucesivas ejecuciones de `loop()`, utilizaremos variables globales, declaradas fuera de las funciones.
- `INPUT_PULLUP` mantiene la lectura del botón en `HIGH` cuando está libre y en `LOW` cuando está pulsado; por eso se comprueba `!digitalRead(BTNINC)`.
- El `if (servo1Position < 180)` deja incrementar la posición mientras no se haya alcanzado el máximo. El `else` enciende el LED rojo.

Observa dos detalles del programa de partida: **no apaga automáticamente el LED** y, mientras se mantiene pulsado el botón, puede repetir las operaciones en sucesivas ejecuciones de `loop()`. En esta tanda conservaremos esa forma de detectar la pulsación.

---

## 2. Actividad 2.1 — Convertir el incremento en una constante

**Problema.** El paso de giro está escrito directamente en la instrucción `servo1Position += 2;`. Si queremos probar otro incremento, tendremos que editar esa instrucción. Es preferible darle un nombre al valor.

### Paso 1. Declarar la constante al comienzo

Añadimos, junto a los otros `#define`:

```cpp
#define SERVO_STEP 2 //2.1
```

`SERVO_STEP` representa el número de grados de cada avance. El comentario `//2.1` identifica el cambio solicitado en el enunciado.

### Paso 2. Sustituir el valor fijo

**Antes:**

```cpp
servo1Position += 2;
```

**Después:**

```cpp
servo1Position += SERVO_STEP;
```

El resultado es inicialmente el mismo, porque `SERVO_STEP` vale `2`. La ventaja es que el incremento está definido en **un único lugar**.

**Comprobación:** simula varias pulsaciones y cambia temporalmente el valor de `SERVO_STEP`. Comprueba que los saltos varían sin modificar la instrucción de suma. Para la solución final dejamos el valor en `2`.

---

## 3. Actividad 2.2 — Apagar automáticamente el LED rojo

**Problema.** En el programa original, al alcanzar el límite, se enciende el LED rojo pero no existe una instrucción que lo apague. Queremos que solo permanezca encendido durante un segundo.

### Paso 1. Declarar el tiempo de encendido

Añadimos:

```cpp
#define LED_MS_ON 1000 //2.2
```

El nombre indica su finalidad y el valor está expresado en **milisegundos**: `1000 ms = 1 s`.

### Paso 2. Completar el bloque que gestiona el límite

**Antes:**

```cpp
else
{
  digitalWrite(LEDRED,HIGH);
}
```

**Después:**

```cpp
else
{
  digitalWrite(LEDRED,HIGH);
  delay(LED_MS_ON);
  digitalWrite(LEDRED,LOW);
}
```

Las instrucciones se ejecutan **en orden**: encender, esperar y apagar. `delay()` detiene temporalmente la ejecución; en esta actividad **no necesitamos responder al botón durante ese segundo**.

**Comprobación:** al llegar a 180°, el LED rojo se ilumina durante un segundo y después se apaga. Si el botón sigue pulsado, el siguiente paso por `loop()` puede volver a encenderlo: la detección de una pulsación única no es el objetivo de esta tanda.

---

## 4. Actividad 2.3 — Incorporar el segundo botón y el LED azul

Ahora queremos que el botón derecho incremente la posición hasta 180° y que el botón izquierdo la **decremente** hasta 0°. El LED rojo avisará del límite superior; el azul, del inferior. Ambos se apagarán automáticamente tras `LED_MS_ON`.

### Paso 1. Definir los pines que faltan

Al comienzo del programa añadimos:

```cpp
#define LEDBLU 4  // Blue led (blue wire)
#define BTNDEC 5  // DECrease BuTtoN on pin 5 (dark green wire)
```

### Paso 2. Configurarlos en `setup()`

Junto a los `pinMode()` existentes:

```cpp
pinMode(LEDBLU, OUTPUT);
pinMode(BTNDEC, INPUT_PULLUP);
```

Y junto al apagado inicial del LED rojo:

```cpp
digitalWrite(LEDBLU, LOW);
```

### Paso 3. Añadir el comportamiento simétrico

En esta actividad es razonable **duplicar provisionalmente** la lógica del botón original y adaptarla. El nuevo bloque que incorporamos a `loop()` es:

```cpp
if (!digitalRead(BTNDEC))
{
  if (servo1Position > 0)
  {
    servo1Position -= SERVO_STEP;
  }
  else
  {
    digitalWrite(LEDBLU, HIGH);
    delay(LED_MS_ON);
    digitalWrite(LEDBLU, LOW);
  }

  servoMotor1.write(servo1Position);
  delay(10);
}
```

Observa las diferencias entre los dos controles:

| Botón de incremento | Botón de decremento |
|---|---|
| `BTNINC` | `BTNDEC` |
| `LEDRED` | `LEDBLU` |
| `servo1Position < 180` | `servo1Position > 0` |
| `servo1Position += SERVO_STEP` | `servo1Position -= SERVO_STEP` |

**¿Por qué hacemos esto si repetimos código?** Porque primero queremos entender y comprobar las dos operaciones. Una vez funcionan, será más sencillo localizar qué tienen en común y qué debemos convertir en parámetros en la actividad 2.4.

**Comprobación:** desde 0° el botón de incremento desplaza el servo hacia 180°; desde 180° el botón de decremento lo desplaza hacia 0°. Al intentar avanzar más allá de cualquiera de los extremos, se enciende el LED correspondiente durante un segundo.

---

## 5. Actividad 2.4 — Refactorizar: un método para atender ambos botones

En la actividad anterior hemos escrito dos bloques muy parecidos. **Refactorizar** consiste en reorganizar ese código para hacerlo más reutilizable y fácil de mantener **sin cambiar su comportamiento**.

La idea es crear `CheckButton()`, que contenga la lógica común, y llamarlo una vez por cada botón. Para entender bien cómo funciona el paso de información a un método, vamos a introducir **los parámetros de uno en uno**.

### 5.1. Identificar qué cambia y qué se repite

Ambos bloques realizan las mismas tareas:

1. Comprobar si se ha pulsado un botón.
2. Comprobar si todavía es posible mover el servo en ese sentido.
3. Modificar la posición en un paso.
4. Si está en el límite, encender, esperar y apagar el LED correspondiente.
5. Enviar la posición al servo y realizar una breve pausa.

Lo que varía entre un bloque y otro es **qué botón**, **qué LED** y **qué sentido de giro** se utiliza. Esos serán los tres parámetros.

### 5.2. Primer parámetro: `button`

Empecemos por generalizar la lectura del botón. Un método escrito solo para el botón de incremento podría comenzar así:

```cpp
void CheckButton(byte button)
{
  if (!digitalRead(button))
  {
    // Aquí irá el resto del código que atiende la pulsación.
  }
}
```

En lugar de escribir `BTNINC` o `BTNDEC` dentro de la función, escribimos `button`: **un parámetro que recibe el pin que queremos comprobar**.

Para utilizar el método con los dos botones, necesitamos dos **invocaciones**:

```cpp
CheckButton(BTNINC);
CheckButton(BTNDEC);
```

**Relación fundamental:** `byte button` aparece en la **declaración** del método; `BTNINC` o `BTNDEC` es el **argumento** que proporcionamos en cada **llamada**. En la primera llamada, `button` recibe el valor de `BTNINC`; en la segunda, el de `BTNDEC`.

> **Importante:** este es un paso explicativo, todavía no el método definitivo. Cuando extraigamos el código completo tendremos que generalizar también el LED y el sentido de giro.

### 5.3. Segundo parámetro: `led`

Encontramos otra diferencia: un bloque usa `LEDRED` y el otro `LEDBLU`. Añadimos por tanto un segundo parámetro:

```cpp
void CheckButton(byte button, byte led)
{
  if (!digitalRead(button))
  {
    // ...
    digitalWrite(led, HIGH);
    delay(LED_MS_ON);
    digitalWrite(led, LOW);
    // ...
  }
}
```

Ahora **también debemos cambiar ambas invocaciones**:

```cpp
CheckButton(BTNINC, LEDRED);
CheckButton(BTNDEC, LEDBLU);
```

La correspondencia es **por posición**:

- **Primer argumento** → primer parámetro, `button`.
- **Segundo argumento** → segundo parámetro, `led`.

Si añades `led` a la declaración, pero sigues invocando `CheckButton(BTNINC)`, **faltará un argumento** y la llamada no se ajustará a la nueva firma del método. Declaración y llamadas deben evolucionar juntas.

> Igual que en el paso anterior, este fragmento solo ilustra el nuevo parámetro; todavía falta resolver la diferencia entre incrementar y decrementar.

### 5.4. Tercer parámetro: `sign`

La última diferencia importante es el sentido de giro. En vez de escribir dos instrucciones distintas:

```cpp
servo1Position += SERVO_STEP; // Incrementar
servo1Position -= SERVO_STEP; // Decrementar
```

Podemos utilizar una sola expresión multiplicando el paso por un **signo**:

```cpp
servo1Position += SERVO_STEP * sign;
```

- Si `sign` vale `+1`, sumamos `SERVO_STEP`.
- Si `sign` vale `-1`, restamos `SERVO_STEP`.

Añadimos el tercer parámetro a la declaración:

```cpp
void CheckButton(byte button, byte led, int sign)
```

Y, **una vez más, actualizamos ambas invocaciones**:

```cpp
CheckButton(BTNINC, LEDRED, +1);
CheckButton(BTNDEC, LEDBLU, -1);
```

Comprueba la concordancia completa:

| Posición | Parámetro en la declaración | Llamada para incrementar | Llamada para decrementar |
|---|---|---|---|
| 1 | `byte button` | `BTNINC` | `BTNDEC` |
| 2 | `byte led` | `LEDRED` | `LEDBLU` |
| 3 | `int sign` | `+1` | `-1` |

**Regla esencial:** no basta con añadir un parámetro a la función: también hay que **usar ese parámetro dentro** y **proporcionar un argumento del tipo adecuado en cada llamada, en el orden correcto**. Los nombres de los argumentos no tienen por qué coincidir con los nombres de los parámetros; lo que importa es su posición y el valor que transmiten.

### 5.5. Resolver el límite según el signo

Todavía queda una dificultad: para incrementar comprobábamos `< 180`, pero para decrementar comprobábamos `> 0`. El método debe decidir qué condición aplicar.

La solución final combina las dos posibilidades en un único `if`:

```cpp
if (
     ((sign > 0) && (servo1Position < 180))
     ||
     ((sign < 0) && (servo1Position > 0))
   )
{
  servo1Position += SERVO_STEP * sign;
}
else
{
  digitalWrite(led, HIGH);
  delay(LED_MS_ON);
  digitalWrite(led, LOW);
}
```

Interpretemos la condición **por partes**:

- `sign > 0 && servo1Position < 180`: **si vamos a incrementar**, solo podemos hacerlo mientras no hayamos llegado a 180°.
- `sign < 0 && servo1Position > 0`: **si vamos a decrementar**, solo podemos hacerlo mientras estemos por encima de 0°.
- `||` significa **«o»**: basta con que se cumpla una de las dos posibilidades para mover el servomotor.
- Si ninguna es verdadera, ejecutamos `else`: hemos alcanzado el límite del sentido elegido y avisamos con el LED recibido como parámetro.

Aquí vemos por qué **no necesitamos recibir los límites como parámetros**: el propio signo nos permite elegir entre las comparaciones con 180° y 0°.

### 5.6. El método completo de nuestra solución

Una vez integradas todas las diferencias, `CheckButton()` queda así:

```cpp
void CheckButton(byte button, byte led, int sign)
{
  if (!digitalRead(button)) // If button is pressed
  {
    // Increase or decrease the servo position
    if (
         ((sign>0)&&(servo1Position<180))
         ||
         ((sign<0)&&(servo1Position>0))
       )
    {
      servo1Position += SERVO_STEP*sign;
    }
    else
    {
      digitalWrite(led,HIGH);
      delay(LED_MS_ON);
      digitalWrite(led,LOW);
    }

    servoMotor1.write(servo1Position);
    delay(10);
  }
}
```

Ahora `loop()` ya no necesita contener dos bloques repetidos:

```cpp
void loop()
{
  delay(10);
  CheckButton(BTNINC, LEDRED, +1);
  CheckButton(BTNDEC, LEDBLU, -1);
}
```

**Lectura de la primera llamada:** comprueba `BTNINC`; si corresponde mover el servo, incrementa en pasos positivos; si se alcanzó el límite, avisa con `LEDRED`.

**Lectura de la segunda llamada:** comprueba `BTNDEC`; si corresponde mover el servo, decrementa en pasos negativos; si se alcanzó el límite, avisa con `LEDBLU`.

La operación es la misma; **lo que cambia son los argumentos**. Ésta es la utilidad de parametrizar un método.

### 5.7. No olvidemos los cambios en `setup()`

Aunque la refactorización se centre en `loop()`, el programa final también necesita declarar y configurar los dos botones y los dos LED:

```cpp
#define SERVO1 3
#define LEDRED 7
#define LEDBLU 4
#define BTNINC 6
#define BTNDEC 5

#define SERVO_STEP 2 //2.1
#define LED_MS_ON 1000 //2.2
```

Y en `setup()`:

```cpp
pinMode(LEDRED, OUTPUT);
pinMode(LEDBLU, OUTPUT);
pinMode(BTNINC, INPUT_PULLUP);
pinMode(BTNDEC, INPUT_PULLUP);

servoMotor1.attach(SERVO1);
servo1Position = 0;
servoMotor1.write(servo1Position);

digitalWrite(LEDRED, LOW);
digitalWrite(LEDBLU, LOW);
```

Los comentarios `//2.1` y `//2.2` identifican las constantes solicitadas en aquellas actividades; la solución final facilitada en clase contiene comentarios descriptivos equivalentes.

### 5.8. Comprobar y comprender el resultado

Prueba la versión final en Wokwi:

1. Comprueba que el servomotor comienza en 0°.
2. Mantén pulsado el botón de incremento: la posición avanza de 2° en 2° hasta 180°.
3. En el límite superior, comprueba que se enciende el LED rojo durante `LED_MS_ON`.
4. Utiliza el botón de decremento para regresar hasta 0°.
5. En el límite inferior, comprueba que se enciende el LED azul durante `LED_MS_ON`.
6. Revisa que ambas acciones se atienden mediante **el mismo método**.

**Nota sobre la precisión:** con `SERVO_STEP = 2`, el recorrido desde 0° a 180° coincide exactamente con los extremos. Si se utilizasen otros pasos que no dividen exactamente ese intervalo, convendría añadir una comprobación para evitar sobrepasar el límite. No forma parte de la solución original que estamos explicando.

---

## 6. ¿Qué hemos aprendido?

Esta tanda ha servido para reforzar:

- **Constantes:** sustituir valores fijos por nombres expresivos, como `SERVO_STEP` y `LED_MS_ON`.
- **Secuencia:** encender un LED, esperar y apagarlo.
- **Condiciones:** decidir cuándo mover el servo y cuándo avisar de un límite, usando `if`, `else`, `&&` y `||`.
- **Estado del programa:** almacenar y modificar la posición mediante `servo1Position`.
- **Métodos y parámetros:** extraer instrucciones repetidas y convertir las diferencias en datos recibidos por el método.
- **Invocaciones:** mantener la correspondencia entre los parámetros declarados y los argumentos proporcionados en cada llamada.
- **Refactorización:** mejorar la organización del programa sin cambiar el comportamiento que ya habíamos conseguido.

La idea más importante de la actividad 2.4 es que **declaración, cuerpo del método e invocaciones forman un conjunto coherente**. Si añadimos o cambiamos un parámetro, debemos revisar cómo se utiliza dentro del método y cómo se proporciona desde cada llamada.
