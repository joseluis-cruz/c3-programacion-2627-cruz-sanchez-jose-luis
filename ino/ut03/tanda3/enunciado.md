# UT03 · Programación de microcontroladores — Tanda 3

## Objetivo

Esta tanda de ejercicios es un **refuerzo práctico de los contenidos de la UT03** (secuencia, condición y repetición). Trabajaremos con un circuito de intermitentes mediante el simulador Wokwi, utilizando las funciones de Arduino sobre un ESP32.

## Proyecto de partida

1. Accede al [proyecto compartido por el profesor](https://wokwi.com/projects/479932135432769537).
2. Inicia sesión en Wokwi con tu **cuenta de GitHub** y guarda una copia del proyecto en tu cuenta de Wokwi. No utilices la cuenta `@alu.murciaeduca.es`, ya que su administrador no permite esta autenticación.
3. Realiza las actividades **por orden**, modificando progresivamente el mismo programa. Comprueba el funcionamiento mediante la simulación después de cada cambio.

El proyecto contiene el circuito necesario para simular un sistema de intermitentes. Deberás programar su funcionamiento, utilizando los pulsadores y los LED disponibles en el montaje.

## Actividades

### Actividad 3.1. Configurar el parpadeo de los intermitentes

Modifica el programa para que el LED correspondiente al intermitente izquierdo parpadee de forma continua.

1. Define al principio del código una constante llamada `BLINK_MS` con valor inicial **500** (milisegundos).
2. Añade el comentario en línea `//3.1` junto a su declaración.
3. El LED deberá permanecer encendido durante `BLINK_MS` milisegundos y apagado durante el mismo intervalo.
4. El parpadeo deberá repetirse indefinidamente.
5. Comprueba que puedes modificar la velocidad del parpadeo cambiando únicamente el valor de `BLINK_MS`.

**TIP:** Puedes utilizar `digitalWrite()` para encender y apagar el LED y `delay()` para establecer los intervalos de tiempo.

### Actividad 3.2. Incorporar el intermitente derecho

Amplía el programa para que también funcione el intermitente derecho.

1. El LED izquierdo seguirá parpadeando con el comportamiento de la actividad anterior.
2. El LED derecho deberá realizar el mismo parpadeo, utilizando también la constante `BLINK_MS`.
3. Define una constante para cada uno de los pines de los LED, si todavía no están definidas.
4. Añade el comentario en línea `//3.2` junto a las nuevas declaraciones.
5. Comprueba que ambos intermitentes pueden funcionar de forma independiente.

**TIP:** Puedes utilizar una estructura `if` para decidir qué LED debe encenderse y apagarse. No es necesario duplicar la constante que establece el tiempo de parpadeo.

### Actividad 3.3. Selección del intermitente mediante pulsadores

Modifica el programa para que los intermitentes se controlen mediante los pulsadores del circuito.

El funcionamiento será el siguiente:

1. Al pulsar el botón izquierdo, se activará el intermitente izquierdo.
2. Al pulsar el botón derecho, se activará el intermitente derecho.
3. Si no se pulsa ningún botón, los dos intermitentes permanecerán apagados.
4. Si se activa uno de los intermitentes, deberá parpadear indefinidamente hasta que se seleccione otro modo de funcionamiento.
5. Si se pulsa el botón contrario, el intermitente que estaba funcionando se apagará y comenzará a funcionar el otro.
6. Utiliza una variable para almacenar el modo de funcionamiento actual:
   - `0`: ningún intermitente activado.
   - `1`: intermitente izquierdo.
   - `2`: intermitente derecho.
7. Mantén la velocidad de parpadeo establecida mediante `BLINK_MS`.

**TIP:** Puedes utilizar una variable de tipo `byte` y una estructura `switch` para gestionar los tres modos de funcionamiento. Recuerda que debes distinguir entre la lectura de los pulsadores y el control del parpadeo.

### Actividad 3.4. Incorporar los cuatro intermitentes y refactorizar el código

Amplía el programa para incorporar el funcionamiento de emergencia, en el que los dos intermitentes parpadean simultáneamente.

Para ello, modifica el sistema de selección de modos y reorganiza el código.

1. Incorpora un nuevo modo de funcionamiento:
   - `0`: ningún intermitente activado.
   - `1`: intermitente izquierdo.
   - `2`: intermitente derecho.
   - `3`: emergencia (ambos intermitentes).
2. Utiliza el pulsador disponible para activar el modo de emergencia, si el circuito dispone de él.
3. Cuando esté activado el modo de emergencia, los dos LED deberán encenderse y apagarse simultáneamente.
4. Refactoriza el código para trasladar la gestión del parpadeo a un único método llamado `Blink`.
5. El método no devolverá ningún valor (`void`).
6. Recibirá dos parámetros:
   - `led` (`byte`): pin del LED que se desea controlar.
   - `enabled` (`bool`): indica si el intermitente debe estar activo.
7. Desde `loop()` se llamará al método correspondiente para cada LED, de acuerdo con el modo de funcionamiento seleccionado.
8. El funcionamiento final deberá permitir cambiar entre los cuatro modos sin necesidad de reiniciar el programa.

La declaración del método tendrá esta estructura:

```cpp
void Blink(byte led, bool enabled)
{
  // Código para controlar el parpadeo del LED
}
```

**TIP:** Utiliza variables para almacenar el estado y el instante del último cambio de cada LED. Puedes utilizar `millis()` para controlar los intervalos sin detener la ejecución del programa mediante `delay()`.

## Entrega

Entrega **un único archivo** `.ino` con la solución final de todas las actividades. Los archivos `.ino` contienen el código fuente utilizado en el entorno Arduino.

Guárdalo en tu repositorio en esta ruta exacta:

```text
/ino/ut03/tanda3/tanda3.ino
```

Realiza **un único commit al terminar toda la tanda**, con este mensaje exacto:

```text
UT03 INO Tanda 3 - solución final
```

Sube el commit a tu repositorio remoto.

En el repositorio del profesor encontrarás también el archivo `/ino/ut03/tanda3/tanda3.zip`, que contiene una exportación completa del proyecto de Wokwi, incluyendo `diagram.json` (descripción del circuito) y el código original. **No es necesario descargarlo ni entregarlo**, ya que el proyecto se comparte mediante la URL indicada. Se proporciona únicamente a título informativo y por si fuera necesario restaurar el proyecto original.
