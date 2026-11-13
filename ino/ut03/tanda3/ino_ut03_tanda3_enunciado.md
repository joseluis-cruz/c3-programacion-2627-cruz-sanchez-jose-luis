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

### Actividad 3.3. Selección del estado mediante pulsadores

Modifica el programa para que los intermitentes se controlen mediante los pulsadores del circuito, **recordando en qué estado se encuentra el sistema**.

El funcionamiento será el siguiente:

1. Al pulsar el botón izquierdo, se activará el intermitente izquierdo.
2. Al pulsar el botón derecho, se activará el intermitente derecho.
3. **Si se vuelve a pulsar el botón del intermitente que está funcionando, este se desactivará y dejará de parpadear.**
4. Una vez activado, un intermitente continuará parpadeando aunque se suelte el botón.
5. Si se pulsa el botón contrario, el intermitente activo se apagará y comenzará a parpadear el otro.
6. Si no hay ningún intermitente activado, ambos LED permanecerán apagados.
7. Declara una **variable global** de tipo `byte` llamada `estado`, que recuerde el estado actual del sistema entre sucesivas ejecuciones de `loop()`.
8. Define al principio del código las constantes que identifiquen cada estado:
   - `ESTADO_TODO_APAGADO` (`0`): ambos intermitentes apagados.
   - `ESTADO_PARPADEA_IZQUIERDA` (`1`): intermitente izquierdo activado.
   - `ESTADO_PARPADEA_DERECHA` (`2`): intermitente derecho activado.
9. Inicializa `estado` en `setup()` con el valor `ESTADO_TODO_APAGADO` y mantén la velocidad de parpadeo establecida mediante `BLINK_MS`.

**TIP:** Organiza el programa en dos fases: primero comprueba las pulsaciones para actualizar `estado`; después enciende y apaga los LED según ese estado. Puedes utilizar condiciones `if` y `else if` para decidir las transiciones.

### Actividad 3.4. Incorporar el estado de emergencia

Amplía el programa para incorporar un **estado de emergencia** en el que los dos intermitentes parpadeen simultáneamente.

Ten en cuenta las siguientes condiciones:

1. Añade una nueva constante: `ESTADO_EMERGENCIA` (`3`), que identificará el estado de emergencia.
2. Al pulsar **ambos botones simultáneamente**, el sistema entrará en estado de emergencia, desde cualquiera de los otros estados.
3. Si el estado de emergencia ya está activado, al volver a pulsar ambos botones se desactivará y el sistema regresará a `ESTADO_TODO_APAGADO`.
4. Durante la emergencia, ambos LED deberán encenderse y apagarse **a la vez**, con el intervalo establecido por `BLINK_MS`.
5. Al pulsar únicamente el botón izquierdo o derecho, se seleccionará el estado de ese intermitente, aplicando la misma regla de activación y desactivación de la actividad 3.3.
6. El programa deberá gestionar los cuatro estados y permitir cambiar entre ellos sin reiniciar el sistema.
7. Conserva la organización en dos fases: comprobación de pulsadores y actualización de `estado`; después, control de los LED según ese estado.

**TIP:** Comprueba primero si están pulsados **ambos botones** y utiliza `else if` para que, en ese caso, no se atiendan también las condiciones de los botones por separado. Recuerda que el estado de emergencia implica encender y apagar los dos LED simultáneamente.

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
