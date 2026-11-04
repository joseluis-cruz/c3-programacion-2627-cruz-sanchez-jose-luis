# UT03 · Programación de microcontroladores — Tanda 2

## Objetivo

Esta tanda de ejercicios es un **refuerzo práctico de los contenidos de la UT03** (secuencia, condición y repetición). Trabajaremos con un servomotor, dos pulsadores y dos LED mediante el simulador Wokwi, utilizando las funciones de Arduino sobre un ESP32.

## Proyecto de partida

1. Accede al [proyecto compartido por el profesor](https://wokwi.com/projects/479671974184741889).
2. Inicia sesión en Wokwi con tu **cuenta de GitHub** y guarda una copia del proyecto en tu cuenta de Wokwi. No utilices la cuenta `@alu.murciaeduca.es`, ya que su administrador no permite esta autenticación.
3. Realiza las actividades **por orden**, modificando progresivamente el mismo programa. Comprueba el funcionamiento mediante la simulación después de cada cambio.

En el programa inicial, un pulsador incrementa la posición del servomotor en pasos de 2°. Al alcanzar los 180°, deja de incrementar y se enciende el LED rojo. El circuito también dispone de otro pulsador y un LED azul que todavía no se utilizan en el código.

## Actividades

### Actividad 2.1. Configurar el incremento del servomotor

Modifica el programa original para que el incremento de grados aplicado al servomotor se establezca mediante una constante llamada `SERVO_STEP`, definida al principio del código.

1. Asigna inicialmente a `SERVO_STEP` el valor **2**, para mantener el comportamiento original.
2. Sustituye el valor fijo empleado al incrementar la posición por esta constante.
3. Escribe el comentario en línea **`//2.1`** junto a la declaración de la constante.
4. Comprueba que el incremento puede modificarse cambiando únicamente el valor de `SERVO_STEP`.
5. Mantén el límite de giro de **180°** y la señalización mediante el LED rojo.

**TIP:** Puedes definir la constante con `#define`, igual que en la tanda anterior.

### Actividad 2.2. Apagado automático del LED rojo

Modifica el programa para que, al alcanzar el servomotor su posición máxima de **180°**, el LED rojo se encienda durante **1 segundo** y después se apague automáticamente.

1. Define al principio del código una constante `LED_MS_ON` con valor inicial **1000** (milisegundos).
2. Añade el comentario en línea **`//2.2`** junto a su declaración.
3. Utiliza `LED_MS_ON` para determinar cuánto tiempo permanece encendido el LED rojo.
4. Apaga el LED automáticamente al terminar ese intervalo, aunque el botón continúe pulsado.
5. Durante ese segundo no es necesario atender nuevas pulsaciones.

**TIP:** Puedes utilizar `delay(LED_MS_ON)` y apagar el LED después con `digitalWrite()`.

### Actividad 2.3. Control del servomotor en ambos sentidos

Amplía el programa para utilizar también el **pulsador izquierdo** y el **LED azul**. Su funcionamiento será simétrico al del botón original y el LED rojo.

1. El pulsador original seguirá aumentando la posición del servomotor en pasos de `SERVO_STEP`.
2. Cada pulsación del **botón izquierdo** disminuirá la posición en pasos de `SERVO_STEP`.
3. La posición del servomotor deberá mantenerse siempre entre **0° y 180°**.
4. Al alcanzar los **0°**, el LED azul se encenderá durante `LED_MS_ON` milisegundos y después se apagará automáticamente.
5. El LED rojo conservará su funcionamiento al alcanzar los **180°**.
6. Durante el encendido temporal de cualquiera de los LED no es necesario atender nuevas pulsaciones.
7. Reutiliza las constantes existentes y añade las definiciones e instrucciones necesarias para los nuevos componentes, **sin modificar el circuito**.

**TIP:** Toma como referencia el código que ya controla el botón original y el LED rojo, adaptándolo para el movimiento en sentido contrario.

### Actividad 2.4. Refactorización del código mediante un método

Analiza el código que atiende las pulsaciones de ambos botones y observa cómo la mayor parte del código es común, cambiando solo algunas variables y constantes implicadas.

**Refactoriza el programa** para trasladar ese código común a un único método llamado `CheckButton`, que permita gestionar cualquiera de los dos pulsadores.

1. El método no devolverá ningún valor (`void`).
2. Recibirá tres parámetros:
   - `button` (`byte`): pin del pulsador.
   - `led` (`byte`): pin del LED correspondiente.
   - `sign` (`int`): sentido del movimiento (`1` para incrementar y `-1` para decrementar).
3. El método deberá comprobar la pulsación, actualizar la posición del servomotor y gestionar el encendido y apagado del LED.
4. La posición del servomotor se mantendrá entre **0° y 180°**. El método deberá realizar la comparación adecuada en función de `sign`, **sin recibir los límites como parámetros**.
5. Desde `loop()` se llamará dos veces al mismo método, con los argumentos correspondientes a cada pulsador.
6. El funcionamiento final deberá ser idéntico al obtenido en la actividad 2.3.

La declaración del método tendrá esta estructura:

```cpp
void CheckButton(byte button, byte led, int sign)
{
  // Código común para atender ambos pulsadores
}
```

**TIP:** Puedes unificar el incremento y el decremento multiplicando `SERVO_STEP` por `sign`. Para comprobar los límites, recuerda que el sentido de la comparación cambia según aumente o disminuya la posición.

## Entrega

Entrega **un único archivo** `.ino` con la solución final de todas las actividades. Los archivos `.ino` contienen el código fuente utilizado en el entorno Arduino.

Guárdalo en tu repositorio en esta ruta exacta:

```text
/ino/ut03/tanda2/tanda2.ino
```

Realiza **un único commit al terminar toda la tanda**, con este mensaje exacto:

```text
UT03 INO Tanda 2 - solución final
```

Sube el commit a tu repositorio remoto.

En el repositorio del profesor encontrarás también el archivo `/ino/ut03/tanda2/tanda2.zip`, que contiene una exportación completa del proyecto de Wokwi, incluyendo `diagram.json` (descripción del circuito) y el código original. **No es necesario descargarlo ni entregarlo**, ya que el proyecto se comparte mediante la URL indicada. Se proporciona únicamente a título informativo y por si fuera necesario restaurar el proyecto original.
