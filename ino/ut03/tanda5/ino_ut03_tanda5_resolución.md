# UT03 · Programación de microcontroladores — Tanda 5

## Resolución razonada: sensor de aparcamiento

Esta guía explica **cómo pasar del programa original, que mide y muestra distancias, a un sensor de aparcamiento simulado con destellos de un LED**. Seguiremos la solución realizada en clase, indicando qué instrucciones se añaden, dónde se colocan y por qué.

> **Código fuente:** En el repositorio del profesor, junto a este documento de resolución, encontrarás el código fuente final de la tanda. Los fragmentos de esta guía permiten reconstruir progresivamente la solución.

**Proyecto de partida:** [Wokwi — sensor de aparcamiento](https://wokwi.com/projects/480316366638323713).

En un sensor de aparcamiento real, los avisos sonoros se repiten con mayor frecuencia conforme disminuye la distancia al obstáculo. Aquí los simulamos mediante **destellos del LED**: el tiempo de encendido es fijo y la pausa con el LED apagado depende de la distancia.

---

## 1. Comprender el programa original

### 1.1. Componentes y constantes

El circuito utiliza un **sensor ultrasónico HC-SR04** y un **LED**. Las conexiones y los tiempos están identificados mediante constantes:

```cpp
#define LED 13
#define HCSR04_TRIGGER 10
#define HCSR04_ECHO 9
#define ESPERA_ENCENDIDO 100
#define ESPERA_MS_POR_CM 2
```

- `LED`: pin por el que controlaremos el indicador luminoso.
- `HCSR04_TRIGGER`: pin que ordena al sensor emitir el pulso ultrasónico.
- `HCSR04_ECHO`: pin por el que recibimos la señal de retorno.
- `ESPERA_ENCENDIDO`: tiempo, en milisegundos, durante el que permanecerá encendido el LED en cada destello (**100 ms**).
- `ESPERA_MS_POR_CM`: número de milisegundos de pausa por cada centímetro de distancia (**2 ms/cm**).

Las dos últimas constantes **ya aparecen definidas en el programa original, pero todavía no se utilizan**. Nuestra tarea consistirá en aprovecharlas.

### 1.2. Configuración inicial

```cpp
void setup()
{
  pinMode(LED, OUTPUT);
  pinMode(HCSR04_TRIGGER, OUTPUT);
  pinMode(HCSR04_ECHO, INPUT);
  digitalWrite(LED, LOW);
  digitalWrite(HCSR04_TRIGGER, LOW);
  Serial.begin(9600);
}
```

`setup()` se ejecuta **una sola vez** al arrancar. Configura el LED y el pin de disparo del sensor como salidas, el pin de eco como entrada, deja inicialmente apagado el LED e inicia la consola serie. **No necesitamos cambiar este bloque** para resolver la actividad.

### 1.3. ¿Cómo se obtiene la distancia?

El proyecto ya proporciona el método `GetDistancia()`:

```cpp
float GetDistancia()
{
  // Emite un pulso de 10 microsegundos por TRIGGER
  digitalWrite(HCSR04_TRIGGER, LOW);
  delayMicroseconds(2);
  digitalWrite(HCSR04_TRIGGER, HIGH);
  delayMicroseconds(10);
  digitalWrite(HCSR04_TRIGGER, LOW);

  // Mide la duración del eco y calcula la distancia
  float duration = pulseIn(HCSR04_ECHO, HIGH);
  float distance = (duration * .0343) / 2;
  return distance;
}
```

La función `delayMicroseconds(10)` mantiene el pulso durante **10 microsegundos**, no 10 milisegundos (el comentario original del código contiene esa pequeña errata).

`pulseIn(HCSR04_ECHO, HIGH)` mide la duración del pulso de eco en microsegundos. Con una velocidad aproximada del sonido de **0,0343 cm/µs**, la distancia se calcula así:

```text
distancia = (duración_del_eco * 0.0343) / 2
```

Se divide entre dos porque el sonido recorre el trayecto **de ida y vuelta**. La función devuelve un `float`, es decir, un número que puede tener decimales.

**Importante:** En esta tanda no tenemos que reprogramar el sensor. La función ya funciona y **vamos a reutilizarla**.

### 1.4. ¿Qué hace inicialmente `loop()`?

```cpp
void loop()
{
  int distancia = round(GetDistancia());
  Serial.println(distancia);
  delay(500);
}
```

En cada repetición de `loop()`:

1. `GetDistancia()` obtiene la distancia en centímetros.
2. `round()` redondea ese valor al entero más próximo, que se guarda en la variable local `distancia`.
3. `Serial.println(distancia)` muestra la medida en la consola serie.
4. `delay(500)` espera **siempre medio segundo**, independientemente de la distancia.

**Lo que falta:** el LED no se enciende y la espera es fija. Debemos introducir un destello y sustituir esa pausa de 500 ms por otra proporcional a la distancia.

---

## 2. Actividad 5.1. Construir el aviso luminoso

### Paso 1. Evitar una ejecución excesivamente rápida

En la solución de clase comenzamos `loop()` con una pequeña pausa:

```cpp
delay(10); // evitar saturación del emulador
```

Es un ajuste breve del programa que mantenemos en la implementación final.

### Paso 2. Encender el LED durante un tiempo fijo

Colocamos al principio del ciclo las instrucciones que generan el destello:

```cpp
digitalWrite(LED, HIGH);
delay(ESPERA_ENCENDIDO);
digitalWrite(LED, LOW);
```

La secuencia es importante:

1. `HIGH` **enciende** el LED.
2. `delay(ESPERA_ENCENDIDO)` lo mantiene encendido durante **100 ms**.
3. `LOW` lo **apaga**.

**¿Por qué usar la constante?** Si quisiéramos un destello de 150 ms, bastaría con cambiar `ESPERA_ENCENDIDO` al principio del programa: no necesitaríamos buscar y modificar los `delay()`.

En este punto el LED produce un destello, pero aún nos falta decidir **cuánto permanecerá apagado** antes del siguiente.

### Paso 3. Medir la distancia con el LED apagado

Inmediatamente después de apagarlo, conservamos las instrucciones que ya conocíamos:

```cpp
int distancia = round(GetDistancia());
Serial.println(distancia);
```

De este modo, en cada vuelta actualizamos la distancia y podemos observarla en la consola serie.

`distancia` es una **variable local** declarada dentro de `loop()`. Esto es suficiente porque solo necesitamos su valor durante esa ejecución: en la siguiente vuelta se realizará una nueva medición. No necesitamos conservar la medida anterior.

### Paso 4. Calcular el tiempo que el LED permanecerá apagado

El enunciado establece esta regla:

```text
tiempo de espera (ms) = distancia (cm) * ESPERA_MS_POR_CM
```

Por eso introducimos otra variable local:

```cpp
int tiempo_espera = distancia * ESPERA_MS_POR_CM;
```

Así separamos dos acciones diferentes: **primero calculamos el tiempo** y **después esperamos**. Esto facilita la lectura y la depuración del programa.

Con `ESPERA_MS_POR_CM = 2` obtenemos, por ejemplo:

| Distancia medida | Cálculo | Pausa con LED apagado |
|---|---|---|
| 10 cm | `10 * 2` | 20 ms |
| 50 cm | `50 * 2` | 100 ms |
| 100 cm | `100 * 2` | 200 ms |
| 200 cm | `200 * 2` | 400 ms |

**Fíjate:** cuanto menor es la distancia, **más corta es la pausa**. El destello dura siempre lo mismo, pero el siguiente destello llega antes.

### Paso 5. Sustituir la espera fija por la espera calculada

Finalmente, quitamos la instrucción original:

```cpp
delay(500);
```

Y en su lugar utilizamos:

```cpp
delay(tiempo_espera);
```

Esta es la transformación esencial de la actividad: hemos pasado de esperar **siempre 500 ms** a esperar un tiempo que **depende de la medida obtenida**.

### Paso 6. Comprender el ciclo completo

El nuevo orden de ejecución es:

1. Pausa breve inicial de 10 ms.
2. Encender el LED durante `ESPERA_ENCENDIDO`.
3. Apagar el LED.
4. Medir y mostrar la distancia.
5. Calcular `tiempo_espera`.
6. Mantener el LED apagado durante ese tiempo.
7. Repetir automáticamente porque `loop()` vuelve a comenzar.

No necesitamos añadir un `while` o un `for`: **Arduino ejecuta `loop()` continuamente**.

---

## 3. Código final de referencia

Este es el programa final facilitado por el profesor. Se conserva su estructura y sus comentarios; recuerda únicamente que el pulso de `delayMicroseconds(10)` indicado en el comentario de `GetDistancia()` es de **10 microsegundos**.

```cpp
#define LED 13
#define HCSR04_TRIGGER 10
#define HCSR04_ECHO 9
#define ESPERA_ENCENDIDO 100
#define ESPERA_MS_POR_CM 2

void setup()
{
  pinMode(LED,OUTPUT);
  pinMode(HCSR04_TRIGGER,OUTPUT);
  pinMode(HCSR04_ECHO,INPUT);
  digitalWrite(LED,LOW);
  digitalWrite(HCSR04_TRIGGER,LOW);
  Serial.begin(9600);
}

void loop()
{
  delay(10); // evitar saturación del emulador

  // pulso del led con el tiempo marcado por ESPERA_ENCENDIDO
  digitalWrite(LED, HIGH);
  delay(ESPERA_ENCENDIDO);
  digitalWrite(LED, LOW);
  // ahora es cuando tengo que estar apagado un tiempo proporcional a la distancia
  int distancia = round(GetDistancia());
  Serial.println(distancia);
  // calculo en esta variable el tiempo a esperar
  int tiempo_espera = distancia*ESPERA_MS_POR_CM;
  // ejeucto la espera
  delay(tiempo_espera);
}

float GetDistancia()
{
  // manda un pulso cuadrado de 10ms por el pin del trigger
  digitalWrite(HCSR04_TRIGGER, LOW);
  delayMicroseconds(2);
  digitalWrite(HCSR04_TRIGGER, HIGH);
  delayMicroseconds(10);
  digitalWrite(HCSR04_TRIGGER, LOW);
  // pasa a escuchar el eco de ese pulso
  float duration = pulseIn(HCSR04_ECHO, HIGH);
  float distance = (duration*.0343)/2;
  return distance;
}
```

---

## 4. Comprobar el funcionamiento en Wokwi

1. Abre la simulación y la **consola serie**. Comprueba que se muestran distancias enteras.
2. Acerca el obstáculo: el tiempo con el LED apagado debe **disminuir** y los destellos deben ser **más frecuentes**.
3. Aleja el obstáculo: el tiempo con el LED apagado debe **aumentar** y los destellos deben ser **menos frecuentes**.
4. Cambia temporalmente `ESPERA_MS_POR_CM` y observa cómo se modifica el ritmo sin cambiar el cálculo del programa.
5. Cambia temporalmente `ESPERA_ENCENDIDO` y observa que solo cambia la **duración de cada destello**.

**Precisión:** los tiempos observados no son exactamente la espera calculada: también intervienen la pausa inicial de 10 ms, los 100 ms de encendido y el tiempo empleado en obtener la medición. Por eso hablamos de una simulación sencilla de los avisos de aparcamiento, no de un temporizador de precisión.

## 5. ¿Qué hemos aprendido?

- A **reutilizar** una función que ya resuelve una tarea específica (`GetDistancia()`).
- A construir una **secuencia de instrucciones** para encender, esperar y apagar.
- A almacenar cálculos en **variables locales** (`distancia` y `tiempo_espera`).
- A utilizar **constantes** para configurar el comportamiento sin reescribir las instrucciones.
- A entender que `loop()` aporta la **repetición continua**, incluso sin escribir un bucle adicional.
- A relacionar un **dato de entrada** (distancia) con una **salida** (frecuencia de los destellos).

La idea principal de esta tanda es sencilla: **no hace falta cambiar cómo se mide la distancia; basta con aprovechar esa medida para decidir cuánto tiempo dejamos apagado el LED antes del siguiente destello**.
