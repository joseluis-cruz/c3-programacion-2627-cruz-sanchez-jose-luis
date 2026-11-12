# UT03 · Programación de microcontroladores — Tanda 6: Metrónomo

## Objetivo

Esta tanda de ejercicios es un **refuerzo práctico de los contenidos de la UT03** (secuencia, condición y repetición). Construiremos un **metrónomo visual y mecánico**: el servomotor moverá una aguja imaginaria de un lado a otro, como el péndulo de un metrónomo; el potenciómetro regulará la velocidad y el pulsador permitirá iniciar o detener el movimiento. Trabajaremos con un **Arduino Uno, un potenciómetro, un servomotor y un pulsador** en el simulador Wokwi. No generaremos sonido: el ritmo se representará mediante el movimiento del servomotor.

## Proyecto de partida

1. Accede al [proyecto compartido por el profesor](https://wokwi.com/projects/479671834169382913).
2. Inicia sesión en Wokwi con tu **cuenta de GitHub** y guarda una copia del proyecto en tu cuenta. No utilices la cuenta `@alu.murciaeduca.es`, ya que su administrador no permite esta autenticación.
3. Realiza las actividades **por orden**, partiendo en cada caso del resultado de la anterior, y comprueba su funcionamiento en el simulador. El objetivo final será construir el **metrónomo de movimiento oscilante y velocidad regulable**.

**Aviso sobre el código de partida:** comprueba y corrige los pequeños errores de escritura que impidan compilarlo (en la llamada inicial a `servo1.write()` y en las mayúsculas/minúsculas de `boton1pulsado`) antes de realizar las actividades.

**Importante:** aunque las actividades sean progresivas, **guarda el código de cada una en un archivo `.ino` diferente**: `actividad_6_1.ino`, `actividad_6_2.ino`, `actividad_6_3.ino` y `actividad_6_4.ino`. Así podrás conservar y comprobar por separado las cuatro soluciones.

## Actividades

### Actividad 6.1. Mostrar solo los cambios del valor analógico

Modifica el programa para que **solo se muestre por la consola serie el valor analógico del potenciómetro cuando haya cambiado** respecto al último valor informado.

1. Mantén la lectura del potenciómetro cada **100 ms**.
2. Compara cada lectura con el último valor mostrado por consola.
3. Si el valor ha cambiado, muéstralo por consola serie; si no ha cambiado, no muestres de nuevo ese valor.
4. Conserva el resto del funcionamiento del programa.
5. Opcionalmente, puedes enviar mensajes adicionales a la consola serie para informar de las pulsaciones del botón o de los cambios de sentido del servomotor, cuando correspondan.

**TIP1:** Deberás declarar una **variable global**, como ya se hace con `servo1pos`, para recordar el último valor informado y compararlo con el valor actual antes de volver a mostrarlo.

### Actividad 6.2. Controlar la aguja del metrónomo con el potenciómetro

Modifica el programa para que el servomotor se mueva hasta una **posición proporcional al valor del potenciómetro**.

1. El potenciómetro proporciona valores analógicos entre **0 y 1023**.
2. El servomotor puede posicionarse entre **0° y 180°**.
3. Convierte proporcionalmente el valor del potenciómetro a un ángulo comprendido entre esos límites.
4. Actualiza la posición del servomotor cuando cambie el valor del potenciómetro.
5. Mantén el comportamiento de la actividad 6.1: muestra por consola serie los valores analógicos únicamente cuando cambien.
6. Opcionalmente, puedes enviar mensajes adicionales a la consola serie para informar de las pulsaciones del botón o de los cambios de sentido del servomotor, cuando correspondan.

**TIP2:** Investiga la función `map()` de Arduino, que permite transformar un valor de un intervalo a otro. Puedes utilizarla para convertir el intervalo **0–1023** en **0–180**.

### Actividad 6.3. Movimiento del metrónomo con velocidad regulable

Modifica el programa para que el servomotor simule la **oscilación continua de un metrónomo**, moviéndose de un extremo al otro. El potenciómetro regulará la velocidad de ese movimiento.

1. El servomotor comenzará en **0°** y avanzará en saltos de **10°**: 0°, 10°, 20°… hasta 180°.
2. Al alcanzar **180°**, invertirá el sentido, retrocediendo en saltos de 10° hasta llegar a **0°**.
3. Al llegar a 0°, volverá a invertir el sentido y repetirá el movimiento indefinidamente.
4. El tiempo de espera entre saltos será el valor analógico del potenciómetro **dividido entre 10**, expresado en milisegundos.
5. Cuanto mayor sea el valor del potenciómetro, más lento será el movimiento.
6. Mantén la visualización por consola serie del valor analógico únicamente cuando cambie, como en la actividad 6.1.
7. Opcionalmente, puedes enviar mensajes adicionales a la consola serie para informar de las pulsaciones del botón o de los cambios de sentido del servomotor, cuando correspondan.

**TIP3:** Puedes utilizar una variable global `estado` para indicar si el servomotor está parado (`0`), incrementando grados (`1`) o decrementando grados (`-1`). Así podrás decidir cómo actualizar la posición y cuándo invertir el sentido del movimiento.

### Actividad 6.4. Arranque y parada del metrónomo mediante pulsador

Completa el metrónomo para que el botón permita **arrancar y detener** su movimiento oscilante, alternando entre ambos estados con cada pulsación.

1. Inicialmente, el servomotor estará **parado en 0°**.
2. Al pulsar el botón por primera vez, comenzará el movimiento oscilante de la actividad 6.3.
3. Al pulsarlo de nuevo, el servomotor se detendrá y **volverá a 0°**.
4. La siguiente pulsación iniciará de nuevo el movimiento desde **0° en sentido ascendente**.
5. El potenciómetro seguirá regulando el tiempo de espera entre los saltos de 10°.
6. Mantén la visualización por consola serie del valor analógico únicamente cuando cambie.
7. Cada pulsación deberá procesarse **una sola vez**, aunque el botón permanezca presionado.
8. Opcionalmente, puedes enviar mensajes adicionales a la consola serie para informar de las pulsaciones del botón o de los cambios de sentido del servomotor.

**TIP4:** Utiliza la variable global `estado` para controlar el movimiento: `0` (parado), `1` (incrementando grados) y `-1` (decrementando grados). Al detener el servomotor, establece `estado = 0` y devuelve su posición a 0°. Al arrancarlo, establece `estado = 1`. Aprovecha el mecanismo de detección de pulsaciones individuales que ya incorpora el programa original.

## Entrega

Los programas de Arduino utilizan archivos con extensión **`.ino`**, que contienen el código fuente. Guarda **un archivo por actividad** en tu repositorio, en la siguiente ruta exacta:

```text
src/ino/ut03/tanda6/
├── actividad_6_1.ino
├── actividad_6_2.ino
├── actividad_6_3.ino
└── actividad_6_4.ino
```

Realiza **un único commit al finalizar toda la tanda**, con este mensaje exacto:

```text
UT03 INO Tanda 6 - solución final
```

Sube el commit a tu repositorio remoto.
