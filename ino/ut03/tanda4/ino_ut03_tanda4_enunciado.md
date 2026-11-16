# UT03 · Programación de microcontroladores — Tanda 4

## Objetivo

Esta tanda de ejercicios es un **refuerzo práctico de los contenidos de la UT03** (secuencia, condición y repetición). Desarrollaremos un pequeño **juego de velocidad de reacción** utilizando un pulsador, un LED y la consola serie, mediante el simulador Wokwi y las funciones de Arduino sobre un ESP32.

## Proyecto de partida

1. Accede al [proyecto compartido por el profesor](https://wokwi.com/projects/480296045717363713).
2. Inicia sesión en Wokwi con tu **cuenta de GitHub** y guarda una copia del proyecto en tu cuenta de Wokwi. No utilices la cuenta `@alu.murciaeduca.es`, ya que su administrador no permite esta autenticación.
3. Realiza las actividades **por orden**, modificando progresivamente el mismo programa. Comprueba el funcionamiento mediante la simulación después de cada cambio.

El circuito contiene **un pulsador y un LED**. El programa inicial ya distingue tres estados (`ESTADO_INICIAL`, `ESTADO_ESPERANDO_LUZ` y `ESTADO_LUZ_ENCENDIDA`), detecta pulsaciones individuales mediante `boton_pulsado` y muestra mensajes en la consola serie. Tu tarea será completar el comportamiento del juego.

## Actividades

### Actividad 4.1. Transición entre estados y pulsación anticipada

Modifica el programa para que gestione el paso entre el estado inicial y el estado de espera de encendido del LED.

1. Cuando se pulse el botón en `ESTADO_INICIAL`, el programa cambiará a `ESTADO_ESPERANDO_LUZ`.
2. Si se vuelve a pulsar el botón mientras está en `ESTADO_ESPERANDO_LUZ`, se mostrará por la consola serie el mensaje exacto:

   ```text
   Has perdido por adelantarte al encendido
   ```

3. Después de mostrar este mensaje, el programa volverá a `ESTADO_INICIAL`, quedando preparado para comenzar una nueva partida.
4. Mantén el mecanismo existente para detectar pulsaciones individuales mediante la variable `boton_pulsado`.
5. El LED permanecerá apagado durante toda esta actividad.

**TIP:** Utiliza la variable `estado` para gestionar las transiciones dentro del `switch`. Recuerda que puedes modificar su valor mediante una asignación.

### Actividad 4.2. Encendido aleatorio del LED y tiempo límite de reacción

Amplía el programa para que el LED se encienda después de un tiempo de espera aleatorio y el jugador disponga de un tiempo limitado para reaccionar.

1. Declara una variable de tipo `int` que actuará como **contador de ticks**.
2. Cuando se pulse el botón en `ESTADO_INICIAL`, asigna al contador un número entero aleatorio comprendido entre **200 y 500**, ambos incluidos.
3. Investiga cómo generar números aleatorios con las funciones de Arduino.
4. El contador deberá decrementarse en una unidad en cada ejecución de `loop()`, excepto cuando el programa se encuentre en `ESTADO_INICIAL`.
5. Como el programa incluye un `delay(10)` en cada ejecución de `loop()`, consideraremos que transcurren aproximadamente **100 ticks por segundo**. Por tanto, el LED se encenderá después de una espera aleatoria de entre 2 y 5 segundos.
6. Cuando el contador llegue a **0**, se encenderá el LED y el programa cambiará a `ESTADO_LUZ_ENCENDIDA`.
7. El contador continuará decrementándose. Si alcanza el valor **-200**, se mostrará por la consola serie el mensaje exacto:

   ```text
   Has perdido por no actuar sobre el botón durante demasiado tiempo
   ```

8. Después de mostrar el mensaje, el LED se apagará y el programa volverá a `ESTADO_INICIAL`, quedando preparado para una nueva partida.
9. Mantén el comportamiento de la actividad 4.1: si el jugador pulsa antes de que se encienda el LED, perderá por adelantarse y volverá al estado inicial.

**TIP:** Arduino dispone de la función `random(min, max)`, que genera un entero desde `min` **incluido** hasta `max` **excluido**. Por ejemplo, `random(10, 21)` puede devolver cualquiera de los valores del 10 al 20. Adapta esta idea al intervalo solicitado. Puedes decrementar el contador y comprobar su valor mediante condiciones `if` en `loop()`.

**Nota:** Los tiempos son aproximados: cada ejecución de `loop()` puede tardar algo más de 10 ms. Utilizaremos deliberadamente un contador de ticks para reforzar el trabajo con variables, condiciones y repetición.

### Actividad 4.3. Medición del tiempo de reacción

Completa el programa para medir el tiempo que tarda el jugador en pulsar el botón después de que se encienda el LED.

1. Cuando se pulse el botón en `ESTADO_LUZ_ENCENDIDA`, obtén el valor actual del contador de ticks.
2. Como el contador estará en negativo, conviértelo a **positivo** para calcular el tiempo de reacción.
3. Muestra por la consola serie el siguiente mensaje, sustituyendo `x` por el valor calculado:

   ```text
   Has tardado x centésimas
   ```

4. Después de mostrar el resultado, apaga el LED y vuelve a `ESTADO_INICIAL`, dejando el sistema preparado para una nueva partida.
5. Mantén los comportamientos de las actividades anteriores: pérdida por pulsación anticipada y pérdida por superar el tiempo límite de reacción.

**TIP:** Puedes utilizar el operador de cambio de signo (`-`) para convertir un número negativo en positivo. Recuerda que `Serial.print()` y `Serial.println()` permiten construir mensajes combinando texto y valores de variables.

## Entrega

Entrega **un único archivo** `.ino` con la solución final de todas las actividades. Los archivos `.ino` contienen el código fuente utilizado en el entorno Arduino.

Guárdalo en tu repositorio en esta ruta exacta:

```text
/ino/ut03/tanda4/tanda4.ino
```

Realiza **un único commit al terminar toda la tanda**, con este mensaje exacto:

```text
UT03 INO Tanda 4 - solución final
```

Sube el commit a tu repositorio remoto.

En el repositorio del profesor podrás encontrar también el archivo `/ino/ut03/tanda4/tanda4.zip`, **si está disponible**, con una exportación del proyecto de Wokwi que incluye `diagram.json` (descripción del circuito) y el código original. No es necesario descargarlo ni entregarlo, porque el proyecto se comparte mediante la URL indicada; se facilita únicamente como referencia y para restaurar el proyecto original si fuera necesario.
