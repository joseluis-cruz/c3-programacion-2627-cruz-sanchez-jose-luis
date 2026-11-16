# UT03 · Programación de microcontroladores — Tanda 6

# Resolución razonada: metrónomo con servomotor

> **Código fuente:** Los códigos fuente de referencia están disponibles en el repositorio del profesor, junto a este documento de resolución. Esta guía reconstruye **paso a paso** la evolución desde el programa de partida hasta la solución final. Los fragmentos de cada etapa están pensados para comprenderlos y transcribirlos progresivamente.

**Proyecto en Wokwi:** https://wokwi.com/projects/479671834169382913

## 1. ¿Qué queremos construir?

Vamos a simular un **metrónomo** con un servomotor. Su brazo se moverá repetidamente entre **0° y 180°**, avanzando o retrocediendo de **10° en 10°**. El potenciómetro regulará la velocidad: cuanto mayor sea su valor, mayor será la espera entre movimientos y, por tanto, menor la velocidad. Un pulsador servirá para arrancar o detener el movimiento.

La tanda es un refuerzo de la **UT03**: variables, condiciones, repetición y organización del código.

El circuito del proyecto contiene un **Arduino Uno**, un potenciómetro deslizante, un servomotor y un pulsador. El código utiliza los siguientes pines:

| Identificador | Pin | Componente |
|---|---|---|
| `POTENCIOMETRO1` | `A0` | Lectura analógica del potenciómetro |
| `BOTON1` | `7` | Pulsador, configurado con `INPUT_PULLUP` |
| `SERVO1` | `6` | Señal de control del servomotor |

En el programa se parte de estas declaraciones:

```cpp
#define POTENCIOMETRO1 A0
#define BOTON1 7
#define SERVO1 6

#include <Servo.h>
Servo servo1;
int servo1pos;
bool boton1pulsado = false;
```

`servo1` es el objeto con el que controlamos el motor. `servo1pos` es una **variable global**: recuerda la posición entre sucesivas ejecuciones de `loop()`. `boton1pulsado` también es global, porque recuerda si el botón ya estaba pulsado en la iteración anterior.

En `setup()` se configura el botón, se vincula el servo al pin 6, se coloca inicialmente a 0° y se abre la consola serie:

```cpp
void setup()
{
  pinMode(BOTON1, INPUT_PULLUP);
  servo1.attach(SERVO1);
  servo1pos = 0;
  servo1.write(servo1pos);

  Serial.begin(9600);
  Serial.println("Programa inicializado");
}
```

**Importante:** con `INPUT_PULLUP`, un botón **pulsado** se lee como `LOW` y uno **liberado** como `HIGH`. Por eso comprobamos la pulsación con `!digitalRead(BOTON1)`.

## 2. Actividad 6.1 — Informar solo cuando cambia el potenciómetro

### ¿Qué problema resolvemos?

El código inicial lee el potenciómetro y muestra su valor por consola una y otra vez. Queremos evitar mensajes repetidos cuando la lectura permanece igual.

Para comparar la lectura actual con la anterior, necesitamos **recordar el último valor mostrado**. Lo hacemos con una variable global, declarada fuera de `loop()`:

```cpp
int valor_pot_anterior = -1; // A6.1
```

Inicializamos a `-1` porque una lectura habitual del potenciómetro está entre `0` y `1023`: así, la primera lectura será necesariamente diferente y se mostrará.

### Sustituimos la impresión incondicional

En lugar de mostrar siempre la lectura, utilizamos:

```cpp
int valor_pot = analogRead(POTENCIOMETRO1);

if (valor_pot != valor_pot_anterior)
{
  Serial.print("Valor del potenciómetro: ");
  Serial.println(valor_pot);
  valor_pot_anterior = valor_pot;
}
```

El orden es importante:

1. Leemos el valor actual.
2. Lo comparamos con el último que se mostró (`!=` significa «distinto»).
3. **Solo si cambia**, lo imprimimos.
4. Después guardamos ese valor como anterior, para la siguiente vuelta de `loop()`.

**Comprobación:** deja quieto el potenciómetro: no deberían aparecer continuamente nuevas líneas. Muévelo y observa cómo se muestran los cambios.

> **DEBES SABER:** Una variable local declarada dentro de `loop()` no sirve, por sí sola, para recordar un valor de la ejecución anterior. Por eso `valor_pot_anterior` se declara como variable global, igual que `servo1pos`.

## 3. Actividad 6.2 — Traducir la lectura analógica a un ángulo

### Dos escalas diferentes

El potenciómetro proporciona valores aproximados entre **0 y 1023**, mientras que el servo se sitúa entre **0° y 180°**. No podemos enviar directamente `1023` como ángulo; necesitamos transformar la escala.

Arduino incluye la función `map()`, que permite realizar esa correspondencia:

```cpp
servo1pos = map(valor_pot, 0, 1023, 0, 180);
servo1.write(servo1pos);
```

