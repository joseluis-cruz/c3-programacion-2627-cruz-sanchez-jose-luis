/* Actividad 1.1
  Estas instrucciones define son la forma en la que se definen
  constantes en el lenguaje C. Con ellas, podemos asignar un identificador
  a un valor y modificar rápidamente ese valor para, por ejemplo,
  cambiar el puerto en el que tenemos contectado un dispositivo.
  En este ejemplo, hemos definido como constantes los puertos
  por los que conectamos los 3 leds y el botón.
*/
#define LEDR 4 // led rojo
#define LEDA 3 // led amarillo
#define LEDV 2 // led verde
#define BTN1 7 // botón de pulsación

#define TIEMPO_ESPERA_AMARILLO 1000
#define TIEMPO_ESPERA_ROJO 3000

void setup() //Método que se ejecuta al inicio, sólo una vez
{
  //Establecer modos de cada puerto (entrada o salida)
  //mediante la instrucción pinMode
  //Salidas para leds
  pinMode(LEDR, OUTPUT);
  pinMode(LEDA, OUTPUT);
  pinMode(LEDV, OUTPUT);
  //Entrada para botón
  pinMode(BTN1, INPUT);

  //Apagar todos leds inicialmente
  //digitalWrite sirve para poner una salida digital en
  //estado alto (entregando voltaje) o bajo (sin entregar voltaje)
  digitalWrite(LEDR,LOW);
  digitalWrite(LEDA,LOW);
  digitalWrite(LEDV,HIGH); // Actividad 1.5 - El verde arranca ya encendido
}

void loop() // Método que se ejecuta en bucle, todo el tiempo que el dispositivo está encendido
{
  if (digitalRead(BTN1)) // digitalRead lee el estado de una entrada digital (en este caso, si el botón está pulsado o no)
  {
    //al pulsar el botón, se ejecuta esta secuencia:
    //1. apagar el verde y encender el amarillo
    digitalWrite(LEDV, LOW);      
    digitalWrite(LEDA, HIGH);      
    //2. Esperar 1 segundo
    delay(TIEMPO_ESPERA_AMARILLO); 
    //3. apagar el amarillo y encender el rojo
    digitalWrite(LEDA, LOW);      
    digitalWrite(LEDR, HIGH);      
    //4. Esperar 3 segundos
    delay(TIEMPO_ESPERA_ROJO); 
    //5. Apagar el rojo y encender el verde
    digitalWrite(LEDR, LOW);      
    digitalWrite(LEDV, HIGH);      
  }
  
}
