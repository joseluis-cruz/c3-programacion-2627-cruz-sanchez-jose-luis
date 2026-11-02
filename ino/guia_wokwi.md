# Guía rápida. Programación de microcontroladores con Wokwi

## 1. ¿Qué es un microcontrolador?

Un **microcontrolador** es un pequeño dispositivo electrónico programable que puede recibir información del entorno y controlar otros componentes. Por ejemplo, puede detectar la pulsación de un botón, encender un LED o leer un sensor de temperatura.

A diferencia de un programa que se ejecuta en un ordenador y muestra resultados en pantalla, un programa para microcontroladores puede **interactuar directamente con dispositivos electrónicos** mediante sus entradas y salidas.

Programar un microcontrolador nos permitirá aplicar lo aprendido en la **UT03: secuencia, condición y repetición**, observando sus efectos en un circuito.

## 2. ¿Qué microcontroladores podemos usar?

Existen diferentes familias de microcontroladores y placas de desarrollo que podemos programar. Por ejemplo:

- **Arduino Uno:** placa muy utilizada para aprender programación y electrónica, basada en un microcontrolador ATmega328P.
- **ESP32:** familia de microcontroladores con numerosas entradas y salidas y, en muchos modelos, conectividad Wi-Fi y Bluetooth. Se utiliza, por ejemplo, en proyectos de automatización y dispositivos conectados.
- **Raspberry Pi Pico:** placa de desarrollo basada en microcontroladores de la familia RP2040 o RP2350, según el modelo.

**En nuestras prácticas utilizaremos un ESP32, pero lo programaremos mediante el entorno de desarrollo y las funciones de Arduino.** Así podremos trabajar con instrucciones como `pinMode()`, `digitalWrite()` o `digitalRead()` sin necesidad de aprender inicialmente herramientas específicas del fabricante del ESP32.

El lenguaje empleado es **C++ con las bibliotecas de Arduino**. Aunque su sintaxis difiere en algunos aspectos de C#, las estructuras de secuencia, condición y repetición son muy similares.

Los programas se guardan habitualmente en archivos con extensión **`.ino`** y se conocen como *sketches*.

## 3. ¿Qué es Wokwi?

[**Wokwi**](https://wokwi.com/) es un **simulador de electrónica online**. Permite programar placas como Arduino y comprobar cómo funcionan circuitos virtuales con LED, botones, sensores y otros componentes, sin disponer del material físico.

En Wokwi podemos:

- Escribir y modificar el código del microcontrolador.
- Ejecutar o detener una simulación.
- Pulsar botones virtuales y observar el resultado en los LED.
- Detectar errores, corregir el programa y volver a probarlo.

> **Importante:** Wokwi simula el funcionamiento del circuito, pero el objetivo de estas prácticas es **reforzar la programación**, no estudiar electrónica en profundidad.

## 4. Acceso a la plataforma

1. Entra en [https://wokwi.com/](https://wokwi.com/).
2. Regístrate o inicia sesión utilizando tu **cuenta educativa `@alu.murciaeduca.es`**. Si aparece la opción de acceso mediante Google, utiliza la cuenta educativa correspondiente.
3. Abre el enlace del proyecto que facilite el profesor.
4. Examina el circuito y su código. Inicia la simulación y comprueba qué ocurre al interactuar con los componentes.
5. Realiza los cambios solicitados en cada ejercicio y comprueba su funcionamiento antes de guardar el código.

## 5. Estructura básica de un programa Arduino

```cpp
void setup() {
  // Instrucciones de configuración inicial
}

void loop() {
  // Instrucciones que se ejecutan repetidamente
}
```

- **`setup()`** se ejecuta una vez al arrancar o reiniciar la placa. Se utiliza, por ejemplo, para configurar qué conexiones son entradas o salidas.
- **`loop()`** se ejecuta repetidamente mientras el programa está en funcionamiento.
- **`//`** permite añadir comentarios para explicar el código sin afectar a su ejecución.

## 6. Instrucciones básicas

| Instrucción | Función |
|---|---|
| `#define LEDR 4` | Define un nombre para un valor que se sustituye antes de compilar el programa. |
| `pinMode(4, OUTPUT)` | Configura el pin 4 como salida. |
| `pinMode(7, INPUT)` | Configura el pin 7 como entrada. |
| `digitalWrite(4, HIGH)` | Establece un nivel lógico alto en el pin 4. |
| `digitalWrite(4, LOW)` | Establece un nivel lógico bajo en el pin 4. |
| `digitalRead(7)` | Lee el nivel lógico de una entrada digital. |
| `delay(500)` | Detiene la ejecución del programa durante 500 milisegundos. |

En las prácticas utilizaremos también las estructuras que ya conocemos: **`if`**, **`for`**, **`while`** y otras instrucciones de control de flujo, cuando sean necesarias.

## 7. Cómo trabajar

Lee cada enunciado, modifica el código y **ejecuta la simulación** para verificar que se cumple exactamente lo solicitado. Si el resultado no es correcto, revisa las instrucciones, las condiciones y los tiempos de espera.

Las actividades concretas, el circuito compartido y las instrucciones de entrega se detallarán en el documento de la tanda correspondiente.

---

**Fuentes oficiales:** [Simulación de ESP32 en Wokwi](https://docs.wokwi.com/guides/esp32) · [Documentación de Wokwi](https://docs.wokwi.com/) · [Formato de los circuitos en Wokwi](https://docs.wokwi.com/diagram-format) · [Sitio oficial de Arduino](https://www.arduino.cc/).
