# UT02 - Actividad 3

En las actividades anteriores has trabajado a partir de proyectos ya preparados, identificando elementos de una clase y completando posteriormente una clase parcialmente desarrollada.

En esta actividad darás un paso más: **crearás tú mismo el proyecto C# desde el principio** y desarrollarás el programa siguiendo las indicaciones de cada apartado.

Presta atención al lugar desde el que ejecutas los comandos y realiza cada apartado en el orden indicado. Al finalizar cada uno, haz el correspondiente commit utilizando exactamente la descripción indicada en la última columna.

| Apartado | Tarea a realizar | Descripción del commit |
|----------|------------------|------------------------|
| a | Abre un terminal situado en el **mismo directorio en el que se encuentra este archivo `enunciado.md`** y crea un nuevo proyecto de consola C# ejecutando `"dotnet new console -n actividad_2_3 --use-program-main"`. Comprueba que se ha creado en ese directorio una nueva carpeta llamada `"actividad_2_3"`. | `UT02A03a Creado proyecto actividad_2_3` |
| b | Declara dentro de `"Program.cs"`, al final del archivo, una clase para trabajar con nombres de personas. Puedes elegir su nombre, pero te recomiendo respetar el patrón de escribir la primera letra de cada palabra en mayúscula, sin espacios ni guiones. Agrega a la clase atributos de tipo `"string"` para almacenar el tratamiento (por ejemplo, `"D."`, `"Sr."` o `"Excmo. Sr."`), el nombre, el primer apellido y el segundo apellido de una persona. | `UT02A03b Planteada clase y atributos requeridos` |
| c | Dota a la clase de un método que devuelva, en una única cadena, el nombre y los dos apellidos, en ese orden y separados por espacios. Documenta mediante comentarios el uso del método y el resultado que devuelve. | `UT02A03c Agregado método para obtener nombre y apellidos` |
| d | Dota a la clase de otro método que devuelva, en una única cadena, los dos apellidos y el nombre con el formato `"primer_apellido segundo_apellido, nombre"`: un espacio para separar los apellidos entre sí y una coma seguida de un espacio para separar estos del nombre. Documenta mediante comentarios el uso del método y el resultado que devuelve. | `UT02A03d Agregado método para obtener apellidos, nombre` |
| e | Dota a la clase de otro método que devuelva, en una única cadena, el tratamiento, el nombre y el primer apellido, en ese orden y separados por espacios. Documenta mediante comentarios el uso del método y el resultado que devuelve. | `UT02A03e Agregado método para obtener tratamiento, nombre y primer apellido` |
| f | Añade al programa principal las sentencias necesarias para crear dos objetos de la clase que has desarrollado. Inventa los datos, pero completa la información de uno con el nombre de un varón y la del otro con el nombre de una mujer. Inicializa todos sus atributos y haz una prueba invocando **todos los métodos implementados** tanto para un objeto como para el otro. Recuerda que, para mostrar el resultado de una invocación, deberás utilizar `"Console.WriteLine(objeto.metodo())"`. | `UT02A03f Creados objetos y comprobados métodos implementados` |