| Lectura del potenciómetro | Posición aproximada del servo |
|---:|---:|
| 0 | 0° |
| 512 | 90° |
| 1023 | 180° |

La primera instrucción **calcula** y guarda el ángulo; la segunda lo **envía al servomotor**.

### ¿Dónde incorporarlo?

Podemos añadirlo dentro del `if` de la actividad 6.1, justo después de registrar el nuevo valor. Así, el servo se actualiza cuando la lectura cambia:

```cpp
if (valor_pot != valor_pot_anterior)
{
  Serial.print("Valor del potenciómetro: ");
  Serial.println(valor_pot);
  valor_pot_anterior = valor_pot;

  servo1pos = map(valor_pot, 0, 1023, 0, 180); // A6.2
  servo1.write(servo1pos);
}
```

**Comprobación:** desplaza el potenciómetro desde un extremo hasta el otro y observa el recorrido correspondiente del servo.

**Atención a la evolución del programa:** en la **solución final adjunta por el profesor**, estas dos instrucciones aparecen **comentadas**. No es un error: fueron útiles en la actividad 6.2, pero se desactivan en la 6.3 porque el potenciómetro dejará de fijar directamente el ángulo y pasará a regular la **velocidad**.

## 4. Actividad 6.3 — Crear el movimiento oscilante del metrónomo

### 4.1. Recordar el sentido de giro

Ahora el servo debe recorrer esta secuencia repetidamente:

`0° → 10° → 20° → … → 180° → 170° → … → 0° → …`

Necesitamos saber **hacia dónde se está moviendo**. Declaramos una variable global `estado`:

```cpp
int estado = 1; // A6.3: inicialmente incrementando
```

En esta etapa empleamos dos valores: `1` para **incrementar** y `-1` para **decrementar**. Más adelante, en la actividad 6.4, añadiremos `0` para indicar que está parado.

### 4.2. Avanzar de diez en diez

Al principio de `loop()` incorporamos el movimiento ascendente:

```cpp
if (estado == 1)
{
  servo1pos += 10;
  servo1.write(servo1pos);

  if (servo1pos >= 180)
  {
    estado = -1;
    Serial.println("Reboto para abajo");
  }
}
```

Cada vuelta incrementa la posición y la envía al servo. Cuando llega a **180°**, cambiamos `estado` a `-1`, para que en la siguiente vuelta comience el movimiento descendente.

### 4.3. Completar el movimiento descendente

Añadimos la rama contraria:

```cpp
else if (estado == -1)
{
  servo1pos -= 10;
  servo1.write(servo1pos);

  if (servo1pos <= 0)
  {
    estado = 1;
    Serial.println("Reboto para arriba");
  }
}
```

Fíjate en la simetría: `+= 10` y `>= 180` para subir; `-= 10` y `<= 0` para bajar. Los mensajes de `Serial.println()` permiten observar los cambios de sentido y facilitan la depuración.

### 4.4. Utilizar el potenciómetro para regular la velocidad

El potenciómetro ya **no elige la posición**, sino el tiempo que esperamos antes del siguiente salto:

```cpp
int valor_pot = analogRead(POTENCIOMETRO1);
// Aquí conservamos el if de la actividad 6.1,
// que muestra el valor solo cuando cambia.

int tiempo_espera = valor_pot / 10;
delay(tiempo_espera);
```

| Lectura analógica | Espera entre saltos (aprox.) |
|---:|---:|
| 0 | 0 ms |
| 500 | 50 ms |
| 1000 | 100 ms |

La división es **entera**, porque `valor_pot` es `int`: por ejemplo, `507 / 10` produce `50`. Cuanto mayor sea `tiempo_espera`, más lentamente se mueve el metrónomo.

**Comprobación:** observa cómo cambia la velocidad al mover el potenciómetro y cómo el servo invierte el giro en ambos extremos.

## 5. Actividad 6.4 — Arrancar y detener con un pulsador

### 5.1. Añadir el estado de parada

Hasta ahora el metrónomo estaba siempre en movimiento. Introducimos `estado = 0` para representar que está parado. La **solución final** inicializa la variable así:

```cpp
int estado = 0; // A6.4: empieza parado
```

Como el movimiento al principio de `loop()` solo se ejecuta cuando `estado` es `1` o `-1`, al tener valor `0` no habrá desplazamiento.

### 5.2. Detectar una sola acción por pulsación

El proyecto ya contiene la variable global:

```cpp
bool boton1pulsado = false;
```

La utilizamos para evitar que mantener el botón apretado provoque múltiples cambios entre arrancar y parar:

```cpp
if (!digitalRead(BOTON1))
{
  if (!boton1pulsado)
  {
    Serial.println("Se ha pulsado el botón 1");
    boton1pulsado = true;

    // Aquí decidimos si arrancar o detener.
  }
}
else if (boton1pulsado)
{
  boton1pulsado = false;
}
```

