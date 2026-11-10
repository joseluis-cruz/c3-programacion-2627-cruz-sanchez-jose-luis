# UT03 · Programación de microcontroladores — Tanda 5

## Objetivo

Esta tanda es un **refuerzo práctico de los contenidos de la UT03** (secuencia, condición y repetición). Utilizaremos Wokwi para simular un **sensor de aparcamiento** con un sensor ultrasónico de distancia HC-SR04 y un LED, empleando las funciones de Arduino.

En un sensor de aparcamiento real se escuchan pitidos (*beeps*) cada vez más frecuentes al acercarse a un obstáculo. En nuestro circuito simularemos esos avisos mediante **destellos del LED**:

- Cada destello durará `ESPERA_ENCENDIDO` milisegundos (inicialmente, **100 ms**).
- Entre destellos, el LED permanecerá apagado durante un tiempo proporcional a la distancia medida:

  `espera (ms) = distancia (cm) * ESPERA_MS_POR_CM`

  La constante `ESPERA_MS_POR_CM` vale inicialmente **2**.

Por tanto, **cuanto menor sea la distancia, más frecuentes serán los destellos**.

## Proyecto de partida

1. Accede al [proyecto de Wokwi compartido por el profesor](https://wokwi.com/projects/480316366638323713).
2. Inicia sesión con tu **cuenta de GitHub** y guarda una copia del proyecto en tu cuenta de Wokwi. No utilices la cuenta `@alu.murciaeduca.es`, ya que su administrador no permite esta autenticación.
3. Parte del código proporcionado, que ya mide la distancia al obstáculo mediante `GetDistancia()` y la muestra en la consola serie. Comprueba el funcionamiento mediante la simulación.

El circuito dispone de un **sensor ultrasónico HC-SR04** y un **LED**. No es necesario modificar las conexiones.

## Actividades

### Actividad 5.1. Simulación de un sensor de aparcamiento

Completa el programa original para simular un **sensor de aparcamiento** que avisa de la proximidad de un obstáculo mediante destellos de un LED, en sustitución de los pitidos (*beeps*) de un sensor real.

Ten en cuenta las siguientes condiciones:

1. El programa deberá seguir midiendo la distancia al obstáculo mediante `GetDistancia()`.
2. En cada ciclo, el LED se encenderá durante `ESPERA_ENCENDIDO` milisegundos (inicialmente, **100 ms**).
3. Después se apagará y permanecerá así durante un tiempo proporcional a la distancia medida, calculado como `distancia * ESPERA_MS_POR_CM`.
4. El proceso se repetirá indefinidamente, actualizando la distancia en cada ciclo.
5. Se conservará la visualización de la distancia en centímetros mediante la consola serie.
6. Utiliza las constantes ya definidas, evitando introducir valores fijos en las instrucciones de espera.

**TIP:** Utiliza `digitalWrite()` para controlar el LED y `delay()` para establecer los tiempos de encendido y apagado. Sustituye la espera fija de 500 ms del programa original por las esperas necesarias.

**Objetivo:** Cuanto menor sea la distancia al obstáculo, más frecuentes serán los destellos del LED.

## Entrega

Entrega **un único archivo** `.ino` con la solución final. Los archivos `.ino` contienen el código fuente utilizado en el entorno Arduino.

Guárdalo en tu repositorio en esta ruta:

```text
/ino/ut03/tanda5/tanda5.ino
```

Realiza **un único commit al terminar la tanda**, con este mensaje:

```text
UT03 INO Tanda 5 - solución final
```

Sube el commit a tu repositorio remoto.
