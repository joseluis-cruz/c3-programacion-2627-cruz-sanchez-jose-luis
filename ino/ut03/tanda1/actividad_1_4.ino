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
  digitalWrite(LEDV,LOW);
}

void loop() // Método que se ejecuta en bucle, todo el tiempo que el dispositivo está encendido
{
  if (digitalRead(BTN1)) // digitalRead lee el estado de una entrada digital (en este caso, si el botón está pulsado o no)
  {
    //al pulsar el botón, se ejecuta este bucle for, que se repite 3 veces    
    for (int i=0;i<4;i++) // Actividad 1.4 - Cambio el 5 por 4 (son las repeticiones que pide)
    {
      digitalWrite(LEDR, HIGH);      
      delay(250); // Actividad 1.4 - Este es el tiempo de espera entre cada paso del ciclo
      digitalWrite(LEDR, LOW); // Actividad 1.4 - Encendemos el siguiente y apagamos el anterior
      digitalWrite(LEDA, HIGH);      
      delay(250); 
      digitalWrite(LEDA, LOW); 
      digitalWrite(LEDV, HIGH);      
      delay(250); 
      digitalWrite(LEDV, LOW); 
    }
  }
  
}
