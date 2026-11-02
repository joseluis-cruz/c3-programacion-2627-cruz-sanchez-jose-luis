# Wokwi — UT03. Tanda 1: secuencia, condición y repetición

Estas actividades son **ejercicios auxiliares de refuerzo de la UT03** del módulo de Programación. Su objetivo es practicar las estructuras de **secuencia, condición y repetición** mediante la programación de un microcontrolador ESP32 con las funciones de Arduino.

## Proyecto de partida

El profesor comparte el circuito y el programa inicial en Wokwi:

**[Abrir el proyecto de la tanda 1](https://wokwi.com/projects/479588049590466561)**

El circuito contiene tres LED y un pulsador. Se utilizan las siguientes definiciones:

| Definición | Pin | Componente |
| --- | ---: | --- |
| `LEDR` | 4 | LED rojo |
| `LEDA` | 3 | LED amarillo (ámbar) |
| `LEDV` | 2 | LED verde |
| `BTN1` | 7 | Pulsador |

**Instrucciones generales:** comienza cada actividad a partir del proyecto original, salvo que el profesor indique lo contrario. No modifiques las conexiones ni los pines. Ejecuta la simulación para comprobar el resultado y guarda el código correspondiente a cada actividad.

## Actividades

### Actividad 1. Comprender el código original

Observa el código y analiza su funcionamiento. **Al final del archivo, añade comentarios utilizando `//`** para responder a estas cuestiones:

1. ¿Para qué sirven las instrucciones `#define`?
2. ¿Qué función tiene `setup()` y cuándo se ejecuta?
3. ¿Qué función tiene `loop()` y cuándo se ejecuta?
4. ¿Para qué sirven `pinMode()`, `digitalWrite()`, `digitalRead()` y `delay()`?
5. ¿Qué ocurre cuando se pulsa el botón y qué estructuras de control intervienen?

**Importante:** no modifiques el programa original en esta actividad; escribe las respuestas únicamente como comentarios al final del código.

### Actividad 2. Modificar los parpadeos

Modifica el programa para que, al pulsar el botón, el **LED rojo parpadee 5 veces**, permaneciendo **300 ms encendido** y **300 ms apagado** en cada repetición.

**TIP:** revisa los límites del bucle `for` y los valores de `delay()`.

### Actividad 3. Alternar dos LED

Modifica el programa para que, al pulsar el botón, los LED **rojo y verde se enciendan alternativamente durante 5 ciclos completos**, con un tiempo de conmutación de **250 ms**.

Condiciones:

1. Cuando el rojo esté encendido, el verde estará apagado, y viceversa.
2. Cada ciclo completo incluirá un encendido del rojo y otro del verde.
3. Define una **constante** para el tiempo de conmutación y utilízala en `delay()`.
4. Utiliza un bucle `for` para realizar los 5 ciclos.
5. Al finalizar, ambos LED quedarán apagados.

**TIP:** dentro de cada repetición necesitas dos estados de los LED y una espera después de cada cambio.

### Actividad 4. Secuencia de tres LED

Modifica el programa para que, al pulsar el botón, los tres LED se iluminen secuencialmente durante **4 ciclos completos**.

Condiciones:

1. El orden de encendido será **rojo → amarillo → verde**.
2. Solo podrá haber **un LED encendido al mismo tiempo**: al encender uno, el anterior deberá apagarse.
3. Cada LED permanecerá encendido **250 ms**.
4. Define una **constante** para el tiempo de conmutación.
5. Utiliza un bucle `for` para repetir la secuencia 4 veces.
6. Al terminar, los tres LED quedarán apagados.

**TIP:** organiza `digitalWrite()` y `delay()` dentro del bucle respetando el orden y evitando dos LED encendidos a la vez.

### Actividad 5. Semáforo controlado por pulsador

Modifica el programa para simular un semáforo que permanece normalmente en verde y cambia de estado al pulsar el botón.

Condiciones:

1. Inicialmente, el **LED verde estará encendido** y los otros dos apagados.
2. Al pulsar el botón, el semáforo pasará a **amarillo**.
3. Después de **1 segundo**, pasará de amarillo a **rojo**.
4. Permanecerá **3 segundos** en rojo.
5. Finalmente, volverá al **verde**, donde permanecerá hasta una nueva pulsación.
6. Solo podrá haber **un LED encendido al mismo tiempo**.
7. Define **constantes** para los tiempos de espera.

**TIP:** utiliza `digitalRead()` para comprobar el botón, `digitalWrite()` para controlar los LED y `delay()` para establecer las pausas.

### Actividad 6. Semáforo con amarillo intermitente

Modifica el programa para simular un semáforo que normalmente parpadea en amarillo y cambia temporalmente de estado al pulsar el botón.

Condiciones:

1. Inicialmente, el **LED amarillo parpadeará continuamente**, alternando encendido y apagado cada **500 ms**. Los LED rojo y verde permanecerán apagados.
2. Al pulsar el botón, el amarillo quedará **encendido de forma fija durante 1 segundo**.
3. Después, cambiará a **rojo durante 3 segundos**.
4. Finalmente, se apagará el rojo y el amarillo **volverá a parpadear** hasta una nueva pulsación.
5. Solo podrá haber **un LED encendido al mismo tiempo**.
6. Define **constantes** para los tiempos de espera.
7. Utiliza las estructuras de control necesarias para gestionar el parpadeo y la pulsación.

**TIP:** `loop()` se ejecuta continuamente. Puedes aprovecharlo para generar el parpadeo sin un bucle adicional. Comprueba el botón con la frecuencia necesaria para iniciar la secuencia cuando se detecte la pulsación.

## Entrega de las actividades

Los programas de Arduino se guardan en archivos con extensión **`.ino`**, que contienen su código fuente. En tu repositorio, utiliza la carpeta `/ino/ut03/tanda1/` y estos nombres:

```text
/ino/ut03/tanda1/
├── actividad_1_1.ino
├── actividad_1_2.ino
├── actividad_1_3.ino
├── actividad_1_4.ino
├── actividad_1_5.ino
└── actividad_1_6.ino
```

En el repositorio del profesor encontrarás también el archivo `/ino/ut03/tanda1/diagram.json`, que define el circuito de Wokwi. **No necesitas copiarlo ni entregarlo**, ya que el circuito se ha compartido mediante el [enlace al proyecto](https://wokwi.com/projects/479588049590466561). Se proporciona únicamente **a título informativo y por si fuera necesario restaurar el circuito original**.

Realiza **un commit por actividad**, con estos mensajes exactos:

| Actividad | Mensaje del commit |
| --- | --- |
| 1 | `INO-T1 actividad 1` |
| 2 | `INO-T1 actividad 2` |
| 3 | `INO-T1 actividad 3` |
| 4 | `INO-T1 actividad 4` |
| 5 | `INO-T1 actividad 5` |
| 6 | `INO-T1 actividad 6` |

Finalmente, **sube los commits a tu repositorio remoto**.