**Razonamiento:** cuando detectamos una pulsación nueva, guardamos `true`. Mientras no se libere el botón, no volvemos a ejecutar la acción. Al liberarlo, restablecemos `false` y quedamos preparados para la siguiente pulsación.

### 5.3. Alternar entre arrancar y detener

Dentro del `if (!boton1pulsado)` anterior incorporamos:

```cpp
if (estado == 0)
{
  estado = 1; // Arrancar subiendo desde 0°
}
else
{
  estado = 0; // Detener
  servo1pos = 0;
  servo1.write(servo1pos); // Regresar a 0°
}
```

Si estaba parado, comienza a subir (`estado = 1`). Si se estaba moviendo, se detiene (`estado = 0`) y **vuelve a 0°**. Así, la siguiente pulsación siempre inicia un nuevo movimiento ascendente: no necesitamos guardar por separado el sentido anterior.

**Comprobación:** al iniciar la simulación el servo permanece a 0°. Una pulsación arranca la oscilación; otra la detiene y lo devuelve a 0°; una tercera vuelve a arrancar.

## 6. Código final de referencia

Este es el código de `sketch.ino` incluido en la solución facilitada por el profesor. Conservamos los comentarios de las distintas actividades, incluidos los fragmentos de la actividad 6.2 que deben quedar desactivados en la versión final:

```cpp
#define POTENCIOMETRO1 A0
#define BOTON1 7 // botón verde
#define SERVO1 6 // servomotor

#include <Servo.h> // Incluye la librería Servo

Servo servo1;
int servo1pos;
bool boton1pulsado=false;
//A6.1 inicializo con un valor que sé que va a cambiar cuando lea
int valor_pot_anterior = -1;
//A6.3 defino el estado, que inicialmente será "subiendo"
//int estado = 1;
//A6.4 Para este apartado, hago que comience parado:
int estado = 0;

void setup()
{
  pinMode(BOTON1, INPUT_PULLUP);
  servo1.attach(SERVO1);
  servo1pos = 0;
  servo1.write(servo1pos);

  Serial.begin(9600);
  Serial.println("Programa inicializado");
}

void loop()
{
  //A6.3 Voy a actualizar la posicion del servo según el estado
  if (estado==1)
  {
    servo1pos += 10;
    servo1.write(servo1pos);
    if (servo1pos>=180)
    {
      estado=-1;
      Serial.println("Reboto para abajo");
    }
  }
  else if (estado==-1)
  {
    servo1pos -= 10;
    servo1.write(servo1pos);
    if (servo1pos<=0)
    {
      estado=1;
      Serial.println("Reboto para arriba");
    }
  }
  int valor_pot = analogRead(POTENCIOMETRO1);
  //A6.1 Sólo imprimo si el valor recién leido es diferente del anterior
  if (valor_pot!=valor_pot_anterior)
  {
    Serial.print("Valor del potenciómetro: ");
    Serial.println(valor_pot);
    //A6.1 Recuerdo el valor actual como anterior para el siguiente loop
    valor_pot_anterior = valor_pot;
    //A6.2 Calculo la posición para el servo con map
    /*
    servo1pos = map(valor_pot,0,1023,0,180);
    //...y envío esa posición
    servo1.write(servo1pos);
    */
  }
  //A6.3 Vamos a hacer aquí la espera, una vez que tenemos el valor_pot actual
  int tiempo_espera = valor_pot / 10;
  delay(tiempo_espera);

  //si se pulsa el botón 1
  if (!digitalRead(BOTON1))
  {
    // si antes no estaba pulsado
    if (!boton1pulsado)
    {
      Serial.println("Se ha pulsado el botón 1");
      boton1pulsado = true; // recordamos que se ha pulsado
      //A6.4 Voy a arrancar o parar el metrónomo, según sea su estado actual
      if (estado==0)
      {
        estado = 1;
      }
      else
      {
        estado = 0;
        servo1pos = 0;
        servo1.write(servo1pos);
      }
    }
  }
  else if (boton1pulsado) // dejamos de recordar que se ha pulsado
  {
    boton1pulsado = false;
  }
}
```

## 7. Qué hemos aprendido

- **Variables globales:** `servo1pos`, `valor_pot_anterior`, `estado` y `boton1pulsado` conservan información entre ejecuciones de `loop()`.
- **Condiciones:** decidimos si mostrar un valor, avanzar, retroceder, invertir el giro o detener el motor.
- **Repetición:** `loop()` permite ejecutar continuamente el movimiento sin escribir un bucle adicional.
- **Estados:** una sola variable (`0`, `1`, `-1`) describe si el metrónomo está parado, subiendo o bajando.
- **Control de componentes:** combinamos `analogRead()`, `servo1.write()`, `digitalRead()`, `delay()` y los mensajes por consola.

**Limitación consciente:** `delay()` detiene temporalmente la ejecución; por eso las pulsaciones se comprueban al terminar cada espera y la respuesta no es completamente inmediata. Para esta tanda resulta suficiente y permite reforzar las estructuras de la UT03.
